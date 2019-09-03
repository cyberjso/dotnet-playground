using MySql.Data.MySqlClient;
using Dapper;

namespace  DapperSamples.Persistence {

  public class MySampleDao 
  {
    private MySqlConnection connection = new MySqlConnection("Server=172.17.0.2;Port=3306;Database=some_db;Uid=admin;Pwd=admin123;");

    public MySampleEntity FindById(int Id) 
    {
      return connection.QueryFirstOrDefault<MySampleEntity>("select id, name, description from  SAMPLE where id = @Id", new {Id =  Id});
    
    }

  }
}