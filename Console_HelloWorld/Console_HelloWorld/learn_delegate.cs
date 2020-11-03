using System;
using System.Collections.Generic;
using UtilityTool;


namespace LearnDelegate
{
    /* 委托 */
    class DelegateUsage
    {
        /* Do What: 展示 Delegate 的用法
         *          1. 显式调用
         *          2. 隐式调用
         * 
         * delegate: 实际上是一个类型, 属于引用类型
         *           delegate类是密封的, 不能被继承
         *           委托用于将方法作为参数传递给其他方法
         *              The object A which call delegate <--- delegate <--- The method of object B which need to be called
         *              
         *        ☆ 委托将A和B隔离
         *              例如, A对象是一个书店, B对象是客户端
         *                - 书店知道如何储存书籍、如何查找平装书
         *                - 客户端需要对平装书执行一些操作
         *              客户端代码不知道书店代码如何储存书籍、如何查找平装书, 书店代码不知道客户端要对平装书执行什么处理
         */

        /* 声明一个 delegate 类型的变量 */
        delegate int MyDelegate(int a, int b); // 委托也是可以加访问修饰符的
        /* 👉 实际上, 应该将 "int MyDelegate(int a, int b)" 理解为一个变量
         * 👉 这个变量比较特殊, 它可以有返回值和传入参数, 只能用函数赋值
         */

        /* 定义 Add 方法, Add 方法将通过委托被调用
         * Add 方法的签名必须与委托的签名一致 */
        int Add(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine("两个参数的和为：" + sum);
            return sum;
        }
        /* 隐式调用委托 */
        private static void CallDelegateImplicit(MyDelegate mydelegate)
        {
            Console.Write("隐式调用委托 --> ");
            mydelegate(1, 2);
        }
        /* 显式调用委托 */
        private static void CallDelegateExplicit(MyDelegate mydelegate)
        {
            /* 使用 Invoke 方法显式地调用委托 
             * 这可以清楚地看到委托是类类型，委托实例可以调用实例方法 */
            Console.Write("显式调用委托 --> ");
            mydelegate.Invoke(1, 2);

            /* 无论是显式调用委托，还是隐式调用委托，实际上都是调用委托的Invoke方法
             * 这点可以从IL代码判断 
             */
        }
        public static void Show()
        {
            MyDelegate d; // 声明委托变量, 此时d没有初始化, 默认值为null
            
            /* 实例化 MyDelegate 类型, 并将其赋值给变量 b
             * Add 可以理解为委托类构造函数的参数
             * 因为 Add 不是静态方法, 因此实例化委托的时候必须传入实例方法
             */
            d = new MyDelegate(new DelegateUsage().Add); // C# 1.0

            /* C# 还支持使用以下形式对委托变量赋值, 这些形式和上面的形式是等价的 */

            /* C# 2.0+ 支持以下简写形式
            d = new DelegateUsage().Add;
             */

            /* C# 2.0+ 支持使用匿名方法来声明和初始化委托
             * 匿名方法实际上是传递给委托的代码块. 使用匿名方法不必创建单独的方法, 减少了实例化委托所需的编码系统开销.
             * 定义方式为: delegate(参数列表){方法函数体}
            MyDelegate d2 = delegate (int a, int b)
            {
                int sum = a + b;
                Console.WriteLine("两个参数的和为：" + sum);
                return sum; 
            };
            */

            /* C# 3.0+ 支持使用lambda表达式声明和实例化委托
            MyDelegate d3 = (a, b) => {
                int sum = a + b;
                Console.WriteLine("两个参数的和为：" + sum);
                return sum; };
            */


            // 委托类型作为参数传递给另一个方法
            CallDelegateImplicit(d);
            CallDelegateExplicit(d);

            /* 这样写也是可以的, C# 会自动实例化委托  (不知道什么时候开始支持的特性)
            CallDelegateImplicit(new DelegateUsage().Add); 
            CallDelegateExplicit(new DelegateUsage().Add);
             */
        }
    }
    /* Delegate链 */
    class DelegateChain
    {
        /* 委托链的每一个委托的签名都必须是一致的
         * 即委托链所有委托都必须是同一个委托类型
         */

