using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для NotBaseStatpointsPage.xaml
    /// </summary>
    public partial class NotBaseStatpointsPage : Page
    {
        public NotBaseStatpointsPage()
        {
            InitializeComponent();
            txtName.Text = App.character.Name;
            StrengthTb.Text = Convert.ToString(App.character.Strenght);
            DexterityTb.Text = Convert.ToString(App.character.Dexterity);
            IntelegenceTb.Text = Convert.ToString(App.character.Intelegence);
            VitalityTb.Text = Convert.ToString(App.character.Vitality);

            HealthTB.Text = Convert.ToString(App.character.Vitality * 2 + (App.character.Strenght));
            MannaTB.Text = Convert.ToString(App.character.Intelegence);

            PDamageTb.Text = Convert.ToString(App.character.Strenght);

            ArmorTb.Text = Convert.ToString(App.character.Dexterity);
            MDamageTb.Text = Convert.ToString(App.character.Intelegence * 0.2);
            MDefenceTb.Text = Convert.ToString(App.character.Intelegence * 0.5);
            CRTChanseTb.Text = Convert.ToString(App.character.Dexterity * 0.2);
            CRTDamageTb.Text = Convert.ToString(App.character.Dexterity);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "")
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("Characters");
                var collection = database.GetCollection<Character>("CharacterCollection");

                var filterName = Builders<Character>.Filter.Eq("Name", App.character.Name);
                var filtersStrenght = Builders<Character>.Filter.Eq("Strenght", App.character.Strenght);
                var filtersIntelegence = Builders<Character>.Filter.Eq("Intelegence", App.character.Intelegence);
                var filtersDexterity = Builders<Character>.Filter.Eq("Dexterity", App.character.Dexterity);
                var filtersVitality = Builders<Character>.Filter.Eq("Vitality", App.character.Vitality);
                var filtersHealth = Builders<Character>.Filter.Eq("Heath", App.character.Heath);
                var filtersManna = Builders<Character>.Filter.Eq("Manna", App.character.Manna);
                var filtersPDamage = Builders<Character>.Filter.Eq("PDamage", App.character.PDamage);
                var filtersArmor = Builders<Character>.Filter.Eq("Armor", App.character.Armor);
                var filtersMDamage = Builders<Character>.Filter.Eq("MDamage", App.character.MDamage);
                var filtersMDefense = Builders<Character>.Filter.Eq("MDefence", App.character.MDefence);
                var filtersCRTChanse = Builders<Character>.Filter.Eq("CrtChanse", App.character.CrtChanse);
                var filtersCRTDamage = Builders<Character>.Filter.Eq("CrtDamage", App.character.CrtDamage);

                // параметр обновления
                var update = Builders<Character>.Update.Set("Name", txtName.Text);
                var updateStrenght = Builders<Character>.Update.Set("Strenght", Convert.ToInt32(StrengthTb.Text));
                var updateIntelegence = Builders<Character>.Update.Set("Intelegence", Convert.ToInt32(IntelegenceTb.Text));
                var updateDexterity = Builders<Character>.Update.Set("Dexterity", Convert.ToInt32(DexterityTb.Text));
                var updateVitality = Builders<Character>.Update.Set("Vitality", Convert.ToInt32(VitalityTb.Text));
                var updateHealth = Builders<Character>.Update.Set("Heath", Convert.ToInt32(HealthTB.Text));
                var updateManna = Builders<Character>.Update.Set("Manna", Convert.ToInt32(MannaTB.Text));

                var updatePDamage = Builders<Character>.Update.Set("PDamage", Convert.ToInt32(PDamageTb.Text));

                var updateArmor = Builders<Character>.Update.Set("Armor", Convert.ToInt32(ArmorTb.Text));
                var updateMDamage = Builders<Character>.Update.Set("MDamage", Convert.ToInt32(MDamageTb.Text));
                var updateMDefense = Builders<Character>.Update.Set("MDefence", Convert.ToInt32(MDefenceTb.Text));
                var updateCRTChanse = Builders<Character>.Update.Set("CrtChanse", Convert.ToInt32(CRTChanseTb.Text));
                var updateCRTDamage = Builders<Character>.Update.Set("CrtDamage", Convert.ToInt32(CRTDamageTb.Text));

                var result = collection.UpdateOneAsync(filterName, update);
                collection.UpdateOneAsync(filtersStrenght, updateStrenght);
                collection.UpdateOneAsync(filtersIntelegence, updateIntelegence);
                collection.UpdateOneAsync(filtersDexterity, updateDexterity);
                collection.UpdateOneAsync(filtersVitality, updateVitality);

                collection.UpdateOneAsync(filtersHealth, updateHealth);
                collection.UpdateOneAsync(filtersManna, updateManna);

                collection.UpdateOneAsync(filtersPDamage, updatePDamage);

                collection.UpdateOneAsync(filtersArmor, updateArmor);
                collection.UpdateOneAsync(filtersMDamage, updateMDamage);
                collection.UpdateOneAsync(filtersMDefense, updateMDefense);
                collection.UpdateOneAsync(filtersCRTChanse, updateCRTChanse);
                collection.UpdateOneAsync(filtersCRTDamage, updateCRTDamage);

                Refresh();
        
                MessageBox.Show("ok");
                NavigationService.Navigate(new NotBaseStatpointsPage());


            }
            else
                MessageBox.Show("!!!");
        }


        public void Refresh()
        {
            App.character.Name = txtName.Text;

            App.character.Strenght = Convert.ToInt32(StrengthTb.Text);
            App.character.Intelegence = Convert.ToInt32(IntelegenceTb.Text);
            App.character.Dexterity = Convert.ToInt32(DexterityTb.Text);
            App.character.Vitality = Convert.ToInt32(VitalityTb.Text);

            App.character.Heath = Convert.ToInt32(HealthTB.Text);
            App.character.Manna = Convert.ToInt32(MannaTB.Text);

            App.character.PDamage = Convert.ToInt32(PDamageTb.Text);

            App.character.Armor = Convert.ToInt32(ArmorTb.Text);
            App.character.MDamage = Convert.ToInt32(MDamageTb.Text); 
            App.character.MDefence = Convert.ToInt32(MDefenceTb.Text);
            App.character.CrtChanse = Convert.ToInt32(CRTChanseTb.Text);
            App.character.CrtDamage = Convert.ToInt32(CRTDamageTb.Text);
        }
    }
}
