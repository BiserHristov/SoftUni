using FightingArena; //You should comment this "using" for submitting in Judge
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_EmptyConstructorSholdCreateLiistWithCountZero()
        {
            arena = new Arena();
            Assert.That(0, Is.EqualTo(arena.Warriors.Count));
        }

        [Test]
        public void Enroll_TwoDifferentWarriorsSholdCreateLiistWithCountTwo()
        {
            arena = new Arena();
            arena.Enroll(new Warrior("a", 1, 10));
            arena.Enroll(new Warrior("b", 2, 20));

            Assert.That(2, Is.EqualTo(arena.Count));
        }

        [Test]
        public void Enroll_DuplicateNamewarriorShouldThrow()
        {
            arena = new Arena();
            arena.Enroll(new Warrior("a", 1, 10));
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("a", 2, 20)));
        }

        [Test]
        public void Fight_AttackerDoesNotExistDefenderExistShouldThrow()
        {
            arena = new Arena();
            arena.Enroll(new Warrior("valid", 1, 10));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("invalid","valid"));
        }


        [Test]
        public void Fight_AttackerExistDefenderDoesNotExistShouldThrow()
        {
            arena = new Arena();
            arena.Enroll(new Warrior("valid", 1, 10));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("valid", "invalid"));


        }


        [Test]
        public void Fight_ValidAttackerAndDefender()
        {
            arena = new Arena();
            warrior = new Warrior("a", 50, 80);
            Warrior anotherWarrior = new Warrior("b", 60, 90);
            arena.Enroll(warrior);
            arena.Enroll(anotherWarrior);
            arena.Fight(warrior.Name, anotherWarrior.Name);

            Assert.That(20, Is.EqualTo(warrior.HP));
            Assert.That(40, Is.EqualTo(anotherWarrior.HP));



        }


    }
}
