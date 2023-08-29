using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        public interface ICharacterFactory
        {
            IWeapon CreateWeapon();
            IArmor CreateArmor();
        }
        public class WarriorFactory : ICharacterFactory
        {
            public IWeapon CreateWeapon()
            {
                return new Sword();
            }

            public IArmor CreateArmor()
            {
                return new PlateArmor();
            }
        }

        public class MageFactory : ICharacterFactory
        {
            public IWeapon CreateWeapon()
            {
                return new Staff();
            }
            public IArmor CreateArmor()
            {
                return new Robe();
            }
        }

        public interface IWeapon
        {
            string Attack();
        }

        public interface IArmor
        {
            string Defend();
        }

        public class Sword : IWeapon
        {
            public string Attack()
            {
                return "Slash with sword!";
            }
        }

        public class Staff : IWeapon
        {
            public string Attack()
            {
                return "Cast spell with staff!";
            }
        }

        public class PlateArmor : IArmor
        {
            public string Defend()
            {
                return "Block with plate armor!";
            }
        }

        public class Robe : IArmor
        {
            public string Defend()
            {
                return "Dodge with robe!";
            }
        }

        public class Character
        {
            private IWeapon weapon;
            private IArmor armor;

            public Character(ICharacterFactory factory)
            {
                weapon = factory.CreateWeapon();
                armor = factory.CreateArmor();
            }

            public void Attack()
            {
                Console.WriteLine(weapon.Attack());
            }

            public void Defend()
            {
                Console.WriteLine(armor.Defend());
            }
        }



        static void Main()
        {
            ICharacterFactory warriorFactory = new WarriorFactory();
            Character warrior = new Character(warriorFactory);
            warrior.Attack();
            warrior.Defend();

            ICharacterFactory mageFactory = new MageFactory();
            Character mage = new Character(mageFactory);
            mage.Attack();
            mage.Defend();
        }
    }
}
