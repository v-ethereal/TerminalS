namespace Arsis.RentalSystem.Core.Bll
{
	public class AppRuntime
	{
		private static readonly object syncObject = new object();
		private static readonly object syncObject2 = new object();
		private static volatile AppRuntime instance;
		private volatile IComponentContainer container;

		private AppRuntime()
		{
		}

		public static AppRuntime Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncObject)
					{
						if (instance == null)
						{
							instance = new AppRuntime();
						}
					}
				}
				return instance;
			}
		}

		public void Initialize()
		{
			if (container == null)
			{
				lock (syncObject2)
				{
					if (container == null)
					{
						container = new ComponentContainer();
					}
				}
			}
		}

		public IComponentContainer Container
		{
			get
			{
				return container;
			}
		}
	}
}