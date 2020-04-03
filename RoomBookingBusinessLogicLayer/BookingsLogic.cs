using RoomBookingPocos;
using RoomBookingDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CareerCloud.BusinessLogicLayer;

namespace RoomBookingBusinessLogicLayer
{
    public class BookingsLogic : BaseLogic<BookingsPoco>
    {
        public BookingsLogic(IDataRepository<BookingsPoco> repository): base(repository)
        {
                
        }

        protected override void Verify(BookingsPoco[] pocos)
        {
            List<ValidationExcep> exceptions = new List<ValidationExcep>();
            foreach (BookingsPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.FullName))
                {
                    exceptions.Add(new ValidationExcep(107,"FullName cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void add(params BookingsPoco[] pocos)
        {
            Verify(pocos);
            base.add(pocos);
        }

        public override void Update(params BookingsPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);

        }

        public override void Remove(params BookingsPoco[] pocos)
        {
            Verify(pocos);
            base.Remove(pocos);
        }

    }
}
