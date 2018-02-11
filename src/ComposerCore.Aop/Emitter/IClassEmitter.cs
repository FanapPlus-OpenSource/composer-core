﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using ComposerCore.Attributes;

namespace ComposerCore.Aop.Emitter
{
	[Contract]
	public interface IClassEmitter
	{
		Type EmitClass(IEnumerable<Type> interfaceTypes = null,
		               Type baseType = null,
		               IEnumerable<MethodInfo> methodsToOverride = null,
		               IEnumerable<PropertyInfo> propertiesToOverride = null,
		               IEnumerable<EventInfo> eventsToOverride = null,
		               ConstructorInfo baseConstructor = null,
		               IEnumerable<CustomAttributeBuilder> attributeBuilders = null);
	}
}