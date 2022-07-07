using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class DespesaController
    {
        public static Despesa InserirDespesa(int ProdutoId, int ReservaId)
        {
            ProdutoController.GetProduto(ProdutoId);
            ProdutoController.GetProduto(ReservaId);

            return new Despesa(ProdutoId, ReservaId);
        }

        public static void AtualizarDespesa(int Id, int ProdutoId, int ReservaId)
        {
            Despesa despesa = Models.Despesa.GetDespesa(Id);

            ProdutoController.GetProduto(ProdutoId);
            ProdutoController.GetProduto(ReservaId);

            Despesa.AlterarDespesa(Id, ProdutoId, ReservaId);
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