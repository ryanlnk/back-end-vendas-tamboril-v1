using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.BankAccount;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class BankAccountService
{
  private readonly TamborilContext _context;

  public BankAccountService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  public List<BankAccountResponseDto> GetBankAccounts()
  {
    return _context.BankAccounts.AsNoTracking().ProjectToType<BankAccountResponseDto>().ToList();
  }

  public BankAccountResponseDto GetBankAccount(int id)
  {
    var bank = _context.BankAccounts.AsNoTracking().SingleOrDefault(c => c.Id == id);

    if (bank is null)
      return null;

    var bankResponse = bank.Adapt<BankAccountResponseDto>();

    return bankResponse;
  }

  public BankAccountResponseDto PostBankAccount(BankAccountCreateUpdateDto bankDto)
  {
    var bank = bankDto.Adapt<BankAccount>();

    var dateNow = DateTime.Now;
    bank.CreationDate = dateNow;
    bank.UpdateDate = dateNow;

    _context.BankAccounts.Add(bank);
    _context.SaveChanges();

    var bankResponse = bank.Adapt<BankAccountResponseDto>();

    return bankResponse;
  }

  public BankAccountResponseDto PutBankAccount(int id, BankAccountCreateUpdateDto bankDto)
  {
    var bank = _context.BankAccounts.SingleOrDefault(c => c.Id == id);

    if (bank is null)
      return null;

    bankDto.Adapt(bank);

    bank.UpdateDate = DateTime.Now;
    _context.SaveChanges();

    var bankResponse = bank.Adapt<BankAccountResponseDto>();

    return bankResponse;
  }

  public void DeleteBankAccount(int id)
  {
    var bank = _context.BankAccounts.SingleOrDefault(c => c.Id == id);

    if (bank is null)
      throw new Exception("Bank not found");

    _context.Remove(bank);
    _context.SaveChanges();
  }
}
