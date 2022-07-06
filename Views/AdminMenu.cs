// =============================================================
// System libs.
using System;
using System.Windows.Forms;
// =============================================================
using Views.Lib;
// =============================================================
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
        
        public AdminMenu(Form parent) : base("Menu Administração",SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            btnStorage = new ButtonForm("Despesa", 30, 30, this.handleStorage); 
            btnReservation = new ButtonForm("Reserva", 170, 30, this.handleReservation);
            btnProduct = new ButtonForm("Produto", 30, 130, this.handleProduct);
            btnRoom = new ButtonForm("Quarto", 170, 130, this.handleRoom);
            btnCleaning = new ButtonForm("Limpeza", 30, 230, this.handleCleaning);
            btnEmploye = new ButtonForm("Funcionário", 170, 230, this.handleEmploye);
            btnPayment = new ButtonForm("Pagamento", 30, 330, this.handlePayment);
            btnUser = new ButtonForm("Usuário", 170, 330, this.handleUser);
            btnExit = new ButtonForm("Sair", 100, 430, this.handleExit);

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
            //(new Hospede(this)).Show();
            //this.Hide();
        }
        private void handleReservation(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }
        
        private void handleProduct(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }
        private void handleRoom(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }

        private void handleCleaning(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }
        private void handleEmploye(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }

        private void handlePayment(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }
        private void handleUser(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }

         private void handleExit(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }

    }
}
// =============================================================