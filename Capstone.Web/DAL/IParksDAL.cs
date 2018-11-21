using System.Collections.Generic;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IParksDAL
    {
        IList<Park> GetParks();

        Park GetPark(string parkCode);

        List<WeatherForecast> GetWeatherForecasts(Park park);
    }
}
