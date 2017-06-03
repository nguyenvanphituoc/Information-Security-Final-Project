using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.DAL
{
    public class Clibs_14110434
    {
        //
        public static string GetFilePath_14110434(string sExt)
        {
            string filePath = null;
            bool isExist = true;
            Console.Write("Input your file path : ");
            filePath = Console.ReadLine();
            isExist = isExist & File.Exists(filePath);
            if (sExt != null)
                isExist = isExist & (Path.GetExtension(filePath) == sExt ? true : false);
            return isExist ? filePath : null;
        }
        //
        public static void ViewData_14110434(string sFilePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(sFilePath);
                int characters = GetNumOfCharsInFile(fileInfo.FullName);
                Console.WriteLine("Data of file <3 : ");
                Console.WriteLine("Directory : {0}", fileInfo.FullName);
                Console.WriteLine("Lenght : {0}", fileInfo.Length);
                Console.WriteLine("Characters : {0}", characters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //
        public static string ReadTextFile_14110434(string sFilePath)
        {
            if (!File.Exists(sFilePath)) return null;
            string allText = File.ReadAllText(sFilePath, Encoding.Unicode);
            return allText;
        }
        //
        public static bool WriteTextFile_14110434(string sFilePath, string sData)
        {
            bool complete = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(sFilePath, FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8))
                {
                    sw.WriteLine(sData);
                    sw.Close();
                    complete = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                complete = false;
            }
            return complete;
        }
        //
        public static byte[] ReadBinFile_14110434(string sFilePath)
        {
            if (!File.Exists(sFilePath)) return null;
            byte[] fileBytes = File.ReadAllBytes(sFilePath);
            return fileBytes;
        }
        //
        public static bool WriteBinFile_14110434(string sFilePath, byte[] Data)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePath, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    writer.Write(Data);
                    writer.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /*    support SA      */
        public static int GetNumOfCharsInFile(string filePath)
        {
            int count = 0;
            using (var sr = new StreamReader(filePath))
            {
                while (sr.Read() != -1)
                    count++;
            }
            return count;
        }
        // byte -> hex
        static public string ConvertByteToHex(byte[] buffer)
        {
            //String hexText = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            String hexText = "";
            foreach (byte abyte in buffer)
            {
                hexText += String.Concat(abyte.ToString("X2"));
            }
            hexText = MakeWord(hexText);
            return hexText;
        }
        // string -> hex
        static public string ConvertStringtoHex(string sValues)
        {
            byte[] bytes = ConvertStringtoByte(sValues);
            return ConvertByteToHex(bytes);

        }
        // string -> byte
        static public byte[] ConvertStringtoByte(string sValues) {
            return Encoding.Default.GetBytes(sValues);
        }

        // string -> byte
        static public byte[] ConvertStringtoByteASCII(string sValues)
        {
            return new ASCIIEncoding().GetBytes(sValues);
        }

        static public byte[] ConvertStringtoBigEnByte(string sValues)
        {
            return Encoding.BigEndianUnicode.GetBytes(sValues);
        }

        static public byte[] ConvertStringtoLitEnByte(string sValues)
        {
            return Encoding.Unicode.GetBytes(sValues);
        }
        // byte -> string
        public static string ConvertBytetoString(byte[] Data) {
            return Encoding.Default.GetString(Data);
        }

        // byte -> string
        public static string ConvertBytetoStringASCII(byte[] Data)
        {
            return new ASCIIEncoding().GetString(Data);
        }

        public static string ConvertBytetoBigEnString(byte[] Data)
        {
            return Encoding.BigEndianUnicode.GetString(Data);
        }

        public static string ConvertBytetoLitEnString(byte[] Data)
        {
            return Encoding.Unicode.GetString(Data);
        }
        // byte and byte
        static public byte[] ConvertBigEnToLittleEn(byte[] data)
        {
            String s = ConvertBytetoBigEnString(data);
            return ConvertStringtoLitEnByte(s);
        }

        static public byte[] ConvertLitteEnToBigEn(byte[] data)
        {
            String s = ConvertBytetoLitEnString(data);
            return ConvertStringtoLitEnByte(s);
        }

        static public string BytetoArray(byte[] bytes)
        {
            string text = "";
            foreach (var b in bytes)
            {
                text += " " + Convert.ToString(b);
            }
            return text;
        }

        static private string MakeWord(string sHexArray)
        {
            sHexArray = Regex.Replace(sHexArray, @"\s+", "").Trim();
            int len = sHexArray.Length;
            for (int i = 4; i < sHexArray.Length; i += 4)
            {
                sHexArray = sHexArray.Insert(i, " ");
                // IA insert
                i++;
            }
            return sHexArray;
        }
    }
}
