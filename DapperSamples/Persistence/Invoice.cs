using System.Collections.Generic;

namespace DapperSamples.Persistence
{

  public class InvoiceEntity {
    public InvoiceInfo InvoiceInfo {set; get;}
    public IEnumerable<InvoiceItem> Items {set; get;}
    public Summary Sumamry {set; get;}
  }

  public class InvoiceInfo
  {
    public int Id { set; get; }

    public string Name {set; get;}

    public string Description {set; get;}

  }

  public class InvoiceItem
  {
    public int Id {set; get;}
    public string Description {set; get;}
    public decimal Price{set; get;}
    public int Qtd {set; get;}
    public int InvoiceId {set; get;} 
  }

  public class Summary  {
    public int TotalItems {set; get;}
    public decimal TotalInvoice {set; get;}
  }

}