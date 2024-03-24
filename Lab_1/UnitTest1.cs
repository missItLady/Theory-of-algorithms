using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YourNamespace
{
    [TestClass]
    public class Unittest
    {
        [TestMethod]
        public void SwapValues()
        {
            // ��������� �������� ����� ��� �����
            int A = 4;
            int B = 5;
            int C = 6;
            int expectedA = 6;
            int expectedB = 4;
            int expectedC = 5;

            // ������ ������, ���� �������
            Program.SwapValues(ref A, ref B, ref C);


            Assert.AreEqual(expectedA, A);
            Assert.AreEqual(expectedB, B);
            Assert.AreEqual(expectedC, C);
        }
    }

    public class Program
    {
        //����� ��� ����� ������� ����� ����� �����
        public static void SwapValues(ref int a, ref int b, ref int c)
        {
            int temp = a;
            a = c;
            c = b;
            b = temp;
        }
    }
}