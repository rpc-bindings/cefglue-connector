using System;
using System.Linq;
using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Common;
using DSerfozo.CefGlue.Contract.Renderer;
using Xilium.CefGlue;
using CefV8PropertyAttribute = DSerfozo.CefGlue.Contract.Renderer.CefV8PropertyAttribute;

namespace DSerfozo.CefGlue.Renderer
{
    internal sealed class CefV8ValueImpl : CefBase<CefV8Value>, ICefV8Value
    {
        public bool IsString => Wrapped.IsString;
        public bool HasException => Wrapped.HasException;
        public bool IsBool => Wrapped.IsBool;
        public bool IsDouble => Wrapped.IsDouble;
        public bool IsInt => Wrapped.IsInt;
        public bool IsUInt => Wrapped.IsUInt;
        public bool IsDate => Wrapped.IsDate;
        public bool IsArray => Wrapped.IsArray;
        public bool IsFunction => Wrapped.IsFunction;
        public bool IsObject => Wrapped.IsObject;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CefV8ValueImpl(CefV8Value wrapped) : base(wrapped)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetStringValue()
        {
            return Wrapped.GetStringValue();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetBoolValue()
        {
            return Wrapped.GetBoolValue();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefV8Value ExecuteFunction(ICefV8Value obj, ICefV8Value[] arguments)
        {
            return new CefV8ValueImpl(Wrapped.ExecuteFunction(obj?.Unwrap<CefV8Value>(),
                arguments.Select(_ => _.Unwrap<CefV8Value>()).ToArray()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefV8Exception GetException()
        {
            return new CefV8ExceptionImpl(Wrapped.GetException());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearException()
        {
            Wrapped.ClearException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefV8Value GetValue(string key)
        {
            return new CefV8ValueImpl(Wrapped.GetValue(key));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefUserData GetUserData()
        {
            var impl = Wrapped.GetUserData() as CefUserDataImpl;
            return impl?.UserData;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefV8Value ExecuteFunctionWithContext(ICefV8Context context, ICefV8Value obj, ICefV8Value[] arguments)
        {
            return new CefV8ValueImpl(Wrapped.ExecuteFunctionWithContext(context.Unwrap<CefV8Context>(),
                obj?.Unwrap<CefV8Value>(), arguments.Select(_ => _.Unwrap<CefV8Value>()).ToArray()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetUserData(ICefUserData userData)
        {
            Wrapped.SetUserData(new CefUserDataImpl(userData));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetDoubleValue()
        {
            return Wrapped.GetDoubleValue();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetIntValue()
        {
            return Wrapped.GetIntValue();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetUIntValue()
        {
            return Wrapped.GetUIntValue();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DateTime GetDateValue()
        {
            return Wrapped.GetDateValue();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetArrayLength()
        {
            return Wrapped.GetArrayLength();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetKeys(out string[] keys)
        {
            return Wrapped.TryGetKeys(out keys);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICefV8Value GetValue(int index)
        {
            return new CefV8ValueImpl(Wrapped.GetValue(index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(string key, ICefV8Value value)
        {
            Wrapped.SetValue(key, value.Unwrap<CefV8Value>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(int index, ICefV8Value value)
        {
            Wrapped.SetValue(index, value.Unwrap<CefV8Value>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(string key, ICefV8Value value, CefV8PropertyAttribute attributes)
        {
            Wrapped.SetValue(key, value.Unwrap<CefV8Value>(), (Xilium.CefGlue.CefV8PropertyAttribute) attributes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSame(ICefV8Value cefV8Value)
        {
            return Wrapped.IsSame(cefV8Value.Unwrap<CefV8Value>());
        }
    }
}
