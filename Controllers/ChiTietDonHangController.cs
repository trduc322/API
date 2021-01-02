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
        [HttpPost("ctdh")]
        public IEnumerable<ChiTietDonHang> Get(ChiTietDonHang chitiet)
        {
            List<ChiTietDonHang> chitietdonhang = new List<ChiTietDonHang>();
            List<ChiTietDonHang> dbchitiet = dbContext.ChiTietDonHangs.ToList();
            foreach (ChiTietDonHang item in dbchitiet) {
                if (item.ID_DonHang == chitiet.ID_DonHang) chitietdonhang.Add(item);
            }
            return chitietdonhang;
        }

        [HttpPost]
        public async Task<ActionResult<ChiTietDonHang>> PostUser(ChiTietDonHang chitietdonhang)
        {
            ThucPham thucPham = dbContext.ThucPhams.FirstOrDefault(e => e.ID_ThucPham == chitietdonhang.ID_ThucPham);
            chitietdonhang.TenThucPham = thucPham.Name;
            dbContext.ChiTietDonHangs.Add(chitietdonhang);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_ChiTiet = chitietdonhang.ID_ChiTiet }, chitietdonhang);
        }

        [HttpPut("{id}")]
        public void Put()
        {
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