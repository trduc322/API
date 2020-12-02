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

        [HttpGet("{id}")]
        public DonHang Get(int id)
        {
            return dbContext.DonHangs.FirstOrDefault(e => e.ID_DonHang == id);
        }

        [HttpPost]
        public async Task<ActionResult<ThucPham>> PostDonHang(DonHang donhang)
        {
            dbContext.DonHangs.Add(donhang);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_DonHang = donhang.ID_DonHang }, donhang);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DonHang donhang)
        {
            var entity = dbContext.DonHangs.FirstOrDefault(e => e.ID_DonHang == id);
            entity.PTThanhToan = donhang.PTThanhToan;
            entity.TongTien = donhang.TongTien;
            entity.ID_User = donhang.ID_User;
            dbContext.SaveChanges();
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