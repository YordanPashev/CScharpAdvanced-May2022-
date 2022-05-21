using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<char> box = new Box<char>();
            box.Add('a');
            box.Add('b');
            box.Add('c');
            box.Add('d');
           

        }
    }
}
