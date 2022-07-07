using System;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Models;

namespace Views
{

    public class Login : Form
    {
        Form parent;
        readonly Campos.Field fieldUser;
        readonly Campos.Field fieldPass;
        readonly Button btnConfirm;
        readonly Button btnSair;

        public Login(Menu parent)

        {
            this.parent = parent;
            this.parent.Hide();
            
            this.ClientSize = new Size(300, 300);
            this.fieldUser = new Campos.Field(this.Controls, "Usuário", 20, true);
            this.fieldPass = new Campos.Field(this.Controls, "Senha", 80, true, true);
            this.btnConfirm = new Campos.ButtonForm(this.Controls, "Confirmar", 100, 180, this.handleConfirmClick);
            this.btnSair = new Campos.ButtonForm(this.Controls, "Cancelar", 100, 220, this.handleCancel);

        }

        private void handleConfirmClick(object sender, EventArgs e)
        {
            try
            {
                Usuario.Auth(this.fieldUser.textField.Text, this.fieldPass.textField.Text);
                if(Usuario.UsuarioAuth != null)
                {
                    (new AdminMenu(this)).Show();
                    this.Hide();
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Login ou Senha incorreta.");
            }
        }

        private void handleCancel(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();

        }
    }
}