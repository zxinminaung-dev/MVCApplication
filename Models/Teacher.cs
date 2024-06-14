using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCApplication.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApplication.Models
{
    [Table("tbl_teacher")]
    public class Teacher : BaseEntity 
    {
        public string? name { get; set; }
        public int? Classid { get; set; }

        [ForeignKey("Classid")]
        public virtual Class? Class { get; set; }
    }
}
