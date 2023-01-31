using DesktopApp.ORM;
using DesktopApp.ORM.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    public partial class GenreForm : DesktopApp.Forms.FormWithMenu
    {
        private Genre selectedGenre;
        private GenreDAO genreDAO;


        private string NoGenreSelected { get { return "Není vybraný žádný záznam!"; } }
        private string NameIsEmpty { get { return "Název nesmí být prázdný!"; } }

        public GenreForm()
        {
            InitializeComponent();
            genreDAO = new GenreDAO();        
            genresDGW.AutoGenerateColumns = false;
            LoadGenres();
        }

        public void LoadGenres()
        {
            Collection<Genre> genres = genreDAO.SelectAll();
            genresDGW.DataSource = genres;
            selectedGenre = null;
        }

        private void genresDGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedGenre = (Genre)genresDGW.Rows[e.RowIndex].DataBoundItem;
                nameTB.Text = selectedGenre.Name;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(selectedGenre != null)
            {
                string name = nameTB.Text;
                if (name.Length == 0)
                {
                    MessageBox.Show(NameIsEmpty);
                }
                else
                {
                    selectedGenre.Name = name;
                    genreDAO.Update(selectedGenre);
                    LoadGenres();
                }
                
            }
            else
            {
               MessageBox.Show(NoGenreSelected);
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            if(name.Length == 0 )
            {
                MessageBox.Show(NameIsEmpty);
            }
            else
            {
                Genre genre = new Genre { Name = name };
                genreDAO.Insert(genre);
                LoadGenres();
            }
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in genresDGW.SelectedRows)
            {
                Genre genre = (Genre)row.DataBoundItem;
                genreDAO.Delete(genre);
            }
            LoadGenres();
        }
    }
}
