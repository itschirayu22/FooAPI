using FooAPI.Models;
using FooAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FooAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("postUser")]
        [HttpPost]
        public IHttpActionResult PostUser(User user)
        {
            try
            {
                var repo = new UserRepository();
                if (repo.IsUserExist(user))
                {
                    return Ok(new
                    {
                        Message = Constants.MESSAGE_EXIST
                    });
                }
                else
                {
                    repo.AddUser(user);
                    return Ok(new
                    {
                        Message = Constants.MESSAGE_SUCCESS,
                        User = user
                    });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("authenticateUser")]
        [HttpPost]
        public IHttpActionResult AuthenticateUser(UserDTO userDTO)
        {
            try
            {
                var repo = new UserRepository();
                var user = repo.AuthenticateUser(userDTO.UserName, userDTO.Password);
                if (user == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
