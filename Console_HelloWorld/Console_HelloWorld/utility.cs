using System;


namespace UtilityTool
{
    class Util
    {
        public static void PrintTitle(Action action, string str, bool is_wrap=false)
        {
            Console.WriteLine("###### {0} ######\n", str);
            action.Invoke();
            if (is_wrap)
            {
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------\n");
        }
    }
}
