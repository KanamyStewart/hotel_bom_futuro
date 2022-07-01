using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class DespesaController
    {
        public static Despesa InserirDespesa(string Descricao, double Valor)
        {
            if (Descricao.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição não pode ficar em branco!");
            }

            if (Descricao.IsNullOrEmpty(Valor))
            {
                throw new Exception("Valor não pode ficar em branco!");
            }

            return new Despesa(Descricao, Valor);
        }

        public static void AtualizarDespesa(int Id, string Descricao, double Valor)
        {
            Despesa despesa = Models.Despesa.GetDespesa(Id);

            if(!String.IsNullOrEmpty(Descricao) && !Double.IsNullOrEmpty(Valor))
            {
                despesa.Descricao = Descricao;
                despesa.Valor = Valor;
            }
            else
            {
                throw new Exception("Descrição e valor não pode ficar em branco!");
            }

            Despesa.AlterarDespesa(Id, Descricao, Valor);
        }

        public static Despesa DeletarDespesa(int Id)
        {
            Despesa despesa = Models.Despesa.GetDespesa(Id);
            Despesa.RemoverDespesa(despesa);
            return despesa;
        }

        public static IEnumerable<Despesa> SelecionarDespesas()
        {
            return Models.Despesa.GetDespesas();
        }
    }
}