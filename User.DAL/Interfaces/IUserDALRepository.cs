using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.DAL.Interfaces
{
  public  interface IUserDALRepository
    {
        List<UserDetails> GetAllUsers();

        bool SaveUser(UserDetails userDetails);

        bool DeleteUser(int Id);

        List<UserDetails> GetUserByID(int Id);
    }
}
