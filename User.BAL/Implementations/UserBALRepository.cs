using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using User.BAL.Interfaces;
using User.DAL;
using User.DAL.Implementations;
using User.DAL.Interfaces;

namespace User.BAL.Implementations
{
    public class UserBALRepository : IUserBALRepository
    {
        private IUserDALRepository _userDALRepository = new UserDALRepository();
        public bool DeleteUser(int Id)
        {
            try
            {
            return _userDALRepository.DeleteUser(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserDetails> GetUserByID(int Id)
        {           
                try
                {                    
                    return _userDALRepository.GetUserByID(Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
        }

        public List<UserDetails> GetAllUsers()
        {
            try
            {
                return _userDALRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveUser(UserDetails userDetails)
        {
            try
            {
                return _userDALRepository.SaveUser(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
