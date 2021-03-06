﻿using Kaazing.Security;
using System;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace EchoDemo
{
    public sealed partial class LoginControl : UserControl
    {
        private MainPage parent;

        public LoginControl(MainPage page)
        {
            InitializeComponent();
            parent = page;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            parent.Credentials = new PasswordAuthentication(UsernameBox.Text, PasswordBox.Password.ToCharArray());
            UsernameBox.Text = "";
            PasswordBox.Password = "";
            // Remove the control from the layout. 
            parent.CloseLoginPage();
            parent.userInputCompleted.Set(); //signal Authenticate thread
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            parent.Credentials = null;
            UsernameBox.Text = "";
            PasswordBox.Password = "";
            // Remove the control from the layout. 
            parent.CloseLoginPage();
            parent.userInputCompleted.Set(); //signal Authenticate thread
        }
    }
}

