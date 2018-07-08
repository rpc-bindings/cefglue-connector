using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DSerfozo.CefGlue.Common;
using DSerfozo.CefGlue.Contract.Common;
using DSerfozo.CefGlue.Contract.Renderer;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Renderer
{
    internal sealed class CefV8ContextImpl : CefBase<CefV8Context>, ICefV8Context
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefV8ContextImpl(CefV8Context wrapped) : base(wrapped)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSame(ICefV8Context context)
        {
            return Wrapped.IsSame(context.Unwrap<CefV8Context>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Enter()
        {
            return Wrapped.Enter();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Exit()
        {
            Wrapped.Exit();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefBrowser GetBrowser()
        {
            return new CefBrowserImpl(Wrapped.GetBrowser());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefV8Value GetGlobal()
        {
            return new CefV8ValueImpl(Wrapped.GetGlobal());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefFrame GetFrame()
        {
            return new CefFrameImpl(Wrapped.GetFrame());
        }
    }
}
