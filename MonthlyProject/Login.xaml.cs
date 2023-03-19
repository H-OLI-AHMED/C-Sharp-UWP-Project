using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MonthlyProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            StorageFolder appFolder = ApplicationData.Current.LocalFolder;
            loc2.Text = "Path: " + appFolder.Path;
            loc1.Text = "Path: " + appFolder.Path;
            CreateTextFile2();




        }
        private void login(object sender, RoutedEventArgs e)
        {
            bool isInLandscapeMode = 
 Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Orientation ==
 Windows.UI.ViewManagement.ApplicationViewOrientation.Landscape;
            if (!isInLandscapeMode)
                GetRecords();
            else
                GetRecordLanscapes();
        }
        public async Task GetRecords()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("users.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 1)
                        {
                            if (l[0] == user.Text && l[1] == pass.Password)
                            {
                                this.Frame.Navigate(typeof(MainPage));
                                return;
                            }

                        }
                    }
                    error1.Text = "Invalid User Name or Password. Please try again .....";
                }

            }
            catch (Exception)
            {

            }

        }
        public async Task GetRecordLanscapes()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("users.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 1)
                        {
                            if (l[0] == tuser.Text && l[1] == tpass.Password)
                            {
                                this.Frame.Navigate(typeof(MainPage));
                                return;
                            }

                        }
                    }
                    error2.Text = "Invalid User Name or Password. Please try again .....";
                }

            }
            catch (Exception)
            {

            }

        }
        private void CreateTextFile2()
        {
            CreateTextFile();
        }
        private async Task CreateTextFile()
        {

            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
            if (!File.Exists(storageFolder.Path + "\\sample.txt"))
            {
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                string s = "OLI AHMED,1268129,CS/DITC-M/51/01,1,CHATTOGRAM,100,17 Apr 2022,OLI AHMED.jpg" + Environment.NewLine +
    "Md.Tahsinur Rahman,1269356,CS/DITC-M/51/01,2,CHATTOGRAM,100,17 Apr 2022,Md.Tahsinur Rahman.jpg" + Environment.NewLine + "Mohammad Forkan Uddin,1269400,CS/DITC-M/51/01,3,COMILLA,100,17 Apr 2022,Mohammad Forkan Uddin.jpg" + Environment.NewLine + "Mohammad Naim,1269492,CS/DITC-M/51/01,4,CHATTOGRAM,100,17 Apr 2022,Mohammad Naim.jpg" + Environment.NewLine + "Ariful Islam,1269868,CS/DITC-M/51/01,5,CHATTOGRAM,100,17 Apr 2022,Ariful Islam.jpg" + Environment.NewLine + "MD NASIR UDDIN,1269930,CS/DITC-M/51/01,6,CHATTOGRAM,100,17 Apr 2022,MD NASIR UDDIN.jpg" + Environment.NewLine + "Riyaz Uddin,1269943,CS/DITC-M/51/01,7,CHATTOGRAM,100,17 Apr 2022,Riyaz Uddin.jpg" + Environment.NewLine + "MD.NURUL ISLAM,1269356,CS/DITC-M/51/01,8,CHATTOGRAM,100,17 Apr 2022,MD.NURUL ISLAM.jpg" + Environment.NewLine + "HAMIM HASNAT SHAUN,1270040,CS/DITC-M/51/01,9,CHATTOGRAM,100,17 Apr 2022,HAMIM HASNAT SHAUN.jpg";
                var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Ariful Islam.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/HAMIM HASNAT SHAUN.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Mohammad Naim.JPG"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/MD NASIR UDDIN.JPG"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/MD.NURUL ISLAM.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Md.Tahsinur Rahman.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Mohammad Forkan Uddin.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/OLI AHMED.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Riyaz Uddin.jpg"));
                if (file != null)
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
               
                await Windows.Storage.FileIO.AppendTextAsync(sampleFile, s + Environment.NewLine);
                Windows.Storage.StorageFile sampleFile2 = await storageFolder.CreateFileAsync("users.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                s = "AHMED,947" + Environment.NewLine;


                await Windows.Storage.FileIO.AppendTextAsync(sampleFile2, s + Environment.NewLine);
            }
        }
    }
}
