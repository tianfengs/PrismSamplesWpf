using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using UsingEventAggregator.Core;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        // 3. 订阅一个事件：订阅者可以通过使用其中一个Subscribe()方法进行，此方法重载自PubSubEvent类，有很多种方法进行订阅（在子窗口的ViewModel里）
        IEventAggregator _ea;

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessageListViewModel(IEventAggregator ea)
        {
            //_ea = new EventAggregator(); // 如果使用ThreadOption.UIThread，则必须在View的构造函数里创建事件聚合器
            _ea = ea;
            Messages = new ObservableCollection<string>();

            //_ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.UIThread, false, s=>s.Contains("aaa")); //过滤器，接收包含aaa的字符串
            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
