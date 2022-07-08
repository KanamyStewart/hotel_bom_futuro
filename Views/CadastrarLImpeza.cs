using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;
using Controllers;

namespace Views
{
    public class CadastrarLimpeza : BaseForm
    {
        CrudLimpeza parent;
        FieldForm fieldQuarto;
        FieldForm fieldFuncionario;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ComboBox comboBox;
        CheckedListBox checkedList;
        ListViewItem selectedItem;
        int id = 0;

        public CadastrarLimpeza(CrudLimpeza parent) : base("Cadastrar Limpeza", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            fieldQuarto = new FieldForm("Quarto", 80, 20, 180, 20);
            fieldFuncionario = new FieldForm("Funcionário", 80, 100, 180, 60);
            
            /*IEnumerable<QuartoController> quartos = QuartoController.GetQuartos();
            comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(80, 110);
            comboBox.Name = "Quarto";
            comboBox.Size = new System.Drawing.Size(245, 15);   
            foreach (QuartoController item in quartos)
            {
                comboBox.Items.Add(item.Id + " - " + item.Nome);
            }*/

            btnConfirmar = new ButtonForm("Confirmar", 60, 260, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            this.Controls.Add(checkedList);
            this.Controls.Add(comboBox);
            this.Controls.Add(fieldQuarto.lblField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                string comboBoxValue = this.comboBox.Text; // "1 - Nome"
                string[] destructComboBoxValue = comboBoxValue.Split('-'); // ["1 ", " Nome"];
                string idQuarto = destructComboBoxValue[0].Trim();// "1 " => "1"
            }
                
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void handleCancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.parent.Show();
                this.Close();
            }
        }

    }

}

