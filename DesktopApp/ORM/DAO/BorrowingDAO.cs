using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class BorrowingDAO : AbstractDAO<Borrowing>
    {
        private string findAllSql;
        private string selectForUserSql;

        public BorrowingDAO()
        {
            //9.2 - Seznam výpůjček
            selectAllSql = " SELECT Borrowing.borrowing_id, Borrowing.user_id, \"User\".first_name, \"User\".last_name, \"User\".national_id_num," +
                            " dbo.bookCopyInfoV2(Book.title, Book_copy.release_year, Language.name, Author.first_name, Author.last_name) AS 'Kopie knihy'," +
                            " Borrowing.borrow_date, Borrowing.closing_date, Borrowing.return_date, Borrowing.book_copy_id" +
                            " FROM Borrowing " +
                            " JOIN Book_copy ON Borrowing.book_copy_id = Book_copy.book_copy_id" +
                            " JOIN Language ON Language.language_id = Book_copy.language_id" +
                            " JOIN Book ON Book_copy.book_id = Book.book_id" +
                            " JOIN Author ON Author.author_id = Book.author_id" +
                            " JOIN \"User\" ON Borrowing.user_id = \"User\".user_id";
            // - podle údajů uživatele a knihy a možnost redukce na aktivní výpujčky
            findAllSql = selectAllSql + " WHERE (@1 IS NULL OR \"User\".first_name = @2 ) AND" +
                                        " (@3 IS NULL OR \"User\".last_name = @4 )" +
                                        " AND (@5 IS NULL OR \"User\".national_id_num = @6 )" +
                                        " AND (@7 IS NULL OR Book.title_lower LIKE ('%' + LOWER(@8) + '%'))" +
                                        " AND (@9 IS NULL OR Book.author_id = @10 )" +
                                        " AND (@11 = 0 OR Borrowing.return_date IS NULL)";

            selectSql = selectAllSql + " WHERE Borrowing.borrowing_id = @1";

            // - aktivní výpujčky konkrétního uživatele
            selectForUserSql = " SELECT Borrowing.borrowing_id, Borrowing.user_id, " +
                            " dbo.bookCopyInfoV2(Book.title, Book_copy.release_year, Language.name, Author.first_name, Author.last_name) AS 'Kopie knihy'," +
                            " Borrowing.borrow_date, Borrowing.closing_date, Borrowing.return_date, Borrowing.book_copy_id" +
                            " FROM Borrowing " +
                            " JOIN Book_copy ON Borrowing.book_copy_id = Book_copy.book_copy_id" +
                            " JOIN Language ON Language.language_id = Book_copy.language_id" +
                            " JOIN Book ON Book_copy.book_id = Book.book_id" +
                            " JOIN Author ON Author.author_id = Book.author_id" +
                            " WHERE Borrowing.user_id = @1 AND Borrowing.return_date IS NULL";

            isIdentity = true;
        }

        protected override int FillInsert(Borrowing obj, SqlParameterCollection parameters)
        {
            throw new NotImplementedException();
        }

        protected override Borrowing LoadObject(SqlDataReader reader)
        {
            int i = -1;
            Borrowing borrowing = new Borrowing
            {
                Key = new Key(reader.GetInt32(++i)),
                User = new User
                {
                    Key = new Key(reader.GetInt32(++i)),
                    FirstName = reader.GetString(++i),
                    LastName = reader.GetString(++i),
                    NationalIdNum = reader.GetString(++i)
                },
                BookCopyInfo = reader.GetString(++i),
                BorrowDate = reader.GetDateTime(++i),
                ClosingDate = reader.GetDateTime(++i)
            };
            if(!reader.IsDBNull(++i))
            {
                borrowing.ReturnDate = reader.GetDateTime(i);
            }
            borrowing.BookCopyId = reader.GetInt32(++i);

            return borrowing;
        }

        private Borrowing LoadForUser(SqlDataReader reader)
        {
            int i = -1;
            Borrowing borrowing = new Borrowing
            {
                Key = new Key(reader.GetInt32(++i)),
                User = new User
                {
                    Key = new Key(reader.GetInt32(++i)),
                },
                BookCopyInfo = reader.GetString(++i),
                BorrowDate = reader.GetDateTime(++i),
                ClosingDate = reader.GetDateTime(++i)
            };
            if (!reader.IsDBNull(++i))
            {
                borrowing.ReturnDate = reader.GetDateTime(i);
            }
            borrowing.BookCopyId = reader.GetInt32(++i);

            return borrowing;
        }



        //9.2 - Seznam výpůjček - podle údajů uživatele a knihy a možnost redukce na aktivní výpujčky
        public Collection<Borrowing> FindAll(string title = null, int? authorId = null,
            string firstName = null, string lastName = null,
            string nationalIdNum = null, bool activeOnly = false)
        {
            object[] fields = {firstName, firstName, lastName, lastName, nationalIdNum,
                nationalIdNum, title, title, authorId, authorId, activeOnly ? 1 : 0};
            return CustomSelect(findAllSql, fields);
        }

        //9.2 - Seznam výpůjček - aktivní výpujčky konkrétního uživatele
        public Collection<Borrowing> SelectForUser(int userId)
        {
            object[] fields = {userId};
            return CustomSelect(selectForUserSql, fields, LoadForUser);
        }



        //9.1 - Nová výpůjčka
        public int NewBorrowing(int userId, int bookCopyId)
        {
            string[] paramNames = { "user_id", "book_copy_id" };
            object[] paramValues = { userId, bookCopyId };
            return ExecuteStoredProcedure("newBorrowing", paramNames, paramValues);

        }

        //9.3 - Kontrola výpůjček
        public int CheckBorrowings()
        {
            string[] paramNames = { };
            object[] paramValues = { };
            return ExecuteStoredProcedure("checkBorrowings", paramNames, paramValues);

        }

        //9.4 - Ukončení výpůjčky
        public int CloseBorrowing(int borrowingId)
        {
            string[] paramNames = { "borrowing_id" };
            object[] paramValues = { borrowingId };
            return ExecuteStoredProcedure("closeBorrowing", paramNames, paramValues);

        }
    }
}
