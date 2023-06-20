//定义变量的时候可以不指定它的类型，而是使用var类型
//一旦被赋值之后，匿名类型的变量将去掉隐匿，类型将一直确定，无法再被重新改写类型
namespace C_匿名
{
    //仅当局部变量在相同语句中进行声明和初始化时，才能使用 var；变量不能初始化为 null，也不能初始化为方法组或匿名函数。

    //var 不能在类范围内对字段使用。

    //使用 var 声明的变量不能在初始化表达式中使用。
    //换句话说，此表达式是合法的：int i = (i = 20);，但是此表达式会生成编译时错误：var i = (i = 20);

    //不能在相同语句中初始化多个隐式类型化变量。

    //如果一种名为 var 的类型处于范围内，则 var 关键字会解析为该类型名称，不会被视为隐式类型化局部变量声明的一部分。

    class MyClss { }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClss[] myClsses = new MyClss[10];
            var s = myClsses[0];
            Console.WriteLine("Hello, World!");

            //var 的常见用途是用于构造函数调用表达式。
            //使用 var则不能在变量声明和对象实例化中重复类型名称，如下面的示例所示：
            var xs = new List<MyClss>();
            //在有了上面这句话之后，就不能有
            //int xs = new int();
            //这就是不能重复名称的意思
        }
    }
    class Test
    {
        //从 C# 9.0 开始，构造调用表达式由目标确定类型。
        //也就是说，如果已知表达式的目标类型，则可以省略类型名称
        List<int> xs = new();
    }

}
//强类型和弱类型主要是站在变量类型处理的角度进行分类的。
//强类型是指不允许隐式变量类型转换，而弱类型则允许隐式类型转换

//强类型语言也称为强类型定义语言，是一种总是强制类型定义的语言，
//要求变量的使用要严格符合定义，所有变量都必须先定义后使用。

//与其相对应的是弱类型语言：数据类型可以被忽略的语言。它与强类型定义语言相反，一个变量可以赋不同数据类型的值

//有关更多的详细信息，请参考
//https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables