using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class UsuarioInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        
        readonly Label lblLogin;
        readonly TextBox textLogin;
        readonly Label lblSenha;
        readonly TextBox texSenha;
        readonly Button btnConfirm;
        readonly Button btnCancel;

        public UsuarioInsert() : base("Inserir Usuario")
        {
            this.ClientSize = new System.Drawing.Size(400,700);

            this.lblLogin = new Label
            {
                Text = " Login ",
                Location = new Point(120, 100),
                Size = new Size(240, 15)
            };

            textLogin = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblSenha = new Label
            {
                Text = " Senha",
                Location = new Point(120, 150)
            };


            texSenha = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };
        
            
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.texSenha);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            
            this.btnConfirm = new Campos.ButtonForm(this.Controls,"Confirmar", 80,220, this.handleConfirmClick);
            this.btnCancel = new Campos.ButtonForm(this.Controls,"Cancelar", 190, 220, this.handleCancelClick);
 
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                   UsuarioController.InserirUsuario(
                        textLogin.Text,
                        texSenha.Text

                        
                    );
                    MessageBox.Show("Dados inseridos com sucesso.");
                   UsuarioMenu menu = new UsuarioMenu();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível inserir os dados.");
            }              
        }


        private void handleCancelClick(object sender, EventArgs e)
        {
            Views.Menu menu = new Views.Menu();
            this.Close();
        }  
    }       
}