using System;
using System.Collections.Generic;
using System.Text;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;
using System.Threading.Tasks;

namespace ReuzengildeProject.Classes
{
    public class DatabaseController
    {
        // gebruik DatabasseController.SaveJsonLocal(App.Path) om het json file op te slaan in de app
        public static void SaveJsonLocal(string Path)
        {
            SaveFile(Path);
        }
        //gebruik JsonToCs reus = DatabaseController.JsonFile(App.Path) om alle informatie uit het opgeslagen json file om te zetten naar in list die zit in her var reus
        public static JsonToCs JsonFile(string Path)
        {
            string file = File.ReadAllText(Path);
            return JsonToCs.FromJson(file);
        }


        private static async Task SaveFile(string Path)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://reuzengildetest.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = await client.GetAsync("Reus");
            var json = response.Body;
            File.WriteAllText(Path, json);
        }

    }
}
