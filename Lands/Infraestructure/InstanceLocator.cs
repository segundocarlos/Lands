
namespace Lands.Infraestructure
{

    using ViewModels;

    public class InstanceLocator
    {


        #region propiedades

        public MainViewModel Main
        {
            get;
            set;
        }

        #endregion

        #region costructores

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }

        #endregion

    }
}
