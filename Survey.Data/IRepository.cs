using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data
{
    public interface IRepository<T> where T : MongoBaseModel
    {
        void Init(string dbName,string collectionName);
        IEnumerable<T> Get();
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> option);
        T GetById(ObjectId id);
        T Delete(ObjectId id);
        T Insert(T t);
        T Update(T t);
    }
}
