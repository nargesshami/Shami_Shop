using Shami_Shop.Models;

namespace Shami_Shop.Data.Repositories
{
    public interface IuserRepositories
    {
        bool IsExistUserByMobile(string mobile);
        void AddUser(Users user);
        Users GetUserForLogin(string mobile, string password);
    }

    public class UserRepository : IuserRepositories
    {
        private ShamiShopContext _context;

        public UserRepository(ShamiShopContext context)
        {
            _context = context;
        }
        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string mobile, string password)
        {
            return _context.Users
            .SingleOrDefault(u => u.MobilePhone == mobile && u.Password == password);
        }

        public bool IsExistUserByMobile(string mobile)
        {
            return _context.Users.Any(u => u.MobilePhone == mobile);
        }
    }
}
