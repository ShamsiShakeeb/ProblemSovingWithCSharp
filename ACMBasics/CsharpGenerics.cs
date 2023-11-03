using System;
using System.Collections.Generic;
using System.Text;

namespace ACMBasics
{
    public class CsharpGenerics
    {
        public void Generics()
        {
            LinkedList<int> ll = new LinkedList<int>();
            ll.AddLast(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.RemoveFirst();
            foreach(var l in ll)
            {
                Console.WriteLine(l);
            }
        }
    }
}
