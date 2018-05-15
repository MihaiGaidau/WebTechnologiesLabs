using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
   // [Route("[controller]/[action]")]
    public class AboutController
    {
     //   [Route("")]
        public string Phone()
        {
            return "084667373";
        }
      //  [Route("action")]
        public string Adress()
        {
            return "ion cuza3";
        }
    }
}
