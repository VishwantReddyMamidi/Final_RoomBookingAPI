using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoomBookingPocos
{
    [Table("BookingsTable")]
    public class BookingsPoco
    {

        [Key]
        public Guid BookingID { get; set; }
        public string FullName { get; set; }
        public string RoomNumber { get; set; }

        public virtual PaymentTranscationPoco PaymentTranscation { get; set; }
    }
}