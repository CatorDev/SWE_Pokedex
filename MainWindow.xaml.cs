using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokedex__Erich_Bosak__v1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IO_Controller Ioc = new IO_Controller();

        List<string> status_list = new List<string>();
        List<string> type_list = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            Ioc.obj_Pokedex.readCSV(Ioc.obj_Pokedex.Pokedex_General);
            Ioc.obj_Pokedex.readCSV(Ioc.obj_Pokedex.Pokedex_Not_Caught);
            status_list.Add("All");
            status_list.Add("Not Caught");
            status_list.Add("Seen");
            status_list.Add("Caught");
            type_list.Add("Water");
            type_list.Add("Steel");
            type_list.Add("Rock");
            type_list.Add("Psychic");
            type_list.Add("Poison");
            type_list.Add("Normal");
            type_list.Add("Ice");
            type_list.Add("Ground");
            type_list.Add("Grass");
            type_list.Add("Ghost");
            type_list.Add("Flying");
            type_list.Add("Fire");
            type_list.Add("Fighting");
            type_list.Add("Fairy");
            type_list.Add("Electric");
            type_list.Add("Dragon");
            type_list.Add("Dark");
            type_list.Add("Bug");
            Cb_OutputByType.ItemsSource = type_list;
            Cb_OutputByStatus.ItemsSource = status_list;
            Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.Pokedex_General;
        }

        private void Dg_PokedexTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ioc.Create_Pokemon_Info((Pokemon)Dg_PokedexTable.SelectedItem); // erfasst das ausgewählte Item im DataGrid und gibt dann das Objekt vom Typ Pokemon an die Methode weiter
        }

        private void Cb_OutputByStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(Convert.ToString(Cb_OutputByStatus.SelectedValue))
            {
                case "All":
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.Pokedex_General;
                    Dg_PokedexTable.Items.Refresh();
                    break;
                case "Not Caught":
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.Pokedex_Not_Caught;
                    Dg_PokedexTable.Items.Refresh();
                    break;
                case "Seen":
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.Pokedex_Seen;
                    Dg_PokedexTable.Items.Refresh();
                    break;
                case "Caught":
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.Pokedex_Caught;
                    Dg_PokedexTable.Items.Refresh();
                    break;
                default:
                    MessageBox.Show("Could not change List");
                    Dg_PokedexTable.Items.Refresh();
                    break;
            }
            Cb_OutputByType_SelectionChanged(sender, e);
        }
        private void Cb_OutputByType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Convert.ToString(Cb_OutputByStatus.SelectedValue))
            {
                case "All":
                    Dg_PokedexTable.ItemsSource = null;
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.GetPokemonListByType(Convert.ToString(Cb_OutputByType.SelectedValue), Ioc.obj_Pokedex.Pokedex_General);
                    break;
                case "Not Caught":
                    Dg_PokedexTable.ItemsSource = null;
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.GetPokemonListByType(Convert.ToString(Cb_OutputByType.SelectedValue), Ioc.obj_Pokedex.Pokedex_Not_Caught);
                    break;
                case "Seen":
                    Dg_PokedexTable.ItemsSource = null;
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.GetPokemonListByType(Convert.ToString(Cb_OutputByType.SelectedValue), Ioc.obj_Pokedex.Pokedex_Seen);
                    break;
                case "Caught":
                    Dg_PokedexTable.ItemsSource = null;
                    Dg_PokedexTable.ItemsSource = Ioc.obj_Pokedex.GetPokemonListByType(Convert.ToString(Cb_OutputByType.SelectedValue), Ioc.obj_Pokedex.Pokedex_Caught);
                    break;
                default:
                    break;
            }
        }

        private void Bt_FightPokemon_Click(object sender, RoutedEventArgs e)
        {
            string name = Tb_FightPokemon.Text;
            if(Ioc.obj_Pokedex.CatchPokemon(name))
            {
                MessageBox.Show($"You fight {name} and catch it.");
            }
            else
            {
                if(name == "")
                {
                    MessageBox.Show("Please input a Pokemon");
                }
                else
                {
                    MessageBox.Show($"{name} doesn't exist or you have already caught it");
                }
            }
            Dg_PokedexTable.Items.Refresh();
            Ioc.obj_Pokedex.Pokedex_Not_Caught = Ioc.obj_Pokedex.Pokedex_Sort(Ioc.obj_Pokedex.Pokedex_Not_Caught);
            Ioc.obj_Pokedex.Pokedex_Caught = Ioc.obj_Pokedex.Pokedex_Sort(Ioc.obj_Pokedex.Pokedex_Caught);
        }

        private void Bt_ReleasePokemon_Click(object sender, RoutedEventArgs e)
        {
            string name = Tb_ReleasePokemon.Text;
            if(Ioc.obj_Pokedex.ReleasePokemon(name))
            {
                MessageBox.Show($"You release your {name}");
            }
            else
            {
                if (name == "")
                {
                    MessageBox.Show("Please input a Pokemon");
                }
                else
                {
                    MessageBox.Show($"{name} doesn't exist or you haven't caught it");
                }
            }
            Ioc.obj_Pokedex.Pokedex_Not_Caught = Ioc.obj_Pokedex.Pokedex_Sort(Ioc.obj_Pokedex.Pokedex_Not_Caught);
            Ioc.obj_Pokedex.Pokedex_Caught = Ioc.obj_Pokedex.Pokedex_Sort(Ioc.obj_Pokedex.Pokedex_Caught);
            Dg_PokedexTable.Items.Refresh();
        }
    }
}
