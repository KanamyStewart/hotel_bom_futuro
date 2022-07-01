using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class LimpezaController
    {
        public static Limpeza InserirLimpeza(int QuartoId, int FuncionairoId)
        {
            return new Limpeza(QuartoId, FuncionairoId);
        }

        public static void AtualizarLimpeza(int Id, int QuartoId, int FuncionairoId)
        {
            Limpeza limpeza = Models.Limpeza.GetLimpeza(Id);

            limpeza.QuartoId = QuartoId;
            limpeza.FuncionairoId = FuncionairoId;

            Limpeza.AlterarLimpeza(Id, QuartoId, FuncionairoId);
        }

        public static Limpeza DeletarLimpeza(int Id)
        {
            Limpeza limpeza = Models.Limpeza.GetLimpeza(Id);
            Limpeza.RemoverLimpeza(limpeza);
            return limpeza;
        }

        public static IEnumerable<Limpeza> SelecionarLimpezas()
        {
            return Models.Limpeza.GetLimpezas();
        }
    }
}