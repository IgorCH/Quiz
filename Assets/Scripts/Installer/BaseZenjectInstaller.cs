using Scripts.MVC;
using Zenject;

namespace Installer
{
    public class BaseZenjectInstaller : MonoInstaller
    {
        private DiContainerWrapper _container;

        protected DiContainerWrapper DiContainer
        {
            get
            {
                if (_container == null)
                {
                    _container = new DiContainerWrapper(this.Container);
                }

                return _container;
            }
        }
    }
}