using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Facebook;
using System.Windows.Media.Imaging;
using TARY_Library_Silverlight;
using TARY_Library_Silverlight.Net;
namespace PhotoJ.Pages
{
    public partial class FacebookLoginPage : PhoneApplicationPage
    {
        private const string AppId = "142645005897423";
        public string _accessToken;
        public string _userId;
        public string _lastMessageId;
        public string _FbName;
        /// <summary>
        /// Extended permissions is a comma separated list of permissions to ask the user.
        /// </summary>
        /// <remarks>
        /// For extensive list of available extended permissions refer to 
        /// https://developers.facebook.com/docs/reference/api/permissions/
        /// </remarks>
        private const string ExtendedPermissions = "user_about_me,read_stream,publish_stream";

        private readonly FacebookClient _fb = new FacebookClient();









        TextBoxR txtMessage;
        TextBlock FbName;
        Button OK;
        Image picProfile;
        public FacebookLoginPage()
        {
            InitializeComponent();



            StackPanel g = new StackPanel();
            g.Orientation = System.Windows.Controls.Orientation.Horizontal;
            picProfile = new Image();
            picProfile.Width = 80;
            g.Children.Add(picProfile);
            


            FbName = new TextBlock();
            FbName.FontSize = 48;
            g.Children.Add(FbName);



            txtBoard.Children.Add(g);

            txtMessage = new TextBoxR(100, "我想說的話..");
            txtMessage.Width = 480;
            txtMessage.Height = 200;
            txtMessage.KeyUp += txtMessage_KeyUp;
            txtBoard.Children.Add(txtMessage);




            OK = new Button();
            OK.Content = "傳  送";
            OK.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            OK.Click+=OK_Click;
            txtBoard.Children.Add(OK);

        }

        void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OK.Focus();
            }
        }










        private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        {
            var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);
            webBoard.Navigate(loginUrl);
        }





        private Uri GetFacebookLoginUrl(string appId, string extendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appId;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "touch";

            // add the 'scope' only if we have extendedPermissions.
            if (!string.IsNullOrEmpty(extendedPermissions))
            {
                // A comma-delimited list of permissions
                parameters["scope"] = extendedPermissions;
            }

            return _fb.GetLoginUrl(parameters);
        }








        private void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }

            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                LoginSucceded(accessToken);
            }
            else
            {
                // user cancelled
                MessageBox.Show(oauthResult.ErrorDescription);
            }
        }



        private void GetUserProfilePicture()
        {
            
            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", _userId, "square", _accessToken);

            picProfile.Source = new BitmapImage(new Uri(profilePictureUrl));
        }





        private void LoginSucceded(string accessToken)
        {
            var fb = new FacebookClient(accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var id = (string)result["id"];

                var url = string.Format("/Pages/FacebookInfoPage.xaml?access_token={0}&id={1}", accessToken, id);

                _accessToken = accessToken;
                _userId = id;
                _FbName = " "+(string)result["name"];




                Dispatcher.BeginInvoke(() => tShow());
            };

            fb.GetAsync("me");
        }


        void tShow()
        {

            FbName.Text = _FbName;
            GetUserProfilePicture();


            txtBoard.Visibility = System.Windows.Visibility.Visible;
            webBoard.Visibility = System.Windows.Visibility.Collapsed;
                
        }







        private void OK_Click(object sender, RoutedEventArgs e)
        {
            OK.IsEnabled = false;
            txtMessage.IsEnabled = false;
            var fb = new FacebookClient(_accessToken);

            fb.PostCompleted += (o, args) =>
            {
                if (args.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)args.GetResultData();
                _lastMessageId = (string)result["id"];

                Dispatcher.BeginInvoke(() =>
                {

                    MessageBox.Show("已傳送至Facebook..");

                    txtMessage.myText = string.Empty;

                    NavigationService.GoBack();
                });
            };





            IDictionary<string, object> parameters = new Dictionary<string, object>();


            //MessageBox.Show(System.DateTime.Now.ToString("yyyy-MM-dd  HH：mm：ss"));
            FacebookMediaStream mediaObject = new FacebookMediaStream
            {
                FileName = DateTime.Now.ToString("yyyy-MM-dd  HH：mm：ss"),
                ContentType = "image/jpg"
            };
            mediaObject.SetValue(makephoto.Sendms);



            parameters.Add("message", txtMessage.myText);
            parameters.Add("access_token", _accessToken);
            parameters.Add("source", mediaObject);

            fb.PostAsync("/me/photos", parameters);
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {

            if (Net.GetNetStates() == "None")
            {
                MessageBox.Show("連線失敗,請檢查網路是否連線..");

                NavigationService.GoBack();
            }

        }
    }
}