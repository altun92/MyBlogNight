using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        //Entitiy'e özgü metotların olduğu alan. Article'a özgü metotlar.
        //Entity'e özgü metotları EfArticleDal içerisinde implemente edilmesi gerekir.
        List<Article> ArticleListWithCategory();
        List<Article> ArticleListWithCategoryAndAppUser();
        Article ArticleListWithCategoryAndAppUserByArticleId(int id);
        void ArticleViewCountIncrease(int id);
        List<Article> GetArticleByAppUserId(int id);
    }
}
