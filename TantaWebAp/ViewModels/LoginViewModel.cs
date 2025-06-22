using System.ComponentModel.DataAnnotations;

namespace TantaWebAp.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool  RememberMe { get; set; }
    }
}
