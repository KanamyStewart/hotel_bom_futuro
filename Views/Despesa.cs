using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
using Controllers;
using static lib.Campos;
using lib;


namespace Views
{
    public class Despesa : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

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

        public DespesaInsert() : base("Despesas")
        {
            this.ClientSize = new System.Drawing.Size(400,300);

            this.lblQuarto = new Label
            {
                Text = " Quarto ",
                Location = new Point(120, 100),
                Size = new Size(240, 15)
            };

            textQuarto = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblValorTotal = new Label
            {
                Text = " Valor Total",
                Location = new Point(120, 150)
            };

            textValorTotal = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.lblProduto = new Label
            {
                Text = " Produto",
                Location = new Point(120, 200)
            };

            string[] despesasSuggestion = DespesaController
                .GetDespesas()
                .Select(despesa => despesa.ToSuggestion())
                .ToArray();
            this.comboBoxProduto = new ComboBox{
                Location = new Point(10, 300),
                Size = new Size(360, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.comboBoxProduto.Items.AddRange(despesasSuggestion);


            this.lblQuantidade = new Label
            {
                Text = " Quantidade",
                Location = new Point(120, 325)
            };

            textQuantidade = new TextBox
            {
                Location = new Point(10, 350),
                Size = new Size(360, 20)
            };

             ListView listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                Sorting = SortOrder.Ascending
            };

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader
            {
                Text = "Qtd.",
                Width = -2
            };
            ColumnHeader list1 = new ColumnHeader
            {
                Text = "Produto",
                Width = -2
            };
            ColumnHeader list2 = new ColumnHeader
            {
                Text = "Valor",
                Width = -2
            };

            // Add the column headers to listView1.
            listView.Columns.AddRange(new ColumnHeader[] 
                {list0, list1,list2});


            // Create items and add them to myListView.
			listView.View = View.Details;
			foreach(Despesa item in DespesaController.GetDespesas())
            {
                ListViewItem listDespesa= new ListViewItem(item.Id + "");
                listSenha.SubItems.Add(item.Quantidade);
                listSenha.SubItems.Add(item.Produto);
                listSenha.SubItems.Add(item.Valor);		
                listView.Items.AddRange(new ListViewItem[]{listDespesa});
            }
     

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 240, this.handleCancelClick);

            this.Controls.Add(this.lblDespesas);
            this.Controls.Add(this.lblQuartos);
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
                  
            try
            {
                DespesaController.InserirDespesa(
                    textQuarto.Text,
                    textDescricao.Text
                );

                MessageBox.Show("Dados inseridos com sucesso.");
                Views.CategoriaMenu menu = new Views.CategoriaMenu();
                this.Close();

            }
            catch (System.Exception)
            {
                MessageBox.Show("Não foi possível inserir os dados.");
            }              
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  
    }       
}