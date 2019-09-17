﻿using ComposerCore.FluentExtensions;
using ComposerCore.Implementation;
using ComposerCore.Tests.FluentRegistration.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComposerCore.Tests.FluentRegistration
{
    [TestClass]
    public class FluentGenericComposition
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
            _context.Configuration.DisableAttributeChecking = true;
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        #endregion

        [TestMethod]
        public void DirectClosedGeneric()
        {
            _context.ForComponent<ClosedGenericComponent>()
                .RegisterWith<IGenericContract<string>>();

            var c = _context.GetComponent<IGenericContract<string>>();

            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void OpenGeneric()
        {
            _context.ForGenericComponent(typeof(OpenGenericComponent<>))
                .RegisterWith(typeof(IGenericContract<>));

            var c = _context.GetComponent<IGenericContract<string>>();

            Assert.IsNotNull(c);
        }

        [TestMethod]
        [ExpectedException(typeof(CompositionException))]
        public void IncompatibleGenericTypeInContract()
        {
            _context.ForComponent<ClosedGenericComponent>()
                .RegisterWith<IGenericContract<int>>();
        }
    }
}