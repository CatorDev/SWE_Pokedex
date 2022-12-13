using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pokedex__Erich_Bosak__v1._0
{
    /// <summary>
    /// Interaktionslogik für Pokemon_Info.xaml
    /// </summary>
    public partial class Pokemon_Info : Window
    {
        
        public Pokemon_Info(Pokemon pokemon)
        {
            InitializeComponent();
            Title = pokemon.Name;
            Tbx_ID.Text = Convert.ToString(pokemon.ID);
            Tbx_Name.Text = pokemon.Name;
            Tbx_Generation.Text = Convert.ToString(pokemon.Generation);
            if(pokemon.Legendary)
            {
                Cbx_Legendary.IsChecked = true;
            }
            if(pokemon.Type_1 == "")
            {
                Tbx_Type1.Text = "None";
            }
            else
            {
                Tbx_Type1.Text = pokemon.Type_1;
            }
            if (pokemon.Type_2 == "")
            {
                Tbx_Type2.Text = "None";
            }
            else
            {
                Tbx_Type2.Text = pokemon.Type_2;
            }

            Tbx_Total.Text = Convert.ToString(pokemon.Total);
            Tbx_HP.Text = Convert.ToString(pokemon.HP);
            Tbx_Attack.Text = Convert.ToString(pokemon.Attack);
            Tbx_Defense.Text = Convert.ToString(pokemon.Defense);
            Tbx_Sp_Attack.Text = Convert.ToString(pokemon.Sp_Attack);
            Tbx_Sp_Defense.Text = Convert.ToString(pokemon.Sp_Defense);
            Tbx_Speed.Text = Convert.ToString(pokemon.Speed);
        }
    }
}
