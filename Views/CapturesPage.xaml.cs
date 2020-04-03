﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XboxGameClipLibrary.Models.Screenshots;
using XboxGameClipLibrary.ViewModels.CapturesViewModel;

namespace XboxGameClipLibrary.Views
{
    public partial class CapturesPage : Page
    {
        private bool captureTypeHandle = true;
        private bool filterHandle = true;

        private CapturesViewModel cvm;

        public CapturesPage()
        {
            // Initialize the CapturesPage component
            InitializeComponent();

            // Bind the capture data to the DataContext
            Loaded += CapturesPage_Loaded;
        }

        private void CapturesPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Instantiate ViewModel
            cvm = new CapturesViewModel();

            // Bind the Game Clip capture data to the itemssource of the gameClipListView
            DataContext = cvm;

            // Unhook the Loaded method
            Loaded -= CapturesPage_Loaded;
        }

        private void ScreenshotListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView list = (ListView) sender;
            var dataContext = capturesPage.DataContext as CapturesViewModel;
            var screenshot = dataContext.Screenshots[list.Items.IndexOf(list.SelectedItem)];

            screenshotDetailPane.ScreenshotId = screenshot.ScreenshotId;
            screenshotDetailPane.ScreenshotUri = screenshot.ScreenshotUris[0].Uri;
            screenshotDetailPane.Game = screenshot.TitleName;
            screenshotDetailPane.Device = screenshot.DeviceType;
            screenshotDetailPane.DateTaken = screenshot.DateTaken.ToString();
            screenshotDetailPane.DatePublished = screenshot.DatePublished.ToString();

            screenshotDetailPane.Views = screenshot.Views.ToString();
            screenshotDetailPane.Likes = screenshot.RatingCount.ToString();

            screenshotDetailPane.Visibility = Visibility.Visible;
        }

        private void CaptureTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (captureTypeHandle) HandleCaptureTypeComboBoxSelection();
            captureTypeHandle = true;
        }

        private void CaptureTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            captureTypeHandle = !cmb.IsDropDownOpen;
            HandleCaptureTypeComboBoxSelection();
        }

        // Gets input from comboboxes
        private void HandleCaptureTypeComboBoxSelection()
        {
            switch (captureBox.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "Screenshots":
                    gameClipListView.Visibility = Visibility.Collapsed;
                    screenshotListView.Visibility = Visibility.Visible;
                    break;

                case "Game clips":
                    screenshotListView.Visibility = Visibility.Collapsed;
                    gameClipListView.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void FilterComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (filterHandle) HandleFilterComboBoxSelection();
            filterHandle = true;
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            filterHandle = !cmb.IsDropDownOpen;
            HandleFilterComboBoxSelection();
        }

        // Gets input from comboboxes
        private void HandleFilterComboBoxSelection()
        {
            switch (filterBox.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "By date":
                    var screenshotByDate = cvm.Screenshots.OrderByDescending(o => o.DatePublished).ToList();
                    cvm.Screenshots = screenshotByDate;
                    break;

                case "By game":
                    var screenshotByGame = cvm.Screenshots.OrderBy(o => o.TitleName).ToList();
                    cvm.Screenshots = screenshotByGame;
                    break;
            }
        }
    }
}