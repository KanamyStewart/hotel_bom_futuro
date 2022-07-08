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
    public class CadastrarFormaPagamento : BaseForm
    {
        CrudFormasPagamento parent;
        FieldForm fieldNome;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public CadastrarFormaPagamento(CrudFormasPagamento parent) : base("Cadastrar Formas de Pagamento", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Tipo", 80, 20, 180, 20);
                        
            btnConfirmar = new ButtonForm("Confirmar", 60, 260, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                FormaPagamentoController.InserirFormaPagamento(
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
