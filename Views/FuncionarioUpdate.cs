using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
using Controllers;
using static lib.Campos;
using lib;


namespace Views
{
    public class FuncionarioUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);
        Form parent;
        Label lblId;
        TextBox textId;
        Label lblNome;
        TextBox textNome;
        Label lblFuncao;
        TextBox textFuncao;   
        Label lblTelefone;
        TextBox textTelefone;   
        Button btnConfirm1;
        Button btnCancel1;

        public FuncionarioUpdate(FuncionarioMenu parent) : base("Alterar Funcionário")
        {

            this.parent = parent;
            this.parent.Hide();

            this.lblId = new Label();
            this.lblId.Text = " Id: ";
            this.lblId.Location = new Point(120, 50);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,75);
            textId.Size = new Size(360,20);

            this.lblNome = new Label();
            this.lblNome.Text = " Nome: ";
            this.lblNome.Location = new Point(120, 100);
            this.lblNome.Size = new Size(240,15);

            textNome = new TextBox();
            textNome.Location = new Point(10,125);
            textNome.Size = new Size(360,20);

            this.lblFuncao = new Label();
            this.lblFuncao.Text = " Função: ";
            this.lblFuncao.Location = new Point(120, 100);
            this.lblFuncao.Size = new Size(240,15);

            textFuncao = new TextBox();
            textFuncao.Location = new Point(10,125);
            textFuncao.Size = new Size(360,20);

            this.lblTelefone = new Label();
            this.lblTelefone.Text = " Telefone: ";
            this.lblTelefone.Location = new Point(120, 200);

            textTelefone = new TextBox();
            textTelefone.Location = new Point(10,225);
            textTelefone.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,260, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 260, this.handleCancelClick);


            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.lblFuncao);
            this.Controls.Add(this.textFuncao);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {       
            try
            {
                int Id;
                try
                {
                    Id = int.Parse(textId.Text); 
                }
                catch
                {
                    throw new Exception("ID inválido.");
                }
                
                FuncionarioController.AtualizarFuncionario(
                    Id,
                    textNome.Text,
                    textFuncao.Text,
                    textTelefone.Text
                );

                MessageBox.Show("Dados alterados com sucesso.");
                this.parent.Show();
                this.Close();

            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Não foi possível inserir os dados. {err.Message}");
            }              
        }
        
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }  
    }       
}