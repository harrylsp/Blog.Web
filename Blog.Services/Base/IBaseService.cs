using Blog.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Base
{
    public interface IBaseService : IService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add<T>(T model);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Edit<T>(T model);

        /// <summary>
        /// 删除
        /// 构建要删除的对应实体字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete<T>(T model);

        T GetModel<T>(T model);
    }
}
