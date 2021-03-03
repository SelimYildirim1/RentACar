using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessResult:Result
    {
       public SuccessResult(string message):base(true, message)
        {
            //default true döndürmek için oluşturuldu
        }
        public SuccessResult() : base(true)
        {

        }
    }
}
