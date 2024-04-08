using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YungChing_WebAPI.Models;
using YungChing_WebAPI.Service;

namespace YungChing_WebAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public DataTable Get()
        {
            UserService userService = new UserService();

            return userService.GetUser(); ;
        }

        // GET api/<controller>/5
        public DataTable Get(string userid)
        {
            UserService userService = new UserService();

            return userService.GetUser(userid);
        }

        // POST api/<controller>
        public bool Post([FromBody] User user)
        {
            UserService userService = new UserService();

            return userService.AddUser(user.UserID,user.UserName);
        }

        // PUT api/<controller>/5
        public bool Put(string userid, [FromBody] User user)
        {
            UserService userService = new UserService();

            return userService.UpdUser(userid,user.UserName);
        }

        // DELETE api/<controller>/5
        public bool Delete(string userid)
        {
            UserService userService = new UserService();

            return userService.DelUser(userid);
        }
    }
}