using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;
using Models;


namespace Views
{
    public class ProdutoUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblId;
        TextBox textId;
        Label lblNome;
        TextBox textNome;
        Label lblValor;
        TextBox textValor;
        Button btnConfirm1;
        Button btnCancel1;

        public ProdutoUpdate() : base("Alterar Produto")
        {

            this.lblId = new Label
            {
                Text = " Id para alterar ",
                Location = new Point(80, 100),
                Size = new Size(240, 20)
            };

            textId = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblNome = new Label
            {
                Text = " Nome",
                Location = new Point(120, 150)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.lblValor = new Label
            {
                Text = " Valor",
                Location = new Point(120, 200)
            };

            textValor = new TextBox();
            textValor.Location = new Point(10,225);
            textValor.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls,"Confirmar", 40,260, this.handleConfirmClick);
            this.btnCancel1 = new  Campos.ButtonForm(this.Controls,"Cancelar", 150, 260, this.handleCancelClick);
  
           
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.textValor);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            try
            {
                int Id;
                try
                {
                    Id = int.Parse(textId.Text); 
                }
                catch
                {
                    throw new Exception("ID inválido.");
                }

                double Valor;
                try
                {
                    Valor = double.Parse(textValor.Text); 
                }
                catch
                {
                    throw new Exception("Valor inválido.");
                }
                
               ProdutoController.AlterarProduto(
                    Id,
                    textNome.Text,
                    Valor
                );

                MessageBox.Show("Dados alterados com sucesso.");
                Views.ProdutoMenu menu = new Views.ProdutoMenu();
                this.Close();

            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Não foi possível inserir os dados. {err.Message}");
            }              
        }
        
        private void handleCancelClick(object sender, EventArgs e)
        {
            Views.Menu menu = new Views.Menu();
            this.Close();
        }  
    }       
}