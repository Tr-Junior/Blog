using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection) => _connection = connection;

        public List<TModel> Read() => _connection.GetAll<TModel>().ToList();

        public TModel Read(int id) => _connection.Get<TModel>(id);

        public void Create(TModel tmodel) => _connection.Insert<TModel>(tmodel);

        public void Update(TModel tmodel) => _connection.Update<TModel>(tmodel);

        public void Delete(TModel tmodel) => _connection.Delete<TModel>(tmodel);

    }
}