﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace jcTRENDNET.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        public Shell(Frame frame)
        {
            this.InitializeComponent();
            this.ShellSplitView.Content = frame;
            var update = new Action(() =>
            {
                // update radiobuttons after frame navigates
                var type = frame.CurrentSourcePageType;
                foreach (var radioButton in AllRadioButtons(this))
                {
                    var target = radioButton.CommandParameter as NavType;
                    if (target == null)
                        continue;
                    radioButton.IsChecked = target.Type.Equals(type);
                }
                this.ShellSplitView.IsPaneOpen = false;
                this.BackCommand.RaiseCanExecuteChanged();
            });
            frame.Navigated += (s, e) => update();
            this.Loaded += (s, e) => update();
            this.DataContext = this;
        }

        // back
        MVVM.Command _backCommand;
        public MVVM.Command BackCommand { get { return _backCommand ?? (_backCommand = new MVVM.Command(ExecuteBack, CanBack)); } }
        private bool CanBack()
        {
            var nav = (App.Current as App).NavigationService;
            return nav.CanGoBack;
        }
        private void ExecuteBack()
        {
            var nav = (App.Current as App).NavigationService;
            nav.GoBack();
        }

        // menu
        MVVM.Command _menuCommand;
        public MVVM.Command MenuCommand { get { return _menuCommand ?? (_menuCommand = new MVVM.Command(ExecuteMenu)); } }
        private void ExecuteMenu()
        {
            this.ShellSplitView.IsPaneOpen = !this.ShellSplitView.IsPaneOpen;
        }

        // nav
        MVVM.Command<NavType> _navCommand;
        public MVVM.Command<NavType> NavCommand { get { return _navCommand ?? (_navCommand = new MVVM.Command<NavType>(ExecuteNav)); } }
        private void ExecuteNav(NavType navType)
        {
            var type = navType.Type;
            var nav = (App.Current as App).NavigationService;

            // when we nav home, clear history
            if (type.Equals(typeof(Views.MainPage)))
                nav.ClearHistory();

            // navigate only to new pages
            if (nav.CurrentPageType != null && nav.CurrentPageType != type)
                nav.Navigate(type, navType.Parameter);
        }

        // utility
        public List<RadioButton> AllRadioButtons(DependencyObject parent)
        {
            var list = new List<RadioButton>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is RadioButton)
                {
                    list.Add(child as RadioButton);
                    continue;
                }
                list.AddRange(AllRadioButtons(child));
            }
            return list;
        }

        // prevent check
        private void DontCheck(object s, RoutedEventArgs e)
        {
            // don't let the radiobutton check
            (s as RadioButton).IsChecked = false;
        }
    }

    public class NavType
    {
        public Type Type { get; set; }
        public string Parameter { get; set; }
    }
}
