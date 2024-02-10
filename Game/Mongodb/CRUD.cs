using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Game.Mongodb
{
    public class CRUD
    {
        public static void CreateCharacterWarrior(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static Character GetCharacterWarrior(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();
            return character;
        }

        public static void CreateCharacterRogue(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static void CreateCharacterWizard(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        //public static void CreateWand(Weapon weapon)
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("Characters");
        //    var collection = database.GetCollection<Weapon>("CharacterCollection");
        //    collection.InsertOne(weapon);
        //}

        private static IMongoDatabase ConnectToDatabase(string databaseName)
        {
            var client = new MongoClient("mongodb://localhost");
            return client.GetDatabase(databaseName);
        }

        public static void Put<T>(string databaseName, string collectionName, string name, T record)
        {
            var database = CRUD.ConnectToDatabase(databaseName);
            var collection = database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Name", name);
            var result = collection.ReplaceOne(filter, record);
        }
    }
}
