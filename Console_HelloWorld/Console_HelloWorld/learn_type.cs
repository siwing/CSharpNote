using System;
using System.Collections;
using UtilityTool;


namespace Learn
{
    class AtomicType
    {
        public static void Show()
        {
            /* 数值类型可以用十进制表示，也可以用二进制 0b 或 十六进制 0x 表示 */

            /* 整型
             * sbyte   [-128, 127]                                 8 bit   百
             * byte    [0, 255]                                    8 bit   百
             * short   [-32768, 32767]                             16 bit  万
             * ushort  [0, 65535]                                  16 bit  万
             * int     [-2147483648, 2147483647]                   32 bit  十亿
             * uint    [0, 4294967295]                             32 bit  十亿
             * long    [-9223372036854775808, 9223372036854775807] 64 bit  百亿亿
             * ulong   [0, 18446744073709551615]                   64 bit  千亿亿
             */

            // 定义整型变量
            sbyte sbyte_var = -0x12;
            byte byte_var = 255; //0x00FE
            short short_number = -100;
            ushort ushort_number = 100;
            int int_number = -80;
            uint uint_number = 80;
            long long_number = -1000;
            ulong ulong_number = 1000;

            // 定义浮点型变量

            /* 直接写小数会默认为 double 类型
             * float 类型末尾必须加上 F/f
             * decimal 类型末尾必须加上 M/m
             * double 类型末尾可以加上 D/d，也可以不加
             */
            float float_number = 123.9F;
            double double_number = 1234.12345678;
            decimal decimal_number = 12345678M;
            decimal_number.GetType();

            // 定义字符类型
            /* char 表示单个Unicode UTF-16 字符 
             * 因此，char类型可以用 Unicode 编码对应的16进制表示  👉  '\x + 16进制'
             * 或者用 Unicode 转义序列表示  👉  '\u + 16进制'
             */
            char unicode_string = '\x4e2d';
            string str = "Hello Siwing, Welcome to C# language.";
            
            // 定义布尔变量
            bool bool_var = true;

            // 打印变量值
            Console.WriteLine("This is a sbyte type object:\t{0}", sbyte_var);
            // 使用内插字符串
            Console.WriteLine($"This is a byte type object:\t{byte_var}");
            Console.WriteLine($"This is a short type object:\t{short_number}");
            Console.WriteLine($"This is a ushort type object:\t{ushort_number}");
            Console.WriteLine($"This is a int type object:\t{int_number}");
            Console.WriteLine($"This is a uint type object:\t{uint_number}");
            Console.WriteLine($"This is a long type object:\t{long_number}");
            Console.WriteLine($"This is a ulong type object:\t{ulong_number}");
            Console.WriteLine($"This is a float type object:\t{float_number}");
            Console.WriteLine($"This is a double type object:\t{double_number}");
            Console.WriteLine($"This is a decimal type object:\t{decimal_number}");
            Console.WriteLine($"This is a char type object:\t{unicode_string}");
            Console.WriteLine($"This is a string type object:\t{str}");
            Console.WriteLine($"string object can be index []:\t{str[1]}");
            Console.WriteLine($"This is a bool type object:\t{bool_var}");
        }
    }
    class ConstAndReadOnlyType
    {
        /* 常量无法被赋值，因此在定义常量的时候必须初始化 
         * 常量默认是静态的，因此不允许使用 static 来显式声明 */
        const string str_1 = "const";
        
        /* 只读字段只能在定义该字段的类的构造函数中赋值或初始化，或者在 init-only setter 中赋值 
         * 因此，普通方法中不能定义 readonly 变量 */
        static readonly string str_2 = "readonly";

