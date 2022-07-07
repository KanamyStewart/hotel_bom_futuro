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
    public class UsuarioDelete : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblId;
        TextBox textId;
        Button btnConfirm1;
        Button btnCancel1;

        public UsuarioDelete() : base("Deletar Usuario")
        {

            this.lblId = new Label();
            this.lblId.Text = " Id para Excluir ";
            this.lblId.Location = new Point(80, 100);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,125);
            textId.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 240, this.handleCancelClick);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
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

                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente Excluir esse item?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    UsuarioController.ExcluirUsuario(
                        Id
                        
                    );
                    MessageBox.Show("Dados excluidos com sucesso.");
                    UsuarioMenu menu = new UsuarioMenu();
                    this.Close();
                }  
            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Não foi possível inserir os dados. {err.Message}");
            }              
        }
        
        private void handleCancelClick(object sender, EventArgs e)
        {
            //using (Views.AdminMenu menu = new Views.AdminMenu())
            //{
            //}
           // this.Close(); 
        }  
    }       
}