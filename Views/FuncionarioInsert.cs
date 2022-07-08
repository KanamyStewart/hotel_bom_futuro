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

        
        Form parent;
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblFuncao;
        readonly TextBox textFuncao;
        readonly Label lblTelefone;
        readonly TextBox textTelefone;
        readonly Button btnConfirm;
        readonly Button btnCancel;

        public FuncionarioInsert(FuncionarioMenu parent) : base("Inserir Funcionario")
        {
            this.ClientSize = new System.Drawing.Size(400,300);

            this.lblNome = new Label
            {
                Text = " Nome ",
                Location = new Point(120, 20),
                Size = new Size(240, 15)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 45),
                Size = new Size(360, 20)
            };

            this.lblFuncao = new Label
            {
                Text = " Função",
                Location = new Point(120, 70),
                Size = new Size(240, 15)
            };

            textFuncao = new TextBox
            {
                Location = new Point(10, 95),
                Size = new Size(360, 20)
            };

            this.lblTelefone = new Label
            {
                Text = " Telefone ",
                Location = new Point(120, 120),
                Size = new Size(240, 15)
            };

            textTelefone = new TextBox
            {
                Location = new Point(10, 145),
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
            
            this.btnConfirm = new Campos.ButtonForm(this.Controls,"Confirmar", 80,200, this.handleConfirmClick);
            this.btnCancel = new Campos.ButtonForm(this.Controls,"Cancelar", 190, 200, this.handleCancelClick);
 
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
                    this.parent.Show();
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
            this.parent.Show();
            this.Close();  
        }  
    }       
}