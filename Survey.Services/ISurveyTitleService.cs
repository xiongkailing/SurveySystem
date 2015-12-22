using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services
{
    public interface ISurveyTitleService
    {
        SurveyTitle GetById(string id);
        IEnumerable<SurveyTitle> GetAllSurvery();
        void DeleteById(string id);
        SurveyTitle CreateSurvey(SurveyTitle entity);
        SurveyTitle UpdateSurvey(SurveyTitle entity);
    }
}
