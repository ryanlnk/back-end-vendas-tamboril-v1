using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.Payment;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;

[ApiController]
[Route("/payments")]

public class PaymentController : ControllerBase
{
  private readonly PaymentService _paymentService;

  public PaymentController([FromServices] PaymentService paymentService)
  {
    _paymentService = paymentService;
  }

  [HttpGet]
  public ActionResult<List<PaymentResponseDto>> GetPayments()
  {
    var payment = _paymentService.GetPayments();
    return Ok(payment);
  }
}
