using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefListValueImpl : CefBase<CefListValue>, ICefListValue
    {
        public int Count => Wrapped.Count;

        public CefListValueImpl(CefListValue wrapped) : base(wrapped)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(int index, ICefValue value)
        {
            Wrapped.SetValue(index, value.Unwrap<CefValue>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBinary(int index, ICefBinaryValue value)
        {
            Wrapped.SetBinary(index, value.Unwrap<CefBinaryValue>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefValue GetValue(int index)
        {
            return new CefValueImpl(Wrapped.GetValue(index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetSize(int size)
        {
            Wrapped.SetSize(size);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetBool(int index)
        {
            return Wrapped.GetBool(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString(int index)
        {
            return Wrapped.GetString(index);
        }
    }
}
