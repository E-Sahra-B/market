using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class ShippingDetails
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Range(15,75)]
        public int Age { get; set; }
    }
}
