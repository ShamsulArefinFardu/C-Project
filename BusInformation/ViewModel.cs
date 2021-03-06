using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BusInformation
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<Bus> buses;

        public Command NextBus { get; private set; }
        public Command PreviousBus { get; private set; }


        private int currentBus;
        public ViewModel()
        {

            this.currentBus = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;

            this.NextBus = new Command(this.Next, () => this.buses.Count > 1 && !this.IsAtEnd);

            this.PreviousBus = new Command(this.Previous, () => this.buses.Count > 0 && !this.IsAtStart);



            this.buses = new List<Bus>
            {
                new Bus
                {
                    BusID=1,
                    BusName="Turna",
                    BusNumber="100",
                    BusCategory="AC",
                    NumberOfSeats="40",
                    Route="Ctg-Dhaka"
                },

                new Bus
                {
                    BusID=2,
                    BusName="Green Line",
                    BusNumber="200",
                    BusCategory="AC",
                    NumberOfSeats="40",
                    Route="Ctg-Dhaka"
                },

                new Bus
                {
                    BusID=3,
                    BusName="Desh Travels",
                    BusNumber="300",
                    BusCategory="NON-AC",
                    NumberOfSeats="30",
                    Route="Ctg-Syl"
                }


            };
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


        public Bus Current
        {
            get => this.buses.Count > 0 ? this.buses[currentBus] : null;
        }

        private void Next()
        {
            if (this.buses.Count - 1 > this.currentBus)
            {
                this.currentBus++;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtStart = false;
                this.IsAtEnd = (this.buses.Count - 1 == this.currentBus);
            }
        }

        private void Previous()
        {
            if (this.buses.Count > 0)
            {
                this.currentBus--;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentBus == 0);
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
