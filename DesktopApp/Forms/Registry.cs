using DesktopApp.ORM;
using DesktopApp.ORM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    class Registry
    {
        private BooksForm booksForm;
        private BorrowingsForm borrowingsForm;
        private GenreForm genreForm;
        public BooksForm BooksForm
        {
            get
            {
                if(booksForm == null)
                {
                    booksForm = new BooksForm();
                }
                return booksForm;
            }
        }
        public BorrowingsForm BorrowingsForm
        {
            get
            {
                if (borrowingsForm == null)
                {
                    borrowingsForm = new BorrowingsForm();
                }
                return borrowingsForm;
            }
        }

        private Registry()
        {

        }

        private static Registry instance;
        public static Registry getInstance()
        {
            if (instance == null)
            {
                instance = new Registry();
            }
            return instance;
        }


        //hardcoded user
        private User user;
        public User User
        {
            get
            {
                if (user == null)
                {
                    UserDAO userDAO = new UserDAO();
                    user = userDAO.Select(new Key(1));
                }
                return user;
            }
        }

        public GenreForm GenreForm
        {
            get
            {
                if (genreForm == null)
                {
                    genreForm = new GenreForm();
                }
                return genreForm;
            }
        }
    }
}
