using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitTest.Filters;
using Chris.Framework.Web.Mvc.ModelValidation;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitTest.Controllers
{
    [Route("[Controller]")]
    public class ModelValidationController : Controller
    {

        [HttpPost]
        [ValidateModelState]
        public IActionResult Post([FromBody] UserRequest req)
        {
            if (ModelState.IsValid)
            {
                return Content("success !");
            }
            return BadRequest();
        }
    }

    public class UserRequest
    {
        [ChineseValidation]
        [Required(ErrorMessage = "姓名字段不能为空!")]
        public string Name { get; set; }
        public int Age { get; set; }
        [IdCardValidation]
        public string IdCard { get; set; }

    }
}
