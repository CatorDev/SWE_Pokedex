using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Shapes;
using System.Windows;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Pokedex__Erich_Bosak__v1._0
{
    internal class Pokedex
    {
        internal List<Pokemon> Pokedex_General = new List<Pokemon>();
        internal List<Pokemon> Pokedex_Not_Caught = new List<Pokemon>();
        internal List<Pokemon> Pokedex_Seen = new List<Pokemon>();
        internal List<Pokemon> Pokedex_Caught = new List<Pokemon>();

        public Pokedex()
        { 

        }

        public void readCSV(List<Pokemon> list)
        {
            using (var reader = new StreamReader("pokemon.csv"))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    
                    if (values[0] == "#")
                    { 

                    }
                    else
                    {
                        list.Add(new Pokemon(Convert.ToInt32(values[0]), values[1], values[2], values[3], 
                        Convert.ToInt32(values[4]), Convert.ToInt32(values[5]), Convert.ToInt32(values[6]), Convert.ToInt32(values[7]),
                        Convert.ToInt32(values[8]), Convert.ToInt32(values[9]), Convert.ToInt32(values[10]), Convert.ToInt32(values[11]), Convert.ToBoolean(values[12])));
                    }
                }
            }
        }

        public bool FindPokemon(string pokemon_name, List<Pokemon> list)
        {
            bool result = false;
            foreach (Pokemon item in list)
            {
                if (item.Name == pokemon_name)
                {
                    result = true;
                }
            }
            return result;
        }

        public Pokemon GetPokemonByName(string pokemon_name, List<Pokemon> list)
        {
            Pokemon tmp = null;
            foreach (Pokemon item in list)
            {
                if (item.Name == pokemon_name)
                {
                    tmp = item;
                }
            }
            return tmp;
        }

        public bool CatchPokemon(string name)
        {
            bool success = false;
            if(FindPokemon(name,Pokedex_General))
            {
                if (FindPokemon(name, Pokedex_Not_Caught) && !FindPokemon(name, Pokedex_Caught))
                {
                    Pokedex_Caught.Add(GetPokemonByName(name, Pokedex_General));
                    Pokedex_Not_Caught.Remove(GetPokemonByName(name,Pokedex_Not_Caught));
                    if (!FindPokemon(name, Pokedex_Seen))
                    {
                        Pokedex_Seen.Add(GetPokemonByName(name, Pokedex_General));
                    }
                    success = true;
                }
            }
            return success;
        }

        public bool ReleasePokemon(string name)
        {
            bool success = false;
            if(FindPokemon(name, Pokedex_General))
            {
                if(!FindPokemon(name, Pokedex_Not_Caught) && FindPokemon(name, Pokedex_Caught))
                {
                    Pokedex_Not_Caught.Add(GetPokemonByName(name, Pokedex_General));
                    Pokedex_Caught.Remove(GetPokemonByName(name, Pokedex_Caught));
                    success = true;
                }
            }
            return success;
        }

        public List<Pokemon> Pokedex_Sort(List<Pokemon> list)
        {
            return list.OrderBy(pokemon => pokemon.ID).ToList();
        }

        public List<Pokemon> GetPokemonListByType(string type, List<Pokemon> list)
        {
            List<Pokemon> output = new List<Pokemon>();
            foreach (Pokemon pokemon in list)
            {
                if(pokemon.Type_1 == type || pokemon.Type_2 == type)
                {
                    output.Add(pokemon);
                }
            }
            return output;
        }
    }
}
