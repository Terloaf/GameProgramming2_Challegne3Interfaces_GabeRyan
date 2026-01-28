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
            
            while(_isPlaying == true)
            {

                Draw();
                ConsoleKeyInfo input = Console.ReadKey(true);
                if(input.Key == ConsoleKey.M)
                {
                    enemy.Move();
                }
                if(input.Key == ConsoleKey.I)
                {
                    enemy._movementType = Enemy.MovementType.agressive;
                }
                if (input.Key == ConsoleKey.O)
                {
                    enemy._movementType = Enemy.MovementType.passive;
                }
                if (input.Key == ConsoleKey.P)
                {
                    enemy._movementType = Enemy.MovementType.random;
                }
                Console.Clear();




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

            ConsoleColor _playerColour;
            public Position _playerPosition;

            
            public Player(int playerPosX, int playerPosY, ConsoleColor playerColour)
            {
                _playerPosition = new Position(playerPosX, playerPosY);
                _playerColour = playerColour;
            }
            
        }



        public class Enemy
        {
            
            ConsoleColor _enemyColour;
            public Position _enemyPosition;

            public Enemy(int enemyPosX, int enemyPosY, ConsoleColor enemyColour)
            {
                _enemyPosition = new Position(enemyPosX, enemyPosY);
                _enemyColour = enemyColour;
            }
            public enum MovementType
            {
                agressive,
                passive,
                random

            };
            public MovementType _movementType;

            public void Move()
            {
                if(_movementType == MovementType.agressive)
                {
                    if(_enemyPosition._x < player._playerPosition._x)
                    {
                        _enemyPosition._x += 1;
                    }
                    if (_enemyPosition._x > player._playerPosition._x)
                    {
                        _enemyPosition._x -= 1;
                    }
                    if (_enemyPosition._y < player._playerPosition._y)
                    {
                        _enemyPosition._y += 1;
                    }
                    if (_enemyPosition._y > player._playerPosition._y)
                    {
                        _enemyPosition._y -= 1;
                    }
                }
                if(_movementType == MovementType.passive)
                {
                    if (_enemyPosition._x > player._playerPosition._x)
                    {
                        _enemyPosition._x += 1;
                    }
                    if (_enemyPosition._x < player._playerPosition._x)
                    {
                        _enemyPosition._x -= 1;
                    }
                    if (_enemyPosition._y > player._playerPosition._y)
                    {
                        _enemyPosition._y += 1;
                    }
                    if (_enemyPosition._y < player._playerPosition._y)
                    {
                        _enemyPosition._y -= 1;
                    }
                }
                if(_movementType == MovementType.random)
                {
                    Random random = new Random();

                    int randomX = random.Next(-1, 2);
                    int randomY = random.Next(-1, 2);

                    _enemyPosition._x += randomX;
                    _enemyPosition._y += randomY;
                }
                
                
            }


        }

        public static void Draw()
        {
            Console.SetCursorPosition(player._playerPosition._x, player._playerPosition._y);
            Console.Write("O");
            Console.SetCursorPosition(enemy._enemyPosition._x, enemy._enemyPosition._y);
            Console.Write("X");
        }
    }
}
