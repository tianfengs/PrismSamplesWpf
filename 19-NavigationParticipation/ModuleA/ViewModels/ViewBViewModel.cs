using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    /// <summary>
    /// INavigationAware接口：为导航中涉及的对象提供一种通知导航行为的方法
    /// Provides a way for objects involved in navigation to be notified of navigation activities
    /// 扩展此接口需要实现三个方法：
    /// 1. IsNavigationTarget(NavigationContext navigationContext):确定是否可以处理导航请求。Called to determine if this instance can handle the navigation request.
    /// 2. OnNavigatedFrom(NavigationContext navigationContext)：当导航离开时调用。Called when the implementer is being navigated away from.
    /// 3. OnNavigatedTo(NavigationContext navigationContext)：当进入导航时调用。Called when the implementer has been navigated to.
    /// </summary>
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        private string _title = "ViewB";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public ViewBViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
