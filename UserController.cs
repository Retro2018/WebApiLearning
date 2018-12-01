using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceUser_WebAPI_.Models;

namespace ServiceUser_WebAPI_.Controllers
{

    public class UserController : ApiController
    {
        Repository repository = new Repository();
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
           return repository.GetUsers();
        }


        //public HttpResponseMessage GetUsers()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();
        //    if (users.Count() == 0)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    else
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.OK,users);
        //    }
        //    return response;
        //}
        
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody]User user)
        {
            repository.AddUser(user);
            var massege = Request.CreateResponse(HttpStatusCode.Created, user);
            return massege;
        }
        [HttpPut]
        public HttpResponseMessage UpdateUser(int id, [FromBody]User user)
        {
            try
            {
                repository.UpdateUser(id, user);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, e.Message.ToString());
            }        
        }
        [HttpDelete]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                repository.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, e.Message.ToString());
            }
        }

    }
}
