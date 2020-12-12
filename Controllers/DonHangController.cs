using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public DonHangController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<DonHang> Get()
        {
            return dbContext.DonHangs.ToList();
        }
        [HttpPost("layngay")]
        public IEnumerable<DonHang> Get(DonHang donhang ) 
        {
            List<DonHang> dbdonhang = dbContext.DonHangs.ToList();
            List<DonHang> donhangs = new List<DonHang>();
            foreach(DonHang item in dbdonhang) 
            {
                if (item.NgayThang == donhang.NgayThang) donhangs.Add(item);
            }
            return donhangs;
        }
        [HttpGet("{id}")]
        public IEnumerable<DonHang> Get(int id)
        {
            List<DonHang> donhang = new List<DonHang>();
            List<DonHang> dbdonhang = dbContext.DonHangs.ToList();
            foreach (DonHang item in dbdonhang) {
                if (item.ID_User == id) donhang.Add(item);
            }
            return donhang;
        }

        [HttpPost]
        public async Task<ActionResult<ThucPham>> PostDonHang(DonHang donhang)
        {
            dbContext.DonHangs.Add(donhang);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_DonHang = donhang.ID_DonHang }, donhang);
        }

        [HttpPut]
        public void Put()
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donhang = await dbContext.DonHangs.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }

            dbContext.Remove(donhang);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}