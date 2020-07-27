using FightingArena; //You should comment this "using" for submitting in Judge
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior anotherWarrior;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ValidDataShouldCreateValidWarrior()
        {
            warrior = new Warrior("a", 1, 10);
            Assert.That("a", Is.EqualTo(warrior.Name));
            Assert.That(1, Is.EqualTo(warrior.Damage));
            Assert.That(10, Is.EqualTo(warrior.HP));

        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase("" +
            "")]
        public void Name_InvalidNameShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, 1, 10));


        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Damage_InvalidDamageShouldThrow(int damage)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("a", damage, 10));

        }

        [Test]
        public void Damage_InvalidHPShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("a", 1, -1));
        }



        [TestCase(30)]
        [TestCase(29)]
        public void Attack_AttackerHPIsLowerThanMinHp(int hp)
        {
            warrior = new Warrior("a", 10, hp);
            anotherWarrior = new Warrior("b", 20, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(anotherWarrior));
        }

        [TestCase(30)]
        [TestCase(29)]
        public void Attack_DefenderHPIsLowerThanMinHp(int hp)
        {
            warrior = new Warrior("a", 10, 40);
            anotherWarrior = new Warrior("b", 5, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(anotherWarrior));
        }

        [Test]
        public void Attack_AttackerHPIsLowerThanDefenderDamage()
        {
            warrior = new Warrior("a", 10, 40);
            anotherWarrior = new Warrior("b", 60, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(anotherWarrior));
        }

        [Test]
        public void Attack_ValidWarriorsAttackerWinDeadDefender()
        {
            warrior = new Warrior("a", 70, 40);
            anotherWarrior = new Warrior("b", 20, 50);
            warrior.Attack(anotherWarrior);
            Assert.That(0, Is.EqualTo(anotherWarrior.HP));
        }


        [Test]
        public void Attack_ValidWarriorsBothAlive()
        {
            warrior = new Warrior("a", 70, 40);
            anotherWarrior = new Warrior("b", 20, 80);
            warrior.Attack(anotherWarrior);
            Assert.That(20, Is.EqualTo(warrior.HP));
            Assert.That(10, Is.EqualTo(anotherWarrior.HP));

        }
    }
}