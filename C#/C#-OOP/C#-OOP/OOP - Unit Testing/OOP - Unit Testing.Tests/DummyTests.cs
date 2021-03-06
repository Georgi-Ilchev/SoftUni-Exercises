using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void Test_If_Dummy_Lose_Health_When_Attacked()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);

        //Act
        dummy.TakeAttack(10);
        var expectedResult = 90;
        var actualResult = dummy.Health;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Test_If_Dead_Dummy_Throws_Exception_When_Attacked()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 100);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
    }

    [Test]
    public void Test_If_Dead_Dummy_Can_Give_Xp()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 100);
        //Act
        var expected = 100;
        var actual = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_If_Alive_Dummy_Cant_Give_Xp()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
