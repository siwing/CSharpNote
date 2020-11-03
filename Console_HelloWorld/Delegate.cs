namespace Console_HelloWorld
{
    class Program_r
    {
        public static void test()
        {
            A a = new A();
            B b = new B();
            a.FunctionA(delegate () { b.FunctionB(); });
        }
    }
    class A
    {
        public void FunctionA(System.Action action)
        {
            //*********
            Console.WriteLine("我是函数A");
            action.Invoke();
            //*********
        }
    }
    class B
    {
        public void FunctionB()
        {
            //********
            Console.WriteLine("我是函数B");

            //*******        

        }
    }
}
