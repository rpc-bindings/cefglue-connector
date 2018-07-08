using System;
using DSerfozo.CefGlue.Contract.Common;
using Xilium.CefGlue;
using CefProcessId = DSerfozo.CefGlue.Contract.Common.CefProcessId;

namespace DSerfozo.CefGlue.Common
{
    internal sealed class CefBrowserImpl : CefBase<CefBrowser>, ICefBrowser
    {
        public int Identifier => Wrapped.Identifier;

        public CefBrowserImpl(CefBrowser browser)
            : base(browser)
        {
        }

        public void SendProcessMessage(CefProcessId processId, ICefProcessMessage message)
        {
            Wrapped.SendProcessMessage((Xilium.CefGlue.CefProcessId)processId, message.Unwrap<CefProcessMessage>());
        }
    }
}
