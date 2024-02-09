using Game.Mongodb;
using MongoDB.Bson;
using MongoDB.Driver;
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

namespace Game.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterPageWizard.xaml
    /// </summary>
    public partial class CharacterPageWizard : Page
    {
        public CharacterPageWizard()
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

            if (strength > 45 || intelegence > 250 || dexterity > 80 || vitality > 70)
            {
                MessageBox.Show("Превышены максимальные значения");
            }
            else
            {
                CRUD.CreateCharacterWizard(new Character(name, "Wizard", strength, 45, dexterity, 80, intelegence, 250, vitality, 70, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1, 1000));

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
        }
    }
}
