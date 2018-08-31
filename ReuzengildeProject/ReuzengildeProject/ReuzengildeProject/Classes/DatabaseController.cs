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
        //haalt informatie uit de database en slaat het op 
        public static void SaveJsonLocal(string Path)
        {
            SaveFile(Path);
        }

        
        //haalt informatie die opgeslagen is op de telefoon
        public static JsonToCs GetJson(string Path)
        {
            string file = File.ReadAllText(Path);
            return JsonToCs.FromJson(file);
        }

        //maakt verbinding met de database en haalt de informatie eruit
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
