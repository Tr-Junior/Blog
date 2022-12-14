using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
// {
//     public class Repository<TModel> where TModel : class
//     {
//         private readonly SqlConnection _connection;

//         public Repository(SqlConnection connection) => _connection = connection;

//         public List<TModel> Read() => _connection.GetAll<TModel>().ToList();

//         public TModel Read(int id) => _connection.Get<TModel>(id);

//         public void Create(TModel tmodel) => _connection.Insert<TModel>(tmodel);

//         public void Update(TModel tmodel) => _connection.Update<TModel>(tmodel);

//         public void Delete(TModel tmodel) => _connection.Delete<TModel>(tmodel);

//     }
// }

{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection) => _connection = connection;

        public IEnumerable<T> Get() => _connection.GetAll<T>();

        public T Get(int id) => _connection.Get<T>(id);

        public void Create(T model) => _connection.Insert<T>(model);

        public void Update(T model) => _connection.Update<T>(model);

        public void Delete(T model) => _connection.Delete<T>(model);

        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}