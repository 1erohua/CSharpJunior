//运算符重载可以在类内、方法和结构中使用，当然这就涉及到一个成员的公有私有的问题



using System.Runtime.Intrinsics;

namespace C_运算符重载
{
    internal class Program
    {

        internal static void Main(string[] args)
        {
            //同时，对于二元运算符而言，重载的运算符必须至少有一个参数是类本身的类型或可空类型。
            Vector Vector1 = new Vector(0, 0, 0);
            Vector Vector2 = new Vector(1, 2, 3);
            Vector vector3 = Vector1 + Vector2;
        }
    }

    class Vector
    {
        private float x;
        private float y;
        private float z;

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //C#要求所有的运算符重载都声明为public和static
        //这表示它们与它们的类或结构相关联，而不是与实例相关联
        //所以运算符重载的代码体不能访问非静态类成员，也不能访问this标识符
        public static Vector operator +(Vector a, Vector b)
        {
            //这不🈲令我想起Unity中的
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            //重载运算符的两个必备条件：要重载的类、要重载的符号、重载符号后返回的值（这里重载的类和返回值都是Vector）
        }
    }


}