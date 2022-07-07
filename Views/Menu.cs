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
            btnClient =  new Campos.ButtonForm(this.Controls,"Hóspede", 30, 30, this.handleClient);
            btnAdmin =  new Campos.ButtonForm(this.Controls,"Administrador", 170, 30, this.handleAdmin);
            btnExit = new Campos.ButtonForm(this.Controls,"Sair", 100, 130, this.handleExit);

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
            Menu menu = new Menu();
            menu.ShowDialog();
        }
        private void handleExit(object sender, EventArgs e)
        {
           
        }
    }
}
