using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MonthlyProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       public ViewModel viewModel = new ViewModel();
        public MainPage()
        {
            CreateTextFile2();
            this.DataContext = viewModel;
            this.InitializeComponent();
        }

        
        public async Task GetRecords()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("sample.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 6)
                        {
                            var img1 = "";
                            if (File.Exists(ApplicationData.Current.LocalFolder.Path + "\\" + l[7]))
                            {
                                img1 = l[7];
                            }
                            else
                            {
                                img1 = "Images/gray.jpg";
                            }

                            var b = (from c in viewModel.a where c.NAME == tid.Text select c).FirstOrDefault();
                            if (b.NAME != l[0])
                                all += $"{l[0]},{l[1]},{l[2]},{double.Parse(l[3])},{(l[4])},{double.Parse(l[5])},{l[6]},{img1}" + Environment.NewLine;
                            else
                            {
                                img1 = file1.Name;

                                all += $"{tid.Text},{tfname.Text},{tlname.Text},{double.Parse(tfather.Text)},{(tmother.Text)},{double.Parse(tclass.Text)},{taddate.Text},{img1}" + Environment.NewLine;
                            }
                        }
                    }
                    StorageFolder storageFolder =
    ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await storageFolder.GetFileAsync("sample.txt");
                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, all);
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }

        StorageFile file1;
        private async void upload(object sender, RoutedEventArgs e)
        {
            try
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                openPicker.FileTypeFilter.Add(".jpg");
                file1 = await openPicker.PickSingleFileAsync();
                if (file1 != null)
                {

                    await file1.CopyAsync(ApplicationData.Current.LocalFolder, file1.Name, NameCollisionOption.ReplaceExisting);
                    var stream = await file1.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    var image = new BitmapImage();
                    image.SetSource(stream);
                    img.Source = image;
                    img.Stretch = Stretch.UniformToFill;
                    cimg.Source = image;
                    cimg.Stretch = Stretch.UniformToFill;
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void dowork3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage5));
        }

        public async Task RemoveRecords()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("sample.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 6)
                        {
                            var img = "";
                            if (File.Exists(ApplicationData.Current.LocalFolder.Path+"\\"+ l[7]))
                            {
                                img = Path.Combine(ApplicationData.Current.LocalFolder.Path, l[7]);
                            }
                            else
                            {
                                img = "OLI AHMED.jpg"; img = "Md.Tahsinur Rahman.jpg"; img = "Mohammad Forkan Uddin.jpg"; img = "Mohammad Naim.jpg";
                                img = "Ariful Islam.jpg"; img = "MD NASIR UDDIN.jpgg"; img = "Riyaz Uddin.jpg"; img = "MD.NURUL ISLAM.jpg";
                                img = "HAMIM HASNAT SHAUN.jpg";
                            }
                            var b = (from c in viewModel.a where c.NAME == tid.Text select c).FirstOrDefault();
                            if (b.NAME != l[0])
                                all += $"{l[0]},{l[1]},{l[2]},{double.Parse(l[3])},{(l[4])},{double.Parse(l[5])},{l[6]},{img}" + Environment.NewLine;                          
                        }
                    }
                    StorageFolder storageFolder =
    ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await storageFolder.GetFileAsync("sample.txt");
                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, all);
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }

        private void add2(object sender, RoutedEventArgs e)
        {
            
            GetRecords();
            MessageDialog s = new MessageDialog("Saved");
            s.ShowAsync();
        }

        private void del2(object sender, RoutedEventArgs e)
        {
            RemoveRecords();
            MessageDialog s = new MessageDialog("Removed");
            s.ShowAsync();
            this.Frame.Navigate(typeof(BlankPage1));
        }
        private void dowork(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));

        }

        private void dowork2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage4));
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
                file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/ Mohammad Naim.JPG"));
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
