using StudentManagementDao;
using StudentManagementDao.StudentAdoDao;
using StudentManagementVo;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace StudentManagementDao
{
    public class StudentDao : IStudentDao
    {
        public void FetchAllStudent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
                {
                    //Using Data Table

                    SqlDataAdapter da = new SqlDataAdapter("SELECT student.Id,student.Name, student.Age, course.cname FROM student INNER JOIN course ON student.Id = course.Id", con);//joins
                    //Using Data Table
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //The following things are done by the Fill method
                    //1. Open the connection
                    //2. Execute Command
                    //3. Retrieve the Result
                    //4. Fill/Store the Retrieve Result in the Data table
                    //5. Close the connection
                    Console.WriteLine("Using Data Table");
                    //Active and Open connection is not required
                    //dt.Rows: Gets the collection of rows that belong to this table
                    //DataRow: Represents a row of data in a DataTable.
                    foreach (DataRow row in dt.Rows)
                    {
                        //Accessing using string Key Name
                        Console.WriteLine(row["Id"] + "," + row["Name"] + ",  " + row["Age"] + ",  " + row["cname"]);
                        //Accessing using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine("---------------");

                    //After Update
                    dt.Rows[1]["Age"] = 36;
                    dt.Rows[1]["Name"] = "Jay";

                    // Retrieve the updated results using the Select method
                    DataRow[] results = dt.Select();

                    // Iterate over the rows of the DataTable using a foreach loop
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine("{0} {1} {2} {3}", row["ID"], row["Name"], row["Age"], row["cname"]);
                    }


                    /*//Using DataSet
                    DataSet ds = new DataSet();
                    da.Fill(ds, "student"); //Here, the datatable student will be stored in Index position 0
                    Console.WriteLine("Using Data Set");
                    //Tables: Gets the collection of tables contained in the System.Data.DataSet.
                    //Accessing the datatable from the dataset using the datatable name
                    foreach (DataRow row1 in ds.Tables["student"].Rows)
                    {
                        //Accessing the data using string Key Name
                        Console.WriteLine(row1["Id"] + ",  " + row1["Name"] + ",  " + row1["Age"] + "," + row1["cname"]);
                        //Accessing the data using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    //Accessing the datatable from the dataset using the datatable index position
                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    //    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Age"]);
                    //}*/

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to Fetch the Records.\n" + e);
            }
            Console.ReadKey();
        }

        public void FetchAllStudentBySP()
        {
            using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
            {
                try
                {

                    using (SqlCommand command = new SqlCommand("FindAll", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            // Use the DataTable here
                            //DataTable dataTable = ExecuteStoredProcedure("FindAll");

                            foreach (DataRow row in dataTable.Rows)
                            {
                                foreach (DataColumn col in dataTable.Columns)
                                {
                                    Console.WriteLine("{0}: {1}", col.ColumnName, row[col]);
                                }
                                Console.WriteLine("=====================");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
        }

        public void FetchById()
        {

            using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
            {
                try
                {
                    string query = "SELECT student.Id, student.Name, course.cname FROM student INNER JOIN course ON student.Id = course.Id;";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))

                    {
                        // Create a new DataTable to hold the results
                        DataTable dataTable = new DataTable();

                        // Create a DataSet to store the results
                        DataSet dataSet = new DataSet();
                        // adapter.Fill(dataSet);


                        // Fill the DataTable using the SqlDataAdapter
                        adapter.Fill(dataTable);

                        //Adding the DataTable to DataSet
                        dataSet.Tables.Add(dataTable);
                        // Display the results
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["cname"]);
                        }




                    }

                }



                catch (Exception ex)
                {
                    // Handle any exceptions
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }


        }

        public void FetchDataFromTwoQuery()
        {
            using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
            {
                string queryString1 = "SELECT * FROM student";
                string queryString2 = "SELECT * FROM course";

                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = new DataTable();
                DataSet dataSet = new DataSet();


                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(queryString1, con);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(queryString2, con);

                dataAdapter1.Fill(dataTable1);
                dataAdapter2.Fill(dataTable2);
                dataSet.Tables.Add(dataTable1);
                dataSet.Tables.Add(dataTable2);

                // Iterate over the data tables using a foreach loop.

                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Console.WriteLine(row["Id"] +" "+ row["Name"]);
                    }
                }
            }

        }

        public void FetchStudent(int Id)
        {

            try
            {
                // Creating Connection  
                using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
                {

                    // Creating SqlCommand objcet   
                    SqlCommand cmd = new SqlCommand("select * from student where Id=@Id", con);



                    cmd.Parameters.AddWithValue("@Id", Id);
                    // Opening Connection  
                    con.Open();

                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Console.WriteLine(sdr.GetInt32(0) +
                                sdr.GetString(1) + sdr.GetInt32(2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    sdr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to retrieve a record.\n" + e);
            }
            Console.ReadKey();
        }




        public void SaveStudent(StudentVo vo)
        {
            try
            {
                //Automatic disposal of unmanaged resources:
                //When you declare an object that implements the IDisposable interface,
                //you can wrap it in a using statement.
                //This allows the object to be automatically disposed of when the using block is exited,
                //ensuring that any unmanaged resources (such as file handles or database connections) are properly released.

                // Creating Connection  
                using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
                {
                    // writing sql query
                    String query = "insert into student values(@Id,@Name,@Age);";

                    // Opening Connection  
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@Id", vo.Id);
                        cmd.Parameters.AddWithValue("@Name", vo.Name);
                        cmd.Parameters.AddWithValue("@Age", vo.Age);


                        // Executing the SQL query 
                        Int32 rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Student Record Added Successfully." + " " + " Student ID:" + " " + vo.Id);
                            Console.ReadLine();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when Adding Student Details.\n" + e);
            }
            finally
            {

                Console.WriteLine("Some msg...");

            }
            Console.ReadLine();
        }

        public void UpdateDataTableWithTable()
        {
            try
            {

                string query = "SELECT * FROM student";

                using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
                {
                    // Create a new DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dataTable);


                    // Make changes to the DataTable object, such as modifying or adding rows
                    DataRow[] rowsToUpdate = dataTable.Select("Name = 'Boston'");
                    foreach (DataRow row in rowsToUpdate)
                    {
                        row["Name"] = "Krish";
                    }

                    // Create a CommandBuilder object for the DataAdapter
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    // Call the Update method of the DataAdapter, passing in the DataTable object
                    adapter.Update(dataTable);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to retrieve a record.\n" + e);
            }
            Console.ReadKey();
        }




        public void UpdateStudent()
        {
            using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
            {
                try
                {

                    con.Open();
                    string sql = "UPDATE student SET Name = @Name WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("@Name", "Krish");
                    command.Parameters.AddWithValue("@Id", 1);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + rowsAffected);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to retrieve a record.\n" + e);
                }
                Console.ReadKey();
            }
        }

        public void UpdateWithDataTableWithTableUsingJoin()
        {
            try
            {
                string query = "SELECT customers.Id, customers.Name, customers.Mobile,orders.amount FROM customers INNER JOIN orders ON customers.Id = orders.CustomerId;";
                using (SqlConnection con = new SqlConnection(StudentManagementDaoConstant.StudentManagementSystem_DB_URL))
                {
                    // Create a new DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dataTable);


                    // Make changes to the DataTable object, such as modifying or adding rows
                    DataRow[] rowsToUpdate = dataTable.Select("Name = 'Anurag'");
                    foreach (DataRow row in rowsToUpdate)
                    {
                        row["Name"] = "Rajesh";

                        row["Mobile"] = "1234567890";
                        row["Amount"] = 50000;
                    }

                    // Create a CommandBuilder object for the DataAdapter
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    // Call the Update method of the DataAdapter, passing in the DataTable object
                    adapter.Update(dataTable);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to retrieve a record.\n" + e);
            }
            Console.ReadKey();
        }
    }
}




