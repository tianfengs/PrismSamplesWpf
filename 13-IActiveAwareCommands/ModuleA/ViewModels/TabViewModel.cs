using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;
using UsingCompositeCommands.Core;

namespace ModuleA.ViewModels
{
    /// <summary>
    /// http://prismlibrary.github.io/docs/composite-commands.html
    /// 如果子窗口只有一个命令不能执行，主窗口的复合命令在可执行的命令的子串口还要可执行，就要引入IActiveAware接口
    /// 此接口定义： 一个IsActive的属性来返回可用状态，一个事件IsActiveChanged，并根据激活状态的改变来激发
    /// DelegateCommand类也扩展了IActiveAware接口。通过添加CanExecute状态，复合命令可以评估子命令的激活状态
    /// 在引入IActiveAware接口之后，程序会被通知何时view是active状态或inactive状态。当view为active状态时，就会把子命令更新为active状态，
    /// 当调用复合命令时，就会调用active的子命令
    /// </summary>
    public class TabViewModel : BindableBase, IActiveAware
    {
        IApplicationCommands _applicationCommands;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updatedText;

        public string UpdateText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;

            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(() => CanUpdate);

            _applicationCommands.SaveCommand.RegisterCommand(UpdateCommand);
        }

        private void Update()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }

        bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnIsActiveChanged();
            }
        }
        private void OnIsActiveChanged()
        {
            UpdateCommand.IsActive = IsActive;              //set the command as active

            IsActiveChanged?.Invoke(this, new EventArgs()); //invoke the event for al listener
        }


        public event EventHandler IsActiveChanged;
    }
}
