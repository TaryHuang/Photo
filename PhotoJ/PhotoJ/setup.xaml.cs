using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TARY_Library_Silverlight;
namespace PhotoJ
{
    public partial class setup : PhoneApplicationPage
    {

        public ButtonListR SizeBtn;//自動調整 大小模式



        public setup()
        {
            InitializeComponent();

            Init();
        }

        public void Init(){
            //相片大小調整
            string[] strSize = new string[] { "不調整", "1920", "1600", "1366", "1280", "1024(建議)", "800", "600" };
            SizeBtn = new ButtonListR("相片調整 :",this,strSize,MainPage.SetupDB.CTYPE);


            ContentPanel.Children.Add(SizeBtn);


        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            // Look to see if the tile already exists and if so, don't try to create again.
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("DefaultTitle=FromTile"));

            // Create the tile if we didn't find it already exists.
            if (TileToFind == null)
            {
                // Create the tile object and set some initial properties for the tile.
                // The Count value of 12 will show the number 12 on the front of the Tile. Valid values are 1-99.
                // A Count value of 0 will indicate that the Count should not be displayed.
                StandardTileData NewTileData = new StandardTileData
                {
                    BackgroundImage = new Uri("Red.jpg", UriKind.Relative),
                    Title = "",
                    Count = 0,
                    BackTitle = "哈摟",
                    BackContent = "Welcome to the back of the Tile",
                    BackBackgroundImage = new Uri("Blue.jpg", UriKind.Relative)
                };

                // Create the tile and pin it to Start. This will cause a navigation to Start and a deactivation of our application.
                try
                {
                    ShellTile.Create(new Uri("/MainPage.xaml?INDEX=Camera", UriKind.Relative), NewTileData);
                }
                catch
                {

                }
            }

        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            // Find the tile we want to delete.
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("DefaultTitle=FromTile"));

            // If tile was found, then delete it.
            if (TileToFind != null)
            {
                TileToFind.Delete();
            }
        }



        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainPage.SetupDB.CTYPE = SizeBtn.Index;
            MainPage.tDBHandler.SubmitChanges();
        }



    }
}