using MVCApplication.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApplication.Models
{
    [Table("tbl_perent")]
    public class Parent :BaseEntity
    {
        //[Column("father_name")]
        [Required(ErrorMessage ="Father Name is Required")]
        public string? father_name { get; set; }
        [Required(ErrorMessage = "Mother Name is Required")]
        public string? mother_name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string? address { get; set; }
        
    }
}
