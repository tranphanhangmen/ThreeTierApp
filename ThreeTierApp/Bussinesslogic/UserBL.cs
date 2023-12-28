using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess; // for acessing DataAccess class  
using BussinessObject; // for acessing bussiness object class
using System.Text.RegularExpressions;

namespace Bussinesslogic
{
    public class UserBL
    {
        public int SaveUserregisrationBL(UserBO objUserBL) // passing Bussiness object Here  
        {
            try
            {
                // check valid UserBO
                int checkResult = objUserBL.CheckValidation();

                //if (this.CheckValidUserBO(objUserBL)== true)
                if (checkResult == 0)
                {
                    UserDA objUserda = new UserDA(); // Creating object of Dataccess  
                    return objUserda.AddUserDetails(objUserBL); // calling Method of DataAccess  
                }
                else
                {
                    return checkResult;
                }
            }
            catch
            {
               throw;
            }

            return 0;
        }
        public List<UserBO> GetUserregisrationBL()
        {
            List<UserBO> listBO = new List<UserBO>();

            var userDA = new UserDA();
            listBO = userDA.GetUserList();

            return listBO;
        }

        public bool CheckValidUserBO(UserBO userBO)
        {
            bool isValid = false;
            // check email
            string exprestion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            isValid = Regex.IsMatch(userBO.EmailID, exprestion);
            if(isValid==true)
            {
                // check mobile number
                string checkp = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";

                isValid = Regex.IsMatch(userBO.Mobilenumber, checkp);
            }           
            return isValid;
        }
    }
}
