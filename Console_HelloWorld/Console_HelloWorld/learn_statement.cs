using System;
using UtilityTool;

namespace LearnStatement
{
    class Statement
    {
        static void ExecuteIf(int x)
        {
            if (x < 5)
            {
                Console.WriteLine("x is less than 5.");
            }
            else if (x > 10)
            {
                Console.WriteLine("x is more than 10.");
            }
            else
            {
                Console.WriteLine($"The value of x  is: {x}");
            }
        }
        static void ExecuteSwitch(int x)
        {
            switch (x)
            {
                case 0:
                    Console.WriteLine("x fall into 0 switch branch");
                    break;
                case 1:
                    Console.WriteLine("x fall into 1 switch branch");
                    break;
                case 2:
                    Console.WriteLine("x fall into 2 switch branch");
                    break;
                case > 2:
                    Console.WriteLine("x fall into >2 switch branch");
                    break;
                default:
                    Console.WriteLine($"x fall into default switch branch, x is {x}");
                    break;
            }
        }
        static void ExecuteWhile(int repeat_num)
        {
            Console.Write($"Input repeat_num is: {repeat_num}. Do loop:");
            while (repeat_num > 0)
            {
                Console.Write($"{repeat_num} ");
                repeat_num--;
            }
        }
        static void ExecuteDoWhile(int repeat_num)
        {
            Console.Write($"Input repeat_num is: {repeat_num}. Do loop:");
            do
            {
                Console.Write($"{repeat_num} ");
                repeat_num--;
            } while (repeat_num > 0);
        }
        static void ExecuteFor()
        {
            string str = "欢迎来到 C# 世界";
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
            }
        }
        static void ExecuteForeach()
        {
            string str = "欢迎来到 C# 世界";
            foreach (char element in str)
            {
                Console.Write(element);
            }
        }
        static void ExecuteBreak()
        {
            string str = "欢迎来到 C# 世界";
            foreach (char element in str)
            {
                if (element == '到')
                {
                    break;
                }
                Console.Write(element);
            }
        }
        static void ExecuteContinue()
        {
            string str = "欢迎来到 C# 世界";
            foreach (char element in str)
            {
                if (element == '到')
                {
                    continue;
                }
                Console.Write(element);
            }
        }
        static char ExecuteReturn(bool is_return=false)
        {
            string str = "欢迎来到 C# 世界";
            foreach (char element in str)
            {
                if (element == '到')
                {
                    return element;

                }
                if (!is_return)
                {
                    Console.Write(element);
                }
            }
            return '无';
        }
        public static void Show()
        {
            int x, y;
            Random random = new Random();
            x = random.Next(0, 15);
            y = random.Next(1, 5);

            Util.PrintTitle(delegate () { Statement.ExecuteIf(x); }, "If");
            Util.PrintTitle(delegate () { Statement.ExecuteSwitch(y); }, "Switch");
            Util.PrintTitle(delegate () { Statement.ExecuteWhile(5); }, "While", true);
            Util.PrintTitle(delegate () { Statement.ExecuteDoWhile(5); }, "Do While", true);
            Util.PrintTitle(delegate () { Statement.ExecuteFor(); }, "For", true);
            Util.PrintTitle(delegate () { Statement.ExecuteForeach(); }, "Foreach", true);
            Util.PrintTitle(delegate () { Statement.ExecuteBreak(); }, "Break", true);
            Util.PrintTitle(delegate () { Statement.ExecuteContinue(); }, "Continue", true);
            /* C# 在2010引入了命名参数
             * 命名参数比位置参数需要更多的性能代价
             */
            Util.PrintTitle(delegate () { Statement.ExecuteReturn(); }, $"Return {ExecuteReturn(is_return:true)}", true);
        }
    }
}
