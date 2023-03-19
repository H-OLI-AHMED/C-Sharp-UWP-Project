using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyProject
{
    public class Items : INotifyPropertyChanged
    {
        public string NAME { get; set; }
        public string _Name;
        public string ID
        {
            get => this._Name;
            set
            {
                this._Name = value;
                this.OnPropertyChanged(nameof(NAME));
            }
        }
        public string _batch;
        public string BATCH
        {
            get => this._batch;
            set
            {
                this._batch = value;
                this.OnPropertyChanged(nameof(BATCH));
            }
        }
        public double _slon;
        public double SLNO
        {
            get => this._slon;
            set
            {
                this._slon = value;
                this.OnPropertyChanged(nameof(SLNO));
            }
        }
        public string _address;
        public string ADDRESS
        {
            get => this._address;
            set
            {
                this._address = value;
                this.OnPropertyChanged(nameof(ADDRESS));
            }
        }

        public double _amount;
        public double AMOUNT
        {
            get => this._amount;
            set
            {
                this._amount = value;
                this.OnPropertyChanged(nameof(AMOUNT));
            }
        }
        public string _date;
        public string DATE
        {
            get => this._date;
            set
            {
                this._date = value;
                this.OnPropertyChanged(nameof(DATE));
            }
        }
        public string _image;
        public string IMAGE
        {
            get => this._image;
            set
            {
                this._image = value;
                this.OnPropertyChanged(nameof(IMAGE));
            }
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
    }
}
