using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Models
{
    public class DonHang
    {
        public DonHang() {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int ID_DonHang {get; set; }
        public string PTThanhToan {get; set; }
        public int TongTien {get; set; }
        public int ID_User {get; set; }
        public System.DateTime NgayThang {get; set; }
        [ForeignKey("ID_User")]
        public virtual User User {get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs {get; set; }
    }
}