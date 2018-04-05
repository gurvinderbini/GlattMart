using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using GlattMart.Helper;
using GlattMart.Models;
using GlattMart.Validator;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GlattMart
{
    public class ForgotPasswordPageModel: FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        public ForgotPasswordParamModel UserObj { get; set; }
        ServiceResponse<string> data = new ServiceResponse<String>();



        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
                //this.Set(ref this._username, value, "UserName");
            }
        }

       


        private readonly IValidator _validator;
        public ForgotPasswordPageModel()
        {
            _validator = new ForgotPasswordValidator();
        }
        private Command signUpCommand;
        public Command SignUpCommand
        {
            get
            {
                return signUpCommand ?? (signUpCommand = new Command(ExecuteSignUpCommand));
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
        protected async void ExecuteSignUpCommand()
        {
            UserObj = new ForgotPasswordParamModel
            {
               
                Email = _email

            };
            var validationResult = _validator.Validate(UserObj);
            if (validationResult.IsValid)
            {

                await Task.Factory.StartNew(() =>
                {
                    DependencyService.Get<IProgressbar>().Show("");
                    ForgotParamModel param = new ForgotParamModel();
                    param.token = ConstantData.token;
                    param.email = Email;
                    data = ServiceManager.GenericRestCallUsingHttpClient<string, ForgotParamModel>("account/forgotPassword", HttpMethod.Post, param);
                });
                DependencyService.Get<IProgressbar>().Hide();
                if (data != null)
                {
                    if (data.Data != null)
                    {
                        var resultSet = JsonConvert.DeserializeObject<List<ForgotPwdResponseModel>>(data.Data);
                        if (resultSet[0].result == true)
                        {
                            var result=  await Application.Current.MainPage.DisplayAlert("Alert", resultSet[0].msg[0], null,"Ok");

                            if(!result)
                            {
                                await Application.Current.MainPage.Navigation.PopAsync();
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", resultSet[0].msg[0], "OK");

                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < validationResult.Errors.Count; i++)
                {
                    ValidateMessage += validationResult.Errors[i] + "\n";
                }
                await Application.Current.MainPage.DisplayAlert("Alert", ValidateMessage, "OK");
            }
        }
    }
}