using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    class HotelSQLConnection
    {
        public static SqlConnection SqlConnection = new SqlConnection("" +
            "Server=.;user=sa;pwd=123456;database=hotel");
        public static Login loginFrom;
        public static ShowGuest ShowGuestFrom;
    }
}
