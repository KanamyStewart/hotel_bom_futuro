// =============================================================
// System libs.
using System.Windows.Forms;
// =============================================================
namespace Views.Lib {
    public enum SizeScreen
    {
        Tiny,
        Small,
        Medium,
        Large,
        Different
    }


    public class BaseForm : Form
    {
        public BaseForm(
            string Title,
            SizeScreen size
        )
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            switch (size)
            {
                case SizeScreen.Large:
                    this.ClientSize = new System.Drawing.Size(900, 900);
                    break;
                case SizeScreen.Medium:
                    this.ClientSize = new System.Drawing.Size(600, 600);
                    break;
                case SizeScreen.Small:
                    this.ClientSize = new System.Drawing.Size(300, 300);
                    break;
                case SizeScreen.Tiny:
                    this.ClientSize = new System.Drawing.Size(300, 200);
                    break;
                default:
                    this.ClientSize = new System.Drawing.Size(300, 400);
                    break;
            }
            this.Text = Title;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
    
}
// =============================================================