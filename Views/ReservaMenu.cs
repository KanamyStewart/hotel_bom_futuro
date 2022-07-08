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
    public class ReservaMenu : BaseForm
    {
        Form parent;
        public ListView listView;
        readonly Button btnList;
        readonly Button btnReservar;
        readonly Button btnAlterar;
        readonly Button btnExcluir;
        readonly Button btnVoltar;
        internal static readonly object listQuarto;
        public ReservaMenu(Menu parent) : base(" Menu Reservas")
        {
            this.parent = parent;
            this.parent.Hide();

            ListView listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                Sorting = SortOrder.Ascending
            };

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader
            {
                Text = "Reservar",
                Width = -2
            };
            ColumnHeader list1 = new ColumnHeader
            {
                Text = "Nome",
                Width = -2
            };

            ColumnHeader list3 = new ColumnHeader
            {
                Text = "Número",
                Width = -2
            };

            ColumnHeader list4 = new ColumnHeader
            {
                Text = "Descrição",
                Width = -2
            };

            ColumnHeader list5 = new ColumnHeader
            {
                Text = "Diaria",
                Width = -2
            };
            
            // Add the column headers to listView1.
            listView.Columns.AddRange(new ColumnHeader[] 
                {list0, list1,list3,list4,list5});


            // Create items and add them to myListView.
			listView.View = View.Details;
			foreach( Quarto item in QuartoController.GetQuartos())
            {
                ListViewItem listQuarto= new ListViewItem(item.Id + "");
                listQuarto.SubItems.Add(item.Nome);
                listQuarto.SubItems.Add(item.Numero);
                listQuarto.SubItems.Add(item.Descricao);
                listQuarto.SubItems.Add(item.Valor + "");		
                listView.Items.AddRange(new ListViewItem[]{listQuarto});
            }

            this.btnList = new Button
            {
                Text = "Listar ",
                Location = new Point(40, 230),
                Size = new Size(100, 30)
            };
            this.btnList.Click += new EventHandler(this.handleListClick);

            this.btnReservar = new Button
            {
                Text = "Reservar",
                Location = new Point(40, 230),
                Size = new Size(100, 30)
            };
            this.btnReservar.Click += new EventHandler(this.handleReservarClick);

            this.btnAlterar = new Button
            {
                Text = "Alterar",
                Location = new Point(150, 230),
                Size = new Size(100, 30)
            };
            this.btnAlterar.Click += new EventHandler(this.handleAlterarClick);

            this.btnExcluir = new Button
            {
                Text = "Excluir",
                Location = new Point(260, 230),
                Size = new Size(100, 30)
            };
            this.btnExcluir.Click += new EventHandler(this.handleExcluirClick);

            this.btnVoltar = new Button
            {
                Text = "Voltar",
                Location = new Point(370, 230),
                Size = new Size(100, 30)
            };
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClik);     

            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVoltar);

                // Initialize the form.
            this.Controls.Add(listView);    
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = " Produto:";
            }

        private void handleListClick(object sender, EventArgs e)
        {
            //ReservaReservar menu = new ReservaReservar();
            //menu.ShowDialog();
        }    
        private void handleReservarClick(object sender, EventArgs e)
        {
            (new ReservaInsert(this)).Show();
            this.Hide();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           (new ReservaUpdate(this)).Show();
           this.Hide();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(this.listView.SelectedItems[0].Text);
                DialogResult result = MessageBox.Show(
                    $"Deseja excluir o item {id}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    ReservaController.ExcluirReserva(id);
                    //this.LoadInfo();
                }
            }
            else
            {
                MessageBox.Show("Selecione ao menos um item", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();       
        }  
    }           
}