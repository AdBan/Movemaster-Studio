﻿using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IDE.Common.Views
{
    /// <summary>
    /// Interaction logic for SaveAsDialog.xaml
    /// </summary>
    public partial class SaveAsDialog : ModernDialog
    {
        public SaveAsDialog(string textAboveInput)
        {
            InitializeComponent();

            TextBlock_AboveInput.Text = textAboveInput;
            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }

        public string UserInput
        {
            get { return TextBox_UserInput.Text; }
        }
    }
}