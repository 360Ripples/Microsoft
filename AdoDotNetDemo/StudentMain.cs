using StudentManagementDao;
using StudentManagementVo;

public class StudentMain
{

    public static void Main(string[] args)
    {
        StudentVo vo = new StudentVo();
        vo.Id = 11;
        vo.Name = "Ravi";
        vo.Age = 21;
        IStudentDao studentDao = new StudentDao();
        //studentDao.SaveStudent(vo);
        studentDao.FetchStudent(2);
        //studentDao.FetchStudent(21);
        //studentDao.FetchAllStudent();
        //   studentDao.FetchById();
        //studentDao.UpdateDataTableWithTable();
        //studentDao.UpdateStudent();
        // studentDao.UpdateWithDataTableWithTableUsingJoin();//error
        //studentDao.FetchAllStudentBySP();
        studentDao.FetchDataFromTwoQuery();
    }
}