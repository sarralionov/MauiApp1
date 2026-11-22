using System;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        // This map belongs to the page and survives individual button clicks.
        private readonly StoreMap map;

        public MainPage()
        {
            InitializeComponent();

            // To try the second map, change only this line to CreateMap2().
            map = MapFactory.CreateMap1();

            StartPicker.ItemsSource = map.Points;
            TargetPicker.ItemsSource = map.Points;
        }

        private void OnNavigateClicked(object? sender, EventArgs e)
        {
            RouteLabel.Text = string.Empty;
            LengthLabel.Text = string.Empty;

            if (StartPicker.SelectedItem == null ||
                TargetPicker.SelectedItem == null)
            {
                StatusLabel.Text = "בחרי גם נקודת מוצא וגם יעד.";
                return;
            }

            string start = (string)StartPicker.SelectedItem;
            string target = (string)TargetPicker.SelectedItem;

            RouteResult result = RouteFinder.FindRoute(map, start, target);

            if (!result.Found)
            {
                StatusLabel.Text = "אין מסלול זמין בין הנקודות שנבחרו.";
                return;
            }

            StatusLabel.Text = "המסלול שנמצא:";
            RouteLabel.Text = string.Join(" -> ", result.Points);
            LengthLabel.Text = "אורך כולל: " + result.TotalLength;
        }
        private async void OnMapClicked(
    object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MapPage));
        }

    }
}

