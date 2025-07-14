namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
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
    }
}
