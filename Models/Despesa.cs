using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Windows.Forms;

namespace Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public int Quarto { get; set; }
        public double ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        

        public Despesa() { }

        public Despesa(
            int Quarto,
            double ValorTotal,
            int ProdutoId,
            int Quantidade
        )
        {
            this.Quarto = Quarto;
            this.ValorTotal = ValorTotal;
            this.ProdutoId = ProdutoId;
            this.Quantidade = Quantidade;

            Context db = new Context();
            db.Despesas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $" {this.Id}, {this.Quarto}, {this.ValorTotal}, {this.Quantidade}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Despesa.ReferenceEquals(this, obj))
            {
                return false;
            }
            Despesa it = (Despesa)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarDespesa(
            int Id,
            int Quarto,
            double ValorTotal,
            int ProdutoId,
            int Quantidade
        )
        {
            Despesa despesa = GetDespesa(Id);
            despesa.Quarto = Quarto;
            despesa.ValorTotal = ValorTotal;
            despesa.ProdutoId = ProdutoId;
            despesa.Quantidade = Quantidade;

            Context db = new Context();
            db.Despesas.Update(despesa);
            db.SaveChanges();
        }
        public static IEnumerable<Despesa> GetDespesas()
        {
            Context db = new Context();
            return (from Despesa in db.Despesas select Despesa);
        }
        public static Despesa GetDespesa(int Id)
        {
            Context db = new Context();
            IEnumerable<Despesa> despesas = from Despesa in db.Despesas
                                            where Despesa.Id == Id
                                            select Despesa;

            return despesas.First();
        }
        public static void RemoverDespesa(Despesa despesa)
        {
            Context db = new Context();
            db.Despesas.Remove(despesa);
            db.SaveChanges();
        }
    }
}