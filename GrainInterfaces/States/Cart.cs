using System;
using System.Collections.Generic;
using System.Linq;

namespace GrainInterfaces.States
{
    [Serializable]
    public class Cart
    {
        public Guid Id { get; set; }

        public List<Product> Products { get; set; }

        public string PromoCode { get; set; }

        public decimal Total
        {
            get
            {
                return Products?.Sum(_ => _.ProductPrice) ?? 0;
            }
        }
    }
}

    