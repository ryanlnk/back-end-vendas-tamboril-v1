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

  //Retornando um pagamento pelo ID
  public PaymentResponseDto GetPayment(int id)
  {
    var payment = _context.Payment.AsNoTracking().SingleOrDefault(c => c.Id == id);

    if (payment is null)
      return null;

    var paymentResponse = payment.Adapt<PaymentResponseDto>();

    return paymentResponse;
  }
}
