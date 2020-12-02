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
    public class ChiTietDonHangController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public ChiTietDonHangController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<ChiTietDonHang> Get()
        {
            return dbContext.ChiTietDonHangs.ToList();
        }

        [HttpGet("{id}")]
        public ChiTietDonHang Get(int id)
        {
            return dbContext.ChiTietDonHangs.FirstOrDefault(e => e.ID_ChiTiet == id);
        }

        [HttpPost]
        public async Task<ActionResult<ChiTietDonHang>> PostUser(ChiTietDonHang chitietdonhang)
        {
            dbContext.ChiTietDonHangs.Add(chitietdonhang);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_ChiTiet = chitietdonhang.ID_ChiTiet }, chitietdonhang);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ChiTietDonHang chitietdonhang)
        {
            var entity = dbContext.ChiTietDonHangs.FirstOrDefault(e => e.ID_ChiTiet == id);
            entity.ID_DonHang = chitietdonhang.ID_DonHang;
            entity.ID_ThucPham = chitietdonhang.ID_ThucPham;
            entity.So_Luong = chitietdonhang.So_Luong;
            entity.NgayThang = chitietdonhang.NgayThang;
            entity.DonGia = chitietdonhang.DonGia;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var chitietdonhang = await dbContext.ChiTietDonHangs.FindAsync(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            dbContext.Remove(chitietdonhang);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}