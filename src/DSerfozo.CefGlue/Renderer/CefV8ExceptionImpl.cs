using DSerfozo.CefGlue.Common;
using DSerfozo.CefGlue.Contract.Renderer;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Renderer
{
    internal sealed class CefV8ExceptionImpl : CefBase<CefV8Exception>, ICefV8Exception
    {
        public string Message => Wrapped.Message;

        public CefV8ExceptionImpl(CefV8Exception wrapped) : base(wrapped)
        {
        }
    }
}
