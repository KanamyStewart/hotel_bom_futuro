using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Windows.Forms;
using Models;

namespace Models
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public FormaPagamento() { }

        public FormaPagamento(
            string Nome
        )
        {
            this.Nome = Nome;

            Context db = new Context();
            db.FormaPagamentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.Nome}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!FormaPagamento.ReferenceEquals(this, obj))
            {
                return false;
            }
            FormaPagamento it = (FormaPagamento)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarFormaPagamento(
            int Id,
            string Nome
        )
        {
            FormaPagamento formaPagamento = GetFormaPagamento(Id);
            formaPagamento.Nome = Nome;

            Context db = new Context();
            db.FormaPagamentos.Update(formaPagamento);
            db.SaveChanges();
        }
        public static IEnumerable<FormaPagamento> GetFormaPagamentos()
        {
            Context db = new Context();
            return (from FormaPagamento in db.FormaPagamentos select FormaPagamento);
        }
        public static FormaPagamento GetFormaPagamento(int Id)
        {
            Context db = new Context();
            IEnumerable<FormaPagamento> formaPagamentos = from FormaPagamento in db.FormaPagamentos
                                            where FormaPagamento.Id == Id
                                            select FormaPagamento;

            return formaPagamentos.First();
        }
        public static void RemoverFormaPagamento(FormaPagamento formaPagamento)
        {
            Context db = new Context();
            db.FormaPagamentos.Remove(formaPagamento);
            db.SaveChanges();
        }
    }
}