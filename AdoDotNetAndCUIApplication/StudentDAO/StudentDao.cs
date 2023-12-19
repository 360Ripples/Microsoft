using StudentManagementDao;
using StudentManagementVo;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementDao
{
    public class StudentDao : IStudentDao
    {
       // StudentVo vo = new StudentVo();

        public void FetchStudent(int id)
        {
            
        }

         void IStudentDao.SaveStudent(StudentVo vo)
        {
            try
            {
                string ConString = " data source =.; database = Test;  integrated security = SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("insert into Student values (2, 'kokila',23)", connection);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted Rows = " + rowsAffected);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when Adding Student Details.\n" + e);


            }
            finally
            {

                Console.WriteLine("some msg...");

            }
        }
    }
    }