using RoomBookingDataAccessLayer;
using RoomBookingPocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBookingBusinessLogicLayer
{
   public class PaymentTranscationLogic : BaseLogic<PaymentTranscationPoco>
    {
        public PaymentTranscationLogic(IDataRepository<PaymentTranscationPoco> respository): base(respository)
        {

        }

        protected override void Verify(PaymentTranscationPoco[] pocos)
        {
            base.Verify(pocos);
        }

        public override void add(params PaymentTranscationPoco[] pocos)
        {
            base.add(pocos);
        }

        public override void Update(params PaymentTranscationPoco[] pocos)
        {
            base.Update(pocos);
        }

        public override void Remove(params PaymentTranscationPoco[] pocos)
        {
            base.Remove(pocos);
        }

    }
}
