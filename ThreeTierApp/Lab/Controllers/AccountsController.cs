using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.Models;
using PagedList;

namespace Lab.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        int pageSize = 3;
        public ActionResult AccountList(int? page=1)
        {
            DBAccount db = new DBAccount();
            ModelState.Clear();
            int totalRow = 0;
            int pageNumber = page ?? 1;
            var result = db.GetAccount(pageNumber, pageSize, out totalRow);
            var paging = new StaticPagedList<Account>(result, pageNumber, pageSize, totalRow);

            var accountList = new AccountListModel()
            {
                ListofModel = result,
                Page = pageNumber,
                PagingMetaData = paging.GetMetaData()
            };

            return View(accountList);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBAccount sdb = new DBAccount();
                    var result = sdb.AddAccount(smodel);
                    if (result.ErrorCode == 0)
                    {
                        ViewBag.Message = "Account Details Added Successfully";
                        ModelState.Clear();
                        return RedirectToAction("AccountList");
                    }
                    else
                    {
                        if (result.ErrorCode == 1)
                        {
                            ModelState.AddModelError("NickName", result.ErrorMessage);
                        }
                        else if (result.ErrorCode == 2)
                        {
                            ModelState.AddModelError("Email", result.ErrorMessage);
                        }
                        else if (result.ErrorCode == 3)
                        {
                            ModelState.AddModelError("Email", result.ErrorMessage);
                        }
                        else
                        {
                            ModelState.AddModelError("Mobile", result.ErrorMessage);
                        }

                        return View();
                    }
                }
                else
                {
                    return View();
                }
           
            }
            catch
            {
                return RedirectToAction("AccountList");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                DBAccount ac = new DBAccount();
                if (ac.DeleteAccount(id))
                {
                    
                }
                return RedirectToAction("AccountList");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Approve(int id)
        {
            try
            {
                DBAccount sdb = new DBAccount();
                if (sdb.UpdateStatus(id))
                {
                }
                return RedirectToAction("AccountList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel ac)
        {
            try
            {
                DBAccount sdb = new DBAccount();
                var dt = sdb.GetAccountByEmail(ac.Email);
                if (dt.Password == ac.Password)
                {
                    Session["uid"] = ac.Email;
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ViewBag.Showmsg = "Invalid Email or Password!";
                    ModelState.Clear();
                }
            }
            catch (Exception ex )
            {
                ViewBag.Showmsg = ex.Message;
            }
            
            return View();
        }
        public ActionResult Welcome()
        {
            DBAccount sdb = new DBAccount();
            var ck = sdb.GetAccountByEmail(Session["uid"].ToString());
            return View(ck);
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel ac)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBAccount sdb = new DBAccount();
                    var error = sdb.ChangePassword(Session["uid"].ToString(), ac.Password, ac.NewPassword);
                    if (error > 0)
                    {
                        ModelState.AddModelError("Password", "Invalid old password");
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Welcome");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }

    }
}