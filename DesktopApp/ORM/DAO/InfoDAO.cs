using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class InfoDAO : AbstractDAO<Info>
    {
        public InfoDAO()
        {
            //11.2 - Výpis
            selectAllSql = "SELECT reservation_duration_days,  reservation_penalty_days," +
                            " borrowing_duration_days, before_closing_date_days, queues_per_user" +
                            " FROM Info";
            //11.1 - Aktualizace
            updateSql = "UPDATE Info SET reservation_duration_days = @1,  reservation_penalty_days = @2," +
                            " borrowing_duration_days = @3, before_closing_date_days = @4, queues_per_user = @5";
        }

        //11.2 - Výpis (v tabulce je pouze jeden záznam)
        public Info SelectFirst()
        {
            return SelectAll()[0];
        }

        protected override int FillInsert(Info obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.ReservationDurationDays);
            parameters.AddWithValue("@" + (++i), obj.ReservationPenaltyDays);
            parameters.AddWithValue("@" + (++i), obj.BorrowingDurationDays);
            parameters.AddWithValue("@" + (++i), obj.BeforeClosingDateDays);
            parameters.AddWithValue("@" + (++i), obj.QueuesPerUser);
            return i;
        }

        protected override Info LoadObject(SqlDataReader reader)
        {
            int i = -1;
            Info info = new Info
            {
                ReservationDurationDays = reader.GetInt32(++i),
                ReservationPenaltyDays = reader.GetInt32(++i),
                BorrowingDurationDays = reader.GetInt32(++i),
                BeforeClosingDateDays = reader.GetInt32(++i),
                QueuesPerUser = reader.GetInt32(++i),
            };

            return info;
        }
    }
}
