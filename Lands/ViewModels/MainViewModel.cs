
namespace Lands.ViewModels
{
    public class MainViewModel
    {

        #region ViewModels

        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            instancia = this;
            this.Login = new LoginViewModel();

        }

        #endregion


        #region Singleton
        // para que no se me creen muchas instancias 
        private static MainViewModel instancia;

        public static  MainViewModel ObtenerInstancia()     
        {
            if (instancia == null)
            {
                return new MainViewModel();
            }

            return instancia;
        }

        #endregion
    }
}
