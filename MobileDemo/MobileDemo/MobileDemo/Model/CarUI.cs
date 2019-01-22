using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileDemo.Model
{
    public class CarUI : Car, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CarUI()
        {

        }

        public CarUI(Car car)
        {
            _make = car._make;
            _model = car._model;
            _year = car._year;
        }

        public string Make
        {
            get { return _make; }
            set
            {
                _make = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Make"));
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Model"));
            }
        }

        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Year"));
            }
        }
    }
}
