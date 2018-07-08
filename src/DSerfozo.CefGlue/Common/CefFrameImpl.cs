using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefFrameImpl : CefBase<CefFrame>, ICefFrame
    {
        public long Identifier => Wrapped.Identifier;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefFrameImpl(CefFrame wrapped) : base(wrapped)
        {
        }
    }
}
