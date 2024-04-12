using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp.Models
{
    internal class Arrays
    {
        /// <summary>
        /// Array Looping and Printing Array Elements
        /// </summary>
        public void ArrayFunction(){
            int[] Ages = new int[3];
            Ages[0] = 102;
            Ages[1] = 103;
            Ages[2] = 104;
            
            for(int i = 0; i < Ages.Length; i++)
            {
                Console.WriteLine(Ages[i]);
            }

            int Count2 = Ages.Length - 1;
            while (Count2 >= 0)
            {
                Console.WriteLine(Ages[Count2]);
                Count2--;
            }

            int Count3 = Ages.Length - 1;
            do
            {
                Console.WriteLine(Ages[Count3]);
                Count3--;
            } while (Count3 >= 0);
        }
    }
}
