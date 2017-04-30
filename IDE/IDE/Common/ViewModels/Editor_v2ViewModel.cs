﻿using ChromeTabs;
using IDE.Common.Models;
using IDE.Common.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System;
using RadialMenu.Controls;
using System.Windows.Media;

namespace IDE.Common.ViewModels
{
    public class Editor_v2ViewModel : ObservableObject
    {

        #region Fields

        private ObservableCollection<TabItem> tabItems;
        private ObservableCollection<RadialMenuItem> radialMenuItems;
        private bool radialMenuIsOpen;
        private Visibility radialMenuItem1Visibility;
        private Visibility radialMenuItem2Visibility;
        private Visibility radialMenuItem3Visibility;
        private Visibility radialMenuItem1IconVisibility;
        private Visibility radialMenuItem2IconVisibility;
        private Visibility radialMenuItem3IconVisibility;
        private Visibility radialMenuCheckbox1Visibility;
        private Visibility radialMenuCheckbox2Visibility;
        private SolidColorBrush radialMenuArrow1Background;
        private SolidColorBrush radialMenuArrow2Background;
        private SolidColorBrush radialMenuArrow3Background;
        private string radialMenuItem1Text;
        private string radialMenuItem2Text;
        private string radialMenuItem3Text;
        private bool radialMenuCheckbox1IsChecked;
        private bool radialMenuCheckbox2IsChecked;

        #endregion

        #region Constructor

        public Editor_v2ViewModel()
        {
            DeclareCommands();

            SetupMainSubmenu();
            TabItems = new ObservableCollection<TabItem>();
            
        }

        #endregion

        #region Properties
        
        public ObservableCollection<RadialMenuItem> RadialMenuItems
        {
            get
            {
                return radialMenuItems;
            }
            private set
            {
                radialMenuItems = value;
                NotifyPropertyChanged("RadialMenuItems");
            }
        }

        public ObservableCollection<TabItem> TabItems
        {
            get
            {
                return tabItems;
            }
            set
            {
                tabItems = value;
                NotifyPropertyChanged("TabItems");
            }
        }

        public TabItem SelectedTab { get; set; }

        #endregion

        #region Actions


        #endregion

        #region Commands

