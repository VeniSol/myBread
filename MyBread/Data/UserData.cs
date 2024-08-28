using MyBread.Models;

namespace MyBread.Db
{
    public class UserData
    {
        private Data data = new Data();

        public IEnumerable<User> FindAll()
        {
            return data.Users.ToList();
        }

        public User FindById(int id)
        {
            return data.Users.Find(id);
        }

        public User FindByLogin(string login)
        {
            return data.Users.FirstOrDefault(user => user.Login == login);
        }

        public void DelById(int id)
        {
            User user = FindById(id);
            if (user != null)
            {
                data.Users.Remove(user);
                data.SaveChanges();
            }
        }

        public void Save(User user)
        {
            data.Users.Add(user);
            data.SaveChanges();
        }
        public void Update(User user)
        {
            data.Users.Update(user);
            data.SaveChanges();
        }
    }
}