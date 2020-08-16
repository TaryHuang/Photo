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
using System.Windows.Media.Imaging;
using System.Windows.Controls.Common;
namespace PhotoJ
{
    public partial class selectType : PhoneApplicationPage
    {




        ImgBtn temp;

        public selectType()
        {
            InitializeComponent();








            for (int i = 0; i < selectTypeList.P0.Count();i+=2 )
            {
                gImg G = new gImg();
                P0.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P0[i], new Uri("images/" + selectTypeList.P0[i][0].ToString() + "/" + selectTypeList.P0[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i+1) <= selectTypeList.P0.Count()-1)
                {
                    ImgBtn I2 = new ImgBtn(this,selectTypeList.P0[i + 1], new Uri("images/" + selectTypeList.P0[i][0].ToString() + "/" + selectTypeList.P0[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }
                
            }










            for (int i = 0; i < selectTypeList.P1.Count(); i += 2)
            {
                gImg G = new gImg();
                P1.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P1[i], new Uri("images/" + selectTypeList.P1[i][0].ToString() + "/" + selectTypeList.P1[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P1.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P1[i + 1], new Uri("images/" + selectTypeList.P1[i][0].ToString() + "/" + selectTypeList.P1[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }







            for (int i = 0; i < selectTypeList.P2.Count(); i += 2)
            {
                gImg G = new gImg();
                P2.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P2[i], new Uri("images/" + selectTypeList.P2[i][0].ToString() + "/" + selectTypeList.P2[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P2.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P2[i + 1], new Uri("images/" + selectTypeList.P2[i][0].ToString() + "/" + selectTypeList.P2[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }






            for (int i = 0; i < selectTypeList.P3.Count(); i += 2)
            {
                gImg G = new gImg();
                P3.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P3[i], new Uri("images/" + selectTypeList.P3[i][0].ToString() + "/" + selectTypeList.P3[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P3.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P3[i + 1], new Uri("images/" + selectTypeList.P3[i][0].ToString() + "/" + selectTypeList.P3[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }














            //@@@@@@






            for (int i = 0; i < selectTypeList.P4.Count(); i += 2)
            {
                gImg G = new gImg();
                P4.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P4[i], new Uri("images/" + selectTypeList.P4[i][0].ToString() + "/" + selectTypeList.P4[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P4.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P4[i + 1], new Uri("images/" + selectTypeList.P4[i][0].ToString() + "/" + selectTypeList.P4[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }





            for (int i = 0; i < selectTypeList.P5.Count(); i += 2)
            {
                gImg G = new gImg();
                P5.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P5[i], new Uri("images/" + selectTypeList.P5[i][0].ToString() + "/" + selectTypeList.P5[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P5.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P5[i + 1], new Uri("images/" + selectTypeList.P5[i][0].ToString() + "/" + selectTypeList.P5[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }




            for (int i = 0; i < selectTypeList.P6.Count(); i += 2)
            {
                gImg G = new gImg();
                P6.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P6[i], new Uri("images/" + selectTypeList.P6[i][0].ToString() + "/" + selectTypeList.P6[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P6.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P6[i + 1], new Uri("images/" + selectTypeList.P6[i][0].ToString() + "/" + selectTypeList.P6[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }


            for (int i = 0; i < selectTypeList.P7.Count(); i += 2)
            {
                gImg G = new gImg();
                P7.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P7[i], new Uri("images/" + selectTypeList.P7[i][0].ToString() + "/" + selectTypeList.P7[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P7.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P7[i + 1], new Uri("images/" + selectTypeList.P7[i][0].ToString() + "/" + selectTypeList.P7[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }





            for (int i = 0; i < selectTypeList.P8.Count(); i += 2)
            {
                gImg G = new gImg();
                P8.Items.Add(G);



                ImgBtn I1 = new ImgBtn(this, selectTypeList.P8[i], new Uri("images/" + selectTypeList.P8[i][0].ToString() + "/" + selectTypeList.P8[i] + ".png", UriKind.RelativeOrAbsolute));
                I1.SetValue(Grid.ColumnProperty, 0);
                I1.MouseLeftButtonUp += I_MouseLeftButtonUp;
                G.Children.Add(I1);

                if ((i + 1) <= selectTypeList.P8.Count() - 1)
                {
                    ImgBtn I2 = new ImgBtn(this, selectTypeList.P8[i + 1], new Uri("images/" + selectTypeList.P8[i][0].ToString() + "/" + selectTypeList.P8[i + 1] + ".png", UriKind.RelativeOrAbsolute));
                    I2.SetValue(Grid.ColumnProperty, 1);
                    I2.MouseLeftButtonUp += I_MouseLeftButtonUp;
                    G.Children.Add(I2);
                }

            }


        }

        void I_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImgBtn btn = sender as ImgBtn;

            if(temp==null){
                temp = btn;
                return;
            }



            if (btn != temp)
            {
                temp.unLock();

                temp = btn;
            }
        }












        class gImg : Grid
        {
            public gImg()
            {
                ColumnDefinition Col1 =new ColumnDefinition();
                Col1.Width = new GridLength(225);
                ColumnDefinition Col2 =new ColumnDefinition();
                Col2.Width = new GridLength();


                this.ColumnDefinitions.Add(Col1);
                this.ColumnDefinitions.Add(Col2);
            }
        }




        class ImgBtn : Grid{
            string ID; 
            Image IMG = new Image();

            PhoneApplicationPage page;



            Border B = new Border();


            public void Lock(){
                B.BorderThickness = new Thickness(4, 4, 4, 4);
            }

            public void unLock()
            {
                B.BorderThickness = new Thickness(0, 0, 0, 0);
            }

            public ImgBtn(PhoneApplicationPage Page,string id, Uri URI)
            {
                page = Page;
                this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                this.Margin = new Thickness(0, 0, 0, 50);
                ID = id;

                BitmapImage Bimg = new BitmapImage(URI);
                IMG.Source = Bimg;

                
                if (id[0] == 'P')
                {
                    IMG.Width = 160;
                    IMG.Height = 225;
                }
                else if (id[0] == 'L')
                {
                    IMG.Width = 200;
                    IMG.Height = 142;
                }
                else if (id == "S0A")
                {
                    IMG.Width = 160;
                    IMG.Height = 225;

                }
                else if (id == "S0B")
                {
                    IMG.Width = 200;
                    IMG.Height = 142;

                }
                else if (id == "S0C")
                {
                    IMG.Width = 129;
                    IMG.Height = 256;

                }
                else if (id == "S0D")
                {
                    IMG.Width = 220;
                    IMG.Height = 156;


                }
                else if (id == "S0E")
                {
                    IMG.Width = 180;
                    IMG.Height = 253;

                }





                IMG.MouseLeftButtonUp += IMG_MouseLeftButtonUp;

                unLock();
                B.BorderBrush = new SolidColorBrush(Colors.Orange);
                B.Child = IMG;
                this.Children.Add(B);
            }

            void IMG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                if(B.BorderThickness.Top==0){
                    Lock();
                    return;
                }
                switch(ID){


                    case "S0A": Window.OBJ = new Photo_S0A(); break;
                    case "S0B": Window.OBJ = new Photo_S0B(); break;
                    case "S0C": Window.OBJ = new Photo_S0C(); break;
                    case "S0D": Window.OBJ = new Photo_S0D(); break;
                    case "S0E": Window.OBJ = new Photo_S0E(); break;


                    case "P1A": Window.OBJ = new Photo_P1A(); break;
                    case "P1B": Window.OBJ = new Photo_P1B(); break;
                    case "P1C": Window.OBJ = new Photo_P1C(); break;
                    case "P1D": Window.OBJ = new Photo_P1D(); break;
                    case "P1E": Window.OBJ = new Photo_P1E(); break;
                    case "P1F": Window.OBJ = new Photo_P1F(); break;

                    case "L1A": Window.OBJ = new Photo_L1A(); break;
                    case "L1B": Window.OBJ = new Photo_L1B(); break;
                    case "L1C": Window.OBJ = new Photo_L1C(); break;
                    case "L1D": Window.OBJ = new Photo_L1D(); break;
                    case "L1E": Window.OBJ = new Photo_L1E(); break;
                    case "L1F": Window.OBJ = new Photo_L1F(); break;






                    case "P2A": Window.OBJ = new Photo_P2A(); break;
                    case "P2B": Window.OBJ = new Photo_P2B(); break;
                    case "P2C": Window.OBJ = new Photo_P2C(); break;
                    case "P2D": Window.OBJ = new Photo_P2D(); break;
                    case "P2E": Window.OBJ = new Photo_P2E(); break;
                    case "P2F": Window.OBJ = new Photo_P2F(); break;

                    case "L2A": Window.OBJ = new Photo_L2A(); break;
                    case "L2B": Window.OBJ = new Photo_L2B(); break;
                    case "L2C": Window.OBJ = new Photo_L2C(); break;
                    case "L2D": Window.OBJ = new Photo_L2D(); break;
                    case "L2E": Window.OBJ = new Photo_L2E(); break;
                    case "L2F": Window.OBJ = new Photo_L2F(); break;



                    case "P3A": Window.OBJ = new Photo_P3A(); break;
                    case "P3B": Window.OBJ = new Photo_P3B(); break;
                    case "P3C": Window.OBJ = new Photo_P3C(); break;
                    case "P3D": Window.OBJ = new Photo_P3D(); break;
                    case "P3E": Window.OBJ = new Photo_P3E(); break;
                    case "P3F": Window.OBJ = new Photo_P3F(); break;
                    case "P3G": Window.OBJ = new Photo_P3G(); break;
                    case "P3H": Window.OBJ = new Photo_P3H(); break;

                    case "L3A": Window.OBJ = new Photo_L3A(); break;
                    case "L3B": Window.OBJ = new Photo_L3B(); break;
                    case "L3C": Window.OBJ = new Photo_L3C(); break;
                    case "L3D": Window.OBJ = new Photo_L3D(); break;
                    case "L3E": Window.OBJ = new Photo_L3E(); break;
                    case "L3F": Window.OBJ = new Photo_L3F(); break;
                    case "L3G": Window.OBJ = new Photo_L3G(); break;
                    case "L3H": Window.OBJ = new Photo_L3H(); break;







                    case "P4A": Window.OBJ = new Photo_P4A(); break;
                    case "P4B": Window.OBJ = new Photo_P4B(); break;
                    case "P4C": Window.OBJ = new Photo_P4C(); break;
                    case "P4D": Window.OBJ = new Photo_P4D(); break;
                    case "P4E": Window.OBJ = new Photo_P4E(); break;
                    case "P4F": Window.OBJ = new Photo_P4F(); break;


                    case "L4A": Window.OBJ = new Photo_L4A(); break;
                    case "L4B": Window.OBJ = new Photo_L4B(); break;
                    case "L4C": Window.OBJ = new Photo_L4C(); break;
                    case "L4D": Window.OBJ = new Photo_L4D(); break;
                    case "L4E": Window.OBJ = new Photo_L4E(); break;
                    case "L4F": Window.OBJ = new Photo_L4F(); break;
                    case "L4G": Window.OBJ = new Photo_L4G(); break;
                    case "L4H": Window.OBJ = new Photo_L4H(); break;



                    case "P5A": Window.OBJ = new Photo_P5A(); break;
                    case "P5B": Window.OBJ = new Photo_P5B(); break;
                    case "P5C": Window.OBJ = new Photo_P5C(); break;
                    case "P5D": Window.OBJ = new Photo_P5D(); break;
                    case "P5E": Window.OBJ = new Photo_P5E(); break;
                    case "P5F": Window.OBJ = new Photo_P5F(); break;

                    case "L5A": Window.OBJ = new Photo_L5A(); break;
                    case "L5B": Window.OBJ = new Photo_L5B(); break;
                    case "L5C": Window.OBJ = new Photo_L5C(); break;
                    case "L5D": Window.OBJ = new Photo_L5D(); break;
                    case "L5E": Window.OBJ = new Photo_L5E(); break;
                    case "L5F": Window.OBJ = new Photo_L5F(); break;
                    case "L5G": Window.OBJ = new Photo_L5G(); break;




                    case "P6A": Window.OBJ = new Photo_P6A(); break;
                    case "P6B": Window.OBJ = new Photo_P6B(); break;
                    case "P6C": Window.OBJ = new Photo_P6C(); break;
                    case "P6D": Window.OBJ = new Photo_P6D(); break;
                    //case "P6E": Window.OBJ = new Photo_P6E(); break;
                    case "L6A": Window.OBJ = new Photo_L6A(); break;
                    case "L6B": Window.OBJ = new Photo_L6B(); break;
                    case "L6C": Window.OBJ = new Photo_L6C(); break;



                    case "P7A": Window.OBJ = new Photo_P7A(); break;
                    case "P7B": Window.OBJ = new Photo_P7B(); break;
                    case "P7C": Window.OBJ = new Photo_P7C(); break;
                    case "P7D": Window.OBJ = new Photo_P7D(); break;

                    case "L7A": Window.OBJ = new Photo_L7A(); break;
                    case "L7B": Window.OBJ = new Photo_L7B(); break;
                    case "L7C": Window.OBJ = new Photo_L7C(); break;
                    case "L7D": Window.OBJ = new Photo_L7D(); break;
                    case "L7E": Window.OBJ = new Photo_L7E(); break;
                    case "L7F": Window.OBJ = new Photo_L7F(); break;




                    case "P8A": Window.OBJ = new Photo_P8A(); break;
                    case "P8B": Window.OBJ = new Photo_P8B(); break;

                    case "L8A": Window.OBJ = new Photo_L8A(); break;
                    //case "P8D": Window.OBJ = new Photo_P8D(); break;
                    default: Window.OBJ = new Photo_P1A(); break;
                }

                page.NavigationService.Navigate(new Uri("/Window.xaml", UriKind.Relative));
            }
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (MainPage.ClosePhoto)
            {
                NavigationService.GoBack();
            }
        }
    }
}