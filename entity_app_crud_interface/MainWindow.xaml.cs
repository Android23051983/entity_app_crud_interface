using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace entity_app_crud_interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db = new AppContext();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Heroes.Load();
            DataContext = db.Heroes.Local.ToObservableCollection();
            heroesList.SelectedIndex = 0;
            heroesList.Focus();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Hero hero = new Hero
            {
                Name = nameTextBox.Text,
                Race = raceTextBox.Text,
                Age = Convert.ToInt32(ageTextBox.Text),
                Weapon = weaponTextBox.Text
            };
            if (allParametersRB.IsChecked == true) 
            {
                HeroMethodsManagement.AddAll(hero);
            }
            else if(NameRB.IsChecked == true)
            {
                HeroMethodsManagement.AddName(hero);
            }
            else if(allParametersRB.IsChecked == false && NameRB.IsChecked == false )
            {
                MessageBox.Show("Выберите пожалуйста будете ли вы добавлять (удалять) по имени или по вем параметрам. Так же введите свои данные вместо уже введённых!!!");
            }
            
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Hero hero = new Hero
            {
                Name = nameTextBox.Text,
                Race = raceTextBox.Text,
                Age = Convert.ToInt32(ageTextBox.Text),
                Weapon = weaponTextBox.Text
            };
            HeroMethodsManagement.Del(hero);
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Hero? hero = heroesList.SelectedItem as Hero;
            if (hero is null) return;
            hero.Name = nameTextBox.Text;
            hero.Race = raceTextBox.Text;
            hero.Age = Convert.ToInt32(ageTextBox.Text);
            hero.Weapon = weaponTextBox.Text;

            hero = db.Heroes.Find(hero.Id);
            db.SaveChanges();
            heroesList.Items.Refresh();
        }


        private void heroesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hero? hero = heroesList.SelectedItem as Hero;
            if (hero is null) return;
            nameTextBox.Text = hero.Name;
            raceTextBox.Text = hero.Race;
            ageTextBox.Text = hero.Age.ToString();
            weaponTextBox.Text = hero.Weapon;
        }
    }
}
