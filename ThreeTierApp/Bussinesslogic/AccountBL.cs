using BussinessObject;
using Lab.DataAccess;
using System;
using System.Collections.Generic;

namespace Bussinesslogic
{
    public interface IAccountBL
    {
        DBResult AddAccount(Account smodel);

        List<Account> GetAccount(int pageNo, int pageSize, out int totalRow);

        bool DeleteAccount(int id);

        bool UpdateStatus(int id);

        Account GetAccountByEmail(string email);

        int ChangePassword(string email, string password, string newpw);

        string CreateMD5(string input);
    }

    public class AccountBL : IAccountBL
    {
        private DBAccount dbAccount;

        public AccountBL()
        {
            dbAccount = new DBAccount();
        }

        public DBResult AddAccount(Account model)
        {
            var password = model.Password;
            var pwdHash = CreateMD5(password);

            model.Password = pwdHash;
            return dbAccount.AddAccount(model);
        }

        public int ChangePassword(string email, string password, string newpw)
        {
            var passwordHash = CreateMD5(password);
            var newpwHash = CreateMD5(newpw);

            return dbAccount.ChangePassword(email, passwordHash, newpwHash);
        }

        public bool DeleteAccount(int id)
        {
            return dbAccount.DeleteAccount(id);
        }

        public List<Account> GetAccount(int pageNo, int pageSize, out int totalRow)
        {
            return dbAccount.GetAccount(pageNo, pageSize, out totalRow);
        }

        public Account GetAccountByEmail(string email)
        {
            return dbAccount.GetAccountByEmail(email);
        }

        public bool UpdateStatus(int id)
        {
            return dbAccount.UpdateStatus(id);
        }


        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    }
}
