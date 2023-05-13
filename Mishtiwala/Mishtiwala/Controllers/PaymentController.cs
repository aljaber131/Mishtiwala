using BLL.DTOs;
using Mishtiwala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.Services;
using BLL.Services.BLL.Services;

namespace Mishtiwala.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly PaymentService _paymentService;

        public PaymentController()
        {
            _paymentService = new PaymentService();
        }

        [HttpGet]
        [Route("api/payment")]
        public HttpResponseMessage Get()
        {
            var payments = _paymentService.GetAllPayments();
            return Request.CreateResponse(HttpStatusCode.OK, payments);
        }

        [HttpGet]
        [Route("api/payment/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            return Request.CreateResponse(HttpStatusCode.OK, payment);
        }

        [HttpPost]
        [Route("api/payment/add")]
        public HttpResponseMessage Add(PaymentCreateModel payment)
        {
            if (ModelState.IsValid)
            {
                PaymentDTO paymentDTO = new PaymentDTO
                {
                    Amount = payment.Amount,
                    SweetId = payment.SweetId,
                    UserId = payment.UserId
                };
                try
                {
                    _paymentService.CreatePayment(paymentDTO);
                    return Request.CreateResponse(HttpStatusCode.OK, "Payment Created");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPatch]
        [Route("api/payment/update/{id}")]
        public HttpResponseMessage Patch(PaymentDTO payment, int id)
        {
            _paymentService.UpdatePayment(payment, id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/payment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _paymentService.DeletePayment(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}