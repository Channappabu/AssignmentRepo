using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Interfaces
{
    public interface IUserBALRepository
    {
        List<UserDetails> GetAllUsers();

        bool SaveUser(UserDetails userDetails);

        bool DeleteUser(int Id);
        List<UserDetails> GetUserByID(int Id);
    }
}
