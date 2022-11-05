using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace SERVIS_WEB_PROYECTO.DataBase
{
    public class dbAcceso
    {
        public static SqlConnection ConectaBD()
        {
            SqlConnection cn = new SqlConnection(
    ConfigurationManager.ConnectionStrings["CadenaBD"].ConnectionString);
            return cn;
        }
    }
}