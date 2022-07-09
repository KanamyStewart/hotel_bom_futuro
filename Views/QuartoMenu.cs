using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;
using Models;
using Controllers;

namespace Views
{
    public class QuartoMenu : BaseForm
    {
        Form parent;
        FieldForm fieldPeriodoInicio;
        FieldForm fieldPeriodoFinal;
        FieldForm fieldStatus;
        ListView listView;
        ComboBox comboBox;
        ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        public QuartoMenu(AdminMenu parent) : base("Lista de Quartos", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            listView = new ListView();
            listView.Location = new Point(20, 250);
            listView.Size = new Size(450, 150);
            listView.View = View.Details;
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Quarto", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Numero", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Status", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;
            fieldPeriodoInicio = new FieldForm("Filtro: Inicio", 20, 40, 100, 50);
            fieldPeriodoFinal = new FieldForm("Final", 150, 40, 100, 50);
            fieldStatus = new FieldForm("Filtro: Status", 20, 120, 100, 50);
            //IEnumerable<Categoria> categorias = CategoriaController.GetCategorias();
            comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(20, 150);
            comboBox.Name = "Status";
            comboBox.Size = new System.Drawing.Size(245, 15);
            /*foreach (Categoria item in categorias)
            {
                comboBox.Items.Add(item.Id + " - " + item.Nome);
            }*/
            btnIncluir = new ButtonForm("Incluir", 100, 450, this.handleIncluir);
            btnAlterar = new ButtonForm("Alterar", 200, 450, this.handleAlterar);
            btnExcluir = new ButtonForm("Excluir", 300, 450, this.handleExcluir);
            btnVoltar = new ButtonForm("Voltar", 400, 450, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(fieldPeriodoInicio.lblField);
            this.Controls.Add(fieldPeriodoInicio.txtField);
            this.Controls.Add(fieldPeriodoFinal.lblField);
            this.Controls.Add(fieldPeriodoFinal.txtField);
            this.Controls.Add(fieldStatus.lblField);
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
            this.Controls.Add(comboBox);
        }
        public void LoadInfo()
        {
            IEnumerable<Quarto> quartos = QuartoController.GetQuartos();

            this.listView.Items.Clear();
            foreach (Quarto item in quartos)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Nome);
                lvItem.SubItems.Add(item.Numero);
                //lvItem.SubItems.Add(item.Status);

                this.listView.Items.Add(lvItem);
            }
        }

        private void handleIncluir(object sender, EventArgs e)
        {
            (new QuartoInsert(this)).Show();
            this.Hide();
        }
        private void handleAlterar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                (new QuartoUpdate(this)).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecione 1 item da lista");
            }
        }
        private void handleExcluir(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try
                {
                    QuartoController.ExcluirQuarto(
                        id
                    );
                    this.LoadInfo();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione 1 item da lista");
            }
        }
        private void handleVoltar(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }
    }
}