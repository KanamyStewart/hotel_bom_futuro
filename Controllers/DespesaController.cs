using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class DespesaController
    {
        public static Despesa InserirDespesa(int QuartoId, double ValorTotal,int ProdutoId,int Quantidade)
        {
            if(Double.IsNaN(ValorTotal))
            {
                throw new Exception("Valor não pode ficar em branco!");
            }

            return new Despesa(QuartoId,ValorTotal,ProdutoId,Quantidade);
        }

        public static void AtualizarDespesa(int Id,int QuartoId, double ValorTotal,int ProdutoId,int Quantidade)
        {
            Despesa despesa = GetDespesa(Id);

            if(Double.IsNaN(ValorTotal))
           
            Despesa.AlterarDespesa(Id, QuartoId, ValorTotal, ProdutoId, Quantidade);
        }

        public static Despesa DeletarDespesa(int Id)
        {
            Despesa despesa = Models.Despesa.GetDespesa(Id);
            Despesa.RemoverDespesa(despesa);
            return despesa;
        }

        public static IEnumerable<Despesa> GetDespesas()
        {
            return Despesa.GetDespesas();
        }

        public static Despesa GetDespesa(int Id)
        {
            try 
            {
                Despesa despesa = (
                    from Despesa in Despesa.GetDespesas()
                        where Despesa.Id == Id
                        select Despesa
                ).First();

                if (despesa == null)
                {
                    throw new Exception("Categoria não encontrada");
                }

                return despesa;
            }
            catch
            {
                throw new Exception("Categoria não encontrada");
            }
        }

        public static IEnumerable<Despesa> SelecionarDespesas()
        {
            return Despesa.GetDespesas();
        }
    }
}