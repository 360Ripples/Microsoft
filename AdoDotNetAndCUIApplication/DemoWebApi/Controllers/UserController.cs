
using Abp.Domain.Entities;
using DemoWebApi.Controllers;
using DemoWebApi.Model;
using LibraryManagementBo.LibraryService;
using LibraryManagementVo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Web.Http.Filters;

namespace DemoWebApi.Controllers
{
    public class LogAttribute : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Log("OnActionExecuted", context.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log("OnActionExecuting", context.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Log("OnResultExecuted", context.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Log("OnResultExecuting ", context.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
            Debug.WriteLine(message);
        }
    }




    [ApiController]
    [Log]

        public class UserController : ControllerBase
        {

            [HttpGet]
            [Route("api/User/print")]
            public string Print()
            {
                Trace.WriteLine("Inside the method get...!!!");
                return "Success!!!";
            }


            [HttpGet]
            [Route("api/User/Add")]
            public string Add(int n1, int n2)
            {
                int sum = n1 + n2;
                return "Sum:" + sum;
            }


            [HttpPost]
            [Route("api/User/DisplayNames")]
            public IList<string> DisplayNames(string[] name)
            {
                IList<string> list = new List<string>();
                foreach (string s in name)
                {
                    list.Add(s);
                }

                return list;

            }


            [HttpPost]
            [Route("api/User/AddStudent")]
            public StudentVo AddStudent([FromBody] StudentVo studentVo)
            {

                return studentVo;
            }


            [HttpPost]
            [Route("api/User/AddStudentList")]
            public IList<StudentVo> AddStudentList([FromBody] List<StudentVo> studentVo)
            {
                IList<StudentVo> list = new List<StudentVo>();
                StudentVo studentVo1 = new StudentVo();
                StudentVo studentVo2 = new StudentVo();
                list.Add(studentVo1);
                list.Add(studentVo2);
                return list;

            }

            [HttpPost]
            [Route("api/User/AddBook")]
          

            public ResponseObject AddBook(BookVo vo)
            {

                BookService b = new BookService();
                return b.SaveBook(vo);

            }

            [HttpGet]
            [Route("api/User/FetchBookById")]
          
            public BookVo FetchBookById(int Id)
            {

                BookService b = new BookService();
                return b.GetBookById(Id);

            }






        }
    }
    