        public delegate void DelegateTest(); // 声明一个委托类型
        public static void Show()
        {
            DelegateTest dt_static = new DelegateTest(Method1); // 用静态方法来实例化委托 dt_static
            DelegateTest dt_instance = new DelegateTest(new DelegateChain().Method2); // 用实例方法来实例化委托 dt_instance

            // 定义一个委托对象, 一开始初始化为null, 没有和任何方法关联
            DelegateTest delegate_chain = null; // 初始化不是必须的

            // 使用 + 号链接委托, 多个委托链接起来形成委托链
            delegate_chain = dt_static + dt_instance;

            /* 显然, 使用符合赋值 += 符号亦可
            delegate_chain += dt_static;
            delegate_chain += dt_instance; 
             */

            // 调用委托链
            delegate_chain();

            // 使用 - 或 -= 取消链接委托
            delegate_chain -= dt_static;
            delegate_chain();

            // 委托链可以重新赋值
            delegate_chain = dt_static;
            delegate_chain();
        }
        public static void Method1()
        {
            Console.WriteLine("委托1：这是静态方法");
        }
        private void Method2()
        {
            Console.WriteLine("委托2：这是实例方法");
        }
    }
    /* 事件 */
    class BridegroomEven
    {
        /* 事件 实际上是一个委托
         * 事件 使用方法和委托链的使用一样 
         * 有专门的关键字 event 用于声明事件
         * 被关键字 event 声明的事件和一般的委托有点不一样
         *    - 事件只能出现在 '+=' 或 '-=' 的左边, 不能出现在 '=' 的左边; 委托可以出现在'+='、'-='、'='的左边
         *    - 事件只能在类内调用, 不能在类外被调用; 委托可以在类外被调用
         *    - event 关键字修饰的是一个对象, delegate 关键字修饰的是一个类型
         *    
         * 从上述区别可以看出, event的处理逻辑(发出通知)只能包含在事件拥有者的内部
         * 
         * https://blog.csdn.net/qq826364410/article/details/80330303
         */

        /* 定义委托类 MarrayHandler */
        public delegate void MarrayHandler(string msg);
        /* 使用委托类 MarrayHandler 定义事件 可见事件实际上是一个委托对象 */
        public event MarrayHandler MarryEvent;

        /* 触发事件 */
        public void Notice(string msg)
        {
            /* 触发事件实际上是 隐式调用委托 */
            if (MarryEvent != null)  // 判断事件是否绑定了处理方法
            {
                MarryEvent(msg);
            }
        }
        public static void Show()
        {
            BridegroomEven bridegroom = new BridegroomEven();
            // 实例化 Friend 对象
            Friend friend_zhangsan = new Friend("张三");
            Friend friend_lisi = new Friend("李四");
            Friend friend_wangwu = new Friend("王五");

            // 使用 += 来订阅事件
            bridegroom.MarryEvent += new MarrayHandler(friend_zhangsan.Reply);
            bridegroom.MarryEvent += new MarrayHandler(friend_lisi.Reply);

            // 发出通知, 只有订阅了事件的对象才能收到通知
            bridegroom.Notice("发出通知!");
            Console.WriteLine("-+-+-+-+-+");

            // 使用 -= 来取消事件订阅, 此时李四将收不到通知
            bridegroom.MarryEvent -= new MarrayHandler(friend_lisi.Reply);
            // 此时王五将收到通知
            bridegroom.MarryEvent += new MarrayHandler(friend_wangwu.Reply);

            // 发出通知
            bridegroom.Notice("发出通知!");
            Console.WriteLine("-+-+-+-+-+");
        }
    }
    class Friend
    {
        public string Name;
        public Friend(string name)
        {
            Name = name;
        }
        /* 事件处理函数 该函数需要符合 MarryHandler 委托的定义 */
        public void Reply(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(this.Name + "收到了");
        }
        /* 事件处理函数 匹配 EventHander 的签名 */
        public void Reply(object o, EventArgs s)
        {
            Console.WriteLine(this.Name + "收到了");
        }
        /* 事件处理函数 匹配 EventArgs 的签名 */
        public void Reply(object sender, UseEventArgs.MarrayEventArgs msg)
        {
            Console.WriteLine(msg.Message);
            Console.WriteLine(this.Name + "收到了");
        }
    }
    class UseEventHandler
    {
        /* 直接使用 System.EventHandler 委托类型定义事件
         * System.EventHandler 的签名如下，不能接受更多的参数，因此事件不能处理额外的参数
         * System.EventHandler(object? sender, EventArgs e);
         */
        public event EventHandler MarrayEvent;
        /* 触发事件 */
        public void Notice(string msg)
        {
            if (MarrayEvent != null)
            {
                Console.WriteLine(msg);
                MarrayEvent(this, new EventArgs()); // EventArgs 只有无参构造函数
            }
        }
        public static void Show()
        {
            UseEventHandler event_handler = new UseEventHandler();
            Friend friend_zhangsan = new Friend("张三");
            Friend friend_lisi = new Friend("李四");

            event_handler.MarrayEvent += new EventHandler(friend_zhangsan.Reply);
            event_handler.MarrayEvent += new EventHandler(friend_lisi.Reply);

            event_handler.Notice("发出通知"); // 发出通知
        }

    }
    class UseEventArgs
    {
        /* 自定义一个参数类 继承于System.EventArgs类 
         * MarrayEventArgs 用于委托方法的参数 */
        public class MarrayEventArgs : EventArgs
        {
            public string Message;
            public MarrayEventArgs(string msg)
            {
                Message = msg;
            }
        }
        // 自定义委托
        public delegate void MsgEventHander(object sender, MarrayEventArgs msg);
        // 定义事件
        public event MsgEventHander MarrayEvent;

