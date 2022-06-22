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

  [HttpGet("{id:int}")]
  public ActionResult<PaymentResponseDto> GetPayment([FromRoute] int id)
  {
    var payment = _paymentService.GetPayment(id);

    if (payment is null)
      return NotFound();

    return Ok(payment);
  }

  [HttpPost]
  public ActionResult<PaymentResponseDto> PostPayment([FromBody] PaymentCreateUpdateDto p)
  {
    var payment = _paymentService.PostPayment(p);

    return CreatedAtAction(nameof(GetPayments), new { id = payment.Id }, payment);

  }
}
