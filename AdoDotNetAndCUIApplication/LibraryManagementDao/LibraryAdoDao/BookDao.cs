using Castle.Core.Resource;
using LibraryManagementDao.LibraryException;
using LibraryManagementVo;
using LinqToDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace LibraryManagementDao.LibraryAdoDao
{

    public class BookDao : IBookDao
    {
        
        public bool AddBook(BookVo vo)
        {
            using (SqlConnection con = new SqlConnection(LibraryManagementSystemDaoConstants.LibraryManagementSystem_DB_URL)) //Try with resources   it implements

            {
                String query = "insert into book values(@Id,@Name,@Author,@isbn);";
                bool flag = false;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@Id", vo.id));
                        cmd.Parameters.Add(new SqlParameter("@Name", vo.name));
                        cmd.Parameters.Add(new SqlParameter("@Author", vo.author));
                        cmd.Parameters.Add(new SqlParameter("@isbn", vo.isbn));
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            flag = true;
                        }
                    }
                    catch (SqlException e)
                    {
                        throw new BookManagementException("Error when adding Book Please Reach out Admin", e);

                    }

                    return flag;//true
                }
            }
        }
        public BookVo FetchBook(int id)
        {
            BookVo vo = new BookVo();
            using (SqlConnection con = new SqlConnection(LibraryManagementSystemDaoConstants.LibraryManagementSystem_DB_URL))

            {
                String query = "select * from book where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            vo.id = Convert.ToInt32(dr[0]);
                            vo.name = Convert.ToString(dr[1]);
                            vo.author = Convert.ToString(dr[2]);
                            vo.isbn = Convert.ToString(dr[3]);
                        }
                        else
                        {
                            throw new BookNotFoundException("fetching book id not found...");
                        }
                    }
                    catch (SqlException e)
                    {
                        throw new BookManagementException("Error when fetching Book", e);
                    }
                    return vo;

                }

            }
        }

        public List<BookVo> FetchBooks()
        {
            using (SqlConnection con = new SqlConnection(LibraryManagementSystemDaoConstants.LibraryManagementSystem_DB_URL))

            {
                con.Open();
                String query = "select * from book";
                using (SqlCommand command = new SqlCommand(query, con))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        List<BookVo> dataList = new List<BookVo>();
                        BookVo vo = new BookVo();
                        try
                        {
                            DataSet dataSet = new DataSet();
                            da.Fill(dataSet);


                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    vo = new BookVo();
                                    vo.id = Convert.ToInt32(row[0]);
                                    vo.name = Convert.ToString(row[1]);
                                    vo.author = Convert.ToString(row[2]);
                                    vo.isbn = Convert.ToString(row[3]);

                                    dataList.Add(vo);

                                }

                            }

                        }
                        catch (SqlException e)
                        {
                            throw new BookManagementException("Error when fetching Book", e);
                        }

                        return dataList;
                    }
                }
            }
        }

    }
}





