using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int ID_ChiTiet {get; set; }
        public int ID_DonHang {get; set; }
        
        public int ID_ThucPham {get; set; }

        public string TenThucPham {get; set; }
        public int So_Luong {get; set; } 
        public int DonGia {get; set; }
        
        [ForeignKey("ID_ThucPham")]
        public virtual ThucPham ThucPham {get; set; }
        [ForeignKey("ID_DonHang")]
        public virtual DonHang DonHang {get; set; }
    }
}
        