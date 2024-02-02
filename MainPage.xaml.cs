using Pizza.ViewModel;

namespace Pizza
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MonkeyViewModel monkeyViewModel)
        {
            InitializeComponent();
            BindingContext = monkeyViewModel;
        }

    }

}
