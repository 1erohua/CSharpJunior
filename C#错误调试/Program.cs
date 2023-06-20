//本代码基于.Net6
namespace C_错误调试
{
    //介绍try catch 语句
    //try
    //try放入测试的语句，遇到有问题的语句，那么该语句下面的所有语句（注意是try里面的所有语句）都不执行

    //catch
    //catch负责捕捉错误类型
    //可以用Exception ex作为参数 来捕捉任意的错误类型，同时也可以将其用console输出
    //ex存储最先发生的异常
    //也可以指定错误类型并用多个catch捕捉
    //不写参数则任意错误类型都会触发

    //finally
    //无论任何情况都会执行的代码

    //注意
    //catch 可以有0个和无数个
    //finally只能有1个或者0个
    //无论如何，都不能只有一个try


    internal class Program
    {
        static void Main(string[] args)
        {
            int[] zero = new int[2];
            try
            {
                zero[3] = 10;
            }
            catch (Exception ex)
            {
                Console.WriteLine("输出与此处:" + ex);
            }
            finally
            {
                Console.WriteLine("测试结束");
            }

        }
    }
}
