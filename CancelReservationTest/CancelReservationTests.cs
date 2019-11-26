using NestedConditionals;
using System;
using Xunit;
using FluentAssertions;

namespace CancelReservationTest
{
    public class CancelReservationTests
    {

        [Fact]
        public void GoldCustomer_CancellingMoreThan24Hours_ShouldCancel()
        {
            var customer = CreateGoldcustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(25));
            reservation.Cancel();
            reservation.IsCancelad.Should().Be(true);
        }


        [Fact]
        public void GoldCustomer_CancellingLessThan24Hours_ShouldThrowException()
        {
            var customer = CreateGoldcustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(23));
            var ex = Assert.Throws<InvalidOperationException>(() => reservation.Cancel());
            Assert.Equal("It큦 too late to cancel", ex.Message);
        }




        [Fact]
        public void RegularCustomer_CancellingLessThan48Hours_ShouldThorwException()
        {
            var customer = CreateRegularCustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(47));

            //Assert.Throws<InvalidOperationException>(() => reservation.Cancel());


            //reservation.Cancel().Should().BeOfType<InvalidOperationException>().Which.Message.Should().Be("It큦 too late to cancel");

            Action act = () => reservation.Cancel();
            act.Should().Throw<InvalidOperationException>().WithMessage("It큦 too late to cancel");

            var ex = Assert.Throws<InvalidOperationException>(() => reservation.Cancel());

            Assert.Equal("It큦 too late to cancel", ex.Message);

        }


        [Fact]
        public void RegularCustomer_CancellingMoreThan48HourBefore_ShouldCancel()
        {
            var customer = CreateRegularCustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(49));
            reservation.Cancel();
            reservation.IsCancelad.Should().Be(true);
        }



        [Fact]
        public void RegularCustomer_CancellingLessThan48Hours_ShouldThrowException()
        {
            var customer = CreateRegularCustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(47));
            var ex = Assert.Throws<InvalidOperationException>(() => reservation.Cancel());
            Assert.Equal("It큦 too late to cancel", ex.Message);
        }

        [Fact]
        public void RegularCustomer_CancellingMore48_Ok()
        {
            var customer = CreateRegularCustomer();
            var reservation = new Reservation(customer, DateTime.Now.AddHours(50));
            reservation.Cancel();
            reservation.IsCancelad.Should().Be(true);
        }

        private Customer CreateRegularCustomer()
        {
            var customer = new Customer { LoyaltyPoints = 65 };
            return customer;
        }

        private Customer CreateGoldcustomer()
        {
            var customer = new Customer { LoyaltyPoints = 120 };
            return customer;
        }
    }
}
