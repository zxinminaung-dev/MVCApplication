using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int id { get; set; }
        //public abstract void GetAll();
    }
}
