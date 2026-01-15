using System;
using System.Collections;

using Arsis.RentalSystem.TerminalShell.BLL.Interface;

using Spring.Context;

namespace Arsis.RentalSystem.TerminalShell.BLL
{
	public class SpringContainer : IComponentContainer, IApplicationContextAware
	{
		private IApplicationContext context;

		public T GetComponent<T>()
		{
			IDictionary objects = context.GetObjectsOfType(typeof(T));
			foreach (DictionaryEntry entry in objects)
			{
				return (T)entry.Value;
			}
			throw new ApplicationException(String.Format("Component <{0}> not found in contatiner", typeof(T)));
		}

		public IApplicationContext ApplicationContext
		{
			set { context = value; }
			get { return context; }
		}
	}
}