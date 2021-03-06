using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BusInformation
{
    public class Bus : INotifyPropertyChanged
    {
        public int _busID;
        public int BusID
        {
            get => this._busID;
            set
            {
                this._busID = value;
                this.OnPropertyChanged(nameof(BusID));
            }
        }

        public string _busName;
        public string BusName
        {
            get => this._busName;
            set
            {
                this._busName = value;
                this.OnPropertyChanged(nameof(BusName));

            }
        }

        public string _busNumber;
        public string BusNumber
        {
            get => this._busNumber;
            set
            {
                this._busNumber = value;
                this.OnPropertyChanged(nameof(BusNumber));

            }
        }


        public string _busCategory;
        public string BusCategory
        {
            get => this._busCategory;
            set
            {
                this._busCategory = value;
                this.OnPropertyChanged(nameof(BusCategory));

            }
        }

        public string _numberOfSeats;
        public string NumberOfSeats
        {
            get => this._numberOfSeats;
            set
            {
                this._numberOfSeats = value;
                this.OnPropertyChanged(nameof(NumberOfSeats));

            }
        }

        public string _route;


        public string Route
        {
            get => this._route;
            set
            {
                this._route = value;
                this.OnPropertyChanged(nameof(Route));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
