// =============================================================
// System libs.
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Dynamic;
using System.Drawing;
using System.Linq;
using System.IO;
// =============================================================
// Repository related files.
using Controllers;
using Views.Lib;
using Models;
// =============================================================
// Main "CategoryCrud" code
namespace Views
{
    public class ListaPagamentos : baseform
    {
        Form parent;
        public ListView listView;
        ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        public ListaPagamentos(form parent) : base("Formas de Pagamentos", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            listView = new ListView();
			listView.Location = new Point(10, 20);
			listView.Size = new Size(580,350);
			listView.View = View.Details;
			listView.Columns.Add("Tipo", -2, HorizontalAlignment.Left);
			listView.Columns.Add("Descrição", -2, HorizontalAlignment.Right);
            listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;
            btnIncluir = new ButtonForm("Cadastrar",100,450, this.handleIncluir);
            btnAlterar = new ButtonForm("Editar",200,450, this.handleAlterar);
            btnExcluir = new ButtonForm("Excluir",300,450, this.handleExcluir);
            btnVoltar = new ButtonForm("Cancelar",400,450, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }
        public void LoadInfo()
        {
            IEnumerable<FormaPagamento> formapagamentos = FormaPagamentoController.SelecionarFormaPagamentos();

            this.listView.Items.Clear();
            foreach (Produto item in formapagamentos)
            {
                ListViewItem lvItem = new ListViewItem(item.name.ToString());
                lvItem.SubItems.Add(item.Preco);

                this.listView.Items.Add(lvItem);
            }
        }
        private void handleIncluir(object sender, EventArgs e)
        {
            (new InserirFormaPagamento(this)).Show();
            this.Hide();
        }
         private void handleAlterar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                (new AtualizarFormaPagamento(this)).Show();
                this.Hide();
            } 
            else
            {
                MessageBox.Show("Selecione 1 item da lista para alterar");
            }
        }
         private void handleExcluir(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView.SelectedItems[o];
                int id = ConvertBinder.ToInt32(item.Text);
                try
                {
                    FormaPagamentoController.DeletarFormaPagamento(id);
                    this.LoadInfo();
                }
                catch (Exception err)
                {
                     MessageBox.Show(ErrorEventArgs.Message);
                }
            } 
            else
            {
                MessageBox.Show("Selecione 1 item da lista para alterar");
            }
        }
        private void handleVoltar(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }
    }
}
// =============================================================