using MongoDB.Bson;
using Survey.Data;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> questionRepository;
        public QuestionService(IRepository<Question> questionRepository, string dbName, string collectionName)
        {
            this.questionRepository = questionRepository;
            this.questionRepository.Init(dbName, collectionName);
        }
        public Question CreateQuestion(Question question)
        {
            return this.questionRepository.Insert(question);
        }

        public IEnumerable<Question> GetQuestionBySurvey(string sId)
        {
            Expression<Func<Question, bool>> filter = f => f.SurveryId == sId;
            return this.questionRepository.GetByCondition(filter);
        }

        public Question GetQuestionById(string id)
        {
            ObjectId objId = new ObjectId();
            if (ObjectId.TryParse(id, out objId))
            {
                return this.questionRepository.GetById(objId);
            }
            else
            {
                throw new ArgumentException("id不是一个有效的objectid字符串");
            }
        }

        public Question UpdateQuestion(Question question)
        {
            return this.questionRepository.Update(question);
        }

        public void Delete(string id)
        {
            ObjectId objId = new ObjectId();
            if (ObjectId.TryParse(id, out objId))
            {
                this.questionRepository.Delete(objId);
            }
            else
            {
                throw new ArgumentException("不是一个有效的objectid字符串");
            }
        }
    }
}
