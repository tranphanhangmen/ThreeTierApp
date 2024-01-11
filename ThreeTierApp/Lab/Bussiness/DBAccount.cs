using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab.Models
{
    public class DBAccount
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constring);
        }
        public DBResult AddAccount(Account smodel)
        {
            DBResult result = new DBResult();
            connection();
            SqlCommand cmd = new SqlCommand("AddAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NickName", smodel.NickName);
            cmd.Parameters.AddWithValue("@Email", smodel.Email);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);
            cmd.Parameters.AddWithValue("@Mobile", smodel.Mobile);
            cmd.Parameters.AddWithValue("@DOB", smodel.DOB);
            cmd.Parameters.AddWithValue("@Sex", smodel.Sex);
            cmd.Parameters.AddWithValue("@Status", smodel.Status);

            // output
            cmd.Parameters.Add("@Error", SqlDbType.VarChar, 100);
            cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@ErrorCode", 0).Direction = ParameterDirection.Output;

            con.Open();
            int i = cmd.ExecuteNonQuery();
            var error = cmd.Parameters["@Error"].Value.ToString();
            var errorCode = (int)cmd.Parameters["@ErrorCode"].Value;

            con.Close();

            if (errorCode == 0)
                result.ErrorCode = 0;
            else 
            {
                result.ErrorCode = errorCode;
                result.ErrorMessage = error;
            }           
            return result;



        }
        public List<Account> GetAccount(int pageNo, int pageSize, out int totalRow)
        {
            connection();
            List<Account> accountlist = new List<Account>();

            SqlCommand cmd = new SqlCommand("GetAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNo", pageNo);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);
            cmd.Parameters.Add("@TotalRows", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            int i = cmd.ExecuteNonQuery();
            sd.Fill(dt);

            totalRow = (int)cmd.Parameters["@TotalRows"].Value;
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                accountlist.Add(new Account{
                    AccountID = Convert.ToInt32(dr["AccountID"]),
                    NickName = dr["Nickname"].ToString(),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    DOB = dr.Field<DateTime?>("DOB"),
                    Sex = Convert.ToInt32(dr["Sex"]),
                    Status = dr["Status"].ToString(),
                });
                
            }
            return accountlist;
        }
        public bool DeleteAccount(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AccountID", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool UpdateStatus(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountID", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public Account GetAccountByEmail(string email)
        {
            connection();
            SqlCommand cmd = new SqlCommand("GetAccountByEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            int i = cmd.ExecuteNonQuery();
            sd.Fill(dt);
            
            DataRow dr = dt.Rows[0];


            var account = new Account
            {
                AccountID = Convert.ToInt32(dr["AccountID"]),
                NickName = dr["Nickname"].ToString(),
                Email = dr["Email"].ToString(),
                Password = dr["Password"].ToString(),
                Mobile = dr["Mobile"].ToString(),
                DOB = dr.Field<DateTime?>("DOB"),
                Sex = Convert.ToInt32(dr["Sex"]),
                Status = dr["Status"].ToString(),
            };


            return account;
        }
        public int ChangePassword(string email, string password, string newpw)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@NewPassword", newpw);
            cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            var error = (int)cmd.Parameters["@Error"].Value;
            return error;
        }
        

    }
}