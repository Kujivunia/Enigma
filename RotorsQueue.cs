using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class RotorsQueue
    {
        private List<Rotor> Rotors = new List<Rotor>();
        private int[] Indexes;
        public RotorsQueue(List<Rotor> rotors)
        {
            foreach (var rotor in rotors)
            {
                //rotor.RotateTo(0);
                Rotors.Add(rotor);
            }
            Indexes = new int[Rotors.Count];


            foreach (var item in Rotors)
            {
                int temp = 0;
                foreach (var item1 in item.GetCommutator())
                {
                    //Console.Write(temp + "->" + item1 + "  ");
                    //if ((temp + 1) % 10 == 0) Console.WriteLine();
                    temp++;
                }
                //Console.WriteLine();
            }


        }

        public int Encrypt(int index) //шифруем это число
        {
            int temp = 0;
            /////////////////////////////////
            //Console.Write(index + "|->");

            for (int i = 0; i < Rotors.Count - 1; i++) //для каждого ротора
            {
                temp = (Rotors[i].GetOffset() - Rotors[i + 1].GetOffset());
                //index = Rotors[i].GetValueFromIndex(Rotors[i].Ring(index + (Rotors[i].GetOffset() - Rotors[i + 1].GetOffset())), false);//число шифруется ротором №i
                index = Rotors[i].Ring(Rotors[i].GetValueFromIndex(index, false) + (Rotors[i].GetOffset() - Rotors[i + 1].GetOffset()));//число шифруется ротором №i

                //Console.Write(index + "[" + i + "]" + "(" + Rotors[i].GetOffset() + ")" + "{" + temp + "}" + "->");
            }

            for (int i = Rotors.Count - 1; i > 0; i--) //возвращаемся
            {
                temp = ((Rotors[i].GetOffset() - Rotors[i - 1].GetOffset()));
                //index = Rotors[i].GetValueFromIndex(Rotors[i].Ring(index + ((Rotors[i].GetOffset() - Rotors[i - 1].GetOffset()))), false);
                index = Rotors[i].Ring(Rotors[i].GetValueFromIndex(index, false) + (Rotors[i].GetOffset() - Rotors[i - 1].GetOffset()));
                //Console.Write(index + "[" + i + "]" + "(" + Rotors[i].GetOffset() + ")" + "{" + temp + "}" + "->");
            }

            ////////////////////////////////
            
            for (int i = 1; i < Rotors.Count - 1; i++) //для каждого ротора кроме рефлектора и входного колеса
            {
                if (i == 1) //поворачиваем первый ротор при новом шифровании
                {
                    Indexes[i] += 1; //offsets
                    Rotors[i].Rotate();
                }
                if (i > 1)//поворачиваем ротор, если предыдущий крутнулся на полный оборот
                {
                    if (Indexes[i - 1] >= Rotors[i - 1].GetSize())
                    {
                        Rotors[i].Rotate();
                        Rotors[i - 1].RotateTo(0);
                        Indexes[i] += 1;
                        Indexes[i - 1] = 0;
                    }
                }
            }
            
            return index;
        }

    }
}
