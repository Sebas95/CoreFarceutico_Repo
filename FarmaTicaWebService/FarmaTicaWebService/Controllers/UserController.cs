using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmaTicaWebService.Models;

namespace FarmaTicaWebService.Controllers
{
    public class UserController : ApiController
    {
        public User getUser() { return new User(); }
    }
}
