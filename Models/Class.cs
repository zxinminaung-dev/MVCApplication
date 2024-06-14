using MVCApplication.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApplication.Models
{
    [Table("tbl_class")]
    public class Class : BaseEntity
    {
        [Required(ErrorMessage ="Name is Required!")]
        public string? name { get; set; }
        [Required(ErrorMessage = "Education Year is Required!")]
        public string? education_year { get; set; }
    }
}
