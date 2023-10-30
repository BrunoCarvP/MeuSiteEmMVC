using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class UsuarioController : Controller
    {
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
		{
			_usuarioRepositorio = usuarioRepositorio;
		}
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário Cadastrado com sucesso";
                    return RedirectToAction("Index");

                }


                return View(usuario);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
