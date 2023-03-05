using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace 基金管理
{
    public class SerializerHelper
    {
        public static void Serializer<T>(string path,T model)
        {
            // Create a new instance of a StreamWriter
            // to read and write the data.
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(fs);
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            ser.WriteObject(writer, model);
            //Console.WriteLine("Finished writing object.");
            writer.Close();
            fs.Close();
        }

        public static T DeSerializer<T>(string path)
        {
            // from an XML file. First create an instance of the XmlDictionaryReader.
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(fs, new XmlDictionaryReaderQuotas());

            // Create the DataContractSerializer instance.
            DataContractSerializer ser = new DataContractSerializer(typeof(T));

            // Deserialize the data and read it from the instance.
            T result = (T)ser.ReadObject(reader);
            Console.WriteLine("Reading this object:");
            //Console.WriteLine(String.Format("{0}, ID: {1}",
            //newPerson.Name, newPerson.ID));
            reader.Close();
            fs.Close();

            return result;
        }
    }
}
