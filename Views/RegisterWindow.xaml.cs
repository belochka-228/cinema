using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using cinema.Models;
using cinema.Services;

namespace cinema.Views
{
    public partial class RegisterWindow : Window
    {
        private DatabaseService dbService = new DatabaseService();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string fullName = FullNameTextBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName))
            {
                ErrorText.Text = "Заполните все обязательные поля";
                return;
            }

            try
            {
                if (dbService.GetUsers().Any(u => u.Email == email))
                {
                    ErrorText.Text = "Пользователь с таким email уже существует";
                    return;
                }

                var newUser = new User
                {
                    Email = email,
                    Password = password,
                    FullName = fullName,
                    BirthDate = birthDate,
                    CreatedAt = DateTime.Now
                };

                dbService.AddUser(newUser);
                SessionManager.CurrentUser = newUser;
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                ErrorText.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}
