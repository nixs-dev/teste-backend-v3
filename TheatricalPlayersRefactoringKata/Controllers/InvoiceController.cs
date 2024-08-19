using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using TheatricalPlayersRefactoringKata.DTOs;
using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Core;
using TheatricalPlayersRefactoringKata.Services;
using TheatricalPlayersRefactoringKata.Core.PrinterTypes;

namespace TheatricalPlayersRefactoringKata.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly TheatreContext _context;
    private readonly PrintInvoiceService _printInvoiceService;

    public InvoiceController(TheatreContext context, PrintInvoiceService printInvoiceService)
    {
        _context = context;
        _printInvoiceService = printInvoiceService;
    }

    // GET: api/invoice
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> All()
    {
        return await _context.invoices.ToListAsync();
    }

    // GET: api/invoice/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        Invoice invoice = await _context.invoices.Include(i => i.Performances)
                                        .ThenInclude(p => p.Play)
                                        .Where(i => i.Id == id)
                                        .FirstAsync();

        if (invoice == null) return NotFound();


        if (Request.Query.TryGetValue("format", out StringValues format))
        {
            AbstractStatementPrinter? printer = StatementPrinterFactory.Build(invoice, format);

            if (printer == null) return BadRequest("Formato inválido!");

            return Ok(printer.Print());
        }

        return Ok(invoice);
    }

    // POST: api/invoice
    [HttpPost]
    public async Task<ActionResult<Invoice>> Create([FromBody] InvoiceCreationRequestDTO request)
    {
        Invoice invoice = new Invoice();
        invoice.Customer = request.Customer;

        _context.invoices.Add(invoice);

        foreach (DTOs.PerformanceDTO performanceDto in request.Performances)
        {
            Play? play = await _context.plays.FindAsync(performanceDto.PlayId);

            if(play == null)
            {
                return NotFound("Peça com ID " + performanceDto.PlayId.ToString() + " não encontrada!");
            }

            Models.Performance performance = new Models.Performance();
            performance.Invoice = invoice;
            performance.Play = play;
            performance.Audience = performanceDto.Audience;

            _context.performances.Add(performance);
        }

        
        await _context.SaveChangesAsync();

        await this._printInvoiceService.PrintInvoiceAsync(new XMLPrinter(invoice));

        return Ok();
    }

    // PUT: api/invoice/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Invoice invoice)
    {
        if (id != invoice.Id)
        {
            return BadRequest();
        }

        _context.Entry(invoice).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!Exists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/invoice/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var invoice = await _context.invoices.FindAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }

        _context.invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool Exists(int id)
    {
        return _context.invoices.Any(e => e.Id == id);
    }
}
