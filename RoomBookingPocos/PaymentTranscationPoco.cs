using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoomBookingPocos
{
    [Table("PaymentTranscation")]
    public class PaymentTranscationPoco
    {
        [Key]
        public Guid PaymentTranscationID { get; set; }
        public Guid BookingID { get; set; }
        public int AmountPaid { get; set; }

        public virtual BookingsPoco Booking { get; set; }
    }
}
