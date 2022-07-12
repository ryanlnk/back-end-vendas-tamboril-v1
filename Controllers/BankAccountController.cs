using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.BankAccount;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;


[ApiController]
[Route("/banks")]
public class BankAccountController : ControllerBase
{
  private readonly BankAccountService _bankService;

  public BankAccountController([FromServices] BankAccountService bankService)
  {
    _bankService = bankService;
  }

  [HttpGet]
  public ActionResult<BankAccountResponseDto> GetBankAccounts()
  {
    var bank = _bankService.GetBankAccounts();
    return Ok(bank);
  }

  [HttpGet("{id:int}")]
  public ActionResult<BankAccountResponseDto> GetBankAccount([FromRoute] int id)
  {
    var bank = _bankService.GetBankAccount(id);

    if (bank is null)
      return NotFound();

    return Ok(bank);
  }

  [HttpPost]
  public ActionResult<BankAccountResponseDto> PostBankAccount([FromBody] BankAccountCreateUpdateDto c)
  {
    var bank = _bankService.PostBankAccount(c);
    return CreatedAtAction(nameof(GetBankAccounts), new { id = bank.Id }, bank);
  }

  [HttpPut("{id:int}")]
  public ActionResult<BankAccountResponseDto> PutBankAccount([FromRoute] int id, [FromBody] BankAccountCreateUpdateDto c)
  {
    var bank = _bankService.PutBankAccount(id, c);

    if (bank is null)
      return null;

    return Ok(bank);
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteBankAccount([FromRoute] int id)
  {
    try
    {
      _bankService.DeleteBankAccount(id);
      return NoContent();
    }
    catch { return NotFound(); }
  }
}
