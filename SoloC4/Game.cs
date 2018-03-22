using System;
using System.Collections.Generic;
using System.Text;

namespace SoloC4
{
    class Game
    {
        private Player playerOne;
        private Player playerTwo;
        private bool status;
        private Board curBoard;

        public Game()
        {
            this.curBoard = new Board();
            this.status = true;
            WelcomeMessage();
            SetupGame();
            Play();
        }


        public Player ChangePlayer(Player curPlayer)
        {
            if (curPlayer == playerOne) return playerTwo;
            return playerOne;
        }
        public void Play()
        {
            var nextToMove = playerOne;
            while (status)
            {
                Console.Clear();
                this.curBoard.drawBoard();
                Console.WriteLine( $"{nextToMove.GetName()}, Where Would You Like To Move? Enter 1-7 to Drop Your Piece in that Slot, Or Type 'End' To Quit.");
                var inputRaw = Console.ReadLine();
                var inputLowerCase = inputRaw.ToLower();
                if(inputLowerCase == "end")
                {
                    EndProcess();
                        return;
                }
                int inputToInt;
                var isValidMove = int.TryParse(inputLowerCase, out inputToInt);
                if(isValidMove == false)
                {
                    Console.WriteLine("Not a valid Move. Press Any Key to Continue.");
                    Console.ReadKey();
                }
                else
                {
                    bool results = curBoard.DropValid(inputToInt-1);
                    if (results)
                    {
                        curBoard.DropPiece(nextToMove.GetNum(), inputToInt - 1);
                        nextToMove = ChangePlayer(nextToMove);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid Move. Press Any Key to Continue.");
                        Console.ReadKey();
                    }

                }
            }
        }
        public void EndProcess()
        {
            status = false;
            Console.WriteLine(@"
                                       Thank you for playing Connect Four!
                                       Press Any Key to Shut Window.

            ");
            Console.Read();

        }
        public void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
                                       Welcome to Connect Four!
                                       Press Any Key to Start.

            ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        public void SetupGame()
        {
            var playerOneName = "";
            var playerTwoName = "";
            while(playerOneName.Length < 2)
            {
                Console.WriteLine("Player One, What Is Your Name?");
                playerOneName = Console.ReadLine();
            }
            while (playerTwoName.Length < 2)
            {
                Console.WriteLine("Player Two, What Is Your Name?");
                playerTwoName = Console.ReadLine();
            }

            playerOne = new Player(playerOneName, 1);
            playerTwo = new Player(playerTwoName, 2);

        }
    }
}
