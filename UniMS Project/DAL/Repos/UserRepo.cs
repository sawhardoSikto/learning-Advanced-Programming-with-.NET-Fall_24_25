using DAL.EF;
using DAL.EF.Models;

namespace DAL.Repos
{
    public class UserRepo
    {
        UniMS db;

        public UserRepo(UniMS db)
        {
            this.db = db;
        }

        public User Login(string username, string password)
        {
            return db.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }
    }
}
