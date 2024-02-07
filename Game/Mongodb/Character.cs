using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [BsonIgnoreExtraElements]
    public class Character
    {
        public string Name { get; set; }
        public int MaxVitality { get; set; }
        public int MaxDexterity { get; set; }
        public int MaxStrength { get; set; }
        public int MaxIntelegence { get; set; }
        public int Vitality { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }   
        public int Intelegence { get; set; }
        public double PDamage { get; set; }
        public double Armor { get; set; }
        public double MDamage { get; set; }
        public double MDefence { get; set; }
        public double CrtChanse { get; set; }
        public double CrtDamage { get; set; }

        //public double CrtDamage
        //{
        //    get => _crtDamage;

        //    set 
        //    {
        //        if (value > _crtDamage)

        //    }
        //}

        public double Heath { get; set; }
        public double Manna { get; set; }
        public Character(string name, int strenght, int maxStrenght, int dexterity, int maxDexterity, 
            int intelegence, int maxIntelegence, int vitality, int maxVitality, double health, double manna, 
            double pdamage, double armor, double mdamage, double mdefence, double crtchanse, double crtmdamage)
        {
            Name = name;
            Strenght = strenght;
            MaxStrength = maxStrenght;
            Dexterity = dexterity;
            MaxDexterity = maxDexterity;
            Intelegence = intelegence;
            MaxIntelegence = maxIntelegence;
            Vitality = vitality;
            MaxVitality = maxVitality;
            Heath = health ;
            Manna = manna;
            PDamage = pdamage;
            Armor = armor;
            MDamage = mdamage;
            MDefence = mdefence;
            CrtChanse = crtchanse;
            CrtDamage = crtmdamage;          
        }
        public void GetAttributsWarrrior()
        {
            Heath = Vitality * 2;
            Manna = Intelegence;
        }

        public void GetAttributsWizard()
        {
            Heath = Vitality * 1.4 + 0.2;
            Manna = 1.5 * Intelegence;
        }
    }
}
