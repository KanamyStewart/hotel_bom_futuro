using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class ReservaUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);
        Form parent;

        readonly Label lblId;
        readonly TextBox textId;
        readonly Label lblCheckin;
        readonly TextBox textCheckin;
        readonly Label lblCheckout;
        readonly TextBox textCheckout;
        readonly Label lblQuarto;
        CheckedListBox checkListBoxQuarto;
        readonly Label lblNomeHospede;
        readonly TextBox textNomeHospede;
        readonly Label lblDataNasc;
        readonly TextBox textDataNasc;
        readonly Label lblEmail;
        readonly TextBox textEmail;
        readonly Label lblTelefone;
        readonly TextBox textTelefone;
        readonly Label lblCpf;
        readonly TextBox textCpf;
        readonly Label lblNomeMae;
        readonly TextBox textNomeMae;
        readonly Label lblFormaPagamento;
        CheckedListBox checkListBoxFormaPagamento;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public ReservaUpdate(ReservaMenu parent) : base("Reserva")
        {
            this.parent = parent;
            this.parent.Hide();

            this.ClientSize = new System.Drawing.Size(400,700);

             this.lblId = new Label
            {
                Text = " Id para Alterar",
                Location = new Point(120, 01),
                Size = new Size(240, 15)
            };

            textId = new TextBox
            {
                Location = new Point(10, 20),
                Size = new Size(360, 20)
            };

            this.lblCheckin = new Label
            {
                Text = " Checkin ",
                Location = new Point(120, 40),
                Size = new Size(240, 15)
            };

            textCheckin = new TextBox
            {
                Location = new Point(10, 65),
                Size = new Size(360, 20)
            };

            this.lblCheckout = new Label
            {
                Text = " Checkout",
                Location = new Point(120, 85)
            };

            textCheckout = new TextBox
            {
                Location = new Point(10, 105),
                Size = new Size(360, 20)
            };

            this.lblQuarto = new Label
            {
                Text = " Quarto",
                Location = new Point(120, 125)
            };

            // Create and initialize a CheckBox.

            string[] quartoSuggestion = QuartoController
                .GetQuartos()
                .Select(Quarto => Quarto.ToSuggestion())
                .ToArray();
            this.checkListBoxQuarto = new CheckedListBox{
                Location = new Point(10, 145),
                Size = new Size(360, 100),
                
            };
            checkListBoxQuarto.Items.AddRange(quartoSuggestion);


            this.lblNomeHospede = new Label
            {
                Text = " Nome do Hospede",
                Location = new Point(120, 235),
                Size = new Size(360,20)
            };

            textNomeHospede = new TextBox
            {
                Location = new Point(10, 260),
                Size = new Size(360, 20)
            };

            this.lblDataNasc = new Label
            {
                Text = " Data de Nascimento",
                Location = new Point(120, 275),
                Size = new Size(360,20)
            };

            textDataNasc= new TextBox
            {
                Location = new Point(10, 300),
                Size = new Size(360, 20)
            };

            this.lblEmail = new Label
            {
                Text = " Email",
                Location = new Point(120, 325)
            };

            textEmail= new TextBox
            {
                Location = new Point(10, 350),
                Size = new Size(360, 20)
            };

            this.lblTelefone = new Label
            {
                Text = " Telefone",
                Location = new Point(120, 375)
            };

            textTelefone= new TextBox
            {
                Location = new Point(10, 400),
                Size = new Size(360, 20)
            };

            this.lblCpf = new Label
            {
                Text = " CPF",
                Location = new Point(120, 425)
            };

            textCpf= new TextBox
            {
                Location = new Point(10, 450),
                Size = new Size(360, 20)
            };

            this.lblNomeMae = new Label
            {
                Text = " Nome da M??e",
                Location = new Point(120, 475)
            };

            textNomeMae= new TextBox
            {
                Location = new Point(10, 500),
                Size = new Size(360, 20)
            };

             this.lblFormaPagamento = new Label
            {
                Text = " Forma de Pagamento",
                Location = new Point(120, 525),
                Size = new Size(360,20)
            };

            // Create and initialize a CheckBox.

            string[] formaPagamentoSuggestion = FormaPagamentoController
                .SelecionarFormaPagamentos()
                .Select(Quarto => Quarto.ToSuggestion())
                .ToArray();
            this.checkListBoxFormaPagamento = new CheckedListBox{
                Location = new Point(10, 550),
                Size = new Size(360, 100),
                
            };
            checkListBoxFormaPagamento.Items.AddRange(formaPagamentoSuggestion);


            this.btnConfirm1 = new Campos.ButtonForm(this.Controls,"Confirmar", 80,650, this.handleConfirmClick);
            this.btnCancel1 = new  Campos.ButtonForm(this.Controls,"Cancelar", 190, 650, this.handleCancelClick);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.lblCheckin);
            this.Controls.Add(this.textCheckin);
            this.Controls.Add(this.lblCheckout);
            this.Controls.Add(this.textCheckout);
            this.Controls.Add(this.lblQuarto);
            this.Controls.Add(this.checkListBoxQuarto);
            this.Controls.Add(this.lblNomeHospede);
            this.Controls.Add(this.textNomeHospede);
            this.Controls.Add(this.lblDataNasc);
            this.Controls.Add(this.textDataNasc);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.textCpf);
            this.Controls.Add(this.lblNomeMae);
            this.Controls.Add(this.textNomeMae);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.checkListBoxFormaPagamento);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            string[] comboValue = checkListBoxQuarto.Text.Split(" ");
            int QuartoId = int.Parse(comboValue[0]);
            DateTime CheckinId;
            DateTime Checkout;
            string[] comboValue1 = checkListBoxFormaPagamento.Text.Split(" ");
            int FormaPagamentoId = int.Parse(comboValue[0]);

            try
            {
               CheckinId = DateTime.Parse(textCheckin.Text);
            }
            catch
            {
                throw new Exception("Data inv??lida.");
            }

            try
            {
                Checkout = DateTime.Parse(textCheckout.Text); 
            }
            catch
            {
                throw new Exception("Valor inv??lido.");
            }

            try
            
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    ReservaController.InserirReserva(
                        CheckinId,
                        Checkout,
                        QuartoId,
                        textNomeHospede.Text,
                        textDataNasc.Text,
                        textEmail.Text,
                        textTelefone.Text,
                        textCpf.Text,
                        textNomeMae.Text,
                        FormaPagamentoId
                        
                    );
                }

                MessageBox.Show("Dados inseridos com sucesso.");
                   this.parent.Show();
                   this.Close();

            }
            catch
            {
                MessageBox.Show("N??o foi poss??vel inserir os dados.");
            }                      
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();     
        }  
          
    }       
}