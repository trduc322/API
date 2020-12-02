using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class NhapXuat
    {
        [Key]
        public int ID_NhapXuat { get; set; }
        public int ID_ThucPham { get; set; }
        public int So_Luong {get; set; }
        public bool Nhap_Xuat {get; set; }
        public System.DateTime NgayNX {get; set; }
        [ForeignKey("ID_ThucPham")]
        public virtual ThucPham ThucPham { get; set; }
    }
}