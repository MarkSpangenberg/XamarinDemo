using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileDemo.Model
{
    public class Car 
    {
        public Car()
        {

        }

        public Car(Car car)
        {
            _make = car._make;
            _model = car._model;
            _year = car._year;
        }

        public Car(string make, string model, string year)
        {
            _make = make;
            _model = model;
            _year = year;
        }

        public string _make { get; set; }
        public string _model { get; set; }
        public string _year { get; set; }
    }
}
