using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Login(string username, string password)
        {
            var user = DataAccessFactory.AuthData().Login(username, password);
            if (user != null) 
            {
                var genToken = new Token { Role = user.Role, TokenKey = Guid.NewGuid().ToString(), UserId = user.Id };
                try
                {
                    DataAccessFactory.TokenData().Add(genToken);
                    TokenDTO tokenDTO = new TokenDTO
                    {
                        Role = genToken.Role,
                        TokenKey = genToken.TokenKey,
                        UserId = genToken.UserId
                    };
                    return tokenDTO;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var existToken = DataAccessFactory.ITokenData().IsValidToken(token);
            if(existToken != null )
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string token)
        {
            var existToken = DataAccessFactory.ITokenData().IsValidToken(token);
            if(existToken != null)
            {
                DataAccessFactory.TokenData().Update(existToken);
                return true;
            }
            return false;
        }
    }
}
