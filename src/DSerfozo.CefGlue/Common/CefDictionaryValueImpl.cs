using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefDictionaryValueImpl : CefBase<CefDictionaryValue>, ICefDictionaryValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefDictionaryValueImpl(CefDictionaryValue wrapped) : base(wrapped)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(string key, ICefValue value)
        {
            Wrapped.SetValue(key, value.Unwrap<CefValue>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBinary(string key, ICefBinaryValue value)
        {
            Wrapped.SetBinary(key, value.Unwrap<CefBinaryValue>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefValue GetValue(string key)
        {
            return new CefValueImpl(Wrapped.GetValue(key));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefDictionaryValue GetDictionary(string key)
        {
            return new CefDictionaryValueImpl(Wrapped.GetDictionary(key));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString(string key)
        {
            return Wrapped.GetString(key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string[] GetKeys()
        {
            return Wrapped.GetKeys();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasKey(string key)
        {
            return Wrapped.HasKey(key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetString(string key, string value)
        {
            Wrapped.SetString(key, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDictionary(string key, ICefDictionaryValue value)
        {
            Wrapped.SetDictionary(key, value.Unwrap<CefDictionaryValue>());
        }
    }
}
