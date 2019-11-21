using System;
using ComposerCore.Attributes;

namespace ComposerCore.Tests.Features.Components
{
    [Contract, Component, Transient]
    public class NonDisposableTransientComponent : IDisposable
    {
        public bool Disposed { get; private set; }
        
        public void Dispose()
        {
            Disposed = true;
        }
    }
}