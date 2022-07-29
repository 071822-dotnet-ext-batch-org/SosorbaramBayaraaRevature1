using System;

namespace RpsConsole2
{
    class Program
    {
        static void Main(string[] args)
        {

            //create an instance of a Player
            Player p1 = new Player();
            p1.Fname = "Sam";
            p1.Lname = "Bayaraa";
            p1.DoB = new DateTime(10,  23,  1988);

            Console.WriteLine($"The players name is {p1.Fname} {p1.Lname} and his age is {p1.DoB.ToShortDateString()}.");
            p1.SetAge(111);
            Console.WriteLine($"The players age is {p1.GetAge()}");
            p1.Wins = 1;
            int wins = p1.Wins;

            Console.WriteLine($"{p1.Fname} has {p1.Wins} wins");




            //create players






            //Welcome message...
            Console.WriteLine ("\t\tWelcome to your favorite game!\n\t\tThis is Rock-Paper Scissors!\n");

            //Indtructions to play... explanation of the game flow, which keys are used
            Console.WriteLine("\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\n\tThe computer will make it's choice and you will be notified as to the winner.\nTo play, press Enter. \n\n");
           
           
            //start the game by pressing Enter
            Console.Read();

            // (unseen to the user)create some variables to store which choise the user made, computer choice
            // user win, computer win, number of ties, user names, player 1 (user name), player 2 (computer)
            
            
            int computerChoice = 0;
            Random rand = new Random(); // the Random class gets us a psuedorandom decimal between 0 and 1.
            int player1Choice = 0;
            int player1Wins = 0; //how many rounds p1 won  
            int computerWins = 0; //
            int numberOfTies = 0;
            string player1Name = "";
            string computerName = "";
            string player1ChoiceStr = "";
            bool successfulConversion = false;
            bool isTie = true;
            string playAgain = "";


            // start game by pressing enter
            

            //get the user name
            Console.WriteLine("What is your name?");
            player1Name = Console.ReadLine ();

            Console.WriteLine($"Welcome to R-P-S Game, {player1Name}");

            while(true)
            {
    


           // while (isTie)
           //{
            //get users choice
            Console.WriteLine("Please enter...\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");
            player1ChoiceStr = Console.ReadLine();


            //REMEMBER TO VALID USER INPUt





            try
            { 
                player1Choice = Int32.Parse(player1ChoiceStr);
            
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"The parse method failed because {ex.Message}");
                //this method to write to the console is string interpolation
                
            }
            catch (FormatException ex)
            {
                 Console.WriteLine($"The parse method failed because {ex.Message}");
            }   
            catch (ArgumentNullException ex)
            {
                 Console.WriteLine($"The parse method failed because {ex.Message}");
            }
           

           successfulConversion = Int32.TryParse(player1ChoiceStr, out player1Choice);

           Console.WriteLine($"the number you inputted was {successfulConversion}, {player1Choice}");
           
            //get the computer random choice
            computerChoice = (rand.Next(1000) % 3) + 1;
            Console.WriteLine(computerChoice);

            //what do you do when game is tie
            

            //evaluate the choice to determine the winner of the round.
            if(player1Choice == computerChoice)
            {
                //tell them it was a tie and loop back up to the repromt
                Console.WriteLine($"This round was a tie! ... Lets play again.");
                numberOfTies++; // ++ inrements the int by exactly 1
            }
            else if ((player1Choice == 1 && computerChoice == 3) || 
                         (player1Choice == 2 && computerChoice == 1) ||
                            (player1Choice == 3 && computerChoice ==2))

            {// if the user won
                Console.WriteLine($"Congrats, {player1Name}, you won this round");
                player1Wins = player1Wins + 1;
                isTie = false;
                // player1wins +=1
                // player1wins++;

            }
            else
            {// if the computer won
                    Console.WriteLine($"I'm sorry, {computerName} won this round.");
                   //update the tally
                    computerWins += 1; // this method gives you the option of incrementing by more than 1.
            }       isTie = false;
        // }

         // ask if they want to play again
         Console.WriteLine($"Hey {player1Name}, would you like to play again?\n\tEnter'Y' to play again or 'N' to quit the program");
         playAgain = Console.ReadLine();
         if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
         {
            Console.WriteLine($"the string are equal");
         }
         else
         {
           // continue;  // will end the current loop and immediately loop again   
            Console.WriteLine($"I'm sorry to see you go... se la vi.");
            break; // break out of a loop and move on
         }

         }  /**
                1 == rock
                2 == paper
                3 == scissors

            */

            //tell them who won, if there's a winner

            //ask to make another choice if it was a tie (loop)

            //ask if they wnat to play again (loop) if using rounds, each rounds neetds to be store

            //tell the user the tally results as of now

            //quit if they dont't want to play.... loop up to begin again, if Want to play again






        }
    }
