using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlayFlockTest.Model
{
    public class Unit : INotifyPropertyChanged, ICloneable
    {
        public delegate void UnitHandler(object sender, UnitEventArgs e);
        public event PropertyChangedEventHandler PropertyChanged;
        public event UnitHandler DeathNotify;
        public event UnitHandler AttackNotify;
        public event UnitHandler TakeDamageNotify;
        public event UnitHandler TargetTooFarNotify;

        private const int _baseDamage = 10;
        private int _id;
        private int _hp;
        private int _maxHp;
        private int _mana;
        private int _maxMana;
        private int _armor;
        private int _magResist;
        private int _x;
        private int _y;
        private UnitClass _class;
        private AttackType _attackType;
        public bool needToRemove = false;
        public bool needToEdit = false;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public int Hp
        {
            get => _hp;
            set
            {
                if ((value > MaxHp && MaxHp != 0) || value <= 0)
                {
                    _hp = MaxHp;
                }
                else
                {
                    _hp = value;
                }
                OnPropertyChanged();
            }
        }
        public int MaxHp
        {
            get => _maxHp;
            set
            {
                _maxHp = value;
                OnPropertyChanged();
            }
        }
        public int Mana
        {
            get => _mana;
            set
            {
                if ((value > MaxMana && MaxMana != 0)|| value <= 0)
                {
                    _mana = MaxMana;
                }
                else
                {
                    _mana = value;
                }
                OnPropertyChanged();
            }
        }
        public int MaxMana
        {
            get => _maxMana;
            set
            {
                _maxMana = value;
                OnPropertyChanged();
            }
        }
        public int Armor
        {
            get => _armor;
            set
            {
                _armor = value;
                OnPropertyChanged();
            }
        }
        public int MagResist
        {
            get => _magResist;
            set
            {
                _magResist = value;
                OnPropertyChanged();
            }
        }
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged();
            }
        }
        public int BaseDamage
        {
            get => _baseDamage;
        }
        public UnitClass Class
        {
            get => _class;
            set
            {
                _class = value;
                AttackType = GetAttackType(value);
                OnPropertyChanged();
            }
        }
        public AttackType AttackType
        {
            get => _attackType;
            private set
            {
                _attackType = value;
                OnPropertyChanged();
            }
        }

        public Unit()
        {
            if (MaxHp != 0 && Hp > MaxHp)
            {
                Hp = MaxHp;
            }
            if (MaxMana != 0 && Mana > MaxMana)
            {
                Mana = MaxMana;
            }
        }
        public Unit(UnitClass newUnitClass, int newUnitHp, int newUnitMaxHp, int newUnitMana, int newUnitMaxMana, int newUnitArmor, int newUnitMagResist, int newUnitPositionX, int newUnitPositionY)
        {
            Class = newUnitClass;
            AttackType = GetAttackType(Class);
            Hp = newUnitHp;
            MaxHp = newUnitMaxHp;
            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
            Mana = newUnitMana;
            MaxMana = newUnitMaxMana;
            if (Mana > MaxMana)
            {
                Mana = MaxMana;
            }
            Armor = newUnitArmor;
            MagResist = newUnitMagResist;
            X = newUnitPositionX;
            Y = newUnitPositionY;
        }

        private int CalculateDistance(Unit enemy)
        {
            return (int)Math.Sqrt(Math.Pow(this.X - enemy.X, 2) + Math.Pow(this.Y - enemy.Y, 2));
        }
        private int MeleeAttack(Unit enemy)
        {
            if (CalculateDistance(enemy) <= 10)
            {
                //AttackCompeleted
                AttackNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} attacked unit #{enemy.Id} in close combat"));
                return BaseDamage + (MaxHp - Hp) / MaxHp * BaseDamage;
            }
            //TargetToFarAway
            TargetTooFarNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} cant attack unit #{enemy.Id}, distance too far"));
            return 0;
        }
        private int TakeAShot(Unit enemy)
        {
            if (CalculateDistance(enemy) <= 350)
            {
                //AttackCompeleted
                AttackNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} attacked unit #{enemy.Id} in a ranged battle"));
                return BaseDamage + CalculateDistance(enemy) / 350 * BaseDamage;
            }
            //TargetToFarAway
            TargetTooFarNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} cant shot to unit #{enemy.Id}, distance too far"));
            return 0;
        }
        private int CastASpell(Unit enemy)
        {
            if (CalculateDistance(enemy) <= 150)
            {
                if (Mana > 1)
                {
                    //AttackCompeleted
                    AttackNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} attacked unit #{enemy.Id} with a spell"));
                    return BaseDamage * 2;
                }
                else
                {
                    //AttackCompeleted
                    AttackNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} attacked unit #{enemy.Id} with a spell"));
                    return BaseDamage / 2;
                }
            }
            //TargetToFarAway
            TargetTooFarNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} cant cast a spell to unit #{enemy.Id}, distance too far"));
            return 0;
        }
        public int Attack(Unit enemy)
        {
            switch (Class)
            {
                case UnitClass.Warrior:
                    return MeleeAttack(enemy);
                case UnitClass.Archer:
                    return TakeAShot(enemy);
                case UnitClass.Mage:
                    return CastASpell(enemy);
                default:
                    return 0;
            }
        }
        public void TakeDamage(Unit enemy, int damage)
        {
            int factDamage;
            if (enemy.AttackType == AttackType.Magic)
            {
                factDamage = damage - MagResist;
            }
            else
            {
                factDamage = damage - Armor;
            }
            //TakeDamageEvent
            TakeDamageNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} took {factDamage} damage from unit #{enemy.Id}"));
            if (factDamage > Hp)
            {
                factDamage = Hp;
                Hp -= factDamage;
                //DeathEvent
                DeathNotify?.Invoke(this, new UnitEventArgs($"Unit #{Id} died"));
            }
            else
            {
                Hp -= factDamage;
            }
        }
        private static AttackType GetAttackType(UnitClass unit)
        {
            switch (unit)
            {
                case UnitClass.Warrior:
                case UnitClass.Archer:
                    return AttackType.Physical;
                case UnitClass.Mage:
                    return AttackType.Magic;
                default:
                    return 0;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void ChangeInfo(Unit donor)
        {
            Id = donor.Id;
            Hp = donor.Hp;
            Mana = donor.Mana;
            MaxHp = donor.MaxHp;
            MaxMana = donor.MaxMana;
            Armor = donor.Armor;
            MagResist = donor.MagResist;
            Class = donor.Class;
            X = donor.X;
            Y = donor.X;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
