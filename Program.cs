using System;
using System.Collections.Generic;
namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string abc = " abcdefghijklmnopqrstuvwxyz.,!?-—()<>[]{}\'\":;`~1234567890_=+\\|/*@#$%^&абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int len = abc.Length;
            string str = "Enigma - is one of the best encrypt machine in the world! (As of 1941).";
            str = str.ToLower();
            List<Rotor> Rotors = new List<Rotor>();
            Rotors.Add(new Rotor(len));//роторы 1-3
            Rotors.Add(new Rotor(len));
            Rotors.Add(new Rotor(len));
            Rotors.Add(new Rotor(len));//рефлектор
            RotorsQueue rq = new RotorsQueue(Rotors);
            foreach (var item in Rotors)
            {
                for (int i = 0; i < len; i++)
                {
                    //Console.Write(i + "->" + item.GetCommutator()[i] + " ");
                }
                //Console.WriteLine();
            }

            List<int> cr = new List<int>();
            List<int> rc = new List<int>();
            Console.WriteLine("-----------");
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
            Console.WriteLine("-----------");
            for (int i = 0; i < str.Length; i++)
            {
                cr.Add(rq.Encrypt(abc.IndexOf(str[i])));
                //Console.Write(abc[cr[i]]);
                //Console.WriteLine();
            }
            Console.WriteLine("----------");
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(abc[cr[i]]);
                if (i % 5 == 0)
                {
                    //Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("----------");
            rq = new RotorsQueue(Rotors);
            for (int i = 0; i < str.Length; i++)
            {
                rc.Add(rq.Encrypt(cr[i]));
                //Console.Write(abc[rc[i]]);
                //Console.WriteLine();
            }
            Console.WriteLine("----------");
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(abc[rc[i]]);
                if (i % 5 == 0)
                {
                    //Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("----------");
            Console.WriteLine();
            */
            string text = "Pixie bitch";//"Enigma - is one of the best encrypt machine in the world! (As of 1941)."; //
            Machine Enigma = new Machine(3);
            int[] RotorsIndexes = new int[5];
            int[] RotorsStartIndexes = new int[5];//входное колесо, роторы и рефлектор

            RotorsStartIndexes[1] = 1;

            Enigma.PickDefaultRotors(RotorsIndexes, RotorsStartIndexes);
            Console.WriteLine("Encrypting:\n");
            var encrypted = Enigma.Encrypt(text);
            Enigma.PickDefaultRotors(RotorsIndexes, RotorsStartIndexes);
            Console.WriteLine("Decrypting:\n");
            var decrypted = Enigma.Encrypt(encrypted);
            Console.WriteLine(text+"\n"+encrypted+"\n"+ decrypted);

        }
    }
}
