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
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    public partial class BooksForm : DesktopApp.Forms.FormWithMenu
    {

        private bool loading = false;
        private SelectGenresForm genresForm = null;
        private Collection<Language> languages;

        public BooksForm()
        {
            InitializeComponent();
            booksDGW.AutoGenerateColumns = false;
            LanguageDAO languageDAO = new LanguageDAO();
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            languages = languageDAO.SelectAll();
            langCB.DataSource = languages;
            langCB.DisplayMember = "Name";
            langCB.SelectedIndex = -1;
            langCB.DroppedDown = false;
        }


        private async void authorCB_TextChanged(object sender, EventArgs e)
        {
            if (!loading && authorCB.SelectedIndex == -1)
            {
                string name = authorCB.Text;
                if (name.Length >= 3)
                {
                    loading = true;
                    await Utils.LoadAuthorsByName(name, authorCB);
                    loading = false;
                }
                else
                {
                    authorCB.DroppedDown = false;
                }
            }
        }

        private void authorCB_KeyDown(object sender, KeyEventArgs e)
        {
            Utils.comboboxKeyUp(sender, e);
        }

        private void selectGenresLbl_Click(object sender, EventArgs e)
        {
            if(genresForm == null)
            {
                genresForm = new SelectGenresForm();
            }
            genresForm.Show();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            authorCB.DataSource = null;
            authorCB.Text = "";
            langCB.Text = "";
            titleTB.Text = "";
            yearFromTB.Text = "";
            yearToTB.Text = "";
            if(genresForm != null)
            {
                genresForm.Dispose();
                genresForm = null;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Author author = (Author)authorCB.SelectedItem;
            if (author != null && author.Key == null)
            {
                return;
            }
            int? authorId = (author == null) ? (int?)null : author.Key.Id;
            Language language = (Language)langCB.SelectedItem;
            int? languageId = (language == null) ? (int?)null : language.Key.Id;
            string title = titleTB.Text.Length > 0 ? titleTB.Text : null;
            int tmp = 0;
            int? yearFrom = int.TryParse(yearFromTB.Text, out tmp) ? tmp : (int?)null;
            int? yearTo = int.TryParse(yearToTB.Text, out tmp) ? tmp : (int?)null;

            Collection<int> genreIds = null;
            if(genresForm != null)
            {
                genreIds = genresForm.getSelectedGenres();
            }


            BookDAO bookDAO = new BookDAO();
            Collection<Book> books = bookDAO.Search(title, authorId, languageId, genreIds, yearFrom, yearTo);
            booksDGW.DataSource = books;

            Cursor.Current = Cursors.Default;
        }

        private void langCB_TextUpdate(object sender, EventArgs e)
        {
        }

        private void langCB_KeyUp(object sender, KeyEventArgs e)
        {
            Utils.comboboxKeyUp(sender, e);
        }

        private void langCB_Enter(object sender, EventArgs e)
        {
        }

        private void langCB_TextChanged(object sender, EventArgs e)
        {
            if (langCB.SelectedIndex >= 0)
            {
                return;
            }

            string name = langCB.Text;
            if (name.Length == 0)
            {
                langCB.DataSource = languages;
                langCB.SelectedIndex = -1;
                return;
            }
            IEnumerable<Language> result = from l in languages
                                           where l.Name.StartsWith(name, true, null)
                                           orderby l.Name
                                           select l;

            if (result.Count() > 0)
            {
                langCB.DataSource = result.ToList();
                langCB.DroppedDown = true;
                Language lang = (Language)langCB.SelectedItem;
                langCB.SelectionStart = name.Length;
                langCB.SelectionLength = lang.Name.Length - name.Length;
            }
            else
            {
                langCB.DataSource = languages;
                langCB.DroppedDown = false;
            }
        }

        private void booksDGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Book book = (Book)booksDGW.Rows[e.RowIndex].DataBoundItem;
                BookDetailForm form = new BookDetailForm(book.Key);
                form.Show();
            }
        }
    }
}
