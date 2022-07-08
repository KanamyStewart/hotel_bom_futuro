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
    public class EditarFormaPagamento : BaseForm
    {
        CrudFormasPagamento parent;
        FieldForm fieldNome;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ListViewItem selectedItem;
        int id = 0;

        public EditarFormaPagamento(CrudFormasPagamento parent) : base("Editar Formas de Pagamento", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            //FormaPagamentoController formaPagamento = FormaPagamentoController.GetFormaPagamentos(id);

            fieldNome = new FieldForm("Nome", 80, 20, 180, 20);
                        
            btnConfirmar = new ButtonForm("Confirmar", 60, 260, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            //this.fieldNome.txtField.Text = formaPagamento.Nome;
                        
            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                FormaPagamentoController.AtualizarFormaPagamento(
                    Convert.ToInt32(this.parent.listView.SelectedItems[0].Text),
                    this.fieldNome.txtField.Text
                                        
                );
                //this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
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
