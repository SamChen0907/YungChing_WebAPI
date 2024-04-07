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
            DataTable dt = UserService.GetUser();

            return dt;
        }

        // GET api/<controller>/5
        public DataTable Get(string userid)
        {
            DataTable dt = UserService.GetUser(userid);

            return dt;
        }

        // POST api/<controller>
        public bool Post([FromBody] User user)
        {
            bool IsAdd = UserService.AddUser(user.UserID, user.UserName);

            return IsAdd;
        }

        // PUT api/<controller>/5
        public bool Put(string userid, [FromBody] User user)
        {
            bool IsUpd = UserService.UpdUser(userid, user.UserName);

            return IsUpd;
        }

        // DELETE api/<controller>/5
        public bool Delete(string userid)
        {
            bool IsDel = UserService.DelUser(userid);

            return IsDel;
        }
    }
}