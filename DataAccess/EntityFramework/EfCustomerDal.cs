using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace DataAccess.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
        public List<CustomerDto> GetCustomer()
        {
            using (RentACarContext rentACarContext = new  RentACarContext())
            {
                var result = from c in rentACarContext.Customers
                    join u in rentACarContext.Users
                        on c.UserId equals u.UserId
                    select new CustomerDto
                    {
                        CustomerId = c.CustomerId, UserId = u.UserId, CompanyName = c.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
