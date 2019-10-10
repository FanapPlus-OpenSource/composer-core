﻿using System;
using ComposerCore.Attributes;
using ComposerCore.Extensibility;

namespace ComposerCore
{
	[Contract]
	public interface IComponentContext : IComposer
	{
		void Register(Type contract, Type component);
		void Register(Type component);
		void Register(Type contract, string name, Type component);
		void Register(IComponentFactory componentFactory);
		void Register(string name, IComponentFactory componentFactory);
		void Register(string name, Type componentType);
		void Register(Type contract, IComponentFactory factory);
		void Register(Type contract, string name, IComponentFactory factory);

		void RegisterObject(object componentInstance);
		void RegisterObject(Type contract, object componentInstance);
		void RegisterObject(string name, object componentInstance);
		void RegisterObject(Type contract, string name, object componentInstance);

		void Unregister(ContractIdentity identity);
		void UnregisterFamily(Type type);

		void SetVariableValue(string name, object value);
		void SetVariable(string name, Lazy<object> value);
		void RemoveVariable(string name);

		[Obsolete("Resolve ICompositionListenerChain from the context and use its methods instead.")]
		void RegisterCompositionListener(string name, ICompositionListener listener);
		[Obsolete("Resolve ICompositionListenerChain from the context and use its methods instead.")]
		void UnregisterCompositionListener(string name);
	}
}
