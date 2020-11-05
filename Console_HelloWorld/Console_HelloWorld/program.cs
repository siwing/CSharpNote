using System;
using UtilityTool;
using Learn;
using LearnStatement;
/* 如果导入的命名空间存在命名冲突
 * 例如 Ststem 中存在 Type，Learn 中也存在 Type
 * 当需要引用 Type 时，需要指定引用哪个命名空间的 Type
 * using Type = Learn.Type;
 */
using Type = Learn.Type;
using AtomicType = Learn.AtomicType;
using LearnDelegate;
using LearnGeneric;
using JsonIO;


//tex:
//Formula 1: $$(a+b)^2 = a^2 + 2ab + b^2$$
//Formula 2: $$a^2-b^2 = (a+b)(a-b)$$

namespace Console_HelloWorld
{
    class program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World\n");
            //Type.Show();
            //Statement.Show();
            //DoFeature.Show();
            //DoDelegate.Show();

            /* 测试json */
            //MyData.Test();
            //JsonNet.SerializeJSON();
            //JsonNet.DeserializeJSON();
            //JsonNet.DeserializeAnonymous();
            //JsonNet.TestDataSet();


            /* 以下为旧的代码 */
            //PrintTitle(delegate () { BuildIn.type_of(); }, "typeof");

            //printtitle(delegate () { showarraylist.doarraylist(); }, "arraylist");


            //printtitle(delegate () { genericclass.openorclose(); }, "泛型分类");
            //printtitle(delegate () { showstaticfieldingeneric.show(); }, "泛型的静态字段");
            
            //StaticFieldInGeneric.Show();
            DoForJson.Show();
        }
        static void private_constructor_for_single_instance()
        {
            PersonPrivateConstructor person = PersonPrivateConstructor.get_instance();

            Console.WriteLine("类实例的Name属性为：{0}", person.Name);
        }

    }
}


