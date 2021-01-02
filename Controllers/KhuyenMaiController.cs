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
    public class KhuyenMaiController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public KhuyenMaiController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<KhuyenMai> Get()
        {
            return dbContext.KhuyenMais.ToList();
        }
        [HttpPost("khuyenmai")]
        public string Check(KhuyenMai khuyenmai) 
        {
            string Phan_Tram_Khuyen_Mai = "0";
            KhuyenMai khuyenMai = dbContext.KhuyenMais.FirstOrDefault(e => e.Name == khuyenmai.Name);
            if (khuyenMai == null) return Phan_Tram_Khuyen_Mai;
            return khuyenMai.Phan_Tram;
        }
        [HttpGet("{id}")]
        public KhuyenMai Get(int id)
        {
            return dbContext.KhuyenMais.FirstOrDefault(e => e.ID_KM == id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostKM(KhuyenMai khuyenmai)
        {
            dbContext.KhuyenMais.Add(khuyenmai);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_KM = khuyenmai.ID_KM }, khuyenmai);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] KhuyenMai khuyenmai)
        {
            var entity = dbContext.KhuyenMais.FirstOrDefault(e => e.ID_KM == id);
            entity.Name = khuyenmai.Name;
            entity.Phan_Tram = khuyenmai.Phan_Tram;
            entity.Link_Anh = khuyenmai.Link_Anh;
            entity.NgayBatDau = khuyenmai.NgayBatDau;
            entity.NgayKetThuc = khuyenmai.NgayKetThuc;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var khuyenmai = await dbContext.KhuyenMais.FindAsync(id);
            if (khuyenmai == null)
            {
                return NotFound();
            }

            dbContext.Remove(khuyenmai);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}