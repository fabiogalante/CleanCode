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
            // If reservation already started throw exception
            if (IsCAncellationPeriodOver())
                throw new InvalidOperationException("It´s too late to cancel");

            IsCancelad = true;
            //Gold customers can cancel up to 24 hours before
            // Regular customers can cancel up to 48 hours before  
        }

        private bool IsCAncellationPeriodOver()
        {
            return Customer.IsGoldCustomer() && LessThan(24) || !Customer.IsGoldCustomer() && LessThan(48);
        }

        private bool LessThan(int maxHours)
        {
            return (From - DateTime.Now).TotalHours < maxHours;
        }

        public void CancelWithoutRefactor()
        {
            //Gold customers can cancel up to 24 hours before
            if (Customer.LoyaltyPoints > 100)
            {
                // If reservation already started throw exception

                //CÓDIGO DUPLICADO 
                if (DateTime.Now > From)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }


                //CÓDIGO FAZ A MESMA COISA ABAIXO PORÉM COM 48 HORAS
                // EXTRAIR MAGIC NUMBERS
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
                //CÓDIGO DUPLICADO 
                if (DateTime.Now > From)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }


                //CÓDIGO FAZ A MESMA COISA ABAIXO PORÉM COM 24 HORAS
                if ((From - DateTime.Now).TotalHours < 48)
                {
                    throw new InvalidOperationException("It´s too late to cancel");
                }

                IsCancelad = true;
            }
        }
    }
}
