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
    public class ContactController : ApiController
    {
        public void Post(Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    contact = new Contact();
                }
                else
                {
                    var repo = new ContactRepository();
                    repo.AddContact(contact);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
