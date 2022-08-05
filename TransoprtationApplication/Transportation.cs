using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationApplication
{
    public class Transportation
    {
       public int numOfWheels {get; set;}
       public int numOfDoors {get; set;}
        public string color {get; set;}
        public string typeOfEngine {get; set;}


        public virtual int GetNumWheels(){
            return (numOfWheels);
        }
        public virtual int GetNumDoors(){
            return (numOfDoors);
        }

        public virtual string GetColor(){
            return (color);
        }

        public virtual string GetEngine(){
            return (typeOfEngine);
        }



    }
}