using System.ComponentModel.DataAnnotations;

namespace LanchesMac.ViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage ="Indorme o Usuário")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe a Confirmação de senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme Sua Senha")]
        public string Password2 { get; set; }
    }
}
