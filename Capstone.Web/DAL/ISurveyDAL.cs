using System.Collections.Generic;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        IList<SurveyResult> GetSurveyResults();

        void SaveNewSurveyResult(SurveyResult surveyResult);
    }
}
