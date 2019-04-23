using FooAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FooAPI.Controllers
{
    public class ProductController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                var repo = new ProductRepository();
                return Ok(repo.GetProducts());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int index, int size, string search, string orderBy, string orderDir)
        {
            try
            {
                var repo = new ProductRepository();
                return Ok(repo.GetProducts(search, index, size, orderBy, orderDir));
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
                var repo = new ProductRepository();
                return Ok(repo.GetProduct(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
