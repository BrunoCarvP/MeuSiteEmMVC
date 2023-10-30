﻿
using MeuSiteEmMVC.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);
        UsuarioModel  Adicionar(UsuarioModel usuario);

		UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
