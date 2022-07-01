using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Windows.Forms;
using System;

namespace Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int QuartoId { get; set; }
        public Quarto Quarto { get; set; }
        public string NomeHospede { get; set; }
        public string DataNasc { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Reserva() { }

        public Reserva(
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
            this.Checkin = Checkin;
            this.Checkout = Checkout;
            this.QuartoId = QuartoId;;
            this.NomeHospede = NomeHospede;
            this.DataNasc = DataNasc;
            this.Email = Email;
            this.Telefone = Telefone;
            this.Cpf = Cpf;
            this.NomeMae = NomeMae;
            this.FormaPagamentoId = FormaPagamentoId;

            Context db = new Context();
            db.Reservas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.Checkin}, {this.Checkout}, {this.Quarto.Nome}, {this.NomeHospede}, {this.DataNasc}, {this.Email}, {this.Telefone}, {this.Cpf}, {this.NomeMae}, {this.FormaPagamento.Nome}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Reserva.ReferenceEquals(this, obj))
            {
                return false;
            }
            Reserva it = (Reserva)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarReserva(
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
            Reserva reserva = GetReserva(Id);
            reserva.Checkin = Checkin;
            reserva.Checkout = Checkout;
            reserva.QuartoId = QuartoId;
            reserva.NomeHospede = NomeHospede;
            reserva.DataNasc = DataNasc;
            reserva.Email = Email;
            reserva.Telefone = Telefone;
            reserva.Cpf = Cpf;
            reserva.NomeMae = NomeMae;
            reserva.FormaPagamentoId = FormaPagamentoId;

            Context db = new Context();
            db.Reservas.Update(reserva);
            db.SaveChanges();
        }
        public static IEnumerable<Reserva> GetReservas()
        {
            Context db = new Context();
            return (from Reserva in db.Reservas select Reserva);
        }
        public static Reserva GetReserva(int Id)
        {
            Context db = new Context();
            IEnumerable<Reserva> reservas = from Reserva in db.Reservas
                                            where Reserva.Id == Id
                                            select Reserva;

            return reservas.First();
        }
        public static void RemoverReserva(Reserva reserva)
        {
            Context db = new Context();
            db.Reservas.Remove(reserva);
            db.SaveChanges();
        }
    }
}