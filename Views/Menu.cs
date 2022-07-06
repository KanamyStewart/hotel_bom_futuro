using System;
using System.Windows.Forms;
using Views.Lib;

namespace Views
{
    public class Menu : BaseForm
    {
        ButtonForm btnClient;
        ButtonForm btnAdmin;
        ButtonForm btnExit;
        
        public Menu() : base("Menu principal", SizeScreen.Small)
        {            
            btnClient =  new ButtonForm("Hóspede", 30, 30, this.handleClient);
            btnAdmin =  new ButtonForm("Administrador", 170, 30, this.handleAdmin);
            btnExit = new ButtonForm("Sair", 100, 130, this.handleExit);

            this.Controls.Add(btnClient);
            this.Controls.Add(btnAdmin);
            this.Controls.Add(btnExit);
        }
        private void handleClient(object sender, EventArgs e)
        {
            //(new Hospede(this)).Show();
            //this.Hide();
        }
        private void handleAdmin(object sender, EventArgs e)
        {
            //(new AdminMenu(this)).Show();
            //this.Hide();
        }
        private void handleExit(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
