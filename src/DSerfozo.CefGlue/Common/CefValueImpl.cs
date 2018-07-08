using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;
using CefValueType = DSerfozo.CefGlue.Contract.Common.CefValueType;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefValueImpl : CefBase<CefValue>, ICefValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefValueImpl(CefValue wrapped) : base(wrapped)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefListValue GetList()
        {
            return new CefListValueImpl(Wrapped.GetList());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefDictionaryValue GetDictionary()
        {
            return new CefDictionaryValueImpl(Wrapped.GetDictionary());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefBinaryValue GetBinary()
        {
            return new CefBinaryValueImpl(Wrapped.GetBinary());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString()
        {
            return Wrapped.GetString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetInt()
        {
            return Wrapped.GetInt();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetDouble()
        {
            return Wrapped.GetDouble();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBinary(ICefBinaryValue value)
        {
            Wrapped.SetBinary(value.Unwrap<CefBinaryValue>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefValueType GetValueType()
        {
            return (CefValueType) Wrapped.GetValueType();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefValue Copy()
        {
            return new CefValueImpl(Wrapped.Copy());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetNull()
        {
            Wrapped.SetNull();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetList(ICefListValue value)
        {
            Wrapped.SetList(value.Unwrap<CefListValue>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetBool()
        {
            return Wrapped.GetBool();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetString(string value)
        {
            Wrapped.SetString(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetInt(int value)
        {
            Wrapped.SetInt(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDouble(double value)
        {
            Wrapped.SetDouble(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBool(bool value)
        {
            Wrapped.SetBool(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDictionary(ICefDictionaryValue value)
        {
            Wrapped.SetDictionary(value.Unwrap<CefDictionaryValue>());
        }
    }
}
