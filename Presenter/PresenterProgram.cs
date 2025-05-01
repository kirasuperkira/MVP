using System;
using Ninject;
using Model;
using BusinessLogic;
using _3_Практическая_работа_2;
using _3_Практическая_работа_1;
using ConsoleApp2;


namespace Presenter
{
    internal class PresenterProgram
    {
        static void Main(string[] args)
        {
            //Form1 view = new Form1();
            ConsoleProgram view = new ConsoleProgram();

            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            ILogic<Student> logic = ninjectKernel.Get<ILogic<Student>>();

            new Presenter(view, logic);

            Starter.StartConsole(view);
            //Starter.StartForm(view);

            Console.ReadKey();
        }
    }
}
