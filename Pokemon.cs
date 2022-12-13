using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex__Erich_Bosak__v1._0
{
    public class Pokemon
    {
        public Pokemon(int i_ID,string i_Name, string i_Type_1, string i_Type_2, int i_Total, 
                       int i_HP, int i_Attack, int i_Defense, int i_Sp_Attack, int i_Sp_Defense, 
                       int i_Speed, int i_Generation, bool i_Legendary)
        {
            ID = i_ID;
            Name = i_Name;
            Type_1 = i_Type_1;
            Type_2 = i_Type_2;
            Total = i_Total;
            HP = i_HP;
            Attack = i_Attack;
            Defense = i_Defense;
            Sp_Attack = i_Sp_Attack;
            Sp_Defense = i_Sp_Defense;
            Speed = i_Speed;
            Generation = i_Generation;
            Legendary = i_Legendary;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Type_1 { get; set; }

        public string Type_2 { get; set; }

        public int Total { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Sp_Attack { get; set; }

        public int Sp_Defense { get; set; }

        public int Speed { get; set; }

        public int Generation { get; set; }

        public bool Legendary { get; set; }
    }
}
