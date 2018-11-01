

namespace Lands.ViewModels
{

    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool IsRunning
        {
            get;
            set;
        }

        public bool IsRemembered
        {
            get;
            set;
        }


        #endregion

        #region Command

        public ICommand LoginCommand
        {
            get 
            {
                return new RelayCommand(Login);

            }


        }

        private async void  Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                                          "You must enter an Email",
                                                          "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
               await Application.Current.MainPage.DisplayAlert("Error",
                                                          "You must enter a Password",
                                                          "Accept");
                return;
            }

            if (this.Email != "cf" || this.Password !="123")
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                                           "Email or Password Incorrect",
                                                           "Accept");
                return;
            }


            await Application.Current.MainPage.DisplayAlert("OK",
                                                           "Yeahhh",
                                                           "Accept");

        }


        #endregion


        #region Constructors

        public LoginViewModel()
        {
            this.IsRemembered = true;
        }

        #endregion
    }
}
