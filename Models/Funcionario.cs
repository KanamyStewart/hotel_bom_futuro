using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Windows.Forms;

namespace Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; } //MUDAR TUDO
        public string Telefone { get; set; }

        public Funcionario() { }

        public Funcionario(
            string Nome,
            string Funcao,
            string Telefone
        )
        {
            this.Nome = Nome;
            this.Funcao = Funcao;
            this.Telefone = Telefone;

            Context db = new Context();
            db.Funcionarios.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.Nome}, {this.Funcao}, {this.Telefone}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Funcionario.ReferenceEquals(this, obj))
            {
                return false;
            }
            Funcionario it = (Funcionario) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarFuncionario(
            int Id,
            string Nome,
            string Funcao,
            string Telefone
        )
        {
            Funcionario funcionario = GetFuncionario(Id);
            funcionario.Nome = Nome;
            funcionario.Funcao = Funcao;
            funcionario.Telefone = Telefone;

            Context db = new Context();
            db.Funcionarios.Update(funcionario);
            db.SaveChanges();
        }


        public static IEnumerable<Funcionario> GetFuncionarios()
        {
            Context db = new Context();
            return (from Funcionario in db.Funcionarios select Funcionario);
        }

        public static Funcionario GetFuncionario(int Id)
        {
            Context db = new Context();
            IEnumerable<Funcionario> funcionarios = from Funcionario in db.Funcionarios
                            where Funcionario.Id == Id
                            select Funcionario;

            return funcionarios.First();
        }

        public static void RemoverFuncionario(Funcionario funcionario)
        {
            Context db = new Context();
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
        }
    }
}