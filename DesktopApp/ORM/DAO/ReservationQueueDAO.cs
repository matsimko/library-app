using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class ReservationQueueDAO : AbstractDAO<ReservationQueue>
    {
        string selectForUserSql;

        public ReservationQueueDAO()
        {
            //8.4 - Seznam rezervací - jen od aktuálně přihlášeného uživatele, včetně informace o odpovídajících kopiích
            selectForUserSql = "SELECT user_id, book_copy_id, dbo.bookCopyInfo(book_copy_id), queue_position, end_date" +
                                " FROM Reservation_queue";

        }
        protected override int FillInsert(ReservationQueue obj, SqlParameterCollection parameters)
        {
            throw new NotSupportedException();
        }

        protected override ReservationQueue LoadObject(SqlDataReader reader)
        {
            int i = -1;
            ReservationQueue reservationQueue = new ReservationQueue()
            {
                Key = new Key(new[] { reader.GetInt32(++i), reader.GetInt32(++i) }),
                BookCopyInfo = reader.GetString(++i),
                QueuePosition = reader.GetInt32(++i)
            };
            if (!reader.IsDBNull(++i))
            {
                reservationQueue.EndDate = reader.GetDateTime(i);
            }

            return reservationQueue;
        }

        //8.4 - Seznam rezervací - jen od aktuálně přihlášeného uživatele, včetně informace o odpovídajících kopiích
        public Collection<ReservationQueue> SelectForUser(int userId)
        {
            object[] fields = { userId };
            return CustomSelect(selectForUserSql, fields);
        }

        //8.1 - Přidání do fronty rezervací pro kopii
        public int AddToQueue(int userId, int bookCopyId)
        {
            string[] paramNames = { "user_id", "book_copy_id" };
            object[] paramValues = { userId, bookCopyId};
            
            return ExecuteStoredProcedure("addToQueue", paramNames, paramValues);
        }

        //8.2 - Kontrola rezervací
        public int CheckReservations()
        {
            return ExecuteStoredProcedure("checkReservations", new string[] { }, new object[] { });
        }

        //8.3 - Zrušení rezervace
        public int CancelReservation(int userId, int bookCopyId)
        {
            string[] paramNames = { "user_id", "book_copy_id" };
            object[] paramValues = { userId, bookCopyId };

            return ExecuteStoredProcedure("cancelReservation", paramNames, paramValues);
        }
    }
}
