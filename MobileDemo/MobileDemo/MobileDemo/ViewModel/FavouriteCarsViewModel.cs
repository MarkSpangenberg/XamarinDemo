using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MobileDemo.Model;
using MobileDemo.Services;

namespace MobileDemo.ViewModel
{
    public class FavouriteCarsViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DevExpress.Mobile.Core.Containers.BindingList<CarUI> Cars { get; set; }
        private CarRepository _carRepository;

        public FavouriteCarsViewModel()
        {
            _carRepository = new CarRepository();
            List<CarUI> tempList = new List<CarUI>();
            foreach (Car car in _carRepository.GetCars())
            {
                CarUI temp = new CarUI(car);
                tempList.Add(temp);
            }
            Cars = new DevExpress.Mobile.Core.Containers.BindingList<CarUI>(tempList);
        }

        public void UpdateData()
        {
            List<Car> tempList = new List<Car>();
            foreach (Car car in Cars)
            {
                Car tempCar = new Car(car);
                tempList.Add(tempCar);
            }

            _carRepository.Update(tempList);
        }
    }
}
