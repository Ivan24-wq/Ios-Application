using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();

            var settingItem = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
            };
            settingItem.Clicked += OnSettingsClicked;

            
            if (Application.Current.RequestedTheme == AppTheme.Dark)
            {
                settingItem.IconImageSource = "settings_dark.png";
            } else if(Application.Current.RequestedTheme == AppTheme.Light)
            {
                settingItem.IconImageSource = "settings_light.png";
            }
            ToolbarItems.Add(settingItem);
            }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(PasswordLength.Text, out int size))
            {
                if (size < 3)
                {
                    Outputtext.Text = "Ошибка! Пароль должен быть не короче 3 символов.";
                    GeneratedPassword.Text = "Ваш пароль: ";
                    return;
                }
                string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_=*/";
                string password = "";
                Random rand = new Random();

                for (int i = 0; i < size; i++)
                {
                    int index = rand.Next(symbols.Length);
                    password += symbols[index];  
                }

                GeneratedPassword.Text = $"Ваш пароль: {password}";
                Outputtext.Text = "";
            }
            else
            {
                Outputtext.Text = "Введите корректное число!";
                GeneratedPassword.Text = "Ваш пароль: ";
            }
        }
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Сменить тему", "Отмена", null, "Светлая", "Тёмная");
            switch (action)
            {
                case "Светлая":
                    Application.Current.UserAppTheme = AppTheme.Light;
                    break;
                case "Тёмная":
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    break;
            }
        }
    }
}
