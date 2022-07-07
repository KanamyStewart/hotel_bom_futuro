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
    public class ReservaList : BaseForm
    {
       
        readonly Button btnVoltar;
        internal static readonly object listReservas;
        public ReservaList() : base(" Menu Reservas")
        {
            ListView listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                Sorting = SortOrder.Ascending
            };

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader
            {
                Text = "Quarto",
                Width = -2
            };
            ColumnHeader list1 = new ColumnHeader
            {
                Text = "Hóspede",
                Width = -2
            };

            ColumnHeader list3 = new ColumnHeader
            {
                Text = "Check in",
                Width = -2
            };

            ColumnHeader list4 = new ColumnHeader
            {
                Text = "Check out",
                Width = -2
            };
            
            // Add the column headers to listView1.
            listView.Columns.AddRange(new ColumnHeader[] 
                {list0, list1,list3,list4});


            // Create items and add them to myListView.
			listView.View = View.Details;
			foreach( Reserva item in ReservaController.GetReservas())
            {
                ListViewItem listReserva= new ListViewItem(item.Id + "");
                listReserva.SubItems.Add(item.Quarto + "");
                listReserva.SubItems.Add(item.NomeHospede);
                listReserva.SubItems.Add(item.Checkin + "");
                listReserva.SubItems.Add(item.Checkout + "");		
                listView.Items.AddRange(new ListViewItem[]{listReserva});
            }

            this.btnVoltar = new Button
            {
                Text = "Voltar",
                Location = new Point(370, 230),
                Size = new Size(100, 30)
            };
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClik);     

            this.Controls.Add(this.btnVoltar);

                // Initialize the form.
            this.Controls.Add(listView);    
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = " Produto:";
            }

        private void handleVoltarClik(object sender, EventArgs e)
        {
            Menu  menu = new Menu();
            this.Close();       
        }  
    }           
}