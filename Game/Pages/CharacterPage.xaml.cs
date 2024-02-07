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
using Game.Mongodb;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Game.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterPage.xaml
    /// </summary>
    public partial class CharacterPage //Cоздается ВОИН WARRIOR
    {
        public CharacterPage()
        {
            InitializeComponent();  
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int strength = Convert.ToInt32(StrengthTb.Text);
            int intelegence = Convert.ToInt32(IntelegenceTb.Text);
            int dexterity = Convert.ToInt32(DexterityTb.Text);
            int vitality = Convert.ToInt32(VitalityTb.Text);

            CRUD.CreateCharacterWarrior(new Character(name, strength, 250, dexterity, 80, intelegence, 50, vitality, 100, 0, 0, 0, 0, 0, 0, 0, 0));

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var filter = new BsonDocument();
            var result = collection.Find(filter).ToList();

            var pers = result.FirstOrDefault(x => x.Name == name);
            App.character = pers;

            if (pers != null)
                NavigationService.Navigate(new NotBaseStatpointsPage());
            else
                MessageBox.Show("!!!");
        }

        private void PlusStrenghbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinusStrenghbtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