        public ICommand AddTabCommand { get; private set; }
        public ICommand CloseTabCommand { get; private set; }
        public ICommand OpenRadialMenuCommand { get; private set; }
        public ICommand CloseRadialMenuCommand { get; private set; }
        public ICommand RadialMenuItem1Command { get; private set; }
        public ICommand RadialMenuItem2Command { get; private set; }
        public ICommand RadialMenuItem3Command { get; private set; }
        public Visibility RadialMenuItem1Visibility
        {
            get
            {
                return radialMenuItem1Visibility;
            }
            private set
            {
                radialMenuItem1Visibility = value;
                NotifyPropertyChanged("RadialMenuItem1Visibility");
            }
        }
        public Visibility RadialMenuItem2Visibility
        {
            get
            {
                return radialMenuItem2Visibility;
            }
            private set
            {
                radialMenuItem2Visibility = value;
                NotifyPropertyChanged("RadialMenuItem2Visibility");
            }
        }
        public Visibility RadialMenuItem3Visibility
        {
            get
            {
                return radialMenuItem3Visibility;
            }
            private set
            {
                radialMenuItem3Visibility = value;
                NotifyPropertyChanged("RadialMenuItem3Visibility");
            }
        }
        public Visibility RadialMenuItem1IconVisibility
        {
            get
            {
                return radialMenuItem1IconVisibility;
            }
            private set
            {
                radialMenuItem1IconVisibility = value;
                NotifyPropertyChanged("RadialMenuItem1IconVisibility");
            }
        }
        public Visibility RadialMenuItem2IconVisibility
        {
            get
            {
                return radialMenuItem2IconVisibility;
            }
            private set
            {
                radialMenuItem2IconVisibility = value;
                NotifyPropertyChanged("RadialMenuItem2IconVisibility");
            }
        }
        public Visibility RadialMenuItem3IconVisibility
        {
            get
            {
                return radialMenuItem3IconVisibility;
            }
            private set
            {
                radialMenuItem3IconVisibility = value;
                NotifyPropertyChanged("RadialMenuItem3IconVisibility");
            }
        }
        public Visibility RadialMenuCheckbox1Visibility
        {
            get
            {
                return radialMenuCheckbox1Visibility;
            }
            private set
            {
                radialMenuCheckbox1Visibility = value;
                NotifyPropertyChanged("RadialMenuCheckbox1Visibility");
            }
        }
        public Visibility RadialMenuCheckbox2Visibility
        {
            get
            {
                return radialMenuCheckbox2Visibility;
            }
            private set
            {
                radialMenuCheckbox2Visibility = value;
                NotifyPropertyChanged("RadialMenuCheckbox2Visibility");
            }
        }
        public SolidColorBrush RadialMenuArrow1Background
        {
            get
            {
                return radialMenuArrow1Background;
            }
            private set
            {
                radialMenuArrow1Background = value;
                NotifyPropertyChanged("RadialMenuArrow1Background");
            }
        }
        public SolidColorBrush RadialMenuArrow2Background
        {
            get
            {
                return radialMenuArrow2Background;
            }
            private set
            {
                radialMenuArrow2Background = value;
                NotifyPropertyChanged("RadialMenuArrow2Background");
            }
        }
        public SolidColorBrush RadialMenuArrow3Background
        {
            get
            {
                return radialMenuArrow3Background;
            }
            private set
            {
                radialMenuArrow3Background = value;
                NotifyPropertyChanged("RadialMenuArrow3Background");
            }
        }
        public bool RadialMenuCheckbox1IsChecked
        {
            get
            {
                return radialMenuCheckbox1IsChecked;
            }
            private set
            {
                radialMenuCheckbox1IsChecked = value;
                NotifyPropertyChanged("RadialMenuCheckbox1IsChecked");
            }
        }
        public bool RadialMenuCheckbox2IsChecked
        {
            get
            {
                return radialMenuCheckbox2IsChecked;
            }
            private set
            {
                radialMenuCheckbox2IsChecked = value;
                NotifyPropertyChanged("RadialMenuCheckbox2IsChecked");
            }
        }
        public string RadialMenuItem1Text
        {
            get
            {
                return radialMenuItem1Text;
            }
            private set
            {
                radialMenuItem1Text = value;
                NotifyPropertyChanged("RadialMenuItem1Text");
            }
        }
        public string RadialMenuItem2Text
        {
            get
            {
                return radialMenuItem2Text;
            }
            private set
            {
                radialMenuItem2Text = value;
                NotifyPropertyChanged("RadialMenuItem2Text");
            }
        }
        public string RadialMenuItem3Text
        {
            get
            {
                return radialMenuItem3Text;
            }
            private set
            {
                radialMenuItem3Text = value;
                NotifyPropertyChanged("RadialMenuItem3Text");
            }
        }
        public bool RadialMenuIsOpen
        {
            get
            {
                return radialMenuIsOpen;
            }
            private set
            {
                radialMenuIsOpen = value;
                NotifyPropertyChanged("RadialMenuIsOpen");
            }
        }
        public bool RadialMenuSubmenuSaveMode { get; private set; }
        public bool RadialMenuSubmenuSettingsMode { get; private set; }

        private void DeclareCommands()
        {
            AddTabCommand = new RelayCommand(AddTab);
            CloseTabCommand = new RelayCommand(CloseTab);
            OpenRadialMenuCommand = new RelayCommand(OpenRadialMenu);
            CloseRadialMenuCommand = new RelayCommand(CloseRadialMenu);
            RadialMenuItem1Command = new RelayCommand(RadialMenuItem1Execute);
            RadialMenuItem2Command = new RelayCommand(RadialMenuItem2Execute);
            RadialMenuItem3Command = new RelayCommand(RadialMenuItem3Execute);
        }


        private void SetupMainSubmenu()
        {
            RadialMenuSubmenuSettingsMode = false;
            RadialMenuSubmenuSaveMode = false;

            //change text of buttons
            RadialMenuItem1Text = "New file";
            RadialMenuItem2Text = "Save";
            RadialMenuItem3Text = "Settings";

            //change visibility of icons
            RadialMenuItem1IconVisibility = Visibility.Visible;
            RadialMenuItem2IconVisibility = Visibility.Visible;
            RadialMenuItem3IconVisibility = Visibility.Visible;

            //change color of arrows
            radialMenuArrow1Background = Brushes.Transparent;
            RadialMenuArrow2Background = Brushes.White;
            RadialMenuArrow3Background = Brushes.White;

            //change visibility of checkboxes
            RadialMenuCheckbox1Visibility = Visibility.Collapsed;
            RadialMenuCheckbox2Visibility = Visibility.Collapsed;

            //change visibility of buttons
            RadialMenuItem1Visibility = Visibility.Visible;
            RadialMenuItem2Visibility = Visibility.Visible;
            RadialMenuItem3Visibility = Visibility.Visible;
        }

