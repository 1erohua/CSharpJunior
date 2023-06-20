//属性是字段的扩展，且可使用相同的语法来访问
//属性有两个函数，一个是给属性赋值时调用的函数set，一个是使用属性自身时调用的函数get
//get函数必须要有一个返回值return （要注意不能返回 属性名本身，否则会不断迭代）
//set函数中，value代表当前赋值给属性的数值



namespace C_属性
{
    internal class Program
    {
        //属性的初始化简写
        public static string Name { get; set; }
        //这个叫get、set访问器
        //属性还得声明为static才是用在Main函数
        static void Main(string[] args)
        {
            Name = args[0];
            //傻逼玩意
            Console.WriteLine("Hello, World!");
        }
    }

    //属性的三个用处
    //第一个，将某些类里面定义的私有变量通过属性公开给外域
    class UsersInformation
    {
        private string _name;
        private int age;

        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return age; } set { age = value; } }
    }
    //第二个，属性把读取与写入的权限分开了，因此我们可以通过 修饰符分开来确定读取与写入的权限
    class GameObject
    {
        //当前坐标，可读但不可写
        private string Transform;
        public  string TransformNow { 
            get { return Transform;}
        }
    }
    //第三个，由于get、set函数可以看作是一个小函数，因此可以执行一些计算操作

}