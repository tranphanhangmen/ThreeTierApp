using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Models
{
    public class AccountListModel
    {
    
        public int? Page { get; set; }
        public List<Account> ListofModel { get; set; }
        public IPagedList PagingMetaData { get; set; }
    }
}