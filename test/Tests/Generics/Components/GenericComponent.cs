﻿using ComposerCore.Attributes;

namespace ComposerCore.Tests.Generics.Components
{
	[Component]
	public class ClosedComponentOne : IGenericContractOne<string>
	{
		#region Implementation of IGenericContractOne<string>

		public string Get()
		{
			return "";
		}

		public void Set(string t)
		{
			// Do nothing
		}

		#endregion
	}

	[Component]
	public class ClosedComponentTwo : IGenericContractTwo<string, int>
	{
		#region Implementation of IGenericContractTwo<string,int>

		public string Something(int t2)
		{
			return t2.ToString();
		}

		public int AnotherThing(string t1)
		{
			return t1.Length;
		}

		#endregion
	}

	[Component]
	public class OpenComponentOne<T> : IGenericContractOne<T>
	{
		#region Implementation of IGenericContractOne<T>

		public T Get()
		{
			return default;
		}

		public void Set(T t)
		{
			// Do nothing
		}

		#endregion
	}

	[Component]
	public class MultiContractOpenComponent<T> : IGenericContractOne<T>, IGenericContractTwo<T, T>
	{
		public T Get()
		{
			return default;
		}

		public void Set(T t)
		{
			// Do nothing
		}

		public T Something(T t2)
		{
			return t2;
		}

		public T AnotherThing(T t1)
		{
			return t1;
		}
	}
	
	[Component, Transient]
	public class OpenTransientComponent<T> : IGenericContractOne<T>
	{
		public T Get()
		{
			return default;
		}

		public void Set(T t)
		{
			// Do nothing
		}
	}

	[Component, Singleton]
	public class OpenSingletonComponent<T> : IGenericContractOne<T>
	{
		public T Get()
		{
			return default;
		}

		public void Set(T t)
		{
			// Do nothing
		}
	}
	
	[Component]
	public class OpenComponentTwo<T1, T2> : IGenericContractTwo<T1, T2>
	{
		#region Implementation of IGenericContractTwo<T1,T2>

		public T1 Something(T2 t2)
		{
			return default;
		}

		public T2 AnotherThing(T1 t1)
		{
			return default;
		}

		#endregion
	}

	[Component]
	public class ReverseOpenComponentTwo<T1, T2> : IGenericContractTwo<T2, T1>
	{
		public T2 Something(T1 t2)
		{
			return default;
		}

		public T1 AnotherThing(T2 t1)
		{
			return default;
		}
	}

	[Component]
	public class ReverseOpenComponentTwoWithDifferentNames<T3, T4> : IGenericContractTwo<T4, T3>
	{
		public T4 Something(T3 t2)
		{
			return default;
		}

		public T3 AnotherThing(T4 t1)
		{
			return default;
		}
	}

	[Component]
	public class HalfOpenComponent<T> : IGenericContractTwo<string, T>
	{
		#region Implementation of IGenericContractTwo<string,T>

		public string Something(T t2)
		{
			return t2.ToString();
		}

		public T AnotherThing(string t1)
		{
			return default;
		}

		#endregion
	}

	[Component]
	public class RepeatingParamOpenComponent<T> : IGenericContractTwo<T, T>
	{
		#region Implementation of IGenericContractTwo<T,T>

		public T Something(T t2)
		{
			return t2;
		}

		public T AnotherThing(T t1)
		{
			return t1;
		}

		#endregion
	}

	[Component]
	public class ReverseParamOpenComponent<T1, T2> : IGenericContractTwo<T2, T1>
	{
		#region Implementation of IGenericContractTwo<T2,T1>

		public T2 Something(T1 t2)
		{
			return default;
		}

		public T1 AnotherThing(T2 t1)
		{
			return default;
		}

		#endregion
	}
}