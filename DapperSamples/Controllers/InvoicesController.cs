using Microsoft.AspNetCore.Mvc;
using DapperSamples.Persistence;
using DapperSamples.Models;
using System.Linq;

namespace DapperSamples.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InvoicesController : ControllerBase
  {
    private InvoiceDao InvoiceDao = new InvoiceDao();

    [HttpGet("{Id}")]
    public ActionResult<Invoice> Get(int Id)
    {
      InvoiceEntity invoiceEntity = InvoiceDao.FindBy(Id);

      Invoice invoice = new Invoice();
      invoice.Items = invoiceEntity.Items.Select(item => new Item { Id = item.Id, Description = item.Description, Price = item.Price.ToString(), Qtd = item.Qtd });;
      invoice.Id = invoiceEntity.InvoiceInfo.Id;
      invoice.TotalInvoice = invoiceEntity.Sumamry.TotalInvoice.ToString();
      invoice.TotatlItems = invoiceEntity.Sumamry.TotalItems;
      
      return invoice;
    }

  }

}