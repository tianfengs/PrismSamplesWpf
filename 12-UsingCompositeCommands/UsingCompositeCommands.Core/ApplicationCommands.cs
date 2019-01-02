using Prism.Commands;   // CompositeCommand存在于Prism.Commands中

/// <summary>
/// http://prismlibrary.github.io/docs/
/// https://github.com/PrismLibrary/Prism
/// </summary>
namespace UsingCompositeCommands.Core
{
    // 复合命令被一个App共享，需要全局化
    // 因此需要把复合命令定义为一个singleton单例，有两种方法：
    // 1. 用dependency injection（DI）依赖注入
    // 2. 把复合命令设为一个静态类
    // 绑定到UI元素上来实现调用

    ////////////////////
    // 这里用的是方法1：依赖注入
    // 1. 定义复合命令到一个接口
    // 2. 建一个类扩展这个接口
    // 3. 使用时，用container把这个复合命令注册成一个单例singleton(在App.xaml.cs中)，依赖注入DI的过程
    // 4. 在ViewModel的构造函数访问IApplicationCommands接口，并把DelegateCommand注册到这个复合命令上

    

    // 1. 定义复合命令到一个接口
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }

    // 2. 建一个类扩展这个接口
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        //public CompositeCommand SaveCommand { get; } = new CompositeCommand();
    }
}
