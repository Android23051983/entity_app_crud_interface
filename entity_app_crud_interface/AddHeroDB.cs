using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace entity_app_crud_interface
{
    public static class AddHeroDB
    {
        public static void AddAll(Hero hero)
        {
            using (AppContext db = new AppContext())
            {
                Hero h = db.Heroes.Where(c => c.Name == hero.Name && c.Race == hero.Race && c.Age == hero.Age && c.Weapon == hero.Weapon).FirstOrDefault()!;
                if (h == null) 
                { 
                    db.Heroes.Add(hero);
                    db.SaveChanges();
                    MessageBox.Show("Новый герой добавлен в БД");
                }
                else
                {
                    MessageBox.Show("Такой герой уже есть в БД. Добавьте другого героя, введя другие данные!!!");
                }
            }
        }

        public static void AddName(Hero hero)
        {
            using (AppContext db = new AppContext())
            {
                Hero h = db.Heroes.Where(c => c.Name == hero.Name).FirstOrDefault()!;
                if (h == null)
                {
                    db.Heroes.Add(hero);
                    db.SaveChanges();
                    MessageBox.Show("Новый герой добавлен в БД");
                }
                else
                {
                    MessageBox.Show("Такой герой уже есть в БД. Добавьте другого героя, введя другие данные!!!");
                }
            }
        }
    }
}
