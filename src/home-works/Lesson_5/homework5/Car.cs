using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class Car
    {
        //Марка, год, модель, поколение, цвет
        public int id { get; set; }
        public string carMake { get; set; }
        public string carColor { get; set; }
        public string engineVolume { get; set; }
        public DateTime carYear { get; set; }
        public string modelNumber { get; set; }
        public string modelName { get; set; }
        public DateTime modelYear { get; set; }
        //public string baseCharacteristics { get; set; }
        public Car()
        {

        }
    }
}
