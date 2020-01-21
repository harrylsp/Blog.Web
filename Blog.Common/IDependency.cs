using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common
{
    /// <summary>
    /// 依赖注入接口
    /// </summary>
    public interface IDependency
    {
    }
    /// <summary>
    /// 单例模式注入
    /// </summary>
    public interface IDependencySingleton : IDependency
    {
    }
    /// <summary>
    /// 依赖注入接口，继承了本接口的类自动在初始化时，设置生命周期为AsPerRequestSingleton
    /// </summary>
    public interface IDependencyRequestSingleton : IDependencySingleton
    {
    }
}
