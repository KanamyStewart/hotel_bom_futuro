using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;
namespace Views
{
    public class AdminMenu : BaseForm
    {
        Form parent;
        ButtonForm btnStorage;
        ButtonForm btnReservation;
        ButtonForm btnProduct;
        ButtonForm btnRoom;
        ButtonForm btnCleaning;
        ButtonForm btnEmploye;
        ButtonForm btnPayment;
        ButtonForm btnUser;
        ButtonForm btnExit;
        
        public AdminMenu(Form parent) : base("Menu Administração")
        {
            this.parent = parent;
            this.parent.Hide();
            this.ClientSize = new System.Drawing.Size(350,500);

            btnStorage = new Campos.ButtonForm(this.Controls,"Despesa", 50, 30, this.handleStorage); 
            btnReservation = new Campos.ButtonForm(this.Controls,"Reserva", 190, 30, this.handleReservation);
            btnProduct = new Campos.ButtonForm(this.Controls,"Produto", 50, 150, this.handleProduct);
            btnRoom = new Campos.ButtonForm(this.Controls,"Quarto", 190, 150, this.handleRoom);
            btnCleaning = new Campos.ButtonForm(this.Controls,"Limpeza", 50, 250, this.handleCleaning);
            btnEmploye = new Campos.ButtonForm(this.Controls,"Funcionário", 190, 250, this.handleEmploye);
            btnPayment = new Campos.ButtonForm(this.Controls,"Pagamento", 50, 350, this.handlePayment);
            btnUser = new Campos.ButtonForm(this.Controls,"Usuário", 190, 350, this.handleUser);
            btnExit = new Campos.ButtonForm(this.Controls,"Sair", 120, 420, this.handleExit);

            this.Controls.Add(btnStorage);
            this.Controls.Add(btnReservation);
            this.Controls.Add(btnProduct);
            this.Controls.Add(btnRoom);
            this.Controls.Add(btnCleaning);
            this.Controls.Add(btnEmploye);
            this.Controls.Add(btnPayment);
            this.Controls.Add(btnUser);
            this.Controls.Add(btnExit);
        }

        private void handleStorage(object sender, EventArgs e)
        {
            (new DespesaMenu(this)).Show();
            this.Hide();
        }
        private void handleReservation(object sender, EventArgs e)
        {
            (new ReservaList(this)).Show();
            this.Hide();
        }
        
        private void handleProduct(object sender, EventArgs e)
        {
            (new ProdutoMenu(this)).Show();
            this.Hide();
        }
        private void handleRoom(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }

        private void handleCleaning(object sender, EventArgs e)
        {
            //(new CrudLimpeza(this)).Show();
            //this.Hide();
        }
        private void handleEmploye(object sender, EventArgs e)
        {
            (new FuncionarioMenu(this)).Show();
            this.Hide();
        }

        private void handlePayment(object sender, EventArgs e)
        {
            (new CrudFormasPagamento(this)).Show();
            this.Hide();
        }
        private void handleUser(object sender, EventArgs e)
        {
            (new UsuarioMenu(this)).Show();
            this.Hide();
        }

         private void handleExit(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }

    }
}
// =============================================================