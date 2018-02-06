﻿using ComposerCore.Attributes;
using ComposerCore.Cache;

namespace ComposerCore.Tests.ComponentCaching.Components
{
	[Contract]
	[Component]
	[ComponentCache(typeof(ContractAgnosticComponentCache))]
	public class SprComponent : ISomeContract, IAnotherContract
	{
	}

	[Contract]
	[Component]
	[ComponentCache(typeof(ContractAgnosticComponentCache))]
	public class SprComponentWithPlugs
	{
		[ComponentPlug]
		public SprComponent SprComponent { get; set; }

		[ComponentPlug]
		public SpcComponent SpcComponent { get; set; }

		[ComponentPlug]
		public NonSharedComponent NonSharedComponent { get; set; }
	}
}
