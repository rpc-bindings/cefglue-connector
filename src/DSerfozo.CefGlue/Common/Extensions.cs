using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Common
{
    public static class Extensions
    {
        public static ICefBrowser ToInterface(this CefBrowser browser)
        {
            return new CefBrowserImpl(browser);
        }
    }
}
