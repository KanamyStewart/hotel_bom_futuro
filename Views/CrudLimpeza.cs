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
    public class CrudLimpeza : BaseForm
    {
        Form parent;
        public ListView listView;
        ButtonForm btnCadastrar;
        ButtonForm btnEditar;
        ButtonForm btnExcluir;
        ButtonForm btnCancelar;

        public CrudLimpeza(AdminMenu parent) : base("Lista de Limpeza", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();
            listView = new ListView();
            listView.Location = new Point(30, 20);
            listView.Size = new Size(280, 180);
            listView.View = View.Details;
            listView.Columns.Add("Numero", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Quarto", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Funcionário", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            btnCadastrar = new ButtonForm("Cadastrar", 50, 220, this.handleIncluir);
            btnEditar = new ButtonForm("Editar", 50, 260, this.handleAlterar);
            btnExcluir = new ButtonForm("Excluir", 200, 220, this.handleExcluir);
            btnCancelar = new ButtonForm("Voltar", 200, 260, this.handleCancel);

            //this.LoadInfo();
            this.Controls.Add(listView);
            this.Controls.Add(btnCadastrar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnCancelar);

        }

        /*public void LoadInfo()
        {
            IEnumerable<LimpezaController> limpezas = LimpezaController.SelecionarLimpezas();

            this.listView.Items.Clear();
            foreach (LimpezaController item in limpezas)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Numero);
                lvItem.SubItems.Add(item.Quarto);                
                lvItem.SubItems.Add(item.Funcionario);
                
                this.listView.Items.Add(lvItem);
            }
        }*/

        private void handleIncluir(object sender, EventArgs e)
        {
            //(new CadastrarLimpeza(this)).Show();
            //this.Hide();

        }
        private void handleAlterar(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {
                //(new EditarLimpeza(this)).Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Selecione ao menos um item", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void handleExcluir(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(this.listView.SelectedItems[0].Text);
                DialogResult result = MessageBox.Show(
                    $"Deseja excluir o item {id}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    LimpezaController.DeletarLimpeza(id);
                    //this.LoadInfo();
                }
            }
            else
            {
                MessageBox.Show("Selecione ao menos um item", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }
    }
}
