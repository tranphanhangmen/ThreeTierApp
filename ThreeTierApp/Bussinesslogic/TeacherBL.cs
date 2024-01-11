using BussinessObject;
using System;
using System.Collections.Generic;

namespace Bussinesslogic
{
    public interface ITeacherBL
    {
        List<ClassName> GetClassList(int teacherId);
    }

    public class TeacherBL : AccountBL, ITeacherBL
    {
        public List<ClassName> GetClassList(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
