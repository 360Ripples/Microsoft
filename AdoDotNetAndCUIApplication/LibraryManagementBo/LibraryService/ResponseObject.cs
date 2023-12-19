using LibraryManagementVo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBo.LibraryService
{
    public class ResponseObject
    {
        private string successMessage;

        private List<BookVo> bookVoList;

        public List<BookVo> GetBookVoList()
        {
            return bookVoList;
        }

        public void SetBookVoList(List<BookVo> value)
        {
            bookVoList = value;
        }

        public string GetSuccessMessage()
        {
            return successMessage;
        }

        public void SetSuccessMessage(string value)
        {
            successMessage = value;
        }

        private BookVo vo;//fetch by id


        public BookVo GetVo()
        {
            return vo;
        }

        public void SetVo(BookVo value)
        {
            vo = value;
        }

        private string failureMessage;



        public string GetFailureMessage()
        {
            return failureMessage;
        }

        public void SetFailureMessage(string value)
        {
            failureMessage = value;
        }
    }
}
