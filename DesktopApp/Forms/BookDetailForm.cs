using DesktopApp.ORM;
using DesktopApp.ORM.DAO;
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
    public partial class BookDetailForm : Form
    {
        private Key key;

        public BookDetailForm()
        {
            InitializeComponent();
        }

        public BookDetailForm(Key key)
        {
            this.key = key;
            InitializeComponent();
            LoadCopy();
           
        }

        private void LoadCopy()
        {
            BookDAO bookDAO = new BookDAO();
            //Selected the detail of the book
            Book book = bookDAO.Select(key);
            titleLbl.Text = book.Title;
            yearLbl.Text = (book.ReleaseYear != null) ? book.ReleaseYear.ToString() : "";
            authorLbl.Text = book.AuthorFullName;
            langLbl.Text = book.Language.Name;
            descLbl.Text = (book.Description != null) ? book.Description : "";
            string genreText = "";
            foreach (Genre genre in book.Genres)
            {
                genreText += genre.Name + ", ";
            }
            if (genreText.Length >= 2)
            {
                genreText = genreText.Substring(0, genreText.Length - 2);
            }
            genreLbl.Text = genreText;

            copiesDGW.AutoGenerateColumns = false;
            copiesDGW.DataSource = book.BookCopies;
        }

        private void copiesDGW_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if the button was clicked
            if(e.ColumnIndex == 4)
            {
                BookCopy copy = (BookCopy)copiesDGW.Rows[e.RowIndex].DataBoundItem;
                ReservationQueueDAO queueDAO = new ReservationQueueDAO();
                User user = Registry.getInstance().User;
                //if the exception weren't caught in the stored procedure,
                // I would handle the errors here and notify the user accordingly... (using the message from the exception)
                queueDAO.AddToQueue(user.Key.Id, copy.Key.Id);

                LoadCopy();
            }
        }
    }
}
