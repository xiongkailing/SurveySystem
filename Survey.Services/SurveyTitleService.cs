using MongoDB.Bson;
using MongoDB.Driver;
using Survey.Data;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services
{
    public class SurveyTitleService:ISurveyTitleService
    {
        private readonly IRepository<SurveyTitle> surveyRepository;
        public SurveyTitleService(IRepository<SurveyTitle> surveyRepository,string dbName,string collectionName)
        {
            this.surveyRepository=surveyRepository;
            this.surveyRepository.Init(dbName, collectionName);
        }
        public SurveyTitle GetById(string id)
        {
            ObjectId objId = new ObjectId();
            if (ObjectId.TryParse(id, out objId))
            {
                return this.surveyRepository.GetById(objId);
            }
            else
            {
                throw new ArgumentException("不是一个有效的objectid字符串");
            }
        }

        public IEnumerable<SurveyTitle> GetAllSurvery()
        {
            return this.surveyRepository.Get();
        }

        public void DeleteById(string id)
        {
            ObjectId objId = new ObjectId();
            if (ObjectId.TryParse(id, out objId))
            {
                this.surveyRepository.Delete(objId);
            }
            else
            {
                throw new ArgumentException("不是一个有效的objectid字符串");
            }
        }

        public SurveyTitle CreateSurvey(SurveyTitle entity)
        {
            return this.surveyRepository.Insert(entity);
        }

        public SurveyTitle UpdateSurvey(SurveyTitle entity)
        {
            return this.surveyRepository.Update(entity);
        }
    }
}
