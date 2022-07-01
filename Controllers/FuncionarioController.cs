using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class FuncionarioController
    {
        public static Funcionario InserirFuncionario(string Nome, string Funcao, string Telefone)
        {
            if (String.IsNullOrEmpty(Nome) && String.IsNullOrEmpty(Funcao) && String.IsNullOrEmpty(Telefone))
            {
                throw new Exception("Por favor preencha todos os campos!");
            }

            return new Funcionario(Nome, Funcao, Telefone);
        }

        public static void AtualizarFuncionario(int Id, string Nome, string Funcao, string Telefone)
        {
            Funcionario Funcionario = Models.Funcionario.GetFuncionario(Id);

            if(!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Funcao) && !String.IsNullOrEmpty(Telefone))
            {
                Funcionario.Nome = Nome;
                Funcionario.Funcao = Funcao;
                Funcionario.Telefone = Telefone;
            }
            else
            {
                throw new Exception("Os campos não podem ficar em branco!");
            }

            Funcionario.AlterarFuncionario(Id, Nome, Funcao, Telefone);
        }

        public static Funcionario DeletarFuncionario(int Id)
        {
            Funcionario Funcionario = Models.Funcionario.GetFuncionario(Id);
            Funcionario.RemoverFuncionario(Funcionario);
            return Funcionario;
        }

        public static IEnumerable<Funcionario> SelecionarFuncionarios()
        {
            return Models.Funcionario.GetFuncionarios();
        }
    }
}