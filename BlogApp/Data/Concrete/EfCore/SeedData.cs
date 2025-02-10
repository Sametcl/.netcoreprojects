using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning },
                        new Tag { Text = "backend", Url = "backend", Color = TagColors.success },
                        new Tag { Text = "frontend", Url = "frontend", Color = TagColors.secondary },
                        new Tag { Text = "fullstack", Url = "fullstack", Color = TagColors.danger },
                        new Tag { Text = "php", Url = "php", Color = TagColors.primary }
                        );

                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "sametcil", Name="Samet Çil",Email="sametcil@gmail.com",Password="123456",Image = "p1.jpg" },
                        new User { UserName = "muratcil", Name="Murat Çil",Email="Muratcil@gmail.com",Password="123456",Image = "p2.jpg" }

                        );
                    context.SaveChanges();
                }


                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.net Core",
                            Content = "ASP.NET Core, .NET teknojileri ile yazılım geliştirme çalışmaları yapan geliştiricilerin daha duyarlı, güvenilir ve genişletilebilir uygulamalar geliştirebilmelerini kolaylaştırmaktadır. \r\n\r\nASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. \r\n\r\nWeb uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. Microsoft bu platformu düzenli olarak geliştirmektedir. ",
                            Url = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment> {
                                  new Comment { Text = "Çok açıklayıcı bir makale", PublishedOn = DateTime.Now, UserId = 1 },
                                  new Comment { Text = "Daha detaylı yazmanızı istiyorum", PublishedOn = DateTime.Now, UserId = 2 },


                                }
                        },
                         new Post
                         {
                             Title = "Php",
                             Content = "Php dersleri, .NET teknojileri ile yazılım geliştirme çalışmaları yapan geliştiricilerin daha duyarlı, güvenilir ve genişletilebilir uygulamalar geliştirebilmelerini kolaylaştırmaktadır. \r\n\r\nASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. \r\n\r\nWeb uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. Microsoft bu platformu düzenli olarak geliştirmektedir. ",
                             Url = "php",
                             IsActive = true,
                             PublishedOn = DateTime.Now.AddDays(-20),
                             Tags = context.Tags.Take(2).ToList(),
                             Image = "2.jpg",
                             UserId = 2,
                         },
                          new Post
                          {

                              Title = "Java",
                              Url = "java",
                              Content = "Java dersleri, .NET teknojileri ile yazılım geliştirme çalışmaları yapan geliştiricilerin daha duyarlı, güvenilir ve genişletilebilir uygulamalar geliştirebilmelerini kolaylaştırmaktadır. \r\n\r\nASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. \r\n\r\nWeb uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. Microsoft bu platformu düzenli olarak geliştirmektedir. ",
                              IsActive = true,
                              PublishedOn = DateTime.Now.AddDays(-30),
                              Tags = context.Tags.Take(4).ToList(),
                              Image = "3.jpg",
                              UserId = 2,
                          }
                          ,
                          new Post
                          {

                              Title = "React Dersleri",
                              Url = "react-dersleri",
                              Content = "React dersleri, .NET teknojileri ile yazılım geliştirme çalışmaları yapan geliştiricilerin daha duyarlı, güvenilir ve genişletilebilir uygulamalar geliştirebilmelerini kolaylaştırmaktadır. \r\n\r\nASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. \r\n\r\nWeb uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. Microsoft bu platformu düzenli olarak geliştirmektedir. ",
                              IsActive = true,
                              PublishedOn = DateTime.Now.AddDays(-40),
                              Tags = context.Tags.Take(4).ToList(),
                              Image = "3.jpg",
                              UserId = 2,
                          }
                          ,
                          new Post
                          {

                              Title = "Angular",
                              Url = "angular",
                              Content = "Angular dersleri, .NET teknojileri ile yazılım geliştirme çalışmaları yapan geliştiricilerin daha duyarlı, güvenilir ve genişletilebilir uygulamalar geliştirebilmelerini kolaylaştırmaktadır. \r\n\r\nASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. \r\n\r\nWeb uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. Microsoft bu platformu düzenli olarak geliştirmektedir. ",
                              IsActive = true,
                              PublishedOn = DateTime.Now.AddDays(-50),
                              Tags = context.Tags.Take(4).ToList(),
                              Image = "3.jpg",
                              UserId = 2,
                          }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
