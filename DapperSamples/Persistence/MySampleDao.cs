using System;
using MySql.Data.MySqlClient;
using Dapper;

namespace  DapperSamples.Persistence {

  public class MySampleDao 
  {
    private MySqlConnection connection;

    public MySampleDao() 
    {
      
      string dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
      string dbName = Environment.GetEnvironmentVariable("DB_NAME");
      string dbUser = Environment.GetEnvironmentVariable("DB_USER");
      string dbPass = Environment.GetEnvironmentVariable("DB_PASS");

      this.connection = new MySqlConnection($"Server={dbServer};Port=3306;Database={dbName};Uid={dbUser};Pwd={dbPass};");
    }
    
    public MySampleEntity FindById(int Id) 
    {
      return connection.QueryFirstOrDefault<MySampleEntity>("select id, name, description from  SAMPLE where id = @Id", new {Id =  Id});
    
    }

  }
}