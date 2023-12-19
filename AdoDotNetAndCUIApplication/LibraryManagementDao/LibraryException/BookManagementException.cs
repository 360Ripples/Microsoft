using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementDao.LibraryException
{
    [Serializable]
    public class BookManagementException : Exception
    {

        public BookManagementException()
        {
        }

        public BookManagementException(string? message) : base(message)
        {
        }

        public BookManagementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BookManagementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}


