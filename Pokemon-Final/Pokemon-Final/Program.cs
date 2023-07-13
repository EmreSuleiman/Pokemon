using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Final
{
    class Pokemon
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }

        public Pokemon(string name, int attack, int defence, int strength)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Strength = strength;
            Health = 100;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pokemon[] player1Pokemons = {
                new Pokemon("Pikachu", 70, 50, 60),
                new Pokemon("Charizard", 85, 75, 80),
                new Pokemon("Blastoise", 80, 80, 80)
            };

            Pokemon[] player2Pokemons = {
                new Pokemon("Mew", 60, 90, 90),
                new Pokemon("Gardevoir", 70, 65, 70),
                new Pokemon("Lucario", 80, 60, 70)
            };

            int currentPlayer = 1;
            int currentPokemonID = 0;

            while (true)
            {
                Pokemon currentPokemon;
                Pokemon opponentPokemon;

                if (currentPlayer == 1)
                {
                    currentPokemon = player1Pokemons[currentPokemonID];
                    opponentPokemon = player2Pokemons[currentPokemonID];
                }
                else
                {
                    currentPokemon = player2Pokemons[currentPokemonID];
                    opponentPokemon = player1Pokemons[currentPokemonID];
                }

                Console.WriteLine($"Отбор {currentPlayer} е на ход");
                Console.WriteLine($"Твоя покемон е {currentPokemon.Name}");
                Console.WriteLine($"Покемона на опонента е: {opponentPokemon.Name}");

                Console.WriteLine("Избери действие:");
                Console.WriteLine("1. Атака");
                Console.WriteLine("2. Смени покемон");

                int izbor = int.Parse(Console.ReadLine());

                if (izbor == 1)
                {
                    int attackDamage = CalculateDamage(currentPokemon.Attack, opponentPokemon.Defence, opponentPokemon.Strength);
                    opponentPokemon.Health -= attackDamage;

                    Console.WriteLine($"Ти нанесе {attackDamage} щета на {opponentPokemon.Name}!");

                    if (opponentPokemon.Health <= 0)
                    {
                        Console.WriteLine($"{opponentPokemon.Name} умря!");
                        currentPokemon.Health = Math.Min(currentPokemon.Health + currentPokemon.Strength / 10, 100);
                        currentPokemonID++;

                        if (currentPokemonID >= player1Pokemons.Length)
                        {
                            Console.WriteLine($"Отбор {currentPlayer} спечели играта!");
                            break;
                        }
                    }
                }
                else if (izbor == 2)
                {
                    currentPokemon.Health = Math.Min(currentPokemon.Health + currentPokemon.Strength / 10, 100);
                    currentPokemonID++;
                }

                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                }
                else
                {
                    currentPlayer = 1;
                }
            }
        }

        static int CalculateDamage(int attack, int defence, int strength)
        {
            int dmg = 0;
            Random random = new Random();
            int a = random.Next(attack + 1);
            int d = random.Next(defence + 1);

            if (a > d)
            {
                int s = random.Next(strength + 1);

                if (a > s)
                    dmg = a - d;
                else
                    dmg = (a - d) / 2;
            }

            return dmg;
        }
    }
}
