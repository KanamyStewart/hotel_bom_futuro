using System;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class Menu : BaseForm
    {
        ButtonForm btnClient;
        ButtonForm btnAdmin;
        ButtonForm btnExit;
        
        public Menu() : base("Menu principal")
        {            
            btnClient =  new Campos.ButtonForm(this.Controls,"Hóspede", 100, 50, this.handleClient);
            btnAdmin =  new Campos.ButtonForm(this.Controls,"Administrador", 100, 100, this.handleAdmin);
            btnExit = new Campos.ButtonForm(this.Controls,"Sair", 100, 150, this.handleCancel);

            this.Controls.Add(btnClient);
            this.Controls.Add(btnAdmin);
            this.Controls.Add(btnExit);
        }
        private void handleClient(object sender, EventArgs e)
        {
            (new ReservaMenu(this)).Show();
            this.Hide();
        }
        private void handleAdmin(object sender, EventArgs e)
        {
            (new Login(this)).Show();
            this.Hide();
        }
         private void handleCancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
