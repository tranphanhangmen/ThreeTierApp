using BussinessObject;
using System;
using System.Collections.Generic;

namespace Bussinesslogic
{
    public interface ITeacherBL
    {
        List<Class> GetClassList(int teacherId);
    }

    public class TeacherBL : AccountBL, ITeacherBL
    {
        public List<Class> GetClassList(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
