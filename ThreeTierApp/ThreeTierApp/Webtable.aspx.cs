using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ThreeTierApp
{
    public partial class Webtable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var con = ConfigurationManager.ConnectionStrings["connString"].ToString();           
            using (SqlConnection SqlCon = new SqlConnection(con))
            {
                SqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Userinfo", SqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
        }
    }
}