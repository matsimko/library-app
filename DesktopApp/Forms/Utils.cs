using DesktopApp.ORM;
using DesktopApp.ORM.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    class Utils
    {
        public static void comboboxKeyUp(object sender, KeyEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) &&
                combo.SelectedIndex >= 0)
            {
                if (combo.SelectionStart > 0)
                {
                    //combo.Text = combo.Text.Substring(0, combo.SelectionStart - 1);
                    combo.SelectionStart -= 1;
                    combo.SelectionLength = combo.Text.Length - combo.SelectionStart;
                }
                e.Handled = true;
            }
        }

        public static async Task LoadAuthorsByName(string name, ComboBox combo)
        {
            Cursor.Current = Cursors.WaitCursor;

            AuthorDAO authorDAO = new AuthorDAO();
            Task<Collection<Author>> task = Task.Run(() => authorDAO.SelectByName(name));
            Collection<Author> authors = await task;

            if (authors.Count > 0)
            {
                combo.DisplayMember = "FullName";
                Author selectedAuthor = authors[0];
                if (!selectedAuthor.FullName.StartsWith(name))
                {
                    selectedAuthor = new Author { FullName = name };
                    authors.Insert(0, selectedAuthor);
                }
                combo.DataSource = authors;
                combo.DroppedDown = true; //this has to be set before setting the selectionStart... 
                combo.SelectionStart = name.Length;
                combo.SelectionLength = selectedAuthor.FullName.Length - name.Length;

            }
            else
            {
                combo.DroppedDown = false;
            }

            Cursor.Current = Cursors.Default;

        }
    }
}
