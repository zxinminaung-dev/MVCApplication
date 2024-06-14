using MVCApplication.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApplication.Models
{
    [Table("tbl_student")]
    public class Student : BaseEntity
    {

        public string? name { get; set; }
        public string? dob { get; set; }
        public int? Parentid { get; set; } = 0;
        [ForeignKey("Parentid")]
        public virtual Parent? Parent { get; set; }
        public int? Classid { get; set; }=0;
        [ForeignKey("Classid")]
        public virtual Class? Class { get; set; }
    }
}
