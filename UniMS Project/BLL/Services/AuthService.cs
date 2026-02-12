using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class AuthService
    {
        DataAccessFactory factory;
        JwtService jwtService;
        public AuthService(DataAccessFactory factory , JwtService jwtService)
        {
            this.factory = factory;
            this.jwtService = jwtService;
        }

        public string Login(string username, string password)
        {
            var user = factory.UserData().Login(username, password);

            if (user == null)
                return null;

            return jwtService.CreateToken(user);
        }

    }
}
