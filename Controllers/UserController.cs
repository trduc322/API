using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Net;
using System.Net.Mail;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public UserController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return dbContext.Users.ToList();
        }
        public void Send_Mail(string SendFrom, string SendTo, string username) 
        {
            User user = dbContext.Users.FirstOrDefault(e => e.Username == username);
            try {
            MailMessage mail = new MailMessage(SendFrom, SendTo);
            mail.IsBodyHtml = true;
            mail.Subject = "BUN DAU TRANG AN MAT KHAU MOI";
            string send_pass = "";
            Random r = new Random();
            int pass = r.Next(0,999999);
            if (pass < 10) send_pass = "00000" + pass.ToString();
            if (pass < 100 && pass >= 10) send_pass = "0000" + pass.ToString();
            if (pass < 1000 && pass >= 100) send_pass = "000" + pass.ToString();
            if (pass < 10000 && pass >= 1000) send_pass = "00" + pass.ToString();
            if (pass < 1000000 && pass >= 10000) send_pass = pass.ToString();
            string Body = send_pass;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential(SendFrom, "tinhanhem");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            
            smtp.Send(mail);
            user.Password = send_pass;
            dbContext.SaveChanges();
            }
            catch(Exception e) {

            }
        }
        [HttpPost("passforgot")]
        public bool Pass_Forgot([FromBody] User user) 
        {
            User userforgot = dbContext.Users.FirstOrDefault(e => e.Username == user.Username);
            if (userforgot == null) return false;
            Send_Mail("duy147862@gmail.com", userforgot.Email, userforgot.Username);
            return true;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return dbContext.Users.FirstOrDefault(e => e.ID_User == id);
        }
        [HttpPost("check")]
        public User Check([FromBody] User user) 
        {
            return dbContext.Users.FirstOrDefault(e => e.Username == user.Username && e.Password == user.Password);
        }
        [HttpPost]
        public bool PostUser(User user)
        {
            List<User> dbUser = dbContext.Users.ToList();
            foreach(User item in dbUser) {
                if (item.Username == user.Username) {
                    return false;
                }
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            var entity = dbContext.Users.FirstOrDefault(e => e.ID_User == id);
            entity.Name = user.Name;
            entity.Password = user.Password;
            entity.SDT = user.SDT;
            entity.DiaChi = user.DiaChi;
            entity.Email = user.Email;
            entity.Coin = user.Coin;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            dbContext.Remove(user);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}