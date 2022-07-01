using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class ReservaController
    {
        public static Reserva InserirReserva(
            DateTime Checkin,
            DateTime Checkout,
            int QuartoId,
            string NomeHospede,
            string DataNasc,
            string Email,
            string Telefone,
            string Cpf,
            string NomeMae,
            int FormaPagamentoId
        )
        {
            if (Checkin == null && Checkout == null && String.IsNullOrEmpty(NomeHospede) && String.IsNullOrEmpty(DataNasc) && String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Telefone) && String.IsNullOrEmpty(Cpf) && String.IsNullOrEmpty(NomeMae))
            {
                throw new Exception("Preencha todos os campos!");
            }
            try
            {
                QuartoController.GetQuarto(QuartoId);
            }
            catch
            {
                throw new Exception("Quarto inválida");
            }
            try
            {
                FormaPagamentoController.GetFormaPagamento(FormaPagamentoId);
            }
            catch
            {
                throw new Exception("FormaPagamento inválida");
            }

            return new Reserva(Checkin, Checkout, QuartoId, NomeHospede, DataNasc, Email, Telefone, Cpf, NomeMae, FormaPagamentoId);
        }

        public static Reserva AlterarReserva(
            int Id,
            DateTime Checkin,
            DateTime Checkout,
            int QuartoId,
            string NomeHospede,
            string DataNasc,
            string Email,
            string Telefone,
            string Cpf,
            string NomeMae,
            int FormaPagamentoId
        )
        {
            Reserva reserva = Reserva.GetReserva(Id);
            try
            {
                QuartoController.GetQuarto(QuartoId);
            }
            catch
            {
                throw new Exception("Quarto inválida");
            }
            try
            {
                FormaPagamentoController.GetFormaPagamento(FormaPagamentoId);
            }
            catch
            {
                throw new Exception("FormaPagamento inválida");
            }

            if (Checkin == null && Checkout == null && String.IsNullOrEmpty(NomeHospede) && String.IsNullOrEmpty(DataNasc) && String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Telefone) && String.IsNullOrEmpty(Cpf) && String.IsNullOrEmpty(NomeMae))
            {
                throw new Exception("Preencha todos os campos!");
            }

            Models.Reserva.AlterarReserva(Id, Checkin, Checkout, QuartoId, NomeHospede, DataNasc, Email, Telefone, Cpf, NomeMae, FormaPagamentoId);

            return reserva;
        }
        public static Reserva ExcluirReserva(
            int Id
        )
        {
            Reserva reserva = Reserva.GetReserva(Id);
            Models.Reserva.RemoverReserva(reserva);
            return reserva;
        }
        public static IEnumerable<Reserva> GetReservas()
        {
            return Reserva.GetReservas();
        }

        public static Reserva GetReserva(
            int Id
        )
        {
            Reserva reserva = (
                from Reserva in Reserva.GetReservas()
                where Reserva.Id == Id
                select Reserva
            ).First();

            if (reserva == null)
            {
                throw new Exception("Reserva não encontrada");
            }

            return reserva;
        }
        public static void CalcularReserva(Reserva viewModel)
        {

        }
    }
}