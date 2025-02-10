namespace MeetingApp.Models
{
    public  static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo()
            {
                Id = 1,
                Name = "user",
                Email = "user@gmail.com",
                Phone = "11111111111111",
                WillAttend=true
            });
            _users.Add(new UserInfo()
            {
                Id = 2,
                Name = "user2",
                Email = "user2@gmail.com",
                Phone = "111166611111111",
                WillAttend = true
            });
            _users.Add(new UserInfo()
            {
                Id = 3,
                Name = "user3",
                Email = "user3@gmail.com",
                Phone = "111000111111111",
                WillAttend = true
            });
        }

        public static List<UserInfo> Users { 

            get { 
                return _users;
            }        
        }

        public static void CreateUser(UserInfo user) 
        {
            user.Id = Users.Count + 1;

            _users.Add(user);
                
        }

        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id==id);
        }
    }
}
