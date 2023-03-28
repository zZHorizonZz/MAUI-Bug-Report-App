using CommunityToolkit.Maui.Layouts;
using CommunityToolkit.Maui.Markup;

namespace Test;

public class MainPage : ContentPage
{
    public MainPage()
    {
        BindingContext = new MainPageViewModel();

        var views = new List<View>
        {
            new Label { Text = "Loading" }.CenterVertical(),
            new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                RowDefinitions = GridRowsColumns.Rows.Define(GridLength.Star),
                BackgroundColor = Colors.Red,
                Children =
                {
                    new Label { Text = "Empty" }.Center().Row(0)
                },
            },
            new CollectionView()
            {
                ItemsSource = Enumerable.Range(0, 100),
                ItemTemplate = new DataTemplate(() => new Label { Text = "Error" }),
                BackgroundColor = Colors.Red
            },
            new RefreshView
            {
                BackgroundColor = Colors.Blue,
                Padding = new Thickness(0, 64, 0, 0),
                HeightRequest = 256,
                Content = new CollectionView()
                {
                    HeightRequest = 256,
                    BackgroundColor = Colors.Yellow,
                    ItemsSource = Enumerable.Range(0, 100),
                    ItemTemplate = new DataTemplate(() => new Label { Text = "Error" })
                },
            },
            new ScrollView()
            {
                Content = new VerticalStackLayout()
                {
                    new BoxView() { Color = Colors.Red, HeightRequest = 256 },
                    new BoxView() { Color = Colors.Green, HeightRequest = 256 },
                    new BoxView() { Color = Colors.Yellow, HeightRequest = 256 },
                    new BoxView() { Color = Colors.Blue, HeightRequest = 256 },
                    new BoxView() { Color = Colors.Yellow, HeightRequest = 256 },
                    new BoxView() { Color = Colors.Red, HeightRequest = 256 },
                }
            }
        };

        var stateView = new Grid().Fill().Bind(StateContainer.CurrentStateProperty, nameof(MainPageViewModel.State));

        // If we want to replicate crash error after app startup set to true
        StateContainer.SetShouldAnimateOnStateChange(stateView, false);
        StateContainer.SetStateViews(stateView, views);

        StateView.SetStateKey(views[0], "1");
        StateView.SetStateKey(views[1], "2");
        StateView.SetStateKey(views[2], "3");
        StateView.SetStateKey(views[3], "4");
        StateView.SetStateKey(views[4], "5");

        Content = new Grid()
        {
            RowDefinitions = GridRowsColumns.Rows.Define(GridLength.Star, 80),
            Children =
            {
                stateView.Row(0),
                new Button()
                    .Text("Toggle State")
                    .Margin(16)
                    .Bottom()
                    .Row(1)
                    .Bind(Button.CommandProperty, nameof(MainPageViewModel.ToggleStateCommand))
            }
        };

        #region Working Constrains

        /*Content = new Grid()
       {
           new Grid()
           {
               VerticalOptions = LayoutOptions.Center,
               RowDefinitions = GridRowsColumns.Rows.Define(GridLength.Star),
               BackgroundColor = Colors.Red,
               Children =
               {
                   new Label { Text = "Empty" }.Center().Row(0)
               },
           }.Fill()
       }.Fill();*/

        #endregion

        #region Working Scroll View

        /*Content = new Grid()
        {
            RowDefinitions = GridRowsColumns.Rows.Define(GridLength.Star, 80),
            Children =
            {
                new ScrollView()
                {
                    Content = new VerticalStackLayout()
                    {
                        new BoxView() { Color = Colors.Red, HeightRequest = 256 },
                        new BoxView() { Color = Colors.Green, HeightRequest = 256 },
                        new BoxView() { Color = Colors.Yellow, HeightRequest = 256 },
                        new BoxView() { Color = Colors.Blue, HeightRequest = 256 },
                        new BoxView() { Color = Colors.Yellow, HeightRequest = 256 },
                        new BoxView() { Color = Colors.Red, HeightRequest = 256 },
                    }
                }.Row(0),
                new Button()
                    .Text("Toggle State")
                    .Margin(16)
                    .Bottom()
                    .Row(1)
            }
        }.Fill();*/

        #endregion

        #region Working Refresh View

        /*Content = new Grid()
        {
            new RefreshView
            {
                BackgroundColor = Colors.Blue,
                Padding = new Thickness(0, 64, 0, 0),
                Content = new CollectionView()
                {
                    BackgroundColor = Colors.Yellow,
                    ItemsSource = Enumerable.Range(0, 100),
                    ItemTemplate = new DataTemplate(() => new Label { Text = "Error" })
                },
            },
        }.Fill();*/

        #endregion
    }
}