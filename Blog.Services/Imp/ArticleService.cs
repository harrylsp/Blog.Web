using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.DataAccess;
using Blog.Model;
using ServiceStack.OrmLite;

namespace Blog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly BlogDatabase _db;

        public ArticleService(BlogDatabase db)
        {
            _db = db;
        }

        public bool Add(Article article)
        {
            return _db.Save(article);
        }

        public bool Delete(string id)
        {
            return _db.UpdateOnly(() => new Article { Status = EStatus.删除 }, where: a => a.Id == id) > 0 ? true : false;
        }

        public Article Detail(string id)
        {
            return _db.Single<Article>(a => a.Id == id) ?? new Article();
        }

        public bool Edit(Article article)
        {
            return _db.UpdateOnly(article, where: a => a.Id == article.Id) > 0 ? true : false;
        }

        public Article GetArticle(string author)
        {
            var sqlQuery = _db.From<Article>().WhereIf(!string.IsNullOrWhiteSpace(author), a => a.Author.Contains(author));

            return _db.Single(sqlQuery);
        }

        public int GetArticleCount(string where)
        {
            var sqlExpression = _db.From<Article>().UnsafeWhere(string.IsNullOrWhiteSpace(where) ? "1=1" : where);

            return _db.Select(sqlExpression).Count;
        }

        public IList<ArticleView> GetArticleList(string where, int pageIndex = 0, int pageSize = 10)
        {
            var sqlExpression = _db.From<Article>()
                .LeftJoin<Category>((a, c) => a.CategoryId == c.Value)
                .Select<Article, Category>((a, c) => new
                {
                    a,
                    Category = c.Name
                })
                .UnsafeWhere(string.IsNullOrWhiteSpace(where) ? "1=1" : where)
                .OrderBy(c => c.CreateTime).Skip((pageIndex > 0 ? pageIndex - 1 : pageIndex) * pageSize).Take(pageSize);

            return _db.Select<ArticleView>(sqlExpression);
        }

        public async Task<bool> CategoryAdd(Category category)
        {
            return await _db.SaveAsync(category);
        }

        public async Task<int> CategoryEdit(Category category)
        {
            return await _db.UpdateOnlyAsync(() => new Category
            {
                Name = category.Name,
                Description = category.Description
            }, where: c => c.Id == category.Id);
        }

        public int GetCategoryCount(string where)
        {
            var sqlExpression = _db.From<Category>().UnsafeWhere(string.IsNullOrWhiteSpace(where) ? "1=1" : where);

            return _db.Select(sqlExpression).Count;
        }

        public Category GetCategory(string where)
        {
            var sqlExpression = _db.From<Category>().UnsafeWhere(string.IsNullOrWhiteSpace(where) ? "1=1" : where);

            return _db.Single(sqlExpression);
        }


        public IList<CategoryView> GetCategoryList(string search, int pageIndex = 0, int pageSize = 10)
        {
            var sqlExpression = _db.From<Category>().WhereIf(!string.IsNullOrWhiteSpace(search), c => c.Name.Contains(search))
                .OrderBy(c => c.Value).Skip((pageIndex > 0 ? pageIndex - 1 : pageIndex) * pageSize).Take(pageSize);

            return _db.Select<CategoryView>(sqlExpression);
        }

        public IList<Tips> GetTipsList(string search, int pageIndex = 0, int pageSize = 10)
        {
            var sqlExpression = _db.From<Tips>().WhereIf(!string.IsNullOrWhiteSpace(search), c => c.Text.Contains(search))
                .OrderBy(c => c.CreateTime).Skip((pageIndex > 0 ? pageIndex - 1 : pageIndex) * pageSize).Take(pageSize);

            return _db.Select<Tips>(sqlExpression);
        }

        public bool TipsAdd(Tips tips)
        {
            return _db.Save(tips);
        }

        public Tips GetTips(string id)
        {
            return _db.Single<Tips>(a => a.Id == id) ?? new Tips();
        }

        public int GetTipsCount(string where)
        {
            var sqlExpression = _db.From<Tips>().UnsafeWhere(string.IsNullOrWhiteSpace(where) ? "1=1" : where);

            return _db.Select(sqlExpression).Count;
        }

    }
}