        private void SetupSettingsSubmenu()
        {
            RadialMenuSubmenuSettingsMode = true;
            RadialMenuSubmenuSaveMode = false;

            //change text of buttons
            RadialMenuItem1Text = "Intellisense";
            RadialMenuItem2Text = "Syntax check";
            RadialMenuItem3Text = "";

            //change visibility of icons
            RadialMenuItem1IconVisibility = Visibility.Hidden;
            RadialMenuItem2IconVisibility = Visibility.Hidden;
            RadialMenuItem3IconVisibility = Visibility.Hidden;

            //change color of arrows
            radialMenuArrow1Background = Brushes.Transparent;
            RadialMenuArrow2Background = Brushes.Transparent;
            RadialMenuArrow3Background = Brushes.Transparent;

            //change visibility of checkboxes
            RadialMenuCheckbox1Visibility = Visibility.Visible;
            RadialMenuCheckbox2Visibility = Visibility.Visible;

            //change visibility of buttons
            RadialMenuItem1Visibility = Visibility.Visible;
            RadialMenuItem2Visibility = Visibility.Visible;
            RadialMenuItem3Visibility = Visibility.Hidden;
        }

        private void SetupSaveSubmenu()
        {
            RadialMenuSubmenuSettingsMode = false;
            RadialMenuSubmenuSaveMode = true;

            //change text of buttons
            RadialMenuItem1Text = "Save";
            RadialMenuItem2Text = "Save as";
            RadialMenuItem3Text = "Save all";

            //change visibility of icons
            RadialMenuItem1IconVisibility = Visibility.Hidden;
            RadialMenuItem2IconVisibility = Visibility.Hidden;
            RadialMenuItem3IconVisibility = Visibility.Hidden;

            //change color of arrows
            radialMenuArrow1Background = Brushes.Transparent;
            RadialMenuArrow2Background = Brushes.Transparent;
            RadialMenuArrow3Background = Brushes.Transparent;

            //change visibility of checkboxes
            RadialMenuCheckbox1Visibility = Visibility.Collapsed;
            RadialMenuCheckbox2Visibility = Visibility.Collapsed;

            //change visibility of buttons
            RadialMenuItem1Visibility = Visibility.Visible;
            RadialMenuItem2Visibility = Visibility.Visible;
            RadialMenuItem3Visibility = Visibility.Visible;
        }

        private void RadialMenuItem3Execute(object obj) //settings
        {
            if (RadialMenuSubmenuSaveMode)
            {
                //save all
            }
            else if (RadialMenuSubmenuSettingsMode)
            {
                //do nothing
            }
            else
            {
                SetupSettingsSubmenu();
            }
        }

        private void RadialMenuItem2Execute(object obj) //save
        {
            if (RadialMenuSubmenuSaveMode)
            {
                //save as
            }
            else if (RadialMenuSubmenuSettingsMode)
            {
                //do nothing
            }
            else
            {
                SetupSaveSubmenu();
            }
        }

        private void RadialMenuItem1Execute(object obj)
        {
            if (RadialMenuSubmenuSaveMode)
            {
                //save 
            }
            else if (RadialMenuSubmenuSettingsMode)
            {
                //do nothing
            }
            else
            {
                AddTab(null);
            }
        }

        private void CloseRadialMenu(object obj)
        {
            if (RadialMenuSubmenuSaveMode || RadialMenuSubmenuSettingsMode)
            {
                SetupMainSubmenu();
            }
            else
            {
                RadialMenuIsOpen = false;
            }
        }

        private void OpenRadialMenu(object obj)
        {
            RadialMenuIsOpen = true;
        }

        private void CloseTab(object obj)
        {
            TabItems.Remove((TabItem)obj);
        }


        private void AddTab(object obj)
        {
            TabItems.Add(new TabItem($"{TabItems.Count}"));
        }


        #endregion

    }
}
