using System.Collections.Generic;

namespace DapperSamples.Models
{
  public class Invoice
  {
    public int Id { set; get; }

    public IEnumerable<Item> Items { set; get; }

    public string TotalInvoice { set; get; }

    public int TotatlItems { set; get; }

  }

  public class Item
  {
    public int Id { set; get; }
    public string Price { set; get; }
    public string Description { set; get; }
    public int Qtd { set; get; }
  }
  
}