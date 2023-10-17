using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Repository;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Blog
{
    class Program
    {
  
        private const string ConnectionString = "Data Source=DESKTOP-G18LE98;Initial Catalog=Blog;Integrated Security=True;Encrypt=False; ";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            // Chame métodos ou adicione lógica aqui para iniciar o programa.
           ReadUsers(connection);         
           ReadRoles(connection);
           ReadTags(connection);
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
            connection.Close();
         
        }

        public static void ReadUsers(SqlConnection sqlConnection)
        {

             var repository = new Repository<User>(sqlConnection);       
             var users = repository.Get();

            foreach(var user in users)
            {
                Console.WriteLine($"Name is {user.Name}");

            }
        }


           public static void ReadRoles(SqlConnection sqlConnection)
           {
         
             var repository = new Repository<Role>(sqlConnection);
             var roles = repository.Get();
            
             Console.WriteLine("Oque deseja visualizar?Name ou Slug?");
             string escolha = Console.ReadLine().ToLower();
           
              if(escolha == "name" || escolha == "slug" )
              {                                       
                    switch(escolha)
                    {           
                      case "slug":
                        foreach(var role in roles)
                           Console.WriteLine($"Slug is {role.Slug}");
                      break;
                      case "name":
                        foreach(var role in roles)
                          Console.WriteLine($"Name is {role.Name}");
                     break;                 
                    }
              }else
               Console.WriteLine("Voce digitou um nome invalido! saindo do programa..");

            }

         public static void ReadTags(SqlConnection sqlConnection)
        {
             //var repository = new UserRepository(sqlConnection);
             var repository = new Repository<Tag>(sqlConnection);
            // var users = repository.Get();
            var tags = repository.Get();

            foreach(var item in tags)
            {
                Console.WriteLine($"Tag Name is {item.Name}");

            }
        }
 
        #region OLD
        // public static void ReadUser()
        // {
         
        //   var user = _userRepository.GetOne();
            
        // }

        // public static void CreateUser()
        // {
        //     Console.WriteLine("qual o nome do usuario que deseja cadastrar?");
        //     var nome = Console.ReadLine();
        //     Console.WriteLine("de qual empresa?");
        //     var slug = Console.ReadLine();
        //     System.Console.WriteLine("e a Bio?");
        //     var bio = Console.ReadLine();
        //     Console.WriteLine("e o Email?");
        //     var email = Console.ReadLine();
        //     System.Console.WriteLine("e por ultimo  o password");
        //     var Password = Console.ReadLine();

        //     var user = new User()
        //     {
        //         Name = nome,
        //         Email = email,
        //         PasswordHash = Password,
        //         Bio = bio,
        //         Slug = slug,
        //         Image = ""
               
        //     };
        //     using(var connection = new SqlConnection(ConnectionString))
        //     {
        //         var addUser = connection.Insert<User>(user);
                
        //         if(addUser > 0  )
        //            Console.WriteLine($"Usuario {user.Name} adicionado com sucesso");
        //             else
        //            Console.WriteLine("nao foi adicionado nada");
        //     }
        // }

        // public static void UpdateUser()
        // {
        //     Console.WriteLine("qual o nome do usuario que deseja atualizar?");//tratar o update
        //     var nome = Console.ReadLine();
        //     Console.WriteLine("de qual empresa?");
        //     var slug = Console.ReadLine();
        //     System.Console.WriteLine("e a Bio?");
        //     var bio = Console.ReadLine();
        //     Console.WriteLine("e o Email?");
        //     var email = Console.ReadLine();
        //     System.Console.WriteLine("e por ultimo  o password");
        //     var Password = Console.ReadLine();
       
              
                  

        //     var user = new User()
        //     {
        //         Name = nome,
        //         Email = email,
        //         PasswordHash = Password,
        //         Bio = bio,
        //         Slug = slug,
        //         Image = ""
               
        //     };
        //     using(var connection = new SqlConnection(ConnectionString))
        //     {
        //         var addUser = connection.Update<User>(user);
        //         System.Console.WriteLine($"Usuario {user.Name} alterado com sucesso");
                
              
        //     }

        // }
        // public static void DeleteUser()
        // {
        //    using(var connection = new SqlConnection(ConnectionString))
        //    {
        //      Console.WriteLine("Qual Id voce dejesa excluir?");//tratar quando n tem id no banco
        //      var id = Console.ReadLine();
             
        //      var user = connection.Get<User>(id);
        //      if(user == null )
        //      {
        //            Console.WriteLine("ID NAO ENCONTRADO!");
        //            return;
        //      }

                
        //      var deleteUser = connection.Delete<User>(user);
             
        //      System.Console.WriteLine($"Usuario {user.Name} Deletado com sucesso!");
        //    }

        // }
        #endregion

    }
}
