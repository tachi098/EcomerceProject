using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Field must be not blank")]
        [RegularExpression("^([a-zA-Z ]{2,8})+$", ErrorMessage = "Invalid Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Field must be not blank")]
        [RegularExpression("^[a-zA-Z0-9]{5,15}@[a-zA-Z]{2,6}(.[a-zA-Z]{2,5}){1,3}$", ErrorMessage = "Invalid Email...")]
        public string email { get; set; }

        [Required(ErrorMessage = "Field must be not blank")]
        [RegularExpression("^0[89]{1}[0-9]{8}$", ErrorMessage = "Invalid Phone...")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Field must be not blank")]
        public string address { get; set; }

        [Required(ErrorMessage = "Field must be not blank")]
        public string password { get; set; }

        [NotMapped] 
        [Compare("password")]
        public string confirmpassword { get; set; }

        [DataType(DataType.ImageUrl)]
        public string avatar { get; set; }

        public bool level { get; set; }

        public bool status { get; set; }

        public DateTime create_at { get; set; }

        public DateTime update_at { get; set; }

        [ForeignKey("userid")]
        public ICollection<Order> Orders { get; set; }

    }
}
