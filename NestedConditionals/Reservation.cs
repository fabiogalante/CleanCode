using System;

namespace NestedConditionals
{
    public class Reservation
    {
        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCancelad { get; set; }    

        public Reservation(Customer customer, DateTime datetime)
        {
            From = datetime;
            Customer = customer;
        }

        public void Cancel()
        {
            //Gold customers can cancel up to 24 hours before
            if (Customer.LoyaltyPoints > 100)
            {
                // If reservation already started throw exception
                if (DateTime.Now > From)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }

                if ((From - DateTime.Now).TotalHours < 24)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }

                IsCancelad = true;
            }
            else
            {
                // Regular customers can cancel up to 48 hours before

                // If reservation already started throw exception
                if (DateTime.Now > From)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }

                if ((From - DateTime.Now).TotalHours < 48)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }

                IsCancelad = true;
            }
        }
    }
}
