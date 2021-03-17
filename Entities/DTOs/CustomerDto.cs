using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
  public  class CustomerDto:IDto
    {
        public int CustomerId  { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
