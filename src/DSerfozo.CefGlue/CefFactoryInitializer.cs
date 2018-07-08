using System;
using System.Runtime.CompilerServices;
using DSerfozo.CefGlue.Common;
using DSerfozo.CefGlue.Contract.Common;
using DSerfozo.CefGlue.Contract.Renderer;
using DSerfozo.CefGlue.Renderer;
using Xilium.CefGlue;
using CefFactories = DSerfozo.CefGlue.Contract.Common.CefFactories;
using CefRendererFactories = DSerfozo.CefGlue.Contract.Renderer.CefFactories;

namespace DSerfozo.CefGlue
{
    internal static class CefFactoryInitializer
    {
        private static readonly object commonInitLock = new object();
        private static readonly object rendererInitLock = new object();
        private static bool commonInitialized;
        private static bool rendererInitialized;

        public static void InitializeCommon()
        {
            lock (commonInitLock)
            {
                if (!commonInitialized)
                {
                    CefFactories.CreateValue = CreateValue;
                    CefFactories.CreateBinary = CreateBinary;
                    CefFactories.CreateDictionary = CreateDictionary;
                    CefFactories.CreateList = CreateList;
                    CefFactories.CreateProcessMessage = CreateProcessMessage;

                    commonInitialized = true;
                }
            }
        }

        public static void InitializeRenderer()
        {
            lock (rendererInitLock)
            {
                if (!rendererInitialized)
                {
                    CefRendererFactories.CreateArrayValue = CreateArrayValue;
                    CefRendererFactories.CreateBoolValue = CreateBoolValue;
                    CefRendererFactories.CreateDateValue = CreateDateValue;
                    CefRendererFactories.CreateDoubleValue = CreateDoubleValue;
                    CefRendererFactories.CreateFunctionValue = CreateFunctionValue;
                    CefRendererFactories.CreateIntValue = CreateIntValue;
                    CefRendererFactories.CreateNullValue = CreateNullValue;
                    CefRendererFactories.CreateObjectValue = CreateObjectValue;
                    CefRendererFactories.CreateStringValue = CreateStringValue;
                    CefRendererFactories.CurrentContext = CurrentContext;

                    CefGlobals.RuntimeRegisterExtension = RuntimeRegisterExtension;

                    rendererInitialized = true;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RuntimeRegisterExtension(string s, string s1, ICefV8Handler arg3)
        {
            CefRuntime.RegisterExtension(s, s1, new CefV8HandlerImpl(arg3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Context CurrentContext()
        {
            return new CefV8ContextImpl(CefV8Context.GetCurrentContext());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateStringValue(string s)
        {
            return new CefV8ValueImpl(CefV8Value.CreateString(s));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateObjectValue()
        {
            return new CefV8ValueImpl(CefV8Value.CreateObject());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateNullValue()
        {
            return new CefV8ValueImpl(CefV8Value.CreateNull());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateIntValue(int i)
        {
            return new CefV8ValueImpl(CefV8Value.CreateInt(i));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateFunctionValue(string s, ICefV8Handler cefV8Handler)
        {
            return new CefV8ValueImpl(CefV8Value.CreateFunction(s, new CefV8HandlerImpl(cefV8Handler)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateDoubleValue(double d)
        {
            return new CefV8ValueImpl(CefV8Value.CreateDouble(d));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateDateValue(DateTime dateTime)
        {
            return new CefV8ValueImpl(CefV8Value.CreateDate(dateTime));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateBoolValue(bool b)
        {
            return new CefV8ValueImpl(CefV8Value.CreateBool(b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefV8Value CreateArrayValue(int i)
        {
            return new CefV8ValueImpl(CefV8Value.CreateArray(i));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefProcessMessage CreateProcessMessage(string name)
        {
            return new CefProcessMessageImpl(CefProcessMessage.Create(name));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefListValue CreateList()
        {
            return new CefListValueImpl(CefListValue.Create());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefDictionaryValue CreateDictionary()
        {
            return new CefDictionaryValueImpl(CefDictionaryValue.Create());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefBinaryValue CreateBinary(byte[] bytes)
        {
            return new CefBinaryValueImpl(CefBinaryValue.Create(bytes));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ICefValue CreateValue()
        {
            return new CefValueImpl(CefValue.Create());
        }
    }
}
