using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.EntityFrameworkDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBookingBusinessLogicLayer;
using RoomBookingPocos;

namespace RoomBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingsLogic _logic;

        public BookingsController()
        {
            EFGenericRepository<BookingsPoco> Repo = new EFGenericRepository<BookingsPoco>();
            _logic = new BookingsLogic(Repo);
        }

        [HttpPost]
        [Route("Booking")]

        public ActionResult PostBooking
        ([FromBody]BookingsPoco[] Bookings)
        {
            _logic.add(Bookings);
            return Ok();
        }

        [HttpPut]
        [Route("Booking")]

        public ActionResult PutBooking
    ([FromBody]BookingsPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("Booking")]

        public ActionResult DeleteBooking
    ([FromBody] BookingsPoco[] pocos)
        {
            _logic.Remove(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("Booking")]
        public ActionResult GetAllBookings()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(applicants);
            }
        }
    }




}