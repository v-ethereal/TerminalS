using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Arsis.RentalSystem.Core.Helpers
{
    public static class XmlUtility
    {
        public static void SerializeObjectToDisk<T>(string fileStoreName, T objectToSave)
        {
            var serializer = new XmlSerializer(typeof (T));
            var memoryStream = new MemoryStream();
            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            serializer.Serialize(xmlTextWriter, objectToSave);
            memoryStream = (MemoryStream) xmlTextWriter.BaseStream;
            File.WriteAllBytes(fileStoreName, memoryStream.ToArray());
        }

        public static T DeserializeObjectFromDisk<T>(string fileStoreName) where T : class
        {
            var serializer = new XmlSerializer(typeof (T));
            using (XmlReader reader = XmlReader.Create(fileStoreName))
            {
                return (T) serializer.Deserialize(reader);
            }
        }
    }
}