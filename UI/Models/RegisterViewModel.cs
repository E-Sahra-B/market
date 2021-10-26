using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        //([DataType(DataType.Password)]
        public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
