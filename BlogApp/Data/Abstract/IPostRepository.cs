using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Controllers;
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts {get;} // IQueryable bütün postları aldığım zaman ekstra kriter ekleme yapmamaızı sağlıyor. Ienurable olsa bütün postları alır sonra filtreme yapar bu ilk filtreme sonra alır.
        void CreatePost(Post post);
    }
}