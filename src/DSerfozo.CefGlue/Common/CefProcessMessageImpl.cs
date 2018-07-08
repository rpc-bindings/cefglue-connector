using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefProcessMessageImpl : CefBase<CefProcessMessage>, ICefProcessMessage
    {
        public ICefListValue Arguments => new CefListValueImpl(Wrapped.Arguments);

        public string Name => Wrapped.Name;

        public CefProcessMessageImpl(CefProcessMessage wrapped) : base(wrapped)
        {
        }
    }
}
