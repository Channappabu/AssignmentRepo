using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User.BAL;
using User.BAL.Implementations;
using User.BAL.Interfaces;

namespace ServiceIKF.Controllers
{
    [RoutePrefix("Api/User")]
    public class UsersController : ApiController
    {
        private IUserBALRepository _userBALRepository = new UserBALRepository();

        [HttpGet]
        [Route("AllUserDetails")]
        public List<UserDetails> GetUser()
        {
            try
            {
                return _userBALRepository.GetAllUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateUserDetails")]
        public IHttpActionResult PutEmaployeeMaster(UserDetails userDetails)
        {
            try
            {
                _userBALRepository.SaveUser(userDetails);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(userDetails);
        }

        [HttpGet]
        [Route("GetUserByID/{Id}")]
        public List<UserDetails> GetUserByID(int Id)
        {
            try
            {
                return _userBALRepository.GetUserByID(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("InsertUserDetails")]
        public IHttpActionResult PostUser(UserDetails data)
        {
            try
            {
                _userBALRepository.SaveUser(data);                
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteUserDetails")]
        public IHttpActionResult DeleteUserDelete(int id)
        {
            try
            {
                _userBALRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(id);
        }

    }
}
