using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class LimpezaController
    {
        public static Limpeza InserirLimpeza(int QuartoId, int FuncionairoId)
        {
            if (Int32.IsNullOrEmpty(QuartoId) && Int32.IsNullOrEmpty(FuncionairoId))
            {
                throw new Exception("Por favor preencha todos os campos!");
            }

            return new Limpeza(QuartoId, FuncionairoId);
        }

        public static void AtualizarLimpeza(int Id, int QuartoId, int FuncionairoId)
        {
            Limpeza limpeza = Models.Limpeza.GetLimpeza(Id);

            if(!Int32.IsNullOrEmpty(QuartoId) && !Int32.IsNullOrEmpty(FuncionairoId))
            {
                Limpeza.QuartoId = QuartoId;
                Limpeza.FuncionairoId = FuncionairoId;
            }
            else
            {
                throw new Exception("Os campos não podem ficar em branco!");
            }

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