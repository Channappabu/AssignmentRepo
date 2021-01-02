using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using User.DAL.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace User.DAL.Implementations
{
    public class UserDALRepository : IUserDALRepository
    {
        private string Connection= @"Data Source=YH1008671LT\SQLEXPRESS;Initial Catalog=IKFAssign;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool DeleteUser(int Id)
        {
            using (IDbConnection db = new SqlConnection(Connection))
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ID", Id, DbType.String, ParameterDirection.Input, null);
                  var res=  db.Execute("ups_DeleteUser", param, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<UserDetails> GetAllUsers()
        {           
         using( IDbConnection db= new SqlConnection(Connection)){
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                    List<UserDetails> userData = (List<UserDetails>)db.Query<UserDetails>("ups_GetAllUser", commandType: CommandType.StoredProcedure);                   
                    return userData;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<UserDetails> GetUserByID(int Id)
        {
            using (IDbConnection db = new SqlConnection(Connection))
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", Id, DbType.Int32, ParameterDirection.Input, null);
                    var userData = (List<UserDetails>)db.Query<UserDetails>("ups_GetUserByID",param, commandType: CommandType.StoredProcedure);
                    return userData;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool SaveUser(UserDetails userDetails)
        {
            using (IDbConnection db = new SqlConnection(Connection))
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    if (userDetails.Id == 0)
                    {
                        param.Add("@Name", userDetails.Name, DbType.String, ParameterDirection.Input, null);
                        param.Add("@DateOfBirth", userDetails.DateOfBirth, DbType.Date, ParameterDirection.Input, null);
                        param.Add("@Designation", userDetails.Designation, DbType.String, ParameterDirection.Input, null);
                        param.Add("@Skills", userDetails.Skills, DbType.String, ParameterDirection.Input, null);
                     var res=   db.Execute("ups_CreateUser", param, commandType: CommandType.StoredProcedure);                                               
                        if (res < 0)
                            return true;
                        else
                            return false;
                    }
                    if(userDetails.Id>0)
                    {
                        param.Add("@ID", userDetails.Id, DbType.String, ParameterDirection.Input, null);
                        param.Add("@Name", userDetails.Name, DbType.String, ParameterDirection.Input, null);
                        param.Add("@DateOfBirth", userDetails.DateOfBirth, DbType.Date, ParameterDirection.Input, null);
                        param.Add("@Designation", userDetails.Designation, DbType.String, ParameterDirection.Input, null);
                        param.Add("@Skills", userDetails.Skills, DbType.String, ParameterDirection.Input, null);
                      var res=  db.Execute("ups_UpdateUser", param, commandType: CommandType.StoredProcedure);
                        ////To get newly created ID back  
                        //var id = param.Get<int>("@Id");
                        if (res < 0)
                            return true;
                        else
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }
    }
}
