using DesktopApp.ORM;
using DesktopApp.ORM.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    public partial class SelectGenresForm : Form
    {
        public SelectGenresForm()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            GenreDAO genreDAO = new GenreDAO();
            Collection<Genre> genres = genreDAO.SelectAll();
            foreach(Genre genre in genres)
            {
                genresLB.Items.Add(genre);
            }
            ((ListBox)genresLB).DisplayMember = "Name";
            Cursor.Current = Cursors.Default;
        }

        private void SelectGenresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        internal Collection<int> getSelectedGenres()
        {
            Collection<int> result = new Collection<int>();
            foreach(Genre genre in genresLB.CheckedItems)
            {
                result.Add(genre.Key.Id);
            }
            return result;
        }
    }
}
