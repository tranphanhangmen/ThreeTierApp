using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using Bussinesslogic;

namespace ThreeTierApp
{
    public partial class UserList : System.Web.UI.Page
    {

        protected List<UserBO> listUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var userBL = new UserBL();
            listUser = userBL.GetUserregisrationBL();
        }
    }
}