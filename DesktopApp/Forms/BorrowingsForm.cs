using DesktopApp.ORM;
using DesktopApp.ORM.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    public partial class BorrowingsForm : DesktopApp.Forms.FormWithMenu
    {
        public BorrowingsForm()
        {
            InitializeComponent();
            borrowingsDGW.AutoGenerateColumns = false;
        }

        private bool loading = false;

        private void comboboxKeyUp(object sender, KeyEventArgs e)
        {
            Utils.comboboxKeyUp(sender, e);
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

        private void fnameCB_TextChanged(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            LoadComboBoxIfNeeded(fnameCB, userDAO.SelectFirstNames);
        }


        private void lnameCB_TextChanged(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            LoadComboBoxIfNeeded(lnameCB, userDAO.SelectLastNames);
        }

        private void nidCB_TextChanged(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            LoadComboBoxIfNeeded(nidCB, userDAO.SelectNationalIdNums);
        }


        private void showBorrowingsBtn_Click(object sender, EventArgs e)
        {
            LoadBorrowings();
        }

        private void LoadComboBoxIfNeeded(ComboBox combo, Func<string, Collection<string>> loader)
        {
            string input = combo.Text;
            //load only if not already loading and if nothing is selected (there is no point to load if something is already selected)
            if (!loading && combo.SelectedIndex == -1)
            {
                if (input.Length >= 3)
                {
                    LoadComboBox(combo, input, loader);
                }
                else
                {
                    combo.DroppedDown = false;
                }
            }
        }

        private async void LoadComboBox(ComboBox combo, string input, Func<string, Collection<string>> loader)
        {
            loading = true;
            Cursor.Current = Cursors.WaitCursor;

            Task<Collection<string>> task = Task.Run(() => loader(input));
            Collection<string> result = await task;

            if (result.Count > 0)
            {
                combo.DataSource = result;

                combo.DroppedDown = true;

                combo.SelectionStart = input.Length;
                combo.SelectionLength = result[0].Length - input.Length;
            }
            else
            {
                combo.DroppedDown = false;
            }

            Cursor.Current = Cursors.Default;
            loading = false;
        }

        private async void LoadBorrowings()
        {
            Cursor.Current = Cursors.WaitCursor;

            Author author = (Author)authorCB.SelectedItem;
            if (author != null && author.Key == null)
            {
                return;
            }
            int? authorId = (author == null) ? (int?)null : author.Key.Id;
            string fname = (string)fnameCB.SelectedItem;
            string lname = (string)lnameCB.SelectedItem;
            string nid = (string)nidCB.SelectedItem;
            string title = titleTB.Text.Length > 0 ? titleTB.Text : null;
            bool activeOnly = activeOnlyCheckB.Checked;

            BorrowingDAO borrowingDAO = new BorrowingDAO();
            Collection<Borrowing> borrowings = await Task.Run(() =>
                borrowingDAO.FindAll(title, authorId, fname, lname, nid, activeOnly));

            borrowingsDGW.DataSource = borrowings;
            Cursor.Current = Cursors.Default;
        }


        private void CloseBorrowingsBtn_Click(object sender, EventArgs e)
        {
            BorrowingDAO borrowingDAO = new BorrowingDAO();
            bool wasReturned = false;
            foreach(DataGridViewRow row in borrowingsDGW.SelectedRows)
            {
                Borrowing borrowing = (Borrowing)row.DataBoundItem;
                if(borrowing.ReturnDate == null)
                {
                    borrowingDAO.CloseBorrowing(borrowing.Key.Id);
                }
                else
                {
                    wasReturned = true;
                }
                
            }
            if (wasReturned)
            {
                MessageBox.Show("Některá z vybraných výpůjček již byla vrácena");
            }
            LoadBorrowings(); //this wouldn't be needed if CloseBorrowing returned the result...
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            authorCB.DataSource = null;
            authorCB.Text = "";
            titleTB.Text = "";
            fnameCB.DataSource = null;
            fnameCB.Text = "";
            lnameCB.DataSource = null;
            lnameCB.Text = "";
            nidCB.DataSource = null;
            nidCB.Text = "";
            activeOnlyCheckB.Checked = true;
        }

        private void newBorrowingBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
