using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {
            //metotdun içine message yazarsak false ve message dönecek
            //default false döndürmek için oluşturuldu
        }
        public ErrorResult() : base(false)
        {
            //errorrresultı boş bırakırsak false dönecek
        }
    }
}
