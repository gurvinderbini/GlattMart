using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using GlattMart.Helper;
using GlattMart.Helpers;
using GlattMart.Models;
using GlattMart.Pages;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GlattMart.PageModels
{
    public class LoginPageModel:FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        public SignInValidatorModel UserObj { get; set; }
        ServiceResponse<string> data = new ServiceResponse<String>();
        private string _username;
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("UserName");
                //this.Set(ref this._username, value, "UserName");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
                //this.Set(ref this._password, value, "Password");
            }
        }
        //private string _confirmPassword;
        //public string ConfirmPassword
        //{
        //    get
        //    {
        //        return _confirmPassword;
        //    }
        //    set
        //    {

        //        OnPropertyChanged("");
        //       // this.Set(ref this._confirmPassword, value, "ConfirmPassword");
        //    }
        //}


        private readonly IValidator _validator;
        public LoginPageModel()
        {
            _validator = new SinginValidator();
        }
        private Command signInCommand;
        public Command SignInCommand
        {
            get
            {
                return signInCommand ?? (signInCommand = new Command(ExecuteSignInCommand));
            }
        }
        private string _validateMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ValidateMessage
        {
            get
            {
                return _validateMessage;
            }
            set
            {
                _validateMessage = value;
                OnPropertyChanged("ValidateMessage");
                //this.Set(ref this._validateMessage, value, "ValidateMessage");
            }
        }
        protected async void ExecuteSignInCommand()
        {
            //if (_username == null || _password == null)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Alert", "Please enter bith fields and try again", "OK");
            //    return;
            //}
            UserObj = new SignInValidatorModel
            {
                UserName = _username,
                Password = _password,

            };
            var validationResult = _validator.Validate(UserObj);
            if (validationResult.IsValid)
            {
               
                await Task.Factory.StartNew(() =>
                {
                    DependencyService.Get<IProgressbar>().Show("");
                    LoginParamModel param = new LoginParamModel();
                    param.token = ConstantData.token;
                    param.username = UserName;
                    param.password = Password;
                    data = ServiceManager.GenericRestCallUsingHttpClient<string, LoginParamModel>("account/login", HttpMethod.Post, param);
                });
                DependencyService.Get<IProgressbar>().Hide();
                if (data != null)
                {
                    if (data.Data != null)
                    {
                        var resultSet = JsonConvert.DeserializeObject<LoginResponseModel>(data.Data);
                        if (resultSet.result == true)
                        {
                            Settings.UserName=resultSet.model.firstname+" "+ resultSet.model.lirstname;
                            Settings.Email = resultSet.model.email;
                            //    await Application.Current.MainPage.Navigation.PushAsync(new MainDashBoardPage());
                            await Application.Current.MainPage.Navigation.PopModalAsync();

                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", "Invalid Username or Password, Please try again", "OK");
                        }
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Invalid Username or Password, Please try again", "OK");
                }
            }
            else
            {
                ValidateMessage = "Validation Failes..!!";

                await Application.Current.MainPage.DisplayAlert("Alert", "Please enter bith fields and try again", "OK");
            }
        }
    }
}