        public void Notice(string msg)
        {
            if (MarrayEvent != null)
            {
                MarrayEvent(this, new MarrayEventArgs(msg));
            }
        }
        public static void Show()
        {
            UseEventArgs event_args = new UseEventArgs();
            Friend friend_zhangsan = new Friend("张三");
            Friend friend_lisi = new Friend("李四");

            event_args.MarrayEvent += new MsgEventHander(friend_zhangsan.Reply);
            event_args.MarrayEvent += new MsgEventHander(friend_lisi.Reply);

            event_args.Notice("发出通知"); // 发出通知
        }
    }
    class DoDelegate
    {
        public static void Show()
        {
            Util.PrintTitle(delegate () { DelegateUsage.Show(); }, "委托");
            Util.PrintTitle(delegate () { DelegateChain.Show(); }, "委托链");
            Util.PrintTitle(delegate () { BridegroomEven.Show(); }, "事件");

            /* 在类外调用事件是不允许的 */
            //bridegroomeven bridegroom_even = new bridegroomeven();
            //friend friend_zhaoliu = new friend("赵六");
            //bridegroom_even.marryevent += friend_zhaoliu.reply;
            //bridegroom_even.marryevent("msg");

            /* 可以在类外调用委托 */
            //DelegateChain.DelegateTest dt_static = new DelegateChain.DelegateTest(DelegateChain.Method1);
            //dt_static();

            Util.PrintTitle(delegate () { UseEventHandler.Show(); }, "EventHandler委托类");
            Util.PrintTitle(delegate () { UseEventArgs.Show(); }, "自定义EventArgs类用于事件的参数");
        }
    }
    /* 泛型委托 */
    class GenericDelegate
    {
        public delegate T DelegateTwoArgs<T>(T x, T y);
        public static int intAddFunc(int a, int b)
        {
            return a + b;
        }
        public static float floatAddFunc(float a, float b)
        {
            return a + b;
        }
        public static void Show()
        {
            DelegateTwoArgs<int> intAdd = intAddFunc;
            int d = intAdd(1, 2);

            DelegateTwoArgs<float> floatAdd = floatAddFunc;
            float e = floatAdd(0.1f, 0.2f);
        }
    }
    /* Action 委托 */
    class ActionDelegate
    {
        /* Action是 C# 系统中已定义好的委托类型, 可以直接使用
         * Action定义的是返回类型为 void 的委托类型
         *  - 如果没有传入的参数则使用 Action 委托
         *  - 如果有一个参数则可以使用 Action<T> 委托, 同理有 Action<T,U> 及Action <T,U,V> 等等
         */
    }
    /* Func 委托 */
    class FuncDelegate
    {
        /* Func是 C# 系统中已定义好的委托类型, 可以直接使用
         * Func定义的是有返回值的委托类型
         *  - 如果没有传入的参数则使用 Func<TResult> 委托
         *  - 如果有一个参数则可以使用 Func<T, TResult> 委托, 同理有 Func<T, U, TResult>, Func<T, U, V, TResult> 等等
         */
    }
    /* Predicate 委托 */
    class PredicateDelegate
    {
        /* Predicate是 C# 系统中已定义好的委托类型, 可以直接使用
         * Predicate<T> 代表传入一个参数并返回一个bool值的委托类型
         */
        public static bool isEven(int number)
        {
            return number % 2 == 0;
        }
        public static void Show()
        {
            // 用具名的方式定义 Predicate
            Predicate<int> is_even = isEven;
            
            List<int> a = new List<int>{ 1, 2, 3, 4, 5};
            List<int> b = a.FindAll(is_even);
            Console.WriteLine(b);

            // 用lambda表达式来定义 Predicate
            Predicate<int> is_even_2 = (i => i % 2 == 0);
            List<int> c = a.FindAll(is_even_2);
            Console.WriteLine(c);

            // 
            List<int> d = a.FindAll(i => i % 2 == 0);
            Console.WriteLine(d);
        }
    }
    /* Lambda表达式 */
    class LambdaExpression
    {
        /* Lambda 一定程度上与匿名方法实现相同的功能, 且更方便实用. 
         * 创建lambda表达式时, 需要用到lambda运算符 =>, 左侧是参数列表, 右侧是表达式或代码块
         * 当参数为1个时可省去括号
         *     (input-parameters) => expression
         *     (input-parameters) => { statement; }
         */
        public delegate int DelegateTwoInt(int x, int y);
        public delegate int DelegateOneInt(int x);

        //...

        DelegateOneInt func1 = x => x * x;
        DelegateTwoInt func2 = (x, y) => x * y;
        DelegateTwoInt func3 = (x, y) => {
            return x * x + y * y;
        };
    }
}