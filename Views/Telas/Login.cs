using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;

namespace Telas
{
    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblLogin;
        Label lblSenha;
        
        TextBox txtLogin;
        TextBox txtSenha;
        
        Button btnConfirmar;
        Button btnCancelar;

        public Login()
        {

            this.lblLogin = new Label();
            this.lblLogin.Text = "Login:";
            this.lblLogin.Location = new Point(130, 40);

            this.txtLogin = new TextBox();
            this.txtLogin.Location = new Point(60, 60);
            this.txtLogin.Size = new Size(180, 20);

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha:";
            this.lblSenha.Location = new Point(130, 90);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(60, 115);
            this.txtSenha.PasswordChar = '*';

            this.btnConfirmar = new ButtonField("Confirme", 100, 200, 100, 40);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancelar = new ButtonField("Cancela",100, 230,100, 40);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Login";
        }

        private void btnCancelarClick(object sender, EventArgs e)
           {
                this.Close();
           }

           public void btnConfirmarClick(object sender, EventArgs e)
        {
            try 
            {
            string message = "Seu funcionário foi cadastrado com sucesso!";
            string caption = " Enjoy! ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            UsuarioControl.Logins(this.txtLogin.Text, this.txtSenha.Text);
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }
            }catch(Exception){
            string message = "Os dados inseridos foram inválidos, repita o processo!";
            string caption = "Falha";
            MessageBox.Show(message, caption);
            
            }
        }
    }
}