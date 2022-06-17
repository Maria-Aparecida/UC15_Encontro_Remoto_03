using System.ComponentModel.DataAnnotations;

namespace ChapterFST1.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail Requerito")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha Requerita")]
        public string Senha { get; set; }
    }
}
