using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Models
{
    public class ThucPham
    {
        [Key]
        public int ID_ThucPham {get; set; }
        public string Name {get; set; }
        public string LoaiThucPham {get; set; }
        public int ID_KM {get; set; }
        public int GiaGoc {get; set; }
        public string MoTa {get; set; }
        public string Link_Anh {get; set;}  
        [ForeignKey("ID_KM")]

        public virtual KhuyenMai KhuyenMai {get; set; }

    }
}