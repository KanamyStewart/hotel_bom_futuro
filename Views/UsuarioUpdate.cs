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
    public class UsuarioUpdate : BaseForm
    {
        Form parent;
        public delegate void HandleButton(object sender, EventArgs e);
        Label lblId;
        TextBox textId;
        Label lblLogin;
        TextBox textLogin;
        Label lblSenha;
        TextBox textSenha;   
        Button btnConfirm1;
        Button btnCancel1;

        public UsuarioUpdate(UsuarioMenu parent) : base("Alterar Usuarios")
        {
            this.ClientSize = new System.Drawing.Size(400,240);

            this.parent = parent;
            this.parent.Hide();
            
            this.lblId = new Label();
            this.lblId.Text = " Digite o Id  ";
            this.lblId.Location = new Point(120, 20);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,45);
            textId.Size = new Size(360,20);

            this.lblLogin = new Label();
            this.lblLogin.Text = " Digite o Login ";
            this.lblLogin.Location = new Point(120, 70);
            this.lblLogin.Size = new Size(240,15);

            textLogin = new TextBox();
            textLogin.Location = new Point(10,95);
            textLogin.Size = new Size(360,20);

            this.lblSenha = new Label();
            this.lblSenha.Text = " Senha";
            this.lblSenha.Location = new Point(120, 120);

            textSenha = new TextBox();
            textSenha.Location = new Point(10,145);
            textSenha.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,200, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 200, this.handleCancelClick);


            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.textSenha);
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
                
                UsuarioController.AlterarUsuario(
                    Id,
                    textLogin.Text,
                    textSenha.Text
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