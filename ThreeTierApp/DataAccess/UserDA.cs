using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql  
using System.Configuration; // for Using Connection From Web.config   
using BussinessObject;  // for acessing bussiness object class  

namespace DataAccess
{
    public class UserDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconstr"].ToString());
        public int AddUserDetails(UserBO ObjBO) // passing Bussiness object Here  
        {
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("Data Source=LAPTOP-R1Q9EQQN\\MSSQL2016;Initial Catalog=UserDB;User ID=sa;password=123open", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", ObjBO.Name);
                cmd.Parameters.AddWithValue("@Address", ObjBO.address);
                cmd.Parameters.AddWithValue("@EmailID", ObjBO.EmailID);
                cmd.Parameters.AddWithValue("@Mobilenumber", ObjBO.Mobilenumber);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return Result;
            }
            catch
            {
                throw;
            }
        }
    }
}
