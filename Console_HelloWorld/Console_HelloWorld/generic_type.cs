using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;

// TODO 型別參數的條件約束 (C# 程式設計手冊)  https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters


namespace LearnGeneric
{
    /* 使用已有泛型 */
    class GenericSimple
    {
        /* 在 C# 1.0 中, 参数的具体类型在定义方法、接口时就要确定
         * 因此, 如果要写一个数值求和 (整数和浮点数) 的方法, 有以下两种方式:
         *   1. 分别为整型参数和浮点型参数实现一个方法
         *   2. 只为浮点型参数实现一个方法, 对整型求和时, 先将整型参数转换为浮点型
         * 第1种方式需要实现多个方法, 而这些方法又有很多相似的代码, 显然代码量更多, 不利于代码管理.
         * 第2种方式涉及类型转换, 会存在性能损耗.
         * 
         * 因此, C# 2.0 引入泛型解决以上问题. 
         * 泛型不是一个具体的类型, 在定义方法时, 将参数声明为泛型类型, 即未将形参限定为某一具体类型.
         * 具体传入什么类型的变量, 取决于实参的类型.
         * 另外, 这也意味着, 相同的方法能处理不同的类型, 这是因为这些类型都继承了相同的接口.
         */
        public static void Show()
        {
            /* List 是一种容器类型, List<T> 是 .NET 库中实现的泛型类型 */
            List<int> intList = new List<int>(); // 定义List的元素为int类型
            intList.Add(3);

            List<string> stringList = new List<string>(); // 定义List的元素为string类型
            stringList.Add("LearningHard");
        }
    }
    /* 自定义泛型类 */
    public class Compare<T> where T : IComparable  // 注意 <T> 中的T也可以是其他标识符, T只是惯用标识符
    {
        /* T 指代一个具体的类型, 可以在Compare类内使用
        *  where 语句是对类型参数 T 的约束, 限制传入的具体类型必须继承于 IComparable 接口
        *  继承于 IComparable 接口的类型具有CompareTo方法
        */

        // 泛型用在传入参数
        public static T CompareGeneric(T t1, T t2)
        {
            if (t1.CompareTo(t2) > 0)
            {
                Console.WriteLine("{0} 比 {1} 大", t1, t2);
                return t1;
            }
            else
            {
                Console.WriteLine("{0} 比 {1} 大", t2, t1);
                return t2;
            }
        }
        // 泛型用在返回值
        public Tr Generic<Tr>(T b) where Tr : new()
        {
            return new Tr();
        }
        public static void Show()
        {
            Compare<string>.CompareGeneric("10", "20");
            Compare<int>.CompareGeneric(10, 20);
        }
    }
    /* 泛型类型分类 */
    public class DictionaryStringKey<T> : Dictionary<string, T>
    /* 自定义一个泛型类型
     * 该泛型类型继承于 Dictionary<string, T>
     * 因此 DictionaryStringKey<T> 的 T 有两个类型参数
     */
    {
        public static void Show()
        {
            // Dictionary<>是一个开放类型，它有两个类型参数
            Type t = typeof(Dictionary<,>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);

            //Dictionarystringkey<> 也是一个开放类型，但它只有一个类型参数
            t = typeof(DictionaryStringKey<>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);

            // Dictionarystringkey<int>是一个封闭类型
            t = typeof(DictionaryStringKey<int>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);

            // Dictionary<int,int>是一个封闭类型
            t = typeof(Dictionary<int, int>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);

            // 通过 Type.ContainsGenericParameters 属性来判断类型对象是否包含未被实际类型替代的类型参数
        }
    }
    public class GenericClass
    {
        static public void OpenOrClose()
        /* 根据泛型类型参数是否提供实际类型，泛型可以分为两类：
         *  - 未绑定的泛型：还没有为泛型的类型参数指定具体类型
         *  - 已构造的泛型：已为泛型的类型参数指定具体类型
         *       - 开放类型：包含类型参数的泛型，所有未绑定的泛型类型都属于开放类型
         *       - 密封类型：为每一个类型参数都传递了实际数据类型的泛型
         *       
         *  -> 以上分类似乎有问题
         *  .ContainsGenericParameters 如果一个泛型的类型参数已经指定了具体的类型，则返回 true
         *                             如果一个泛型的类型参数是通用的类型，则返回 false
         */
        {
            // Dictionary<,>是一个开放类型，它有两个类型参数
            System.Type t = typeof(Dictionary<,>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);
            // DictionaryStringKey<>也是一个开放类型，但它只有一个类型参数 
            t = typeof(DictionaryStringKey<>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);
            // DictionaryStringKey<int> 是一个封闭类型
            t = typeof(DictionaryStringKey<int>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);
            // Dictionary<int,int> 是一个封闭类型
            t = typeof(Dictionary<int,int>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);
        }
    }
    /* 泛型的静态字段 */
    class StaticFieldInGeneric
    {
        /* 带有静态字段的泛型类 */
        static class GeneriWithStaticField<T>
        {
            // 静态字段
            public static string field;
            // 静态构造函数
            public static void PrintField()
            {
                Console.WriteLine(field + ":" + typeof(T).Name);
            }
        }
        /* 带有静态字段的类 */
        static class TypeWithStaticField
        {
            public static string field;
            public static void PrintField()
            {
                Console.WriteLine(field);
            }
        }
        public static void Show()
        {
            // 使用不同的类型实参来实例化泛型
            GeneriWithStaticField<int>.field = "一";
            GeneriWithStaticField<string>.field = "二";
            GeneriWithStaticField<Guid>.field = "三";

            // 对于非泛型参数，此时field只会有一个值，每次赋值都会覆盖原来的值
            TypeWithStaticField.field = "非泛型类静态字段一";
            TypeWithStaticField.field = "非泛型类静态字段二";
            TypeWithStaticField.field = "非泛型类静态字段三";

            TypeWithStaticField.PrintField();

            // 证明每个封闭类型都有一个静态字段
            GeneriWithStaticField<int>.PrintField();
            GeneriWithStaticField<string>.PrintField();
            GeneriWithStaticField<Guid>.PrintField();
        }
    }
    // TODO 泛型类的静态构造函数
    /* 类型参数推断 */
    class TypeInferenceInGenericMethod
    {
        static void Show()
        {
            // 泛型推断只能用于泛型方法, 它对泛型类不适用
            // 因为编译器不能通过泛型类的构造函数推断出实际参数的类型

            int n1 = 1;
            int n2 = 2;
            // 不使用类型推断的代码
            GenericMethod<int>(ref n1, ref n2);

            // 使用类型推断的代码
            GenericMethod(ref n1, ref n2);
            Console.WriteLine("n1的值现在为：" + n1);
            Console.WriteLine("n2的值现在为：" + n2);

            // 使用类型推断时可能出现编译错误
            string str1 = "123";
            object obj = "456";
            // GenericMethod(ref str1, ref obj);
        }
        /* 带泛型参数的方法 */
        private static void GenericMethod<T>(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }
    }
}

