using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class QuartoController
    {
        public static Quarto InserirQuarto(
            string Nome,
            string Numero,
            string Descricao,
            double Valor
        )
        {
            if (String.IsNullOrEmpty(Nome) && String.IsNullOrEmpty(Numero) && String.IsNullOrEmpty(Descricao) && Double.IsNaN(Valor)) 
            {
                throw new Exception("Preencha todos os campos!");
            }

            return new Quarto(Nome, Numero, Descricao, Valor);
        }

        public static Quarto AlterarQuarto(
            int Id,
            string Nome,
            string Numero,
            string Descricao,
            double Valor
        )
        {
            Quarto quarto = Quarto.GetQuarto(Id);

            if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Numero) && !String.IsNullOrEmpty(Descricao) && !Double.IsNaN(Valor)) {
                quarto.Nome = Nome;
                quarto.Numero = Numero;
                quarto.Descricao = Descricao;
                quarto.Valor = Valor;
            }
            else
            {
                throw new Exception("Preencha todos os campos!");
            }

            Models.Quarto.AlterarQuarto(Id, Nome, Numero, Descricao, Valor);

            return quarto;
        }
        public static Quarto ExcluirQuarto(
            int Id
        )
        {
            Quarto quarto = Quarto.GetQuarto(Id);
            Models.Quarto.RemoverQuarto(quarto);
            return quarto;
        }
        public static IEnumerable<Quarto> GetQuartos()
        {
            return Quarto.GetQuartos();
        }

        public static Quarto GetQuarto(
            int Id
        )
        {
            Quarto quarto = (
                from Quarto in Quarto.GetQuartos()
                    where Quarto.Id == Id
                    select Quarto
            ).First();
            
            if (quarto == null)
            {
                throw new Exception("Quarto não encontrada");
            }

            return quarto;
        }
    }
}