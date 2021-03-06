using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void Test_If_Weapon_Loses_Durability_After_Each_Attack()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);
        Axe axe = new Axe(10, 10);

        //Act
        axe.Attack(dummy);
        var expected = 9;
        var actual = axe.DurabilityPoints;

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Attacking_With_Broken_Axe()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);
        Axe axe = new Axe(10, 0);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }

    [Test]
    [TestCase(100,100,10,10,9)]
    public void Test_If_Weapon_Loses_Durability_After_Each_Attack_V2(
        int health, int experience, int attack, int durability, int expected)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        var actual = axe.DurabilityPoints;

        Assert.AreEqual(expected, actual);
    }
}