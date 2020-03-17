using System.IO;
using static System.Console;
using static System.IO.File;
using static System.Text.Encoding;
namespace FileStreamApp
{
    class Program
    {
        static void Main()
        {
            WriteLine("***** Fun with FileStreams *****\n");

            // Obtain a FileStream object.
            using (FileStream fStream = Open(@"myMessage.dat", FileMode.Create))
            {
                // Encode a string as an array of bytes.
                string msg = "Hello!";
                    byte[] msgAsByteArray = Default.GetBytes(msg);

                // Write byte[] to file.
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                // Reset internal position of stream.
                fStream.Position = 0;

                // Read the types from file and display to console.
                Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Write(bytesFromFile[i]);
                }

                // Display decoded messages.
                Write("\nDecoded Message: ");
                WriteLine(Default.GetString(bytesFromFile));
            }
            ReadLine();
        }
    }
}
