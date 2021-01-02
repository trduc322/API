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
    public class FoodController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public FoodController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<ThucPham> Get()
        {
            return dbContext.ThucPhams.ToList();
        }
        [HttpGet("{id}")]
        public String Get(int id)
        {
            ThucPham thucPham = dbContext.ThucPhams.FirstOrDefault(e => e.ID_ThucPham == id);
            return thucPham.Name;
        }
        [HttpPost("chitiet")]
        public ThucPham Chitiet(ThucPham thucpham) 
        {
            ThucPham thucPham = dbContext.ThucPhams.FirstOrDefault(e => e.ID_ThucPham == thucpham.ID_ThucPham);
            return thucPham;
        }
        [HttpPost]
        public async Task<ActionResult<ThucPham>> PostThucPham(ThucPham food)
        {
            food.ID_KM = 2;
            dbContext.ThucPhams.Add(food);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_ThucPham = food.ID_ThucPham }, food);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ThucPham food)
        {
            food.ID_KM = 2;
            var entity = dbContext.ThucPhams.FirstOrDefault(e => e.ID_ThucPham == id);
            entity.Name = food.Name;
            entity.LoaiThucPham = food.LoaiThucPham;
            entity.ID_KM = food.ID_KM;
            entity.GiaGoc = food.GiaGoc;
            entity.MoTa = food.MoTa;
            entity.Link_Anh = food.Link_Anh;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await dbContext.ThucPhams.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            dbContext.Remove(food);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}