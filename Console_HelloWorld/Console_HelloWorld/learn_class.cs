using Markdig.Extensions.Tables;
using System;
using System.Runtime.CompilerServices;
using UtilityTool;


namespace Learn
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Call BaseClass No-argument constructor");
        }
        public BaseClass(string msg)
        {
            Console.WriteLine("Call BaseClass one parameterized constructor");
        }
        public BaseClass(string msg, string name)
        {
            Console.WriteLine("Call BaseClass two parameterized constructor");
        }
    }
    /* 继承 使用冒号:指定基类 */
    class SubClass : BaseClass
    {
        /* :base() 冒号指定先调用基类的无参构造函数 */
        public SubClass() : base()
        {
            Console.WriteLine("SubClass No-argument constructor");
        }
        /* :base(msg) 冒号指定先调用基类的带有一个参数的构造函数 */
        public SubClass(string msg) : base(msg)
        {
            Console.WriteLine("SubClass one parameter constructor");
        }
        public SubClass(string msg, string name) : base(msg)
        {
            Console.WriteLine("SubClass two parameter constructor");
        }
        public static void DoConstructorInheritance()
        {
            SubClass subclass = new SubClass();
            subclass = new SubClass("one parameter");
            subclass = new SubClass("msg", "name");
        }
    }
    /* 自定义异常类 */
    class InvailValueException : ApplicationException
    {
        /* 子类初始化时，默认调用基类的无参构造函数 */
        public InvailValueException(string msg) : base(msg)
        {

        }
    }
    class BuildIn
    {
        // 如何传入任意类型的参数？
        public static void type_of()
        {
            Console.WriteLine(typeof(string));
            //Console.WriteLine(typeof(Statement));
            Console.WriteLine("typeof的参数似乎只能是类");
        }
    }
    /* 实例构造函数 */
    class PersonCtor
    {
        /* 构造函数中引用的字段需要先定义 
         * 定义字段: 访问修饰符 + 类型 + 名称
         */
        private string name;
        private int age;
        private string gender;
        /* 只读字段只能在定义该字段的类的构造函数中赋值，或者在 init-only setter 中赋值 */
        readonly int id_number;
        public static string static_var = "cannot be access by instance";

        // 无参数 实例构造函数
        public PersonCtor()
        {
            name = "Siwing";
            age = 100;
            gender = "male";
            id_number = 19565;
        }
        /* 带参数 实例构造函数
         * 定义签名不同的构造函数，即是实现了构造函数重载 
         */
        public PersonCtor(string name, int age, string gender, int id_number)
        {
            // this 关键字 表示当前实例
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.id_number = id_number;
        }
        public void OutputInfo()
        {
            Console.WriteLine($"My name is {name}");
            Console.WriteLine($"My age is {age}");
            Console.WriteLine($"My gender is {gender}");
            Console.WriteLine($"My id is {id_number}");
        }
    }
    /* 属性 */
    class PersonAttr
    {
        private string name;
        private int age = 100;
        private string gender;
        public string Name
        {
            // get 访问器
            get
            {
                return name;
            }
            // set 访问器
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            /* 私有set访问器
             * Age 对外部来说，就变为只读属性
             * 或者不写 set 访问器，也可以让属性变为只读属性
             * 同理可以设置只写属性
             */
            private set
            {
                age = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set // 访问器中可以加入控制逻辑
            {
                if (value != "male" && value != "female")
                {
                    throw (new InvailValueException("性别必须是 male 或者 female"));
                }
            }
        }
        public static void Show()
        {
            PersonAttr person_attr = new PersonAttr();
            Console.WriteLine(person_attr.Name);
            person_attr.Name = "set_name";
            Console.WriteLine($"person_attr name is '{person_attr.Name}'");

            /* person_attr.Gender 只能赋值为"male"或"female" */
            try
            {
                person_attr.Gender = "error";
                Console.WriteLine(person_attr.Gender);
            }
            catch (InvailValueException e)
            {
                Console.WriteLine($"发生异常: {e}");
            }
        }
    }
    /* 私有构造函数 */
    class PersonPrivateConstructor
    {
        private string name;
        public static PersonPrivateConstructor person;
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        private PersonPrivateConstructor()
        {
            Console.WriteLine("私有构造函数被调用");
            this.name = "single instance";
        }
        // 利用 私有构造函数 实现单例
        public static PersonPrivateConstructor get_instance()
        {
            person = new PersonPrivateConstructor();
            return person;
        }
    }
    /* 静态构造函数 */
    class PersonStaticConstructor
    {
        private static string name;
        /* 静态构造函数 仅调用一次
         * 在创建实例或引用静态成员之前，CLR将自动调用静态函数
         */
        static PersonStaticConstructor()
        {
            Console.WriteLine("静态构造函数被调用了");
            name = "Learning C#";
        }
        public static string Name
        {
            get
            {
                return name;
            }
        }
        public static void Show()
        {
            Console.WriteLine("第一次实例化 PersonStaticConstructor");
            PersonStaticConstructor person_static = new PersonStaticConstructor();
            Console.WriteLine("第二次实例化 PersonStaticConstructor");
            person_static = new PersonStaticConstructor();
        }
    }
    /* 索引器 */
    class IndexerArray
    {
        // 定义长度为10的一维int数组
        private int[] _array = new int[10];
        public IndexerArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this._array[i] = array[i];
            }
        }
        /* 定义索引器的语法
         * element-type this[int index] 
         * 利用 set get 访问器构造索引器
         */
        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }
        public int[] Array
        {
            get
            {
                return _array;
            }
        }
        internal void Print()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i]);
                Console.Write(' ');
            }
            Console.Write('\n');
        }
        public static void Show()
        {
            int[] my_array = { 1, 2, 3, 4, 5 };
            IndexerArray array = new IndexerArray(my_array);
            Console.WriteLine("通过构造函数初始化 array.array");
            array.Print();
            Console.WriteLine("通过索引给 array.array 赋值");
            array[7] = 10;
            array[8] = 20;
            array.Print();
        }
    }
    /* 类型转换 */
    class TypeConvert
    {
        /* C#有两种类型:
         *   1. 值类型:   整型, 浮点型, 字符类型, 布尔类型, 枚举类型, 结构体类型
         *   2. 引用类型: 字符串类型, 自定义的类类型, 数组类型, 接口类型, 委托类型
         * 
         * 值类型是一种轻量级的类型，一般存放在栈中; 引用类型一般存放在堆中
         * 实际上, 值类型和引用类型的存放位置可以分为以下几种情况: 
         *   1. 引用类型中嵌套的值类型          --> 堆   e.g. 类成员
         *   2. 值类型嵌套引用类型              --> 栈   e.g. 结构体中嵌套一个类对象
         *   3. 没有嵌套在引用类型之中的值类型   --> 栈
         *   3. 没有嵌套在值类型之中的引用类型   --> 堆
         * 
         * 值类型和引用类型的区别:
         * - 值类型继承于ValueType, 而ValueType又继承于System.Obejct; 引用类型则直接继承于System.Obejct
         * - 值类型占用的内存由操作系统管理; 而引用类型的内存管理由GC完成
         * - 值类型不能为null值, 默认初始化为 0; 引用类型默认初始化为 null 值, 表示不指向堆中的任何地址, 对于值为null的引用类型的操作, 可能会引发NullReferenceException异常
         * - 使用值类型, 处理的是对象本身; 使用引用类型, 实际上处理的是指针
         * - 因为值类型是对象本身, 因此传参不会影响原始对象; 引用类型是对象的引用, 传参有可能改变原始对象
         * 
         * 引入引用类型是为了取代指针的作用, 如果没有引用类型, 则必须使用指针
         */


        /* 传参问题
         * 
         * A = 1; B= 2
         * def func(a, b)
         *     ....
         * func(A, B) # A和B是实参; a和b是形参
         * 
         * 传参的情况:
         * - 值类型参数的按值传递       --> 传递值
         * - 值类型参数的按引用传递     --> 传引用
         * - 引用类型参数的按值传递     --> 传递引用
         * - 引用类型参数的按引用传递   --> 传引用的引用
         *   
         * 可以在方法定义和调用方法时, 使用 ref 或 out 关键字实现按引用传参
         * 
         * C#中关键字ref与out的区别（原创）
         * https://www.cnblogs.com/windinsky/archive/2009/02/13/1390071.html
         */


        /* 栈和堆的区别 
         * 
         * 栈是连续的内存空间, 有默认的大小限制, 如果让其任意成长, 会给内存管理带来困难
         * 
         * 栈通常保存着代码的执行步骤, 先进后出, 速度快
         * 堆存放的多是对象、数据, 随意存取, 速度慢
         * 
         * 任何情况下必须满足下列不等式:
         * 堆栈地址最大值 × 线程数目最大值 < 用户态内存地址最大值
         * 
         * 在C#中, 栈是编译期间就分配好的内存空间, 而堆是程序运行期间动态分配的内存空间, 可以根据程序的运行情况确定要分配的堆内存的大小
         * 栈被调用完之后, 马上会被清理, 例如一个方法调用结束, 该方法的栈就会被清理; 而堆则不会, 堆由GC管理
         * 
         * https://www.c-sharpcorner.com/article/C-Sharp-heaping-vs-stacking-in-net-part-i/
         */

        public static void ShowConvert()
        {
            /* 值类型和引用类型的相互转换
             * 
             * 装箱: 由子类转换为基类, 隐式类型转换. 即值类型转换为引用类型.
             * 拆箱: 显示类型转换/强制类型转换, 引用类型转换为值类型. (Type)(变量名或函数)
             * 
             * 装箱和拆箱都会复制数据, 并且会产生多余的对象, 因此最好避免装箱、拆箱操作, 例如可以使用泛型.
             */

            int i = 3;
            object o = i; // 装箱操作
            int y = (int)o; // 拆箱操作
        }
        static void ShowPassParameter()
        {

        }
    }
    /* 匿名类型 */
    class AnonymousType
    {
        /* 匿名类型是 C# 3.0 加入的特性, 从 JavaScript 借鉴过来.
         * 匿名类型什么都不做, 只用来储存一些数据.
         * 因此, 匿名类型只能包含一个或多个公共只读属性, 不能包含其他类成员 (如方法、事件).
         * 用来初始化属性的表达式不能为 null、匿名函数或指针类型.
         */

        // TODO 匿名类型（C# 编程指南）https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types
        public static void Show()
        {
            var v = new { Amount = 108, Message = "Hello" };

            // Rest the mouse pointer over v.Amount and v.Message in the following  
            // statement to verify that their inferred types are int and string.  
            Console.WriteLine(v.Amount + v.Message);
        }
    }
    class DoFeature
    {
        public static void Show()
        {
            PersonCtor person_without_param = new PersonCtor();
            Util.PrintTitle(delegate () { person_without_param.OutputInfo(); }, "无参数实例构造函数");

            PersonCtor person_with_param = new PersonCtor("siwing", 101, "Male", 19596);
            Util.PrintTitle(delegate () { person_with_param.OutputInfo(); }, "带参数实例构造函数");

            Util.PrintTitle(delegate () { SubClass.DoConstructorInheritance(); }, "子类调用基类的构造函数");

            //try
            //{   // 该语句会导致编译不通过
            //    // Console.WriteLine(person_with_param.static_var);
            //    Console.WriteLine(PersonCtor.static_var);
            //}
            //catch
            //{
            //    Console.WriteLine("发生异常");
            //}

            Util.PrintTitle(delegate () { PersonStaticConstructor.Show(); }, "静态构造函数");
            Util.PrintTitle(delegate () { PersonAttr.Show(); }, "属性");
            Util.PrintTitle(delegate () { IndexerArray.Show(); }, "索引器");

            Util.PrintTitle(delegate () { TypeConvert.ShowConvert(); }, "类型转换");
        }
    }
}
