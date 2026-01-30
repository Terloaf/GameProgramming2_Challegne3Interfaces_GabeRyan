using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Challegne3Interfaces_GabeRyan
{
    internal class Program
    {
        
        public static bool _isPlaying = true;
        static Player player = new Player(playerPosX: 5, playerPosY: 5, ConsoleColor.Blue);
        static Enemy enemy = new Enemy(enemyPosX: 20, enemyPosY: 20, ConsoleColor.Red);

        

        static void Main(string[] args)
        {
            AgressiveMoveStrategy agressiveStrategy = new AgressiveMoveStrategy();
            PassiveMoveStrategy passiveMoveStrategy = new PassiveMoveStrategy();
            RandomMoveStrategy randomMoveStrategy = new RandomMoveStrategy();

            enemy._moveStrategy = agressiveStrategy;
            


            while (_isPlaying == true)
            {

                Draw();
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.M)
                {
                    enemy.Move();
                }
                if (input.Key == ConsoleKey.I)
                {
                    enemy._moveStrategy = agressiveStrategy;
                }
                if (input.Key == ConsoleKey.O)
                {
                    enemy._moveStrategy = passiveMoveStrategy;
                }
                if (input.Key == ConsoleKey.P)
                {
                    enemy._moveStrategy = randomMoveStrategy;
                }
                Console.Clear();
            }




        }

        public interface IMoveStrategy
        {
            Position Move(Position position);
            
        }
       


        class AgressiveMoveStrategy : IMoveStrategy
        {
            public Position Move(Position position)
            {
                int currentX = position._x;
                int currentY = position._y;

               

                if (currentX < player._playerPosition._x)
                {
                    currentX += 1;
                }
                if (currentX > player._playerPosition._x)
                {
                    currentX -= 1;
                }
                if (currentY < player._playerPosition._y)
                {
                    currentY += 1;
                }
                if (currentY > player._playerPosition._y)
                {
                    currentY -= 1;
                }

                return new Position(currentX, currentY);

            }
            
        }

        class PassiveMoveStrategy : IMoveStrategy 
        {
            public Position Move(Position position)
            {
                int currentX = position._x;
                int currentY = position._y;

                if (currentX > player._playerPosition._x)
                {
                    currentX += 1;
                }
                if (currentX < player._playerPosition._x)
                {
                    currentX -= 1;
                }
                if (currentY > player._playerPosition._y)
                {
                    currentY += 1;
                }
                if (currentY < player._playerPosition._y)
                {
                    currentY -= 1;
                }
                return new Position(currentX, currentY);

            }
        }

        class RandomMoveStrategy : IMoveStrategy
        {
            public Position Move(Position position)
            {
                int currentX = position._x;
                int currentY = position._y;
                Random random = new Random();

                int randomX = random.Next(-1, 2);
                int randomY = random.Next(-1, 2);

                currentX += randomX;
                currentY += randomY;

                return new Position(currentX, currentY);
            }
        }

        public struct Position
        {
            public int _x;
            public int _y;

            public Position(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }

        public class Player
        {

            public ConsoleColor _playerColour;
            public Position _playerPosition;

            
            public Player(int playerPosX, int playerPosY, ConsoleColor playerColour)
            {
                _playerPosition = new Position(playerPosX, playerPosY);
                _playerColour = playerColour;
            }
            
        }



        public class Enemy
        {
            public IMoveStrategy _moveStrategy;

            
            public ConsoleColor _enemyColour;
            public Position _enemyPosition;

            public Enemy(int enemyPosX, int enemyPosY, ConsoleColor enemyColour)
            {
                _enemyPosition = new Position(enemyPosX, enemyPosY);
                _enemyColour = enemyColour;
            }

            public void Move()
            {
                _enemyPosition = _moveStrategy.Move(_enemyPosition);
               
            }
            
        }

        public static void Draw()
        {
            Console.SetCursorPosition(player._playerPosition._x, player._playerPosition._y);
            Console.ForegroundColor = player._playerColour;
            Console.Write("O");
            Console.ResetColor();
            Console.SetCursorPosition(enemy._enemyPosition._x, enemy._enemyPosition._y);
            Console.ForegroundColor = enemy._enemyColour;
            Console.Write("X");
            Console.ResetColor();
        }
    }
}
