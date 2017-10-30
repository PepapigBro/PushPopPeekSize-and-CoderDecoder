using System;
using System.Collections.Generic;
using System.Text;

public class Program
{

    public byte[] Encode(string message)
    {
        byte[] charBytes = System.Text.Encoding.ASCII.GetBytes(message);

        //Вычисление размера выходного массива
        //double newSize = Math.Ceiling((double)(charBytes.Length) * 7 / 8);

        List<byte> output = new List<byte>();
        var tail = 0;
        var shift = 0;

        for (int i = 0; i < charBytes.Length; i++)
        {
            if ((i) < charBytes.Length - 1 ) {
                tail = charBytes[i + 1] << 7 - shift; } else { tail = 0; }

            var body = (charBytes[i] >> shift) | tail;

            shift++;
            if (shift == 7) {
                shift = 0;
                 body = (charBytes[i+1] << 1) | body;
                i = i + 1;
            }

            output.Add((byte)body);
        }
       
        return output.ToArray();
    }






    public string Decode(byte[] bytes)
    {
        StringBuilder message = new StringBuilder();

        var shift = 0;
        var tail = 0;
        var nullMask = 127; //0111 1111
    
        for (int i = 0; i < bytes.Length; i++)
        {
            var body = bytes[i] << shift;
            body = body & nullMask;
            if (shift > 0) { tail = bytes[i - 1] >> 8 - shift; } else { tail = 0; }
            body = body | tail;

            char character = (char)body;
            message.Append(character);
            
            shift++;
            if (shift == 7)
            {
                shift = 0;
                var additionByte = bytes[i] >> 1;
                    character = (char)(additionByte);
                    message.Append(character);
                
            }        
             
        }

        return message.ToString();
    }





    public static void Main()
    {

        string inputMessage = "123456789-abcdefg-1234567890-ABCDEFG-!!!";

        Program program = new Program();

        //Кодирование
        byte[] bytes = program.Encode(inputMessage);

        //Вывод байтов
        Console.WriteLine("Кодирование");
        Console.WriteLine(new string('-', 20));
        foreach (byte itemByte in bytes)
        {
            Console.WriteLine(getBinaryStringCode(itemByte));
        }
       


        //Декодирование
        Console.WriteLine();
        Console.WriteLine("Декодирование");
        Console.WriteLine(new string('-', 20));

        string message = program.Decode(bytes);
        Console.WriteLine(message);

        Console.WriteLine();
        Console.WriteLine("Длина исходного массива байт " + inputMessage.Length);
        Console.WriteLine("Длина после кодирования (байт) " + bytes.Length);
        Console.ReadLine();

    }







    //Вывод числа в двоичном виде
    public static string getBinaryStringCode(int number)
    {

        var sb = new StringBuilder();
        for (var i = 7; i >= 0; i--)
        {
            sb.Append((number & (1 << i)) == 0 ? '0' : '1');
        }

        return sb.ToString();
    }

}