using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using TheatricalPlayersRefactoringKata.DTOs;
using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Tools;

namespace TheatricalPlayersRefactoringKata.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly TheatreContext _context;

    public InvoiceController(TheatreContext context)
    {
        _context = context;
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
            AbstractStatementPrinter? printer = StatementPrinterFactory.Build(format);

            if (printer == null) return BadRequest("Formato inválido!");

            return Ok(printer.Print(invoice));
        }

        return Ok(invoice);
    }

    // POST: api/invoice
    [HttpPost]
    public async Task<ActionResult<Invoice>> Create([FromBody] InvoiceCreationRequest request)
    {
        Invoice invoice = new Invoice();
        invoice.Customer = request.Customer;

        _context.invoices.Add(invoice);

        foreach (int key in request.Performances.Keys)
        {
            Play? play = await _context.plays.FindAsync(key);

            if(play == null)
            {
                return NotFound("Peça com ID " + key.ToString() + " não encontrada!");
            }

            Performance performance = new Performance();
            performance.Invoice = invoice;
            performance.Play = play;
            performance.Audience = request.Performances.GetValueOrDefault(key);

            _context.performances.Add(performance);
        }

        
        await _context.SaveChangesAsync();

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
