using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class DespesaUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblId;
        TextBox textId;
        readonly Label lblQuarto;
        readonly TextBox textQuarto;
        readonly Label lblValorTotal;
        readonly TextBox textValorTotal;
        readonly Label lblProduto;
        readonly ComboBox comboBoxProduto;
        readonly Label lblQuantidade;
        readonly TextBox textQuantidade;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public DespesaUpdate() : base("Despesas")
        {
            this.ClientSize = new System.Drawing.Size(400,300);

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

            this.lblQuarto = new Label
            {
                Text = " Quarto ",
                Location = new Point(120, 150),
                Size = new Size(240, 15)
            };

            textQuarto = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.lblValorTotal = new Label
            {
                Text = " Valor Total",
                Location = new Point(120, 200)
            };

            textValorTotal = new TextBox
            {
                Location = new Point(10, 225),
                Size = new Size(360, 20)
            };

            this.lblProduto = new Label
            {
                Text = " Produto",
                Location = new Point(120, 250)
            };

            string[] produtosSuggestion = ProdutoController
                .GetProdutos()
                .Select(produto => produto.ToSuggestion())
                .ToArray();
            this.comboBoxProduto = new ComboBox{
                Location = new Point(10, 275),
                Size = new Size(360, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.comboBoxProduto.Items.AddRange(produtosSuggestion);


            this.lblQuantidade = new Label
            {
                Text = " Quantidade",
                Location = new Point(120, 300)
            };

            textQuantidade = new TextBox
            {
                Location = new Point(10, 325),
                Size = new Size(360, 20)
            };

     

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls,"Confirmar", 80,400, this.handleConfirmClick);
            this.btnCancel1 = new  Campos.ButtonForm(this.Controls,"Cancelar", 190, 400, this.handleCancelClick);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.lblQuarto);
            this.Controls.Add(this.textQuarto);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.textValorTotal);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.comboBoxProduto);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.textQuantidade);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            string[] comboValue = comboBoxProduto.Text.Split(" ");
            int ProdutoId = int.Parse(comboValue[0]);
            int Id;
            int QuartoId;
            double ValorId;
            int QuantidadeId;

            try
            {
                Id = int.Parse(textId.Text); 
            }
            catch
            {
                throw new Exception("Número inválido.");
            }
            try
            {
                QuartoId = int.Parse(textQuarto.Text); 
            }
            catch
            {
                throw new Exception("Número inválido.");
            }

            try
            {
                ValorId = double.Parse(textQuarto.Text); 
            }
            catch
            {
                throw new Exception("Valor inválido.");
            }

            try
            {
                QuantidadeId = int.Parse(textQuantidade.Text); 
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
                    DespesaController.InserirDespesa(
                        QuartoId,
                        ValorId,
                        ProdutoId,
                        QuantidadeId
                        
                    );
                }

                MessageBox.Show("Dados inseridos com sucesso.");
                   DespesaMenu menu = new DespesaMenu();
                    this.Close();

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