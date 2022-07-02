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

namespace Views
{
    public class SenhaMenu : BaseForm
    {
        readonly Button btnInsert;
        readonly Button btnAlterar;
        readonly Button btnExcluir;
        readonly Button btnVoltar;
        internal static readonly object listSenha;

        public SenhaMenu() : base(" Produtos")
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
                Text = "Nome",
                Width = -2
            };
            ColumnHeader list1 = new ColumnHeader
            {
                Text = "Valor",
                Width = -2
            };
            
            // Add the column headers to listView1.
            listView.Columns.AddRange(new ColumnHeader[] 
                {list0, list1});


            // Create items and add them to myListView.
			listView.View = View.Details;
			foreach(Produtos item in ProdutosController.GetProdutos())
            {
                ListViewItem listProdutos= new ListViewItem(item.Id + "");
                listSenha.SubItems.Add(item.Nome);
                listSenha.SubItems.Add(item.Valor);		
                listView.Items.AddRange(new ListViewItem[]{listProdutos});
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
            this.Text = "´Produtos:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            Views.ProdutosInsert menu = new Views.ProdutosInsert();
            menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           Views.ProdutosUpdate menu = new Views.ProdutosUpdate();
            menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            Views.ProdutosDelete menu = new Views.ProdutosDelete();
            menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
            using (Views.AdminMenu menu = new Views.AdminMenu())
            {
            }
            this.Close();       
        }  
    }           
}