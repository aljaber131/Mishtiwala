using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    namespace BLL.Services
    {
        public class PaymentService
        {
            private readonly IRepository<Payment> _paymentRepository;
            public PaymentService()
            {
                _paymentRepository = DataAccessFactory.PaymentData();
            }

            public void CreatePayment(PaymentDTO paymentDTO)
            {
                _paymentRepository.Add(new Payment
                {
                    Amount = paymentDTO.Amount,
                    SweetId = paymentDTO.SweetId,
                    UserId = paymentDTO.UserId
                });
            }

            public PaymentDTO GetPaymentById(int id)
            {
                var paymentEntity = _paymentRepository.GetById(id);
                if (paymentEntity == null)
                {
                    return null;
                }
                PaymentDTO payment = new PaymentDTO
                {
                    Amount = paymentEntity.Amount,
                    SweetId = paymentEntity.SweetId,
                    UserId = paymentEntity.UserId,
                    Id = paymentEntity.Id
                };
                return payment;
            }

            public List<PaymentDTO> GetAllPayments()
            {
                var list = _paymentRepository.GetAll();
                var payments = new List<PaymentDTO>();
                foreach (var payment in list)
                {
                    payments.Add(new PaymentDTO
                    {
                        Amount = payment.Amount,
                        SweetId = payment.SweetId,
                        UserId = payment.UserId,
                        Id = payment.Id
                    });
                }
                return payments;
            }

            public void UpdatePayment(PaymentDTO payment, int id)
            {
                var entity = _paymentRepository.GetById(id);
                if (entity == null)
                {
                    return;
                }
                entity.Amount = payment.Amount;
                entity.SweetId = payment.SweetId;
                entity.UserId = payment.UserId;
                entity.Id = payment.Id;
                _paymentRepository.Update(entity);
            }

            public void DeletePayment(int id)
            {
                var entity = _paymentRepository.GetById(id);
                _paymentRepository.Delete(entity);
            }
        }
    }
}
