using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;

namespace Telas
{
    public class CadFuncionario : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblNome;
        Label lblFuncao;
        Label lblTelefone;
        
        TextBox txtNome;
        TextBox txtFuncao;
        TextBox txtTelefone;
        
        Button btnConfirmar;
        Button btnCancelar;

        public CadFuncionario()
        {

            this.lblNome = new Label();
            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new Point(130, 40);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(60, 60);
            this.txtNome.Size = new Size(180, 20);

            this.lblFuncao = new Label();
            this.lblFuncao.Text = "Função:";
            this.lblFuncao.Location = new Point(130, 90);

            this.txtFuncao = new TextBox();
            this.txtFuncao.Location = new Point(60, 115);
            this.txtFuncao.Size = new Size(180, 20);

            this.lblTelefone = new Label();
            this.lblTelefone.Text = "Telefone:";
            this.lblTelefone.Location = new Point(130, 140);

            this.txtTelefone = new TextBox();
            this.txtTelefone.Location = new Point(60, 170);
            this.txtTelefone.Size = new Size(180, 20);

            this.btnConfirmar = new ButtonField("Confirme", 100, 200, 100, 40);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancelar = new ButtonField("Cancela",100, 230,100, 40);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblFuncao);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtFuncao);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Cadastro de funcionário";
        }

        private void btnCancelarClick(object sender, EventArgs e)
           {
                this.Close();
           }

           public void btnConfirmarClick(object sender, EventArgs e)
        {
            try 
            {
            string message = "Seu funcionário foi cadastrado com sucesso!";
            string caption = " Enjoy! ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            UsuarioControl.InserirFuncionarios(this.txtNome.Text, this.txtFuncao.Text, this.txtTelefone.Text);
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }
            }catch(Exception){
            string message = "Os dados inseridos foram inválidos, repita o processo!";
            string caption = "Falha";
            MessageBox.Show(message, caption);
            }
        }
    }
}