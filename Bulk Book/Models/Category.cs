using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Bulk_Book.Models
{
    public class Category
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        //the name that will be displayed for example on Error Messages
        [DisplayName("Display Name")]
        //also possible to add an error message
        [Range(1,100,ErrorMessage ="Diplay order must only be between 1 and 100")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
