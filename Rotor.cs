using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Rotor
    {
        //private System.Collections.Generic.Dictionary<string, string> Commutations = new Dictionary<string, string>();
        private int[] Commutations;
        private int Offset;

        public int Ring(int a)
        {
            while (a < 0)
            {
                a += Commutations.Count();
            }
            while (a >= Commutations.Count())
            {
                a -= Commutations.Count();
            }
            return a;
        }
        public int GetSize()
        {
            return Commutations.Length;
        }
        public Rotor(int RotorSize)
        {
            Commutations = new int[RotorSize];
            for (int i = 0; i < RotorSize; i++) Commutations[i] = -1;
            Random rnd = new Random();
            for (int i = 0; i < RotorSize; i++)
            {
                int temp = rnd.Next(RotorSize);
                while (Commutations.Contains(temp))
                {
                    temp = rnd.Next(RotorSize);
                    if (!Commutations.Contains(-1))
                    {
                        break;
                    }

                }
                if (Commutations[i] < 0)
                {
                    Commutations[i] = temp;
                    if (Commutations[temp] < 0)
                    {
                        Commutations[temp] = i;
                    }
                }
            }
        }
        public int GetOffset()
        {
            return Offset;
        }
        public int GetIndexOf(int inputValue, bool reverse = false)
        {
            /*
            if (!reverse)
            {
                return Ring(Array.IndexOf(Commutations, Ring(inputValue)) + Offset);//Commutations[Ring(inputIndex + Offset)];
            }
            else
                return Ring(Array.IndexOf(Commutations, Ring(inputValue)) - Offset);
            */
            if (!reverse)
            {
                return Ring(Array.IndexOf(Commutations, Ring(inputValue)));
            }
            else
                return Ring(Array.IndexOf(Commutations, Ring(inputValue)));
        }

        public int GetValueFromIndex(int inputIndex, bool reverse = false)
        {
            /*
            if (!reverse)
            {
                return Commutations[Ring(inputIndex + Offset)];
            }
            else
                return Commutations[Ring(inputIndex - Offset)];
            */
            if (!reverse)
            {
                return Commutations[Ring(inputIndex)];
            }
            else
                return Commutations[Ring(inputIndex)];
        }

        public void Rotate(int step = 1, bool reverse = false)
        {
            if (!reverse)
                Offset += step;
            else
                Offset -= step;
            Offset = Ring(Offset);
        }
        public void RotateTo(int index)
        {
            Offset = index;
            Offset = Ring(Offset);
        }
        public int[] GetCommutator()
        {
            int[] result = new int[this.Commutations.Length];
            foreach (var item in Commutations)
            {
                result[item] = Commutations[item];
            }
            return result;
        }
        public void SetCommutator(int[] Commutator)
        {
            for (int i = 0; i < Commutator.Length; i++)
            {
                Commutations[i] = Commutator[i];
            }
        }
    }
}
