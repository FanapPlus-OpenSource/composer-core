using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ComposerCore.Emitter
{
	[Component]
	[ComponentCache(null)]
	public class DefaultPropertyEmitter : IPropertyEmitter
	{
		#region Implementation of IPropertyEmitter

		public PropertyInfo EmitProperty(TypeBuilder typeBuilder,
		                                         PropertyInfo propertyInfo)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}