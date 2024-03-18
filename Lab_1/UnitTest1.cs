using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestSwapValues()
    {
        // Arrange
        int A = 4;
        int B = 5;
        int C = 6;
        int expectedA = 6;
        int expectedB = 4;
        int expectedC = 5;

        // Act
        Program.SwapValues(ref A, ref B, ref C);

        // Assert
        Assert.AreEqual(expectedA, A);
        Assert.AreEqual(expectedB, B);
        Assert.AreEqual(expectedC, C);
    }
}