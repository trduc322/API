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
    public class KhoHangController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public KhoHangController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<KhoHang> Get()
        {
            return dbContext.KhoHangs.ToList();
        }

        [HttpGet("{id}")]
        public KhoHang Get(int id)
        {
            return dbContext.KhoHangs.FirstOrDefault(e => e.ID_KhoHang == id);
        }

        [HttpPost]
        public async Task<ActionResult<KhoHang>> PostKhoHang(KhoHang khohang)
        {
            dbContext.KhoHangs.Add(khohang);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_KhoHang = khohang.ID_KhoHang }, khohang);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] KhoHang khohang)
        {
            var entity = dbContext.KhoHangs.FirstOrDefault(e => e.ID_KhoHang == id);
            entity.ID_ThucPham = khohang.ID_ThucPham;
            entity.SoLuong = khohang.SoLuong;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var khohang = await dbContext.KhoHangs.FindAsync(id);
            if (khohang == null)
            {
                return NotFound();
            }

            dbContext.Remove(khohang);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}