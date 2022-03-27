using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Machine
    {
        private RotorsQueue RQ;
        private int[] RotorsIndex;
        private int[] RotorsStartPositions;
        List<Rotor> DefaultRotors = new List<Rotor>();
        private string abc = " abcdefghijklmnopqrstuvwxyz.,!?-()<>[]{}:;~1234567890_=+*@#$%^&абвгдеёжзийклмнопрстуфхцчшщъыьэюя";//" abcdefghijklmnopqrstuvwxyz.,!?-—()<>[]{}\'\":;`~1234567890_=+\\|/*@#$%^&абвгдеёжзийклмнопрстуфхцчшщъыьэюя";//Длинное тире не работает в консольном выводе и ломает шифровку
        public Machine(int DefaultRotorsCount = 12)
        {
            for (int i = 0; i < abc.Length; i++)
            {
                Console.Write(i + abc[i].ToString() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < DefaultRotorsCount + 2; i++) //входное колесо, роторы и рефлектор
            {
                DefaultRotors.Add(new Rotor(abc.Length));
            }
            Random rnd;
            int[] Commutator = new int[abc.Length];
            for (int seed = 0; seed < DefaultRotors.Count; seed++)//роторы
            {
                for (int i = 0; i < abc.Length; i++) Commutator[i] = -1;
                rnd = new Random(seed);
                for (int i = 0; i < abc.Length; i++)
                {
                    int temp = rnd.Next(abc.Length);
                    while (Commutator.Contains(temp))
                    {
                        temp = rnd.Next(abc.Length);
                        if (!Commutator.Contains(-1))
                        {
                            break;
                        }
                    }
                    if (Commutator[i] < 0)
                    {
                        Commutator[i] = temp;
                        if (Commutator[temp] < 0)
                        {
                            Commutator[temp] = i;
                        }
                    }
                }
                DefaultRotors[seed].SetCommutator(Commutator);
            }
            for (int i = 0; i < abc.Length; i++) Commutator[i] = i; //Входной ротор
            DefaultRotors[0].SetCommutator(Commutator); //Входной ротор

            //Входной ротор
            /*
            DefaultRotors.Add(new Rotor(abc.Length));//рефлектор
            int[] Reflector = new int[abc.Length];
            for (int i = 0; i < abc.Length; i++) Reflector[i] = -1;
            rnd = new Random(DefaultRotors.Count-1);
            for (int i = 0; i < abc.Length; i++)
            {
                int temp = rnd.Next(abc.Length);
                while (Reflector.Contains(temp))
                {
                    temp = rnd.Next(abc.Length);
                    if (!Reflector.Contains(-1))
                    {
                        break;
                    }
                }
                if (Reflector[i] < 0)
                {
                    Reflector[i] = temp;
                    Reflector[temp] = i;
                }
                
            }
            DefaultRotors[DefaultRotors.Count-1].SetCommutator(Reflector);
            */

        }
        public void PickDefaultRotors(int[] RotorsIndex, int[] RotorsStartPositions)
        {
            List<Rotor> tempRotors = new List<Rotor>();
            for (int i = 0; i < DefaultRotors.Count; i++)
            {
                tempRotors.Add(this.DefaultRotors[i]);
            }
            for (int i = 0; i < tempRotors.Count; i++)
            {
                tempRotors[i].RotateTo(RotorsStartPositions[i]);
            }
            RQ = new RotorsQueue(tempRotors);
        }

        public string Encrypt(string input)
        {
            input = input.ToLower();
            List<int> cr = new List<int>();
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                cr.Add(RQ.Encrypt(abc.IndexOf(input[i])));
                //Console.WriteLine();
            }
            for (int i = 0; i < input.Length; i++)
            {
                result += abc[cr[i]];
            }
            //Console.WriteLine("---");
            return result;
        }
    }
}
