using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using UsingEventAggregator.Core;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        // 2. 发布一个事件：通过调用事件聚合器EventAggregator和Publish()方法。
        //    要想获得一个事件聚合器，要使用依赖注入的方法：把一个IEventAggregator类型的参数加入构造函数（在子窗口的ViewModel里）
        IEventAggregator _ea;

        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
