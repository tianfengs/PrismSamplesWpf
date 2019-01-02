using Prism.Events;

/// <summary>
/// http://prismlibrary.github.io/docs/event-aggregator.html
/// Event Aggregator 事件聚合
/// 事件聚合提供一种技术，在松耦合的各部分之间进行通信，它基于事件聚合服务。通过事件的发布和订阅进行交流，而不需要互相引用
/// 事件聚合提供多播发布/订阅机制。
/// Prism创建类型化事件，即进行编译期检测，而不是运行期检测。EventAggregator允许在一个设定的EventBase中去订阅和发布
/// EventAggregator类在容器中如同一个Service被提供，并且通过IEventAggregator接口被调用
/// 
/// PubSubEvent类实际连接发布和订阅两边，它是EventBase的扩展，这个类保存订阅列表并调度订阅者。
/// PubSubEvent类是一个泛型类，并需要赋给它一个payload type（负载类型）。
/// 
/// 1. 创建一个事件：通过继承PubSubEvent<T>实现
/// 2. 发布一个事件：通过调用事件聚合器EventAggregator和Publish()方法。
///    要想获得一个事件聚合器，要使用依赖注入的方法：把一个IEventAggregator类型的参数加入构造函数（在子窗口的ViewModel里）
/// 3. 订阅一个事件：订阅者可以通过使用其中一个Subscribe()方法进行，此方法重载自PubSubEvent类，有很多种方法进行订阅（在子窗口的ViewModel里）
///     3.1 如果需要根据接收到一个事件，来更新界面元素，订阅接收事件要在UI线程上。
///         If you need to be able to update UI elements when an event is received, subscribe to receive the event on the UI thread.
///     3.2 如果需要过滤一个事件，在订阅的时候提供一个过滤器代理。（见MessageListViewModels.cs接收器设置，过滤器实际就是有条件的接收）
///         If you need to filter an event, provide a filter delegate when subscribing.
///     3.3 如果事件的执行有性能问题，请考虑在订阅时使用一个强的引用代理，然后手动从PubSubEvent中取消订阅。
///         If you have performance concerns with events, consider using strongly referenced delegates when subscribing and 
///         then manually unsubscribe from the PubSubEvent.
///     3.4 如果前面的情况都没有，请使用默认的订阅。
///         If none of the preceding is applicable, use a default subscription.
/// </summary>
namespace UsingEventAggregator.Core
{
    // 1. 创建一个事件：通过继承PubSubEvent<T> 实现
    public class MessageSentEvent : PubSubEvent<string>
    {
    }
}