        public static void Show()
        {
            Console.WriteLine($"const {str_1}");
            Console.WriteLine($"readonly {str_2}");
        }
    }
    class ArrayType
    {
        public static void Show()
        {
            /* 使用如下语法可以定义一个元素同质的数组
             * type[] name = new type[item_num]
             */

            int[] array = new int[10];
            array[0] = 10; array[1] = 20;

            Console.WriteLine($"This is a array object:\t{array}");
            Console.WriteLine($"array object item:\t{array[0]}");
            Console.WriteLine($"array object item:\t{array[1]}");
            Console.WriteLine($"array object item:\t{array[2]}");
        }
    }
    class StructType
    {
        public struct Point
        // 结构体
        {
            public int x;
            public int y;
            public Point(int px, int py)
            {
                x = px;
                y = py;
            }
        }
    }
    class EnumType
    {
        /* enum 用于储存一组具有名字的数值常数
         * enum元素的类型默认为 int
         * 可选类型为：byte、sbyte、short、ushort、int、uint、long、ulong
         */
        enum Gender : int
        {
            Female,
            Male
        }

        public static void Show()
        {
            Console.WriteLine($"This is a enum type object:\t{Gender.Male}");
        }
        
    }
    class ShowArrayList
    {
        public static void DoArrayList()
        {
            /* 参考网址
             * https://www.runoob.com/csharp/csharp-arraylist.html
             * https://www.qbl.link/Web/Home/ArticleDetails/ee2897a5-0516-4374-bc59-02d832064441.html
             * https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=netcore-3.1#methods
             */
            ArrayList list = new ArrayList();
            Console.WriteLine("添加一些数据");
            list.Add(10); list.Add(20); list.Add(30);
            Console.WriteLine("ArrayList 当前可以包含 {0} 个元素", list.Capacity);
            Console.WriteLine("ArrayList 当前实际有 {0} 个元素", list.Count);
            Console.WriteLine("ArrayList 是否有固定大小：{0}", list.IsFixedSize);
            Console.WriteLine("ArrayList 是否只读：{0}", list.IsReadOnly);
            Console.WriteLine("ArrayList 是否支持同步（线程安全）：{0}", list.IsSynchronized);
            Console.WriteLine("ArrayList 最后一个元素：{0}", list[list.Count - 1]);

            Console.WriteLine("\n添加一些数据");
            if ((list.Capacity - list.Count) > 0)
            {
                int need_num = list.Capacity - list.Count;
                for (int i = 0; i < (need_num + 1); i++)
                {
                    list.Add((int)list[list.Count - 1] + 10);
                }
            }

            Console.WriteLine("ArrayList 当前可以包含 {0} 个元素", list.Capacity);
            Console.WriteLine("ArrayList 当前实际有 {0} 个元素", list.Count);
            Console.WriteLine("ArrayList 最后一个元素：{0}", list[list.Count - 1]);

            Console.WriteLine("foreach 迭代所有元素");
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }

            // Contains
            Console.WriteLine("ArrayList 包含10吗：{0}", list.Contains(10));
            Console.WriteLine("ArrayList 包含100吗：{0}", list.Contains(100));
            // IndexOf
            Console.WriteLine("ArrayList 10 第一次出现的索引位置：{0}", list.IndexOf(10));
            Console.WriteLine("ArrayList 40 第一次出现的索引位置：{0}", list.IndexOf(40));
            // Insert 指定位置插入元素
            Console.WriteLine("ArrayList 第一个索引处插入 100");
            list.Insert(0, 100);
            foreach (object o in list) Console.WriteLine(o);
            // Sort
            Console.WriteLine("ArrayList 排序");
            list.Sort();
            foreach (object o in list) Console.WriteLine(o);
            // Reverse 逆序
            Console.WriteLine("ArrayList 逆序");
            list.Reverse();
            foreach (object o in list) Console.WriteLine(o);
        }
    }
    class Type
    {
        public static void Show()
        {
            /* 使用匿名委托 */
            Util.PrintTitle(delegate () { AtomicType.Show(); }, "Type");
            Util.PrintTitle(delegate () { ConstAndReadOnlyType.Show(); }, "Const And ReadOnly Type");
        }
    }
}


