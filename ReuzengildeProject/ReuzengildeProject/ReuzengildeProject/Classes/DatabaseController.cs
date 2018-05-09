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
        //gebruik JsonToCs naam = DatabaseController.GetJson(App.Path) om alle informatie uit het opgeslagen json file om te zetten naar in list die zit in het var reus
        //je kan die informatie dan gebruiken door voor de informatie: naam.Reus[nummer van de deelnemer].Informatie.Text of voor de naam: naam.Reus[nummer van de deelnemer].Name.Text 
        public static JsonToCs GetJson(string Path)
        {
            string file = File.ReadAllText(Path);
            return JsonToCs.FromJson(file);
        }

        public static async Task SaveFile(string Path)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://reuzengilde-1089d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = await client.GetAsync("");
            var json = response.Body;
            File.WriteAllText(Path, json);
            App.Information = GetJson(App.Path);
        }
    }
}
