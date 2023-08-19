using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace RINO.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
       
        public List<OrderDetail>? orderDetails { get; set; }
        [Required(ErrorMessage = "Please Enter your FN")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }= string.Empty;
        [Required(ErrorMessage ="Please Enter your LN")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter your Add")]
        [StringLength(100)]
        
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter your ZC")]
        [StringLength(10,MinimumLength =4)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter your City")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter your Region")]
        [StringLength(10)]
        public string Region { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter your Country")]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter your Phone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="Invalid Mail")]
        public string Email { get; set; } = string.Empty;
        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }

    }
}
