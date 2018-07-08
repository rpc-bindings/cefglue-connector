using DSerfozo.CefGlue.Common;
using DSerfozo.CefGlue.Contract.Renderer;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Renderer
{
    public class CefRenderProcessHandlerBase : CefRenderProcessHandler
    {
        private readonly ICefRenderProcessHandler renderProcessHandler;

        public CefRenderProcessHandlerBase(ICefRenderProcessHandler renderProcessHandler)
        {
            CefFactoryInitializer.InitializeCommon();
            CefFactoryInitializer.InitializeRenderer();

            this.renderProcessHandler = renderProcessHandler;
        }

        protected override void OnBrowserCreated(CefBrowser browser)
        {
            renderProcessHandler.OnBrowserCreated(new CefBrowserImpl(browser));
        }

        protected override void OnBrowserDestroyed(CefBrowser browser)
        {
            renderProcessHandler.OnBrowserDestroyed(new CefBrowserImpl(browser));
        }

        protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            renderProcessHandler.OnContextCreated(new CefBrowserImpl(browser), new CefFrameImpl(frame), new CefV8ContextImpl(context));
        }

        protected override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            renderProcessHandler.OnContextReleased(new CefBrowserImpl(browser), new CefFrameImpl(frame), new CefV8ContextImpl(context));
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            return renderProcessHandler.OnProcessMessageReceived(new CefBrowserImpl(browser),
                (DSerfozo.CefGlue.Contract.Common.CefProcessId) sourceProcess, new CefProcessMessageImpl(message));
        }

        protected override bool OnBeforeNavigation(CefBrowser browser, CefFrame frame, CefRequest request, CefNavigationType navigation_type,
            bool isRedirect)
        {
            return renderProcessHandler.OnBeforeNavigation(new CefBrowserImpl(browser), new CefFrameImpl(frame),
                new CefRequestImpl(request), (DSerfozo.CefGlue.Contract.Common.CefNavigationType) navigation_type,
                isRedirect);
        }

        protected override void OnWebKitInitialized()
        {
            renderProcessHandler.OnWebKitInitialized();
        }
    }
}
