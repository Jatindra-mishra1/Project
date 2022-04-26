using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Exceptions
{
    public class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string Message):base(Message){}
    }
}
