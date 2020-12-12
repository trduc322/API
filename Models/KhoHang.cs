using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Models
{
    public class KhoHang
    {
        [Key]
        public int ID_KhoHang { get; set; }
        public int ID_ThucPham { get; set; }
        public string TenThucPham {get; set; }
        public int SoLuong {get; set; }
        [ForeignKey("ID_ThucPham")]

        public virtual ThucPham ThucPham{ get; set; }
    }
}