using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParksDAL : IParksDAL
    {

        public string ConnectionString { get; set; }

        public ParksDAL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT * FROM park";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        GetParkFromRow(reader, park);

                        parks.Add(park);
                    }
                }
            }
            catch
            {
                return null;
            }

            return parks;
        }

        public Park GetPark(string parkCode)
        {
            return GetParks().FirstOrDefault(p => p.ParkCode == parkCode);
        }

        public List<WeatherForecast> GetWeatherForecasts(Park park)
        {
            List<WeatherForecast> forecasts = new List<WeatherForecast>();

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM weather WHERE parkCode = @parkCode";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", park.ParkCode);
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        WeatherForecast weather = new WeatherForecast();
                        GetForecastFromRow(reader, weather);
                        forecasts.Add(weather);
                    }
                }
            }
            catch
            {
                return null;
            }

            return forecasts;
        }

        private static void GetForecastFromRow(SqlDataReader reader, WeatherForecast weather)
        {
            weather.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(reader["low"]);
            weather.High = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);
        }

        private static void GetParkFromRow(SqlDataReader reader, Park park)
        {
            park.ParkCode = Convert.ToString(reader["parkCode"]);
            park.ParkName = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Acreage = Convert.ToInt32(reader["acreage"]);
            park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
            park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
            park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
            park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.ParkDescription = Convert.ToString(reader["parkDescription"]);
            park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
            park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
        }
    }
}
