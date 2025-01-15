namespace VictuZuydApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ViewModels.MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
