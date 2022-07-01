using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Windows.Forms;
using Models;

namespace Models
{
    public class Limpeza
    {
        public int Id { get; set; }
        public int QuartoId { get; set; }
        public int FuncionairoId { get; set; }
        public Limpeza() { }

        public Limpeza(
            int QuartoId,
            int FuncionairoId
        )
        {
            this.QuartoId = QuartoId;
            this.FuncionairoId = FuncionairoId;

            Context db = new Context();
            db.Limpezas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.QuartoId}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Limpeza.ReferenceEquals(this, obj))
            {
                return false;
            }
            Limpeza it = (Limpeza)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarLimpeza(
            int Id,
            int QuartoId,
            int FuncionairoId
        )
        {
            Limpeza limpeza = GetLimpeza(Id);
            limpeza.QuartoId = QuartoId;
            limpeza.FuncionairoId = FuncionairoId;

            Context db = new Context();
            db.Limpezas.Update(limpeza);
            db.SaveChanges();
        }
        public static IEnumerable<Limpeza> GetLimpezas()
        {
            Context db = new Context();
            return (from Limpeza in db.Limpezas select Limpeza);
        }
        public static Limpeza GetLimpeza(int Id)
        {
            Context db = new Context();
            IEnumerable<Limpeza> limpezas = from Limpeza in db.Limpezas
                                            where Limpeza.Id == Id
                                            select Limpeza;

            return limpezas.First();
        }
        public static void RemoverLimpeza(Limpeza limpeza)
        {
            Context db = new Context();
            db.Limpezas.Remove(limpeza);
            db.SaveChanges();
        }
    }
}