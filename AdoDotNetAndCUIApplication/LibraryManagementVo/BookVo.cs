using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementVo
{

    public class BookVo
    {
        public int id
        {
            get; set;
        }

        public string name
        {
            get; set;
        }
        public string author
        {
            get; set;
        }

        public string isbn
        {
            get; set;
        }


        public override string ToString()
        {
            return "[BookVo:" + "Book ID:" + id + " " + "Book Name:" + name + " " + "Author Name:" + author + " " + "ISBN NUMBER:" + isbn + "]";
        }
    }


}