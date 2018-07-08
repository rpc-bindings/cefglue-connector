using System.Linq;
using DSerfozo.CefGlue.Contract.Renderer;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Renderer
{
    internal sealed class CefV8HandlerImpl : CefV8Handler
    {
        private readonly ICefV8Handler handler;

        public CefV8HandlerImpl(ICefV8Handler handler)
        {
            this.handler = handler;
        }

        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue,
            out string exception)
        {
            var res = handler.Execute(name, obj == null ? null : new CefV8ValueImpl(obj),
                arguments.Select(_ => new CefV8ValueImpl(_) as ICefV8Value).ToArray(), out var returnValueWrapped, out exception);
            returnValue = returnValueWrapped?.Unwrap<CefV8Value>();
            return res;
        }
    }
}
