using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationApplication
{
    public class Boats: Transportation
    {
        
         public Boats() : base(){

            this.numOfDoors.Equals(0);
            this.numOfWheels.Equals(0);
            this.color = " ";
            this.typeOfEngine = "";
         }
            public override int GetNumDoors(){
                return 0;
            }
            
            public override int GetNumWheels(){
                return 8;
            }

            public override string GetColor(){
                return "White";
            }

            public override string GetEngine(){
                return "Motor";
            }

            

    }
}