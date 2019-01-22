using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MobileDemo.Model;
using Newtonsoft.Json;
using SQLite;

namespace MobileDemo.Services
{
    public class CarRepository
    {
        private SQLiteAsyncConnection _dbContext;

        private const string CarEndpoint = "/api/Car";

        public CarRepository()
        {
            _dbContext = new SQLiteAsyncConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.SQLiteDirectory));
            _dbContext.CreateTableAsync<Car>().Wait();
        }

        /// <summary>
        /// Returns a list of cars, if there is a connection, it is fetched  from the server.
        /// If there is no connection it is fetched from the database.
        /// If the database is empty, it will be populated from test data.
        /// </summary>
        /// <returns></returns>
        public List<Car> GetCars()
        {
            List<Car> cars = GetFromServer();

            if (cars == null || cars.Count == 0)
                cars = GetFromDB();

            if (cars == null || cars.Count == 0)
                cars = GetTestData();

            return cars;
        }

        /// <summary>
        /// A list of test data.
        /// </summary>
        /// <returns></returns>
        public List<Car> GetTestData()
        {
            List<Car> cars = new List<Car>
            {
                new Car("Toyota", "Fortuner", "2019"),
                new Car("Volkswagen", "Polo", "2017"),
                new Car("Ford", "Bantam", "2015")
            };

            SaveItem(cars);

            return cars;
        }

        /// <summary>
        /// Updates the database.
        /// </summary>
        public void Update(List<Car> cars)
        {
            SaveItem(cars);
        }

        private List<Car> GetFromDB()
        {
            Task<List<Car>> carList = _dbContext.QueryAsync<Car>("SELECT * FROM [Car]");
            carList.Wait();

            return carList.Result;
        }

        public void SaveItem(List<Car> cars)
        {
            ClearDatabase();
            foreach (Car car in cars)
            {
                _dbContext.InsertAsync(car).Wait();
            }
            
        }

        /// <summary>
        /// This drops the database, and creates it again. This ensures the database does not fall over when new columns are added.
        /// </summary>
        private void ClearDatabase()
        {
            _dbContext.DropTableAsync<Car>().Wait();
            _dbContext.CreateTableAsync<Car>().Wait();
        }

        private List<Car> GetFromServer()
        {

            string response = null;

            using (var client = new System.Net.Http.HttpClient())
            {

                //Accept Header
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    Task<HttpResponseMessage> result =
                        client.GetAsync(Constants.RestUrl + CarEndpoint);
                    result.Wait();
                    response = result.Result.Content.ReadAsStringAsync().Result;
                }
                catch (AggregateException ae)
                {
                    foreach (Exception e in ae.Flatten().InnerExceptions)
                    {
                        if (e is HttpRequestException)
                        {
                            throw e;
                        }
                        else
                        {
                            throw ae;
                        }
                    }
                }
            }

            return JsonConvert.DeserializeObject<List<Car>>(response);
        }




    }
}
