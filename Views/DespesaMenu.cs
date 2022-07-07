using System;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class DespesaMenu : BaseForm
    {
        readonly Button btnInsert;
        readonly Button btnAlterar;
        readonly Button btnExcluir;
        readonly Button btnVoltar;
        internal static readonly object listSenha;

        public DespesaMenu() : base(" Despesas")
        {
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
			foreach(Despesa item in DespesaController.SelecionarDespesas())
            {
                ListViewItem listDespesas= new ListViewItem(item.Id + "");
                listDespesas.SubItems.Add(item.Quantidade + "" );
                listDespesas.SubItems.Add(item.Produto + "");
                listDespesas.SubItems.Add(item.ValorTotal + "");		
                listView.Items.AddRange(new ListViewItem[]{listDespesas});
            }

            this.btnInsert = new Button
            {
                Text = "Inserir",
                Location = new Point(40, 230),
                Size = new Size(100, 30)
            };
            this.btnInsert.Click += new EventHandler(this.handleInsertClick);

            this.btnAlterar = new Button
            {
                Text = "Alterar",
                Location = new Point(150, 230),
                Size = new Size(100, 30)
            };
            this.btnAlterar.Click += new EventHandler(this.handleAlterarClick);

            this.btnExcluir = new Button
            {
                Text = "Excluir",
                Location = new Point(260, 230),
                Size = new Size(100, 30)
            };
            this.btnExcluir.Click += new EventHandler(this.handleExcluirClick);

            this.btnVoltar = new Button
            {
                Text = "Voltar",
                Location = new Point(370, 230),
                Size = new Size(100, 30)
            };
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClik);     

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVoltar);

                // Initialize the form.
            this.Controls.Add(listView);    
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = " Produto:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            ProdutoInsert menu = new ProdutoInsert();
           //#menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           Views.ProdutoUpdate menu = new Views.ProdutoUpdate();
            //menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            Views.ProdutoDelete menu = new Views.ProdutoDelete();
            //menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();       
        }  
    }           
}