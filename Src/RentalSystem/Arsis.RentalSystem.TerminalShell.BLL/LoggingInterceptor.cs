using System;
using System.Reflection;
using System.Text;

using AopAlliance.Intercept;

using log4net;

namespace Arsis.RentalSystem.TerminalShell.BLL
{
	public class LoggingInterceptor : IMethodInterceptor
	{
		private readonly ILog logger = LogManager.GetLogger("GeneralAppender");

		public object Invoke(IMethodInvocation invocation)
		{
			string signature = GetMethodSignature(invocation);
			if (logger.IsDebugEnabled)
			{
				logger.Debug(string.Format("Executing method: <{0}>.", signature));
			}
			try
			{
				return invocation.Proceed();
			}
			catch (RentalSystemException)
			{
				throw;
			}
			catch (Exception ex)
			{
				string msg = string.Format("Error executing method: <{0}>.", signature);
				logger.Error(msg, ex);
				throw new RentalSystemException(ex.InnerException != null ? string.Format("{0}; {1}", ex.Message, ex.InnerException.Message) : ex.Message, ex);
			}
		}

		protected static string GetMethodSignature(IMethodInvocation invocation)
		{
			StringBuilder sb = new StringBuilder();
			ParameterInfo[] parameters = invocation.Method.GetParameters();

			for (int i = 0; i < parameters.Length; i++)
			{
				if (sb.Length != 0)
				{
					sb.Append(", ");
				}
				sb.Append(String.Format("{0}", parameters[i].ParameterType.Name));
			}
			return string.Format("{0}::{1}({2})", invocation.Method.DeclaringType.Name, invocation.Method.Name, sb);
		}
	}
}