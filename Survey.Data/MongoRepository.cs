using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data
{
    public class MongoRepository<T> : IRepository<T> where T : MongoBaseModel
    {
        private bool flag = false;
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<T> collection;
        public MongoRepository(IMongoClient client)
        {
            this.client = client;
        }
        public void Init(string dbName, string collectionName)
        {
            this.database = this.client.GetDatabase(dbName);
            this.collection = database.GetCollection<T>(collectionName);
            this.flag = true;
        }
        public IEnumerable<T> Get()
        {
            if (flag)
            {
                Expression<Func<T, bool>> filter = f => true;
                var data = collection.Find(filter);
                return data.ToEnumerable<T>();
            }
            else
            {
                throw new MongoException("未指定数据库");
            }
        }
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> option)
        {
            if (flag)
            {
                var data = collection.Find(option);
                return data.ToEnumerable<T>();
            }
            else
            {
                throw new MongoException("未指定数据库");
            }
        }
        public T GetById(ObjectId id)
        {
            if (flag)
            {
                Expression<Func<T, bool>> filter = f => f._id == id;
                var data = collection.Find(filter);
                return data.FirstOrDefault();
            }
            else
            {
                throw new MongoException("未指定数据库");
            }
            
        }

        public T Delete(ObjectId id)
        {
            if (flag)
            {
                Expression<Func<T, bool>> filter = f => f._id == id;
                var data = collection.FindOneAndDelete(filter);
                return data;
            }
            else
            {
                throw new MongoException("未指定数据库");
            }
            
        }

        public T Insert(T t)
        {
            if (flag)
            {
                collection.InsertOne(t);
                return t;
            }
            else
            {
                throw new MongoException("未指定数据库");
            }          
        }

        public T Update(T t)
        {
            if (flag)
            {
                Expression<Func<T, bool>> filter = f => f._id == t._id;
                return this.collection.FindOneAndReplace(filter, t);
            }
            else
            {
                throw new MongoException("未指定数据库");
            }              
        }
    }
}
