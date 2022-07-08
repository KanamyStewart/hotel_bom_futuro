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
using Models;

namespace Views
{
    public class EditarLimpeza : BaseForm
    {
        CrudLimpeza parent;
        FieldForm fieldNumero;
        FieldForm fieldFuncionario;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ListViewItem selectedItem;
        int id = 0;

        public EditarLimpeza(CrudLimpeza parent) : base("Editar Limpeza", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            //LimpezaController limpeza = LimpezaController.GetLimpeza(id);

            fieldNumero = new FieldForm("Número", 80, 20, 180, 20);
            fieldFuncionario = new FieldForm("Funcionário", 80, 100, 180, 60);
            
            btnConfirmar = new ButtonForm("Confirmar", 60, 260, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            //this.fieldNumero.txtField.Text = limpeza.Numero;
            //this.fieldFuncionario.txtField.Text = limpeza.Funcionario;

            this.Controls.Add(fieldNumero.lblField);
            this.Controls.Add(fieldNumero.txtField);
            this.Controls.Add(fieldFuncionario.lblField);
            this.Controls.Add(fieldFuncionario.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            /*try
            {
                LimpezaController.AtualizarLimpeza(
                    Convert.ToInt32(this.parent.listView.SelectedItems[0].Text),
                    this.fieldNumero.txtField.Text,
                    this.fieldFuncionario.txtField.Text
                );
                //this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }*/

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
