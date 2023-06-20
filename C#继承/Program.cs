//C#允许使用父类和子类，即基类和派生类
//继承：所有的父类成员和函数成员都会被继承到子类里面

//C#中，可以用父类定义变量并用new 子类进行初始化（即我们可以用子类构造一个父类，但不能用父类构造一个子类）、
using 多重派生与重载重写和new重写;
namespace C_继承
{
    class BaseClass
    {
        public string Name;
        public int Value;
        public BaseClass(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public void TestForIt()
        {
            Console.WriteLine(Value);
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass(string name, int value) : base(name, value)
        {
        }
        public int test;
        public void TestForIt()
        {
            Console.WriteLine(base.Value + test);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //可以用父类定义，子类构造，此时本质上是子类的
            BaseClass a = new DerivedClass("Lin", 11);
            //但不能用子类定义然后再用父类构造
            //下面的写法是不正确的
            //DerivedClass b= new BaseClass();
            //这是因为：
            //用什么东西构造，本质上就是什么

            //允许子类构造父类、
            //是为了多态的存在
            //同一父类的不同的对象拥有 不同的子类本质
            Console.WriteLine("Hello, World!");

            //但在C#中，子类可以强转为父类
            //但父类不能强转为子类
            //因为已经形成的高维是可以降维成低维，但低维无法再还原成高维
            BaseClass a_Base = new BaseClass("Shi", 11);
            DerivedClass c_Derived = new DerivedClass("hua", 0);
            //正确的
            a_Base = (BaseClass)c_Derived;//可以直接赋值
            //错误的//运行时会发生报错 
            try
            {
                BaseClass c_Base = new BaseClass("Ni", 11);
                c_Derived = (DerivedClass)c_Base;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //多重派生与重载重写和new重写
            多重派生与重载重写和new重写.ShiOne shiOne = new ShiTwo();
            多重派生与重载重写和new重写.ShiTwo shiTwo = new ShiTwo();
            shiOne.Test();
            shiTwo.Test();

            //override重写与虚方法和抽象方法
            override重写与虚方法和抽象方法.LiOne liOne = new override重写与虚方法和抽象方法.LiTwo();
            override重写与虚方法和抽象方法.LiTwo liTwo = new override重写与虚方法和抽象方法.LiTwo();
            liOne.Wake();
            liTwo.Wake();
            //通测试可以看到，new 与 virtual的不同
            //当父类被子类构造之后，虚方法就消失了，出现的是重写override方法
            //这也是虚方法的优势
            //重写的意义在于，当子类调用父类的某个函数，而这个函数又引用了Run函数，此时重写就有了意义
        }
    }
}

namespace 多重派生与重载重写和new重写
{
    //C#允许多重继承
    class Test1 { }
    class Test2 : Test1 { }
    class Test3 : Test2 { }

    //C#允许子类重写父类的函数
    //第一种方式是通过重载
    class LiOne { public void Test() { Console.WriteLine("这是父类函数，未被重载重写"); } }
    class LiTwo : LiOne { public void Test(int i) { Console.WriteLine("这是子类函数，它将通过参数重写"); } }
    //注意，编译器区分是否重载，是通过参数类型与个数判断重载哪个函数的

    //第二种方式是通过new关键字
    //也就是隐藏方法
    //对于子类来说，隐藏方法不会使父类的方法消失，只是隐藏起来了
    //在子类中使用一个与父类同一签名的方法，则可以将父类的该方法隐藏起来（如果是有意隐藏请在void前面加上new）
    //（同一签名包括返回值类型，参数类型，函数名都相同）
    //神奇的是
    //如果父类定义子类构造，那么调用该方法是父类中被隐藏的
    //如果是子类定义父类构造，那么调用的方式是父类中被隐藏的
    class ShiOne { public void Test() { Console.WriteLine("这是父类"); } }
    class ShiTwo : ShiOne { public new void Test() { Console.WriteLine("这是子类"); } }

    //第三种，override关键字
    //override只能重写虚函数virtual、抽象函数abstract或者本身已是重写函数的override
    //这个放到下面来讲
}

namespace override重写与虚方法和抽象方法
{
    //什么是虚方法
    //虚方法用于继承当中，当子类与父类共同拥有的属性需要被子类修改时，则可以使用虚方法
    class LiOne
    {
        public virtual void Run()
        {
            Console.WriteLine("现在正在奔跑");
        }
        public void Wake()
        {
            Console.WriteLine("执行测试");
            Run();
        }

    }
    class LiTwo : LiOne
    {
        public override void Run()
        {
            Console.WriteLine("现在正在飞行");
        }
    }
    //重写的意义在于，当子类调用父类的某个函数，而这个函数又引用了Run函数，此时重写就有了意义

    //抽象方法/抽象函数更狠了
    //当类中有函数被标记为抽象时，该类也要被标记为抽象
    //而抽象函数在父类中不需要函数体，而派生类中必须重写抽象类
    abstract class HuaOne
    {
        public abstract void Test();
    }
    class HuaTwo : HuaOne
    {
        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}

namespace 密封类与密封方法还有base与this
{
    //用途：商业原因或者防止重写导致错误频繁出现
    //可以对类使用密封，被密封的类将无法进行被继承
    //可以对方法使用密封，被密封的方法无法被override重写（注意，在父类无法使用sealed修饰方法/函数）
    //密封只能密封重写后的，让它不被继承

    sealed class LiOne { }
    //下面将报错
    //class LiTwo:LiOne { }

    abstract class HuaOne
    {
        public abstract void Hello();
    }
    class HuaTwo : HuaOne
    {
        public sealed override void Hello()
        {
            Console.WriteLine($"此函数不可继承，已经密封");
        }
    }

    //this是当前实例的代称
    //base是基类
    //以下是笔记
    //this是只调用该类中的方法，如果为派生类且该派生类使用了隐藏方法，则this调用的是new的新方法（this 只能在自己类中使用）
    //base是只调用父类（基类）中的方法，如果（子类）派生类使用隐藏方法，则base可以在派生类中重新调用父类中的原方法

    //经过测试，如果采用虚函数方式，在子类中进行改写，那么this也是调用子类改写的，base调用的还是父类的原函数
}