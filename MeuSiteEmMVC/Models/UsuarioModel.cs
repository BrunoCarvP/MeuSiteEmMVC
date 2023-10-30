using MeuSiteEmMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o login do contato")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]

        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Senha {  get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
