using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.DataAccess
{
    public class LabDBAccess
    {
        protected SqlConnection con;
        protected void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constring);
        }
    }
}
