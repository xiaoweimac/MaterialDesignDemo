using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MaterialDesignDemo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            MenuModels.Add(new MenuModel() { IconFont = "\xe64c", Title = "我的一天",BackColor = "#218868",Count = 5, Display = false });
            MenuModels.Add(new MenuModel() { IconFont = "\xe646", Title = "重要", BackColor = "#EE3B3B", Count = 3 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe628", Title = "已计划日程", BackColor = "#218868", Count = 4 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe610", Title = "已分配给我", BackColor = "#EE3B3B", Count = 5 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe616", Title = "任务", BackColor = "#218868", Count = 1 });

            MenuModel = MenuModels[0];

            SelectCommand = new RelayCommand<MenuModel>(t => Select(t));
            SelectTaskInfoCommand = new RelayCommand<TaskInfo>(t => SelectTask(t));
        }

        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels 
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); } 
        }

        public RelayCommand<MenuModel> SelectCommand { get; set; }
        public RelayCommand<TaskInfo> SelectTaskInfoCommand { get; set; }

        private MenuModel menuModel;

        public MenuModel MenuModel
        {
            get { return menuModel; }
            set { menuModel = value;RaisePropertyChanged(); }
        }

        private TaskInfo info;
        public TaskInfo Info
        {
            get { return info; }
            set { info = value;RaisePropertyChanged(); }
        }

        private void Select(MenuModel model)
        {
            MenuModel = model;
        }

        public void AddTaskInfo(string content)
        {
            MenuModel.TaskInfos.Add(new TaskInfo(){ Content = content });
        }

        /// <summary>
        /// 选中内容
        /// </summary>
        /// <param name="task"></param>
        public void SelectTask(TaskInfo task)
        {
            Info = task;
            Messenger.Default.Send(task, "Expand");
        }
    }
}
