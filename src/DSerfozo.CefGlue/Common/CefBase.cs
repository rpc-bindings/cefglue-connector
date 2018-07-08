using System;
using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Contract.Common;

namespace DSerfozo.CefGlue.Common
{
    internal class CefBase<TWrapped> : ICefBase where TWrapped : class, IDisposable
    {
        protected TWrapped Wrapped { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefBase(TWrapped wrapped)
        {
            this.Wrapped = wrapped;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Unwrap<T>() where T : class, IDisposable
        {
            return (T)(object)Wrapped;
        }

        public void Dispose(bool disposing)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Wrapped.Dispose();
        }
    }
}
