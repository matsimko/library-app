using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    public partial class FormWithMenu : Form
    {

        public FormWithMenu()
        {
            InitializeComponent();
        }

        private void knihyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.GetType() != typeof(BooksForm)) //!(this is BooksForm)
            {
                SwapForm(Registry.getInstance().BooksForm);
            }
            
        }

        private void výpůjčkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.GetType() != typeof(BorrowingsForm))//(!(this is BorrowingsForm))
            {
                SwapForm(Registry.getInstance().BorrowingsForm);
            }
        }

        private void SwapForm(Form form)
        {
            this.Hide();

            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
        }

        private void FormWithMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void žánryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.GetType() != typeof(GenreForm))
            {
                SwapForm(Registry.getInstance().GenreForm);
            }
        }
    }
}
