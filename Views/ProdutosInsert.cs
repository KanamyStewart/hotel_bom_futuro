using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class ProdutosInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblValor;
        readonly TextBox texValor;
        readonly Button btnConfirm;
        readonly Button btnCancel;

        public SenhaInsert() : base("Inserir Senha")
        {
            this.ClientSize = new System.Drawing.Size(400,700);

            this.lblNome = new Label
            {
                Text = " Nome ",
                Location = new Point(120, 100),
                Size = new Size(240, 15)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblValor = new Label
            {
                Text = " Categoria",
                Location = new Point(120, 150)
            };


            texValor = new TextBox
            {
                Location = new Point(10, 225),
                Size = new Size(360, 20)
            };
        
            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.texValor);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            
            this.btnConfirm = new ButtonForm(this.Controls, "Confirmar", 80,600, this.handleConfirmClick);
            this.btnCancel = new ButtonForm(this.Controls, "Cancelar", 190, 600, this.handleCancelClick);
 
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            string[] comboValue = comboBoxCategoria.Text.Split(" ");
            int CategoriaId = int.Parse(comboValue[0]);
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    SenhaController.InserirSenha(
                        textNome.Text,
                        CategoriaId,
                        textUrl.Text,
                        textUsuario.Text,
                        textSenha.Text,
                        textProcedimento.Text

                        
                    );
                    MessageBox.Show("Dados inseridos com sucesso.");
                    SenhaMenu menu = new SenhaMenu();
                    this.Close();
                }


            }
            catch
            {
                MessageBox.Show("Não foi possível inserir os dados.");
            }              
        }


        private void handleCancelClick(object sender, EventArgs e)
        {
            Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  
    }       
}