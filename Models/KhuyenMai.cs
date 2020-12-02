using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Models
{
    public class KhuyenMai
    {
        [Key]
        public int ID_KM {get; set; }
        public string Name {get; set; }
        public string Phan_Tram {get; set; }
        public string Link_Anh {get; set; }
        public string Mo_ta {get; set; }
        public System.DateTime NgayBatDau {get; set;}
        public System.DateTime NgayKetThuc {get; set;}
    }
}