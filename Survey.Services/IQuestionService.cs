using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services
{
    public interface IQuestionService
    {
        Question CreateQuestion(Question question);
        IEnumerable<Question> GetQuestionBySurvey(string sId);
        Question GetQuestionById(string id);
        Question UpdateQuestion(Question question);
        void Delete(string id);
    }
}
