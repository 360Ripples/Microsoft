using StudentManagementVo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDao
{
    public interface IStudentDao
    {
        public void SaveStudent(StudentVo vo);
        public void FetchStudent(int id);
        
    }
}
