using Microsoft.EntityFrameworkCore;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    //Burada Abstract klasörü içerisinde ki DAL ' a yazılan metotların işleyişi yazılır.
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public EfArticleDal(BlogContext context) : base(context)
        {
        }
        //Burada yazılan metotlar Business katmanında ilgili Entity içine başına T konularak eklenir.
        //Bununla beraber Presentation katmanı bu metotlara erişebilir.
        public List<Article> ArticleListWithCategory()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x=>x.Category).ToList();
            return values;
        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x=>x.Category).Include(y=>y.AppUser).ToList();
            return values;
        }

        public Article ArticleListWithCategoryAndAppUserByArticleId(int id)
        {
            var context = new BlogContext();
            var values = context.Articles.Where(x=>x.ArticleId == id).Include(y=>y.AppUser).Include(t=>t.Category).FirstOrDefault();
            return values;
        }

        public void ArticleViewCountIncrease(int id)
        {
            var context = new BlogContext();
            var updatedValue = context.Articles.Find(id);
            updatedValue.ArticleViewCount += 1;
            context.SaveChanges();
        }
    }
}
