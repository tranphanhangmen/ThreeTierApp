using PagedList;
using System.Collections.Generic;

namespace Lab.Models
{
    public class StudentListModel
    {
        public int? Page { get; set; }
        public List<StudentModel> ListofModel { get; set; }
        public IPagedList PagingMetaData { get; set; }
        public string search1 { get; set; }
        public string search2 { get; set; }
        public List<string> classCate { get; set; }
        public string search3 { get; set; }
        public List<string> ClassName { get; set; }

    }
}