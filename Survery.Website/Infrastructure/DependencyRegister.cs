using Autofac;
using MongoDB.Driver;
using Survey.Data;
using Survey.Models;
using Survey.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survery.Website.Infrastructure
{
    public class DependencyRegister
    {
        public static void Regsister(ContainerBuilder builder)
        {
            builder.RegisterType<MongoClient>().As<IMongoClient>().InstancePerLifetimeScope().WithParameter("connectionString", WebConfig.MongoDb);
            builder.RegisterGeneric(typeof(MongoRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType<SurveyTitleService>().As<ISurveyTitleService>().InstancePerRequest()
                .WithParameters(new List<NamedParameter>() { new NamedParameter("dbName", WebConfig.DbName), new NamedParameter("collectionName", "ServeyTitle") });
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest()
                .WithParameters(new List<NamedParameter>() { new NamedParameter("dbName", WebConfig.DbName), new NamedParameter("collectionName", "ServiceQuestions") });
        }
    }
}