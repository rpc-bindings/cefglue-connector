using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefRequestImpl : CefBase<CefRequest>, ICefRequest
    {
        public CefRequestImpl(CefRequest wrapped) : base(wrapped)
        {
        }
    }
}
