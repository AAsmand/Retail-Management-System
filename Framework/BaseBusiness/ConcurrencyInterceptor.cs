using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.BaseBusiness
{
    class ConcurrencyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            if (invocation.Method.Name.StartsWith("BaseBusiness"))
            {
                var methodInfo = invocation.TargetType.GetMethod("IsValid");
                //if (methodInfo == null)
                //{
                //    if (invocation.TargetType.BaseType != null)
                //        //raisePropertyChangedEvent(invocation, propertyName, type.BaseType);
                //}
                //else
                {
                    methodInfo.Invoke(invocation.InvocationTarget,new object[]{ });
                }
            }
        }
    }
}
