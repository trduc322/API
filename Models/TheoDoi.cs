using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class TheoDoi
    {
        [Key]
        public int ID_TheoDoi {get; set;}
        public string Email {get; set; }
    }
}