﻿using System.Linq;
using ComposerCore.Implementation;
using ComposerCore.Tests.ComponentCaching.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComposerCore.Tests.ComponentCaching
{
	[TestClass]
	public class ContractAgnosticCacheTest
	{
		public TestContext TestContext { get; set; }
		private ComponentContext _context;

		#region Additional test attributes
		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext)
		{
		}

		[ClassCleanup]
		public static void ClassCleanup()
		{
		}

		[TestInitialize]
		public void TestInitialize()
		{
			_context = new ComponentContext();
			_context.Register(typeof(ContractAgnosticComponent));
			_context.Register(typeof(ContractAgnosticComponentWithPlugs));
		}

		[TestCleanup]
		public void TestCleanup()
		{
		}

		#endregion

		[TestMethod]
		public void RegisterTwoTimesQueryBySelf()
		{
			_context.Register(typeof(ContractAgnosticComponent));

			var all = _context.GetAllComponents<ContractAgnosticComponent>();
			Assert.IsNotNull(all);
			Assert.IsTrue(all.Count() == 2);

			var allArray = all.ToArray();
			var c0 = allArray[0];
			var c1 = allArray[1];
			Assert.AreNotSame(c0, c1);
		}

		[TestMethod]
		public void RegisterTwoTimesQueryByContract()
		{
			_context.Register(typeof(ContractAgnosticComponent));

			var all = _context.GetAllComponents<ISomeContract>();
			Assert.IsNotNull(all);
			Assert.IsTrue(all.Count() == 2);

			var allArray = all.ToArray();
			var c0 = allArray[0];
			var c1 = allArray[1];
			Assert.AreNotSame(c0, c1);
		}

		[TestMethod]
		public void CheckDifferentContracts()
		{
			var c0 = _context.GetComponent<ISomeContract>();
			var c1 = _context.GetComponent<IAnotherContract>();
			var c2 = _context.GetComponent<ContractAgnosticComponent>();

			Assert.AreSame(c0, c1);
			Assert.AreSame(c0, c2);
			Assert.AreSame(c1, c2);
		}

		[TestMethod]
		public void QueryTwoTimesByContract()
		{
			var c0 = _context.GetComponent<ISomeContract>();
			var c1 = _context.GetComponent<ISomeContract>();

			Assert.AreSame(c0, c1);
		}

		[TestMethod]
		public void QueryTwoTimesBySelf()
		{
			var c0 = _context.GetComponent<ContractAgnosticComponent>();
			var c1 = _context.GetComponent<ContractAgnosticComponent>();

			Assert.AreSame(c0, c1);
		}

		[TestMethod]
		public void QueryTwoTimesIndirect()
		{
			_context.Register(typeof(ContractAgnosticComponentWithPlugs));
			_context.Register(typeof(DefaultCacheComponent));
			_context.Register(typeof(UncachedComponent));

			var all = _context.GetAllComponents<ContractAgnosticComponentWithPlugs>();
			Assert.IsNotNull(all);
			Assert.IsTrue(all.Count() == 2);

			var allArray = all.ToArray();
			var c0 = allArray[0];
			var c1 = allArray[1];
			Assert.AreNotSame(c0, c1);
			Assert.AreSame(c0.ContractAgnosticComponent, c1.ContractAgnosticComponent);
		}
	}
}
