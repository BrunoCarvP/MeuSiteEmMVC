using MeuSiteEmMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class UsuarioModelSemSenha
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Digite o nome do Usuário")]
		public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do Usuário")]
        public string Login { get; set; }
		[Required(ErrorMessage = "Digite o e-mail do usuário")]
		[EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
		public string Email { get; set; }
		//[EmailAddress(ErrorMessage = "Informe o perfil do usuário")]
		public PerfilEnum? Perfil { get; set; }
        
    }
}
