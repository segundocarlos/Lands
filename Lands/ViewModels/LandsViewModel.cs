

namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {




        #region services
        private ApiService apiService;


        #endregion

        #region Attributes

        //private List<Land> lands;
        // no debe ser una lista sencilla debe ser una lista que se va a pintar  y refrescar, por eso debe ser una observable collections

        private ObservableCollection<Land> lands;

        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        #endregion

        #region constructors

        public LandsViewModel()
        {

            this.apiService = new ApiService();
            this.LoadLands();
        }



        #endregion


        #region Methods
        private async void LoadLands()
        {


            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }


            var response = await this.apiService.GetList<Land>("http://restcountries.eu",
                                                                "/rest",
                                                                "/v2/all");

            if(!response.IsSuccess )
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;

            }

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list); // transformar a una lista observable para pintarla en la pantalla 
        }



        #endregion
    }
}
