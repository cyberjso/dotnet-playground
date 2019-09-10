using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Linq;

namespace DapperSamples.Persistence
{

  public class InvoiceDao
  {
    private MySqlConnection connection;

    public InvoiceDao()
    {

      string dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
      string dbName = Environment.GetEnvironmentVariable("DB_NAME");
      string dbUser = Environment.GetEnvironmentVariable("DB_USER");
      string dbPass = Environment.GetEnvironmentVariable("DB_PASS");

      this.connection = new MySqlConnection($"Server={dbServer};Port=3306;Database={dbName};Uid={dbUser};Pwd={dbPass};");
    }

    public InvoiceEntity FindBy(int InvoiceId)
    {
      string Sql1 = "select ID, NAME, DESCRIPTION from INVOICE as InvoiceInfo where ID  = @InvoiceID; ";
      string Sql2 = "select ID, QTD, PRICE from INVOICE_DETAIL as InvoiceItem where INVOICE_ID = @InvoiceID; ";
      string Sql3 = "select SUM(QTD) as TotalItems, sum(PRICE) AS TotalInvoice from INVOICE_DETAIL as Summary where INVOICE_ID = @InvoiceID";
      var result = connection.QueryMultiple(Sql1 + Sql2 + Sql3, new { InvoiceID = InvoiceId });

      return new InvoiceEntity
      {
        InvoiceInfo = result.Read<InvoiceInfo>().First(),
        Items = result.Read<InvoiceItem>().AsList(),
        Sumamry = result.Read<Summary>().First()
      };
    }

  }

}