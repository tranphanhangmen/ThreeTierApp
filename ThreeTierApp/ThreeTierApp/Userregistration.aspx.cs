using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussinesslogic;
using BussinessObject;

namespace ThreeTierApp
{
    public partial class Userregistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var userBO = new UserBO();

            userBO.Name = Request.Params["txtname"];
            userBO.address = Request.Params["txAddress"];
            userBO.EmailID = Request.Params["txtEmailid"];
            userBO.Mobilenumber = Request.Params["txtmobile"];
            userBO.country = Request.Params["txtcountry"];
            userBO.sex = Request.Params["txtsex"];
            userBO.dbo = Request.Params["txtdbo"];


            var userBL = new UserBL();
            userBL.SaveUserregisrationBL(userBO);
        }
        override protected void OnInit(EventArgs e)
        {
            BtnSave.Click += new EventHandler(BtnSave_Click);

            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }

        protected void txtcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = txtcountry.SelectedValue.ToString();
        }
    }
}