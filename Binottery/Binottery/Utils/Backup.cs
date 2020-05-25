using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Binottery.Utils
{
    public static class Backup
    {
        public static void Save(Game game, string fileName)
        {
            if (game == null)
            {
                return;
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(game.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, game);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The was an error while saving the game!");
            }
        }

        public static Game Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return null;
            }

            Game game = null;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Game));
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        game = (Game)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The was an error while loading the game!");
            }

            return game;
        }
    }
}
