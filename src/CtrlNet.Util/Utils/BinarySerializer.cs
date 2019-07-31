using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CtrlNet.Util.Utils
{
    public class BinarySerializer
    {
        public byte[] Serialize(object data)
        {
            if (data == null)
            {
                data = null;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, data);
                result = memoryStream.ToArray();
            }
            return result;
        }

        public object Deserialize(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object result;
            using (MemoryStream memoryStream = new MemoryStream(data, 0, data.Length))
            {
                memoryStream.Seek(0L, SeekOrigin.Begin);
                object retObject = binaryFormatter.Deserialize(memoryStream);
                result = retObject;
            }
            return result;
        }
    }
}
