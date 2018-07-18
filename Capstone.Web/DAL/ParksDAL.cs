using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
            catch(SqlException ex)
            {
                throw ex;
            }

            return parks;
        }

        public Park GetPark(string parkCode)
        {
            return GetParks().FirstOrDefault(p => p.ParkCode == parkCode);
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
