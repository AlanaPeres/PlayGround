using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using HubDeJogos.Entities;

namespace HubDeJogos.Entities.Json
{

    public class Json
    {

        public Json()
        {
            if(!String.IsNullOrEmpty(Filepath)) File.Create(path).Close();
        }

        public void SerializeJson(List<Account> jogadores, string Filepath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(jogadores);

                File.WriteAllText(Filepath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

        public void DeserializeJson(List<Account> jogadores, string Filepath)
        {
            string jsonstring = File.ReadAllText(Filepath);

                List<Account> allplayers = JsonSerializer.Deserialize<List<Account>>(jsonstring);

                allplayers.ForEach(usuario => jogadores.Add(usuario));
            

        }
    }
}
