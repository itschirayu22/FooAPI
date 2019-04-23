using FooAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FooAPI.Controllers
{
    public class ServiceController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                var repo = new ServiceRepository();
                return Ok(repo.GetServices());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var repo = new ServiceRepository();
                return Ok(repo.GetService(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
