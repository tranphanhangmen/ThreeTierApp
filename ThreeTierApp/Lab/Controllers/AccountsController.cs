using Bussinesslogic;
using BussinessObject;
using Lab.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        int pageSize = 10;
        //public ActionResult AccountList(int? page = 1)
        //{
        //    ModelState.Clear();
        //    int pageNumber = page ?? 1;
        //    var result = accountBL.GetAccount(pageNumber, pageSize, out int totalRow);

        //    var resultModel = result.Select(s => new AccountModel
        //    {
        //        Email = s.Email,
        //        Id = s.Id
        //       ,
        //        NickName = s.NickName,
        //        Mobile = s.Mobile,
        //        DOB = s.DOB,
        //        Sex = s.Sex,
        //        Status = s.Status,
        //        Role = s.Role
        //    }).ToList();
        //    var paging = new StaticPagedList<AccountModel>(resultModel, pageNumber, pageSize, totalRow);

        //    var accountList = new AccountListModel()
        //    {
        //        ListofModel = resultModel,
        //        Page = pageNumber,
        //        PagingMetaData = paging.GetMetaData()
        //    };

        //    return View(accountList);
        //}


        public ActionResult AccountList(int? page = 1)
        {

            int pageNumber = page ?? 1;
            var result = accountBL.GetAccount(pageNumber, pageSize, out int totalRow);
            var accountList = new AccountListModel(){};
            return View(accountList);
        }
        public JsonResult ApiAccountList(int? page = 1)
        {
            int pageNumber = page ?? 1;


            // Update this method to return the total number of records
            var result = accountBL.GetAccount(pageNumber, pageSize, out int totalRow);

            // Calculate total pages
            int totalPages = (int)Math.Ceiling((double)totalRow / pageSize);

            return Json(new { data = result, totalPages }, JsonRequestBehavior.AllowGet);
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
                //if (dt.Password == accountBL.CreateMD5(ac.Password))
                if (dt.Password != null)
                {
                    ac.Role = dt.Role;
                    Session["login"] = ac;
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ViewBag.Showmsg = "Invalid Email or Password!";
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Showmsg = ex.Message;
            }

            return View();
        }
        public ActionResult Welcome()
        {
            var login = HttpContext.Session["login"] as LoginModel;

            var s = accountBL.GetAccountByEmail(login.Email);
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

        [AuthorizeDemo(Roles: "admin,teacher")]
        public ActionResult StudentList(string search1, string search2, string search3, int? page = 1)
        {
            ModelState.Clear();
            int pageNumber = page ?? 1;
            var result = accountBL.StudentList(pageNumber, pageSize, out int totalRow, search1, search2, search3);

            var resultModel = result.Select(s => new StudentModel
            {
                Email = s.Email,
                Id = s.Id,
                NickName = s.NickName,
                Mobile = s.Mobile,
                Name = s.Name
            }).ToList();
            var paging = new StaticPagedList<StudentModel>(resultModel, pageNumber, pageSize, totalRow);

            var studentList = new StudentListModel()
            {
                ListofModel = resultModel,
                Page = pageNumber,
                PagingMetaData = paging.GetMetaData(),
                search2 = "",
                classCate = accountBL.GetClassCate(),
                search3 = "",
                ClassName = accountBL.GetClassName()

            };

            return View(studentList);
        }

        [AuthorizeDemo(Roles:"admin")]
        public ActionResult TeacherList(int? page = 1)
        {
            ModelState.Clear();
            int pageNumber = page ?? 1;
            var result = accountBL.TeacherList(pageNumber, pageSize, out int totalRow);

            var resultModel = result.Select(s => new TeacherModel
            {
                Email = s.Email,
                Id = s.Id,
                NickName = s.NickName,
                Mobile = s.Mobile,
                Name = s.Name
            }).ToList();
            var paging = new StaticPagedList<TeacherModel>(resultModel, pageNumber, pageSize, totalRow);

            var teacherList = new TeacherListModel()
            {
                ListofModel = resultModel,
                Page = pageNumber,
                PagingMetaData = paging.GetMetaData()
            };

            return View(teacherList);
        }

        public JsonResult ApiStudentList(string search1, string search2, string search3, int? page = 1)
        {
            int pageNumber = page ?? 1;


            // Update this method to return the total number of records
            var result = accountBL.StudentList(pageNumber, pageSize, out int totalRow, search1, search2, search3);

            // Calculate total pages
            int totalPages = (int)Math.Ceiling((double)totalRow / pageSize);

            return Json(new { data = result, totalPages }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult StudentList1(string search1, string search2, string search3, int? page = 1)
        {
            
            int pageNumber = page ?? 1;
            var result = accountBL.StudentList(pageNumber, pageSize, out int totalRow, search1, search2, search3);

           
            var studentList = new StudentListModel()
            {
                
                search2 = "",
                classCate = accountBL.GetClassCate(),
                search3 = "",
                ClassName = accountBL.GetClassName()

            };

            return View(studentList);
        }
        
    }   
}