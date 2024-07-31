using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Models
{
    public class TeacherListModel
    {
        public int? Page { get; set; }
        public List<TeacherModel> ListofModel { get; set; }
        public IPagedList PagingMetaData { get; set; }
    }
}