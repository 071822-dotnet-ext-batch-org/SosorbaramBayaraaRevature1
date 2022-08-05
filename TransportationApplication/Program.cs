using System;

namespace TransportationApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Transportation trans = new Transportation();
            Cars car = new Cars();
            Boats boat = new Boats();
            Trains train = new Trains();

            Console.WriteLine(car.color, car.numOfDoors);
            //Console.WriteLine(boat);
            //Console.WriteLine(train);



        }
    }
}
