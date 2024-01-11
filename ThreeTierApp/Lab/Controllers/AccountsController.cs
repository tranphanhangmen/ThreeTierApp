using Bussinesslogic;
using Lab.Models;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Lab.Controllers
{
    public class AccountsController : Controller
    {
        private IAccountBL accountBL;
        public AccountsController()
        {
            accountBL = new AccountBL();
        }

        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        int pageSize = 3;
        public ActionResult AccountList(int? page=1)
        {
            ModelState.Clear();
            int pageNumber = page ?? 1;
            var result = accountBL.GetAccount(pageNumber, pageSize, out int totalRow);

            var resultModel = result.Select(s => new AccountModel {
               Email = s.Email, Id = s.Id
               , NickName = s.NickName, Mobile = s.Mobile, DOB = s.DOB, Sex = s.Sex, Status = s.Status
            }).ToList();
            var paging = new StaticPagedList<AccountModel>(resultModel, pageNumber, pageSize, totalRow);

            var accountList = new AccountListModel()
            {
                ListofModel = resultModel,
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
                    var result = accountBL.AddAccount(smodel);
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
                if (accountBL.DeleteAccount(id))
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
                if (accountBL.UpdateStatus(id))
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
                var dt = accountBL.GetAccountByEmail(ac.Email);
                if (dt.Password == accountBL.CreateMD5(ac.Password))
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
            var s = accountBL.GetAccountByEmail(Session["uid"].ToString());
            var accountModel = new AccountModel
            {
                Email = s.Email,
                Id = s.Id,
                NickName = s.NickName,
                Mobile = s.Mobile,
                DOB = s.DOB,
                Sex = s.Sex,
                Status = s.Status
            };
            return View(accountModel);
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
                    var error = accountBL.ChangePassword(Session["uid"].ToString(), ac.Password, ac.NewPassword);
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