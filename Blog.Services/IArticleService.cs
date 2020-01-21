using Blog.Common;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IArticleService : IService
    {
        bool Add(Article article);

        bool Edit(Article article);

        bool Delete(string id);

        Article GetArticle(string author);

        int GetArticleCount(string where);

        IList<ArticleView> GetArticleList(string where, int pageIndex, int pageSize);

        Article Detail(string id);

        Task<bool> CategoryAdd(Category category);

        Task<int> CategoryEdit(Category category);

        int GetCategoryCount(string where);

        Category GetCategory(string where);

        IList<CategoryView> GetCategoryList(string search, int pageIndex, int pageSize);

        IList<Tips> GetTipsList(string search, int pageIndex, int pageSize);

        bool TipsAdd(Tips tips);

        Tips GetTips(string id);

        int GetTipsCount(string where);

    }
}
