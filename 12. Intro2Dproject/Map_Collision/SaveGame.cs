using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Xml.Serialization;

namespace Map_Collision
{
    public class SaveGame
    {
        public Vector2 playerPosition;

        public SaveGame()
        {

        }

        public SaveGame(Vector2 _playerPosition)
        {
            playerPosition = _playerPosition;
        }
        
        public static void Save(SaveGame saveGame, string fileName)
        {
            using (StreamWriter writeText = new StreamWriter(fileName))
            {
                writeText.WriteLine("" + saveGame.playerPosition.X + ";" + saveGame.playerPosition.Y);
            }
        }

        public static SaveGame LoadGame(String fileName)
        {
            if (File.Exists(fileName))
            {
                Vector2 playerPos = Vector2.Zero;
                using (StreamReader readText = new StreamReader(fileName))
                {
                    string posString = readText.ReadLine();
                    playerPos = new Vector2(float.Parse(posString.Split(';')[0]), float.Parse(posString.Split(';')[1]));
                }
                return new SaveGame(playerPos);
            }
            else
            {
                Console.WriteLine("File does not exist");
                return new SaveGame(new Vector2(100, 100));
            }
        }

        public static void SaveX(SaveGame sg, String fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SaveGame));
            FileStream stream = new FileStream(fileName, FileMode.Create);

            ser.Serialize(stream, sg);
            stream.Close();
        }

        public static SaveGame LoadGameX(String fileName)
        {
            if (!File.Exists(fileName))
            {
                return new SaveGame(new Vector2(100, 100));
            }
            XmlSerializer ser = new XmlSerializer(typeof(SaveGame));
            StreamReader reader = new StreamReader(fileName);
            SaveGame saveGame = (SaveGame)ser.Deserialize(reader);

            reader.Close();

            return saveGame;
        }
    }
}
