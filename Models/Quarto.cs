using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Windows.Forms;

namespace Models
{
    public class Quarto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public Quarto() { }

        public Quarto(
            string Nome,
            string Numero,
            string Descricao,
            double Valor
        )
        {
            this.Nome = Nome;
            this.Numero = Numero;
            this.Descricao = Descricao;
            this.Valor = Valor;

            Context db = new Context();
            db.Quartos.Add(this);
            db.SaveChanges();
        }

        public string ToSuggestion() {
            return $"{this.Id} - {this.Nome}, {this.Numero}, {this.Descricao},  {this.Valor}";
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.Nome}, {this.Numero}, {this.Descricao}, {this.Valor}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Quarto.ReferenceEquals(this, obj))
            {
                return false;
            }
            Quarto it = (Quarto)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarQuarto(
            int Id,
            string Nome,
            string Numero,
            string Descricao,
            double Valor
        )
        {
            Quarto quarto = GetQuarto(Id);
            quarto.Nome = Nome;
            quarto.Numero = Numero;
            quarto.Descricao = Descricao;
            quarto.Valor = Valor;

            Context db = new Context();
            db.Quartos.Update(quarto);
            db.SaveChanges();
        }
        public static IEnumerable<Quarto> GetQuartos()
        {
            Context db = new Context();
            return (from Quarto in db.Quartos select Quarto);
        }
        public static Quarto GetQuarto(int Id)
        {
            Context db = new Context();
            IEnumerable<Quarto> quartos = from Quarto in db.Quartos
                                            where Quarto.Id == Id
                                            select Quarto;

            return quartos.First();
        }
        public static void RemoverQuarto(Quarto quarto)
        {
            Context db = new Context();
            db.Quartos.Remove(quarto);
            db.SaveChanges();
        }
    }
}