using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefBinaryValueImpl : CefBase<CefBinaryValue>, ICefBinaryValue
    {
        public long Size => Wrapped.Size;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefBinaryValueImpl(CefBinaryValue wrapped) : base(wrapped)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long GetData(byte[] buffer, long size, int offset)
        {
            return Wrapped.GetData(buffer, size, offset);
        }
    }
}
