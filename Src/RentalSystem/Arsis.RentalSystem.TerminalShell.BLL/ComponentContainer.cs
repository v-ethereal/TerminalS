using System;
using System.Collections;

using Arsis.RentalSystem.TerminalShell.BLL.Interface;

using Spring.Context;
using Spring.Context.Support;

namespace Arsis.RentalSystem.TerminalShell.BLL
{
	public class ComponentContainer : IComponentContainer
	{
		private readonly IApplicationContext context;

		public ComponentContainer()
		{
			context = ContextRegistry.GetContext();
		}

		public T GetComponent<T>()
		{
			IDictionary objects = context.GetObjectsOfType(typeof(T));
			foreach (DictionaryEntry entry in objects)
			{
				return (T)entry.Value;
			}
			throw new ApplicationException(String.Format("Component <{0}> not found in contatiner", typeof(T)));
		}
	}
}