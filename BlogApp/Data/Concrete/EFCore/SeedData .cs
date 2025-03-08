using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EFCore
{//Test datalarıdır. Bu sayede veri eklemek için arayüz tasarlamaya gerek yoktur.
    public class SeedData 
    {
        public static void SeedDatabase(IApplicationBuilder app) // appe veriyoruzki çalışan uygulamayı alalım builder servvisi il blogcontxte erişcek
        {
              var context=app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>(); // blogcontexte erişim sağladık
              if(context!=null)
              {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate(); // database oluşturuldu
                }
                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag{Text = "Web Programlama"},
                        new Tag{Text = "Asp.Net Core"},
                        new Tag{Text = "Asp.Net Mvc"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User{UserName="KaanKacar"},
                        new User{UserName="KaanKacar2"}
                    );
                    context.SaveChanges();
                }
                
                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {Title="Asp.net core",Tags = context.Tags.Take(2).ToList(),IsActive =true,PublishedOn=DateTime.Now.AddDays(-20),UserId=1},
                        new Post {Title="Asp.net Mvc",IsActive =true, UserId=1,Tags = context.Tags.Take(2).ToList(),PublishedOn=DateTime.Now.AddDays(-20)},
                        new Post {Title="Web Programlama",PublishedOn=DateTime.Now.AddDays(-20),Tags = context.Tags.Take(2).ToList(),IsActive =true,UserId=1}
                    );
                    context.SaveChanges();
                }

           
              }
        }
    }
}