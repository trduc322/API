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
    public class NhapXuatController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public NhapXuatController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<NhapXuat> Get()
        {
            return dbContext.NhapXuats.ToList();
        }

        [HttpGet("{id}")]
        public NhapXuat Get(int id)
        {
            return dbContext.NhapXuats.FirstOrDefault(e => e.ID_NhapXuat == id);
        }

        [HttpPost]
        public async Task<ActionResult<NhapXuat>> PostUser(NhapXuat nhapxuat)
        {
            dbContext.NhapXuats.Add(nhapxuat);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_NhapXuat = nhapxuat.ID_NhapXuat }, nhapxuat);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NhapXuat nhapxuat)
        {
            var entity = dbContext.NhapXuats.FirstOrDefault(e => e.ID_NhapXuat == id);
            entity.ID_ThucPham = nhapxuat.ID_ThucPham;
            entity.So_Luong = nhapxuat.So_Luong;
            entity.Nhap_Xuat = nhapxuat.Nhap_Xuat;
            entity.NgayNX = nhapxuat.NgayNX;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nhapxuat = await dbContext.NhapXuats.FindAsync(id);
            if (nhapxuat == null)
            {
                return NotFound();
            }

            dbContext.Remove(nhapxuat);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}