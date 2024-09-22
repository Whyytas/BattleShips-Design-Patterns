﻿using System;
using System.Collections.Generic;
using System.Windows.Media;
using Szofttech_WPF.Commands;
using Szofttech_WPF.Network;
using Szofttech_WPF.Utils;
using Szofttech_WPF.ViewModel.Base;

namespace Szofttech_WPF.ViewModel
{
    public class ServerListItemViewModel : BaseViewModel
    {
        public static List<ServerListItemViewModel> slistItems = new List<ServerListItemViewModel>();

        private SolidColorBrush selectedColor;
        public SolidColorBrush SelectedColor { get => selectedColor; set { selectedColor = value; OnPropertyChanged(); } }

        private SolidColorBrush darkerColor;
        public SolidColorBrush DarkerColor { get => darkerColor; set { darkerColor = value; OnPropertyChanged(); } }

        public ServerListItemViewModel()
        {
            SelectedColor = new SolidColorBrush(Settings.getBackgroundColor());
            DarkerColor = new SolidColorBrush(ColorChanger.DarkeningColor(StaticViewModel.SelectedColor, -16));
            SelectItem = new SelectItemCommand();

            slistItems.Add(this);
        }

        public SelectItemCommand SelectItem { get; set; }

        public static void SetSelectedServer(object parameter)
        {
            Console.WriteLine((ServerAddress)parameter);
            JoinGameGUIViewModel.SelectedServerAddress = (ServerAddress)parameter;

            SolidColorBrush backColor = new SolidColorBrush(Settings.getBackgroundColor());
            for (int i = 0; i < slistItems.Count; ++i)
            {
                slistItems[i].SelectedColor = backColor;
            }
            slistItems[JoinGameGUIViewModel.SelectedServerAddress.ID].SelectedColor = new SolidColorBrush(ColorChanger.DarkeningColor(StaticViewModel.SelectedColor, -32));
        }
    }
}
