using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using app.ems.api.Repository;
using app.ems.api.Helper;

namespace app.ems.api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        // POST api/<controller>
        /// <summary>
        /// Validate user api.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("api/user/validate")]
        [HttpPost]
        public IHttpActionResult Validate(string userId, string password) // [FromBody] missing
        {
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(password))
            {
                return BadRequest("Please Check the Parameters.");
            }

            try
            {
                var login = _userRepository.GetUser(userId);

                var pwd = EncryptDecrypt.Decrypt(login.Password);

                if (password.Equals(pwd))
                    return Ok();
                return BadRequest("Please provide valid password.");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}