using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class ProdutoInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);
        Form parent;
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblValor;
        readonly TextBox texValor;
        readonly Button btnConfirm;
        readonly Button btnCancel;

        public ProdutoInsert(ProdutoMenu parent) : base("Inserir Produto")
        {
            this.parent = parent;
            this.parent.Hide();

            this.ClientSize = new System.Drawing.Size(400,200);

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

            this.lblValor = new Label
            {
                Text = " Valor",
                Location = new Point(120, 70)
            };


            texValor = new TextBox
            {
                Location = new Point(10, 95),
                Size = new Size(360, 20)
            };
        
            
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.texValor);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            
            this.btnConfirm = new Campos.ButtonForm(this.Controls,"Confirmar", 80,140, this.handleConfirmClick);
            this.btnCancel = new Campos.ButtonForm(this.Controls,"Cancelar", 190, 140, this.handleCancelClick);
 
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            
            double Valor;
            try
            {
                Valor = double.Parse(texValor.Text); 
            }
            catch
            {
                throw new Exception("Valor inválido.");
            }
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                   ProdutoController.InserirProduto(
                        textNome.Text,
                        Valor

                        
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