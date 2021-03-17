using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //Interceptor kodun başında çalıştığında sonunda araya giren bir yapıdır
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]//bu attribute u class lara ve methodlara ekleyebilirsin
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
