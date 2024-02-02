using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pizza.Model;
using Pizza.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Pizza.ViewModel
{
    public partial class MonkeyViewModel : ObservableObject
    {
        
        MonkeyServices MonkeyServices;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        string password;
        public ObservableCollection<Monkey> Monkeys {get;}=new();
        public MonkeyViewModel(MonkeyServices monkeyServices)
        {

            this.MonkeyServices = monkeyServices;
            GetMonkeyAsync();
        }
        

        async Task GetMonkeyAsync()
        {
           
            try
            {
              
                var monkey = await MonkeyServices.GetMonkeys();
                if (monkey != null)
                {
                   Monkeys.Clear();
                    foreach (var item in monkey)
                    {
                        Monkeys.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("error", "unable to get monkeys "+ex.Message, "ok");
            }
            
        }
    }
}
