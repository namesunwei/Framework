using System;
using System.Collections.Generic;
using System.Text;

namespace Chris.Framework.Infrastructure
{
    /// <summary>
    /// 标记一个类型为依赖项（使用此接口的依赖项的生命周期为默认为 per request ）
    /// </summary>
    public interface IDependency
    {
    }
    /// <inheritdoc />
    /// <summary>
    /// 标记一个类型为依赖项（使用此接口的依赖项生命周期为 singleton）。
    /// </summary>
    public interface ISingletonDependency : IDependency
    {
    }
    /// <inheritdoc />
    /// <summary>
    /// 标记一个类型为依赖项（使用此接口的依赖项生命周期为 per usage）。 
    /// </summary>
    public interface ITransientDependency : IDependency
    {

    }
}
