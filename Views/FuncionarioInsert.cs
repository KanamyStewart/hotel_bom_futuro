using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class FuncionarioInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblFuncao;
        readonly TextBox textFuncao;
        readonly Label lblTelefone;
        readonly TextBox textTelefone;
        readonly Button btnConfirm;
        readonly Button btnCancel;

        public FuncionarioInsert() : base("Inserir Funcionario")
        {
            this.ClientSize = new System.Drawing.Size(400,700);

            this.lblNome = new Label
            {
                Text = " Nome ",
                Location = new Point(120, 100),
                Size = new Size(240, 15)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblFuncao = new Label
            {
                Text = " Função",
                Location = new Point(120, 150),
                Size = new Size(240, 15)
            };

            textFuncao = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.lblTelefone = new Label
            {
                Text = " Telefone ",
                Location = new Point(120, 100),
                Size = new Size(240, 15)
            };

            textTelefone = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };
        
            
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.lblFuncao);
            this.Controls.Add(this.textFuncao);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.textTelefone);
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
                   FuncionarioController.InserirFuncionario(
                        textNome.Text,
                        textFuncao.Text,
                        textTelefone.Text

                        
                    );
                    MessageBox.Show("Dados inseridos com sucesso.");
                   FuncionarioMenu menu = new FuncionarioMenu();
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