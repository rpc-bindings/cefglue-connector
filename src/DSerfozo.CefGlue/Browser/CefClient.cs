using DSerfozo.CefGlue.Common;
using DSerfozo.CefGlue.Contract.Browser;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Browser
{
    public class CefClientBase : Xilium.CefGlue.CefClient
    {
        public ICefClient CefClient { get; }

        public CefClientBase(ICefClient cefClient)
        {
            CefFactoryInitializer.InitializeCommon();

            this.CefClient = cefClient;
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            return CefClient.OnProcessMessageReceived(new CefBrowserImpl(browser),
                (DSerfozo.CefGlue.Contract.Common.CefProcessId) sourceProcess, new CefProcessMessageImpl(message));
        }
    }
}
