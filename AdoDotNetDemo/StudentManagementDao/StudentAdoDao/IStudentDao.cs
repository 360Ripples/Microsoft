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
        public void FetchStudent(int Id);
        public void FetchAllStudent();
        public void FetchById();
        public void UpdateStudent();
        public void UpdateDataTableWithTable();
        public void UpdateWithDataTableWithTableUsingJoin();//error
        public void FetchAllStudentBySP();
        public void FetchDataFromTwoQuery();

    }
}
