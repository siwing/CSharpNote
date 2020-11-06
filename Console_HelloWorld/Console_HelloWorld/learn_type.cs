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
    class NullableType
    {
        /* C# 1.0 中是没有null类型的, 但是有些时候, 一些数据本身就是null的.
         * 例如, 在关系数据库中, 一张表的某些字段可能允许存在null值.
         * 所以, 如果将存在null值的数据表映射为C#的对象则会出错, 因为此时C#类对象的字段还不允许为null值.
         * 
         * 为了满足某些应用场景下的需求 (例如上述例子), C# 2.0 引入了"可空类型"(Nullable Type)的特性.
         * 实际上, 可空类型是一个泛型, 即 Nullable<T>, 也属于值类型.
         */
        public static void Show()
        {
            // 定义一个int类型的可空类型
            Nullable<int> a = null; // 此时, a还没有值
            // 也可以这样定义
            Nullable<int> b = new Nullable<int>();
            // 还有更便捷的写法: 值类型后面加问号 表示可空类型 💡
            int? c = null;  // 如果使用了以上写法, VS会提示还有更简单的写法
            // 注意, 在方法中不能引用只声明但未定义的变量; C#只允许引用只声明但未定义的类变量

            // 可空类型的HasValue方法表示变量是否为空
            if (a.HasValue && b.HasValue && c.HasValue)
            {
                Console.WriteLine("a b c 都有值");
                Console.WriteLine($"{a}-{b}-{c}");
            }
            else
            {
                Console.WriteLine("a b c 都为null");
                Console.WriteLine($"{a}-{b}-{c}"); // "--"
                Console.WriteLine($"默认值 {a.GetValueOrDefault()}");
                Console.WriteLine($"默认值 {a.GetValueOrDefault(2)}");
            }

            a = 10; b = 100; c = 1000;
            if (a.HasValue && b.HasValue && c.HasValue)
            {
                Console.WriteLine($"{a.Value}-{b.Value}-{c.Value}");
            }
        }
    }
    class NullCoalescingOperator
    {
        /* ?? 是空合并操作符 (null-coalescing operator) 
         * null ?? 5  如果左边的值不为null, 返回左边的值, 如果左边的值为null, 返回右边的值
         * 
         * 在C＃7.3和更早版本中, ?? 运算符左侧的类型必须是"引用类型"或"可为空的值类型".
         * 从C＃8.0开始, ?? 和 ??= 运算符左侧的类型不能为"不可为null的值类型".
         */
        public static void Show()
        {
            int? a = null;
            int x = a ?? 5;
            Console.WriteLine(x);
            // int x = a ?? 5; 这行代码也可以用三目运算符 ?: 实现
            // p=bool?A:B 当bool=true，p=表达式A, 当bool=false, p=表达式B。
            x = a.HasValue ? a.Value : 5;

            // 引用类型
            string str1 = null;
            string str2 = str1 ?? "右边的值";
            Console.WriteLine(str2);

            // 可以通过 == 判断变量是否为 null
            if (str1 == null)
            {
                Console.WriteLine("str1 为 null");
            }
            if (a == null)
            {
                Console.WriteLine("a 为 null");
            }
        }
    }
    /* 可空类型的装箱和拆箱 */
    class NullTypeConvert
    {
        /* 把一个可空类型的变量赋值给引用类型变量,
         * 如果可空类型为null, null则可以直接赋给引用类型变量, 
         * 如果可空类型不为null, CLR则从可空类型对象中获取值, 并对该值进行装箱.
         */
        public static void Show()
        {
            int? notNull = 5;
            int? beNull = null;
            object obj;
            int value;

            Console.WriteLine($"notNull 的类型为 {notNull.GetType()}");
            try
            {
                beNull.GetType();
                //Console.WriteLine($"beNull 的类型为 {beNull.GetType()}");
            }
            catch (NullReferenceException e)
            {
                // 对为 null 的变量调用方法将出现异常
                Console.WriteLine($"无法获取 beNull 的类型, 因为 beNull 为 null");
            }

            obj = notNull; // 装箱
            Console.WriteLine($"notNull 装箱后的类型为: {obj.GetType()}");
            value = (int)obj; // 拆箱后变成非可空值类型
            notNull = (int?)obj; // 拆箱后变成可空值类型

            obj = beNull; //装箱
            Console.WriteLine($"beNull 装箱后, obj是否为null: {obj==null}");

            try
            {
                // 将 null 拆箱为 非可空类型 将出现异常
                value = (int)obj;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("不能将 null 拆箱为非可空类型");
            }
            
            notNull = (int?)obj;
            Console.WriteLine($"beNull 拆箱后, notNull是否为null: {notNull == null}");
        }
    }
    class Type
    {
        public static void Show()
        {
            /* 使用匿名委托 */
            Util.PrintTitle(delegate () { AtomicType.Show(); }, "Type");
            Util.PrintTitle(delegate () { ConstAndReadOnlyType.Show(); }, "Const And ReadOnly Type");
            Util.PrintTitle(delegate () { NullableType.Show(); }, "Nullable Type");
            Util.PrintTitle(delegate () { NullCoalescingOperator.Show(); }, "Null-Coalescing Operator");
            Util.PrintTitle(delegate () { NullTypeConvert.Show(); }, "Null Type Convert");
        }
    }
}
