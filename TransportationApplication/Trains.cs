using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationApplication
{
    public class Trains : Transportation
    {
         public Trains() : base(){

            this.numOfDoors.Equals(0);
            this.numOfWheels.Equals(0);
            this.color = "Black";
            this.typeOfEngine = "Motor";
         }

             public override int GetNumDoors(){
                return 20;
            }
            
            public override int GetNumWheels(){
                return 8;
            }

            public override string GetColor(){
                return "White";
            }

            public override string GetEngine(){
                return "Electric";
            }
            
    
    }
}