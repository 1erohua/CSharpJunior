//1. 接口定义了所有类继承接口时应遵循的语法合同。
//2. 接口定义了语法合同 "是什么" 部分，派生类定义了语法合同 "怎么做" 部分。
//3. 接口只包含了成员的声明。成员的定义是派生类的责任。
//4. 接口使得实现接口的类或结构在形式上保持一致。
//5. 接口本身并不实现任何功能，它只是和声明实现该接口的对象订立一个必须实现哪些行为的契约。
//6. 无法以接口创建实例
//允许多继承接口但不允许抽象类多继承

namespace C_接口
{
    //制作一个接口Player
    interface IPlayer
    {
        string Name { get; }
        public int Id { get; }
    }

    interface IGame
    {
        string Title { get; set; }
        public void Force();
    }
    abstract class A { }

    class Hua : A, IPlayer, IGame
    {
        public string Name => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();

        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Force()
        {
            throw new NotImplementedException();
        }
    }
}

namespace 两种实现接口的方式
{
    using 显隐式接口的用途;
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            //显示接口实现的示例
            FlyBoss flyBoss = new FlyBoss();
            //我们会发现无法通过FlyBoss的对象直接访问到 显示接口实现的函数
            //即下面会报错
            //flyBoss.EnemyMove();
            //但如果对象本身是由接口定义的（这很常见，由父类定义的对象，根据不同的需求借由子类构造）
            IFlyEnemy flyEnemy = new FlyBoss();
            flyEnemy.EnemyMove();
            //简而言之，显示接口实现是为了让某些功能只能让父类定义的对象使用，而让派生类对象不能使用

            显隐式接口的用途.Boss boss1 = new Boss();
            显隐式接口的用途.IFlyBoss flyBoss1 = new Boss();
            显隐式接口的用途.IWalkBoss walkBoss = new Boss();

            boss1.Attack();//使用隐式接口的函数
            flyBoss1.Attack();//使用显示接口
            walkBoss.Attack();//使用显示接口
            //由此可以看出显隐式接口的用处了

        }
    }

    //显示接口实现
    //使用了显式接口实现的方式来实现接口成员。这意味着，接口成员的实现是私有的，只能通过接口类型的引用来访问
    //显示接口中的方法可以看到从哪里来【通过接口访问，避免访问歧义】，来源相当清晰，隐式接口看不出来源
    interface IFlyEnemy
    {
        void EnemyMove();
    }
    //显式接口实现是一个类成员，只通过指定接口进行调用。 通过在类成员前面加上接口名称和句点可命名该类成员。
    class FlyBoss : IFlyEnemy
    {
        //显示接口实现的继承方法需要用到 接口名.成员名的方式进行
        void IFlyEnemy.EnemyMove()
        {
            Console.WriteLine("Boss在飞行");
        }
    }

    //隐式接口实现
    class FlyEnemy : IFlyEnemy
    {
        //隐式接口无需指定是哪个接口的函数
        public void EnemyMove()
        {

        }
    }
    //显示接口会把父级接口中的方法和属性完全继承，隐式接口会过滤冗余的方法
}

namespace 显隐式接口的用途
{
    interface IFlyBoss
    {
        void Attack();
    }
    interface IWalkBoss
    {
        void Attack();
    }

    class Boss : IFlyBoss, IWalkBoss
    {
        public void Attack()
        {
            Console.WriteLine("这是Boss的攻击");
        }
        void IFlyBoss.Attack()
        {
            Console.WriteLine("这是Boss的飞行攻击");
        }
        void IWalkBoss.Attack() { Console.WriteLine("这是Boss的行走攻击"); }
    }


}
