using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace MonthlyProject
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Items> a=new List<Items>();
        private int currentCustomer;
        public Command NextCustomer { get; private set; }
        public Command PreviousCustomer { get; private set; }
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
                                img = "Images/gray.jpg"; 
                            }
                            this.a.Add(new Items() { NAME = l[0], ID = l[1], BATCH = l[2], SLNO = double.Parse(l[3]), ADDRESS =(l[4]), AMOUNT = double.Parse(l[5]), DATE = l[6], IMAGE = img });
                        }
                    }
                    reader.Close();
                }
                
                }
                catch (Exception)
                {
                    
                }
           
        }

        public ViewModel()
        {
            currentCustomer = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;
            this.NextCustomer = new Command(this.Next, () =>
this.a.Count > 1 && !this.IsAtEnd);
            this.PreviousCustomer = new Command(this.Previous, () =>
            this.a.Count > 0 && !this.IsAtStart);
            GetRecords();
        }
            public Items Current
        {
            get => this.a.Count > 0 ? this.a[currentCustomer] :
            null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart;
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }
        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd;
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }
        private void Next()
        {
            if (this.a.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtStart = false;
                this.IsAtEnd = (this.a.Count - 1 == this.currentCustomer);
            }
        }
        private void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentCustomer == 0);
            }

        }
    }
}
