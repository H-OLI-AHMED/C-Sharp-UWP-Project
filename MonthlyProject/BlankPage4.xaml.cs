using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class BlankPage4 : Page
    {
        Project2 newProject = new Project2();
        public BlankPage4()
        {
            this.InitializeComponent();
            PopulateProjects();
        }
        private void PopulateProjects()
        {
            List<Project2> Projects = new List<Project2>();
            GetRecords();
            
            Projects.Add(newProject);

            

            cvsProjects.Source = Projects;
        }
        public async Task GetRecords()
        {

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
                            if (File.Exists(ApplicationData.Current.LocalFolder.Path + "\\" + l[7]))
                            {
                                img = Path.Combine(ApplicationData.Current.LocalFolder.Path, l[7]);
                            }
                            else
                            {
                                img = "OLI AHMED.jpg"; img = "Md.Tahsinur Rahman.jpg"; img = "Mohammad Forkan Uddin.jpg"; img = "Mohammad Naim.jpg";
                                img = "Ariful Islam.jpg"; img = "MD NASIR UDDIN.jpgg"; img = "Riyaz Uddin.jpg"; img = "MD.NURUL ISLAM.jpg";
                                img = "HAMIM HASNAT SHAUN.jpg";
                            }
                            newProject.Activities.Add(new Items() { NAME = l[0], ID = l[1], BATCH = l[2], SLNO = double.Parse(l[3]), ADDRESS = (l[4]), AMOUNT = double.Parse(l[5]), DATE = l[6], IMAGE = img });
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }
            
        }
        private void dowork(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));

        }

        private void dowork2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void clickMe(object sender, RoutedEventArgs e)
        {            
            this.Frame.Navigate(typeof(MainPage));
        }
    }

    public class Project2
    {
        public Project2()
        {
            Activities = new ObservableCollection<Items>();
        }

        public ObservableCollection<Items> Activities { get;  set; }
    }
}
