using Game.Mongodb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Character SelectedCh { get; set; }
        public static Character character; //типо выбранный перс
        public static Weapon Selectesweapon { get; set; }
        public static Weapon weapon; //Типо выбранное оружие
    }
}
