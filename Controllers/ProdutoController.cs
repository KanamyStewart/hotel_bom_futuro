using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class ProdutoController
    {
        public static Produto InserirProduto(
            string Nome,
            double Valor
        )
        {
            if (String.IsNullOrEmpty(Nome) && Double.IsNaN(Valor)) 
            {
                throw new Exception("Preencha todos os campos!");
            }

            return new Produto(Nome, Valor);
        }

        public static Produto AlterarProduto(
            int Id,
            string Nome,
            double Valor
        )
        {
            Produto produto = Produto.GetProduto(Id);

            if (!String.IsNullOrEmpty(Nome) && !double.IsNaN(Valor)) {
                produto.Nome = Nome;
                produto.Valor = Valor;
            }
            else
            {
                throw new Exception("Preencha todos os campos!");
            }

            Models.Produto.AlterarProduto(Id, Nome, Valor);

            return produto;
        }
        public static Produto ExcluirProduto(
            int Id
        )
        {
            Produto produto = Produto.GetProduto(Id);
            Models.Produto.RemoverProduto(produto);
            return produto;
        }
        public static IEnumerable<Produto> GetProdutos()
        {
            return Produto.GetProdutos();
        }

        public static Produto GetProduto(
            int Id
        )
        {
            Produto produto = (
                from Produto in Produto.GetProdutos()
                    where Produto.Id == Id
                    select Produto
            ).First();
            
            if (produto == null)
            {
                throw new Exception("Produto não encontrada");
            }

            return produto;
        }
    }
}