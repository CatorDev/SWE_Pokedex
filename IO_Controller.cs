using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Pokedex__Erich_Bosak__v1._0
{
    internal class IO_Controller
    {
        internal Pokedex obj_Pokedex = new Pokedex();

        public void Create_Pokemon_Info(Pokemon pokemon)
        {
            Pokemon_Info pokemon_info = new Pokemon_Info(pokemon);
            pokemon_info.Show();
        }
    }
}
