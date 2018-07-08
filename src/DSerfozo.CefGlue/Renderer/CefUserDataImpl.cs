using DSerfozo.CefGlue.Contract.Renderer;
using Xilium.CefGlue;

namespace DSerfozo.CefGlue.Renderer
{
    internal sealed class CefUserDataImpl : CefUserData
    {
        public ICefUserData UserData { get; }

        public CefUserDataImpl(ICefUserData userData)
        {
            this.UserData = userData;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                UserData.Dispose();
            }
        }
    }
}
