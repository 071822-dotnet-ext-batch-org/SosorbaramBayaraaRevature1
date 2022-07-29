using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosorbaramBayaraaRevature1.RpsConsole1
{
    public class Player
    {
        // A class has Properties, attributes, constructors, and method (mainly)

        // an attribute is a single piece of dataa like an age, DoB, name, etc
        // an access modifier controls what parts of code can access a specific class or field (or property, or)

        private int age = 0;
        // A Property is a  spcial C# abstraction that  is a combination of a getter and setter and the data the    
        public DateTime myDoB {get; set;} = new DateTime(05/1/1991);
        public string Fname { get; set; }
        public string Lname { get; set;}
        public bool Gender { get; set;}
        public int Wins {
             get{
                return Wins;
             }
              set{
                this.wins++;
              }
              }
        public int Losses {get; set;}

        public Player(String fname){
            this.Fname = fname;
        }


        public int GetAge(){
            return myAge;
        }

        public void setAge(int age){
            if(myAge > 110 || myAge < 18)
            {
                throw new FieldAccessException($"You can't set the age to {age}");
            }

            else
            {
                this.myAge;
            }
        }



    }
}