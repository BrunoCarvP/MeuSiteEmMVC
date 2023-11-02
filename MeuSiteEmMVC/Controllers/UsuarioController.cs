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
                    usuario = _usuarioRepositorio.Adicionar(usuario);
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
		public IActionResult ApagarConfirmacao(int id)
		{
			UsuarioModel contato = _usuarioRepositorio.ListarPorId(id);
			return View(contato);
		}

		public IActionResult Apagar(int id)
		{
			try
			{
				bool apagado = _usuarioRepositorio.Apagar(id);

				if (apagado)
				{
					TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
				}
				else
				{
					TempData["MensagemSucesso"] = "Ops, não conseguimos apagar seu usuário!";
				}
				return RedirectToAction("index");
			}
			catch (Exception erro)
			{
				TempData["MensagemSucesso"] = $"Ops, não conseguimos apagar seu usuário, mais detalhes {erro.Message} ";
				return RedirectToAction("index");
			}
		}
		public IActionResult Editar(int id)
		{
			UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
			return View(usuario);
		}

		[HttpPost]
		public IActionResult Editar(UsuarioModelSemSenha usuarioSemSenhaModel)
		{
			try
			{
				UsuarioModel usuario = null;
				if (ModelState.IsValid)
				{
					usuario = new UsuarioModel()
					{
						Id = usuarioSemSenhaModel.Id,
						Nome = usuarioSemSenhaModel.Nome,
						Login = usuarioSemSenhaModel.Login,
						Email = usuarioSemSenhaModel.Email,
						Perfil = usuarioSemSenhaModel.Perfil

					};


					usuario = _usuarioRepositorio.Atualizar(usuario);
					TempData["MensagemSucesso"] = "Usuário foi alterado com sucesso";
					return RedirectToAction("Index");
				}
				return View("Editar", usuario);
			}
			catch (Exception erro)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamente, detalhe do erro:{erro.Message}";
				return RedirectToAction("Index");

			}
		}
	}
}
