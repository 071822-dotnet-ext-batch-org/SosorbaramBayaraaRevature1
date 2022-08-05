using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationApplication
{
    public class Cars: Transportation
    {
        public Cars() : base(){
            this.numOfDoors.Equals(4);
            this.numOfWheels.Equals(4);
            this.color = " ";
            this.typeOfEngine = " ";
        }

         public override int GetNumDoors(){
                return 4;
            }
            
            public override int GetNumWheels(){
                return 4;
            }

            public override string GetColor(){
                return "Black";
            }

            public override string GetEngine(){
                return "Motor";
            }
    }
}