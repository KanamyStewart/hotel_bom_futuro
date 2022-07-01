using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class FormaPagamentoController
    {
        public static FormaPagamento InserirFormaPagamento(string Nome)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome não pode ficar em branco!");
            }

            return new FormaPagamento(Nome);
        }

        public static void AtualizarFormaPagamento(int Id, string Nome)
        {
            FormaPagamento formaPagamento = Models.FormaPagamento.GetFormaPagameto(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                formaPagamento.Nome = Nome;
            }
            else
            {
                throw new Exception("Nome não pode ficar em branco!");
            }

            FormaPagamento.AlterarFormaPagamento(Id, Nome);
        }

        public static FormaPagamento DeletarFormaPagamento(int Id)
        {
            FormaPagamento formaPagamento = Models.FormaPagamento.GetFormaPagameto(Id);
            FormaPagamento.RemoverFormaPagamento(formaPagamento);

            return formaPagamento;
        }

        public static IEnumerable<FormaPagamento> SelecionarFormaPagamentos()
        {
            return Models.FormaPagamento.GetFormaPagametos();
        }
    }
}