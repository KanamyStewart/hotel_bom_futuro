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
// Main "ListaQuartos" code
namespace Views
{
    public class ListaQuartos : baseForm
    {
        Form parent;
        public ListView listView;
        ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        public ListaQuartos(form parent) : base("Lista de Quartos", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            /*
            listView = new ListView();
            listView.Location = new Point();
            listView.size = new size();
            listView.Columns.Add("Tipo", -2, HorizontalAlignment.Left);
			listView.Columns.Add("Número", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Status", -2, HorizontalAlignment.Right);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;
            */
            btnIncluir = new ButtonForm("Cadastrar",100,500, this.handleIncluir);
            btnAlterar = new ButtonForm("Editar",200,500, this.handleAlterar);
            btnExcluir = new ButtonForm("Excluir",300,500, this.handleExcluir);
            btnVoltar = new ButtonForm("Cancelar",400,500, this.handleVoltar);

            this.LoadInfo();
            //this.Controls.Add(listView);
            //Deixei o código estruturado para depois testar o tamanho certo para o layout da tela
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }
        public void LoadInfo()
        {
            IEnumerable<Quarto> quartos = QuartoController.GetQuartos();
            this.listView.Items.Clear();
            foreach (Quarto item in quartos)
            {
                ListViewItem lvItem = new ListViewItem(item.name.ToString());
                lvItem.SubItems.Add(tipo,numero,status);

                this.listView.Items.Add(lvItem);
            }
        }
        private void handleIncluir(object sender, EventArgs e)
        {
            (new InserirQuarto(this)).Show();
            this.Hide();
        }
         private void handleAlterar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                (new AlterarQuarto(this)).Show();
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
                    QuartoController.ExcluirQuarto(id);
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