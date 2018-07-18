using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        public string ConnectionString { get; set; }

        public SurveyDAL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IList<SurveyResult> GetSurveyResults()
        {
            IList<SurveyResult> results = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();

                    string sql = @"SELECT survey_result.parkCode, park.parkName, COUNT(survey_result.parkCode) AS survey_count FROM survey_result
                                    JOIN park ON park.parkCode = survey_result.parkCode
                                    GROUP BY survey_result.parkCode, parkName
                                    HAVING COUNT(survey_result.parkCode) > 0
                                    ORDER BY COUNT(survey_result.parkCode) DESC";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult result = new SurveyResult();

                        GetResultFromRow(reader, result);

                        results.Add(result);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return results;
        }

        private static void GetResultFromRow(SqlDataReader reader, SurveyResult result)
        {
            result.ParkName = Convert.ToString(reader["parkName"]);
            result.ParkCode = Convert.ToString(reader["parkCode"]);
            result.SurveyCount = Convert.ToInt32(reader["survey_count"]);
        }
    }
}
