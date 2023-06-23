
namespace C_as_is转换符
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //as可用于Object转为 引用类型 或者 可为null值 的类型，不包括值类型
            Object obj = new Object();
            Boss boss1 = obj as Boss;

            //as不可用于类型与类型之间的转换，
            //除非需要转化对象的类型属于 转换目标类型 或者 转换目标类型的派生类型 时
            IEnemy enemy1 = new Boss();
            Boss boss2 = enemy1 as Boss;

            //as必须与可以为null的类型使用，或者是为引用类型使用
            float? f = 11.3f;
            //以下语句报错
            //int i = f as int；
            //如果是值类型之间的转换，那最好使用系统提供的Convert类所涉及的静态方法。
            int i1 = Convert.ToInt32(f);

            //is转换符是怎么用的
            Boss One = new Boss();
            if(One is IEnemy c)
            {
                Console.WriteLine("实验成功");
            }

            /*
            我在List的源码中找到一段 
            if (collection is ICollection<T> c)
            {
                int count = c.Count;
                if (count == 0)
                {
                    _items = s_emptyArray;
                }
                else
                {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }
             这段代码中的 `if (collection is ICollection<T> c)` 是一个类型模式匹配表达式。
            它检查 `collection` 是否实现了 `ICollection<T>` 接口。
            如果是，则将 `collection` 强制转换为 `ICollection<T>` 类型，并将其赋值给变量 `c`。
            在这种情况下，代码可以使用 `ICollection<T>` 接口定义的方法和属性来操作 `collection`。
            例如，它可以使用 `Count` 属性来获取集合中元素的数量，或使用 `CopyTo` 方法将集合中的元素复制到数组中。
            这种类型模式匹配表达式是 C# 7.0 中引入的一种新语法，它允许您在一个表达式中检查变量的类型并将其强制转换为指定类型。
             */
        }
    }

    interface IEnemy{ }
    class Boss:IEnemy { }


}