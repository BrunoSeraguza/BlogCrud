using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repository
{//Criando um repositorio generico que atende todos os tipos de entidade
    public class Repository<T> where T : class //só vai aceitar a criacao onde o tipo T seja uma class
    {
        
        private readonly SqlConnection sqlConnection;

        public Repository(SqlConnection stringSqlConnection)
        {
            sqlConnection = stringSqlConnection;
        }

        public IEnumerable<T> Get()
        {
             return  sqlConnection.GetAll<T>();
        }

      public T  Get(int id )
        =>  sqlConnection.Get<T>(id);
             

        public void Create(T model  )        
           => sqlConnection.Insert<T>(model);
        

        public void Delete(T model)
        {                               
            var user = sqlConnection.Get<T>(model);
            sqlConnection.Delete<T>(user);
        }
        public void Delete(int id )
        {
            var model = sqlConnection.Get<T>(id);
            sqlConnection.Delete<T>(model);  
        }

        public void Update(T model)
        {
           
                sqlConnection.Update<T>(model);
        }
       
        public IEnumerable<T> GetOne()
        {            
                var user = sqlConnection.Get<T>(1);
                return (IEnumerable<T>)user;
            
        }

    }
}