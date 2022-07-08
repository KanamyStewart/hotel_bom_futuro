using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;
using Models;


namespace Views
{
    public class QuartoInsert : BaseForm
    {
        Form parent;
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblNome;
        TextBox textNome;
        Label lblNumero;
        TextBox textNumero;
        Label lblDescricao;
        TextBox textDescricao;
        Label lblValor;
        TextBox textValor;
        Button btnConfirm1;
        Button btnCancel1;
        PictureBox pbLogo;

        public QuartoInsert(QuartoMenu parent) : base("Alterar Quarto")
        {
            this.parent = parent;
            this.parent.Hide();
            this.ClientSize = new System.Drawing.Size(400, 600);

            this.lblNome = new Label
            {
                Text = " Nome",
                Location = new Point(10, 45)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 70),
                Size = new Size(360, 20)
            };

            this.lblNumero = new Label
            {
                Text = " Numero",
                Location = new Point(10, 95)
            };

            textNumero = new TextBox
            {
                Location = new Point(10, 120),
                Size = new Size(360, 20)
            };

            this.lblDescricao = new Label
            {
                Text = " Descrição",
                Location = new Point(10, 145)
            };

            textDescricao = new TextBox
            {
                Location = new Point(10, 170),
                Size = new Size(360, 20)
            };

            this.lblValor = new Label
            {
                Text = " Valor",
                Location = new Point(10, 195)
            };

            textValor = new TextBox
            {
                Location = new Point(10, 220),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 100, 500, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 200, 500, this.handleCancelClick);

            this.pbLogo = new PictureBox();
            this.pbLogo.Size = new Size(250, 250);
            this.pbLogo.Location = new Point(60, 250);
            this.pbLogo.ClientSize = new Size(250, 250);
            this.pbLogo.Load("quartocasal.jpg");
            this.pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pbLogo);


            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.textNumero);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.textDescricao);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.textValor);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);


        }

        private void handleConfirmClick(object sender, EventArgs e)
        {
            try
            {
                double Valor;
                try
                {
                    Valor = double.Parse(textValor.Text);
                }
                catch
                {
                    throw new Exception("Valor inválido.");
                }

                QuartoController.InserirQuarto(
                     textNome.Text,
                     textNumero.Text,
                     textDescricao.Text,
                     Valor
                 );

                MessageBox.Show("Dados alterados com sucesso.");
                //Views.ProdutoMenu menu = new Views.ProdutoMenu();
                //this.Close();

            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Não foi possível inserir os dados. {err.Message}");
            }
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            //Views.Menu menu = new Views.Menu();
            //this.Close();
        }
    }
}