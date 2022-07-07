using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace lib
{
    public delegate void HandleButton(object sender, EventArgs e);
    public class Campos : Form
    {
        public Campos()
        { }

        public class LabelField : Label
        {

            public LabelField(string Text, int X, int Y)
            {
                this.Text = Text;
                this.Location = new Point(X, Y);
            }

        }

        public class TextBoxField : TextBox
        {

            public TextBoxField(int X, int Y, int Height, int Width)
            {
                this.Location = new Point(X, Y);
                this.Size = new Size(Height, Width);
            }
        }

        public class TextBoxPass : TextBoxField
        {
            public TextBoxPass(int X, int Y, int Height, int Width)
                : base(X, Y, Height, Width)
            {
                this.PasswordChar = '*';
            }
        }

        public class Field
        {
            public LabelField label;
            public TextBoxField textField;

            public Field(
                Control.ControlCollection Ref,
                string Text,
                int Y,
                bool isCenterTitle = false,
                bool isPass = false
            )
            {
                const int _MarginLabel = 35;
                const int _Height = 280;
                const int _Width = 30;

                this.label = new LabelField(Text, isCenterTitle ? 120 : 10, Y);
                if (!isPass)
                {
                    this.textField = new TextBoxField(10, Y + _MarginLabel, _Height, _Width);
                }
                else
                {
                    this.textField = new TextBoxPass(10, Y + _MarginLabel, _Height, _Width);
                }

                Ref.Add(label);
                Ref.Add(textField);
            }
        }

        public class ButtonForm : Button
        {
            public ButtonForm(
                Control.ControlCollection Ref,
                string Text,
                int X,
                int Y,
                HandleButton handleAction
            )
            {
                this.Text = Text;
                this.Location = new Point(X, Y);
                this.Size = new Size(80, 30);
                this.Click += new EventHandler(handleAction);
                Ref.Add(this);
            }
        }

        public class BaseForm : Form
        {
            public BaseForm(string Title)
            {
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(300, 300);
                this.Text = Title;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        public class ButtonField : Button
        {
            public ButtonField(string Text, int x, int y, int Z, int W)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
                this.BackColor = Color.White;
            }
        }

        public class ComboBoxField : ComboBox
        {
            public ComboBoxField(int x, int y, int z, int w)
            {
                this.Location = new Point(x, y);
                this.Size = new Size(z, w);
            }
        }

        public class CheckedListBoxField : CheckedListBox
        {
            public CheckedListBoxField(int x, int y, int z, int w)
            {
                this.Location = new Point(x, y);
                this.Size = new Size(z, w);
            }
        }

    }
}