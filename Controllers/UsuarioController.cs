using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class UsuarioController
    {
        public static Usuario InserirUsuario(
            string Nome,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome) && String.IsNullOrEmpty(Senha)) 
            {
                throw new Exception("Preencha todos os campos!");
            }

            return new Usuario(Nome, Senha);
        }

        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
            string Senha
        )
        {
            Usuario usuario = Usuario.GetUsuario(Id);

            if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Nome)) {
                usuario.Nome = Nome;
                usuario.Senha = Senha;
            }
            else
            {
                throw new Exception("Preencha todos os campos!");
            }

            Models.Usuario.AlterarUsuario(Id, Nome, Senha);

            return usuario;
        }
        public static Usuario ExcluirUsuario(
            int Id
        )
        {
            Usuario usuario = Usuario.GetUsuario(Id);
            Models.Usuario.RemoverUsuario(usuario);
            return usuario;
        }
        public static IEnumerable<Usuario> GetUsuarios()
        {
            return Usuario.GetUsuarios();
        }

        public static Usuario GetUsuario(
            int Id
        )
        {
            Usuario usuario = (
                from Usuario in Usuario.GetUsuarios()
                    where Usuario.Id == Id
                    select Usuario
            ).First();
            
            if (usuario == null)
            {
                throw new Exception("Usuario não encontrada");
            }

            return usuario;
        }
        public static void Auth(string Nome, string Senha) {
            try 
            {
                Usuario.Auth(Nome, Senha);
            }
            catch
            {
                throw new Exception("Nome ou senha inválido");
            }
        }
    }
}