namespace basics.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses
            = new();
        static Repository()
        {
            _courses = new List<Course>()
            {

                    new Course()
                    {
                        Id = 1,
                        Title = "Django Kursu",
                        Description = "Test",
                        Image="1.jpg",
                        Tags=new string[]{"asp.net","web geliştirme"},
                        isActive=true,
                        isHome=true,

                    } ,
                     new Course()
                    {
                        Id = 2,
                        Title = "Python Kursu",
                        Description = "Bu kursu mutlaka dene",
                        Image="2.jpg",
                        Tags=new string[]{"asp.net","web geliştirme"},
                        isActive=false,
                        isHome=true,

                    },
                      new Course()
                    {
                        Id = 3,
                        Title = "C# Kursu",
                        Description = "Bu kursu mutlaka dene",
                        Image="3.jpg",
                        isActive=true,
                        isHome=true,

                    },
                        new Course()
                    {
                        Id = 4,
                        Title = "Java  Kursu",
                        Description = "Bu kursu mutlaka dene",
                        Image="1.jpg",
                        isActive=true,
                        isHome=true,

                    }
            };
        }
        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }
        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault(x => x.Id == id);
        }
    }
}
