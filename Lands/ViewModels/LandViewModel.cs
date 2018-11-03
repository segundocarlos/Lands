
namespace Lands.ViewModels
{
    using Models;
    public class LandViewModel
    {

        #region properties
        public Land Land
        {
            get;
            set;
        }

        #endregion


        #region constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
        }
        #endregion
    }
}
