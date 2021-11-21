using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interseptors
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class MethodInterceptionBaseAttribute : Attribute, IInterceptor
	{
		public int Priority { get; set; }
		public virtual void Intercept(IInvocation invocation)
		{
			
		}
	}
}
