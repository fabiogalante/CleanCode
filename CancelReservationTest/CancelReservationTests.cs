using NestedConditionals;
using System;
using Xunit;

namespace CancelReservationTest
{
    public class CancelReservationTests
    {
        [Fact]
        public void RegularCustomer_CancellingLessThan48Hours_ShouldThorwException()
        {
            var customer = CreateRegularCustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(47));

            reservation.Cancel();


        }

        private Customer CreateRegularCustomer()
        {
            var customer = new Customer { LoyaltyPoints = 65 };
            return customer;
        }
    }
}
