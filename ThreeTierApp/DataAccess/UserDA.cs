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
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        public int AddUserDetails(UserBO ObjBO) // passing Bussiness object Here  
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString()))
                {
                    /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
                    SqlCommand cmd = new SqlCommand("sprocUserinfoInsertUpdateSingleItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", ObjBO.Name);
                    cmd.Parameters.AddWithValue("@Address", ObjBO.address);
                    cmd.Parameters.AddWithValue("@EmailID", ObjBO.EmailID);
                    cmd.Parameters.AddWithValue("@Mobilenumber", ObjBO.Mobilenumber);
                    cmd.Parameters.AddWithValue("@country", ObjBO.country);
                    cmd.Parameters.AddWithValue("@sex", ObjBO.sex);
                    cmd.Parameters.AddWithValue("@dbo", ObjBO.dbo);
                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UserBO> GetUserList()
        {
            List<UserBO> listUser = new List<UserBO>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString()))
            {
                /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("sprocGetUserList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                var  reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                foreach(DataRow row in dt.Rows)
                {
                    var user = new UserBO(row["name"].ToString(), row["Address"].ToString(), row["emailid"].ToString());

                    //user.Name = row["name"].ToString();
                    //user.EmailID = row["emailid"].ToString();
                    user.Mobilenumber = row["Mobilenumber"].ToString();
                    //user.address = row["Address"].ToString();
                    user.country = row["country"].ToString();
                    user.sex = row["sex"].ToString();
                    user.dbo = row["dbo"].ToString();
                    listUser.Add(user);
                }
            }

            return listUser;
        }

    }
}
