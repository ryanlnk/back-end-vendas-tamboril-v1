using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Payment;

namespace VendasTamboril.Services;

public class PaymentService
{
  private readonly TamborilContext _context;

  public PaymentService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  //Retornando todos os dados da tabela pagamentos
  public List<PaymentResponseDto> GetPayments()
  {
    return _context.Payment.AsNoTracking().ProjectToType<PaymentResponseDto>().ToList();
  }
}
