using System.Windows;
using System.Windows.Controls;
using HelpDesk.Models;

namespace HelpDesk.Views
{
    public partial class TicketEditWindow : Window
    {
        private Ticket _ticket;

        public TicketEditWindow(Ticket ticket)
        {
            InitializeComponent();
            _ticket = ticket;
            LoadData();
        }

        private void LoadData()
        {
            TicketNumberTextBlock.Text = $"Заявка №: {_ticket.Id}";
            DescriptionTextBox.Text = _ticket.Description;

            foreach (ComboBoxItem item in CategoryComboBox.Items)
                if (item.Content.ToString() == _ticket.Category) { CategoryComboBox.SelectedItem = item; break; }

            foreach (ComboBoxItem item in PriorityComboBox.Items)
                if (item.Content.ToString() == _ticket.Priority) { PriorityComboBox.SelectedItem = item; break; }

            foreach (ComboBoxItem item in StatusComboBox.Items)
                if (item.Content.ToString() == _ticket.Status) { StatusComboBox.SelectedItem = item; break; }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Описание не может быть пустым.", "Проверка данных",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _ticket.Category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            _ticket.Description = DescriptionTextBox.Text;
            _ticket.Priority = (PriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            _ticket.Status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            MessageBox.Show("Изменения сохранены (временно в памяти).", "HelpDesk",
                MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}