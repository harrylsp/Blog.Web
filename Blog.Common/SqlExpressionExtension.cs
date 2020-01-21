using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Common
{
    public static class SqlExpressionExtension
    {
        public static SqlExpression<T> WhereIf<T>(this SqlExpression<T> sql, bool condition, Expression<Func<T, bool>> predicate)
         => condition ? sql.Where(predicate) : sql;
    }
}
