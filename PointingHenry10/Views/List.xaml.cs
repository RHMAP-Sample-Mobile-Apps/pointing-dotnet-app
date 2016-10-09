﻿using System;
using Windows.Foundation;
using System.Collections.Generic;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PointingHenry10.ViewModels;
using PointingHenry10.Models;
using Windows.UI.Popups;
using Template10.Mvvm;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Newtonsoft.Json;
using Template10.Services.SerializationService;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PointingHenry10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class List : Page
    {
        public List()
        {
            this.InitializeComponent();
            List<Session> items = new List<Session>();
            items.Add(new Session() { Name = "Session1", CreatedBy = "Passos" });
            items.Add(new Session() { Name = "Session2", CreatedBy = "Summers" });
            items.Add(new Session() { Name = "Session3", CreatedBy = "Julio" });
            listSessions.ItemsSource = items;
            textBox.Text = "";
        }

        private  async void StackPanel_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var sendControl = (StackPanel)sender;
            var sessionName = ((TextBlock)(sendControl.Children[1])).Text;
            if (textBox.Text == "")
            {
                var dialog = new MessageDialog($"Before entering session: {sessionName} you should enter a name.");
                await dialog.ShowAsync();
            }
            else
            {
                // http://stackoverflow.com/questions/37976653/template-10-navigation-fails-windows-ui-xaml-controls-frame-navigationfailed-wa
                var list = new Dictionary<string, string>() { { "session", sessionName }, { "nick", textBox.Text} };
                string str = SerializationService.Json.Serialize(list);
                Frame.Navigate(typeof(CreateSession), str);
            }
        }
    }

}
