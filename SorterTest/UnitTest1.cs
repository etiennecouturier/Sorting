using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sorter;

namespace SorterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] data =
                    {
                        "id:1,nev:Margit",
                        "id:2,nev:Jancsi",
                        "id:3,nev:Robert"
                    };
            Program.sortAll
                (
                    data,
                    0, 3,
                    new Ordering[]
                    {
                        new Ordering("nev", true)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 2,1,3 }, ExtractResult(data));
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] data =
                    {
                        "id:1,nev:Bela,kor:1",
                        "id:2,nev:Margit,kor:12",
                        "id:3,nev:Sanyi,kor:2",
                        "id:4,nev:Gizi,kor:15",
                        "id:5,nev:Margit,kor:6",
                        "id:6,nev:Robert,kor:12"
                    };
            Program.sortAll
                (
                    data,
                    0, 6,
                    new Ordering[]
                    {
                        new Ordering("kor", true),
                        new Ordering("nev", false)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 1, 3, 5, 6, 2, 4 }, ExtractResult(data));
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] data =
                    {
                        "id:1,nev:Jancsi,azonosito:tt,kor:12,nem:f",
                        "id:2,nev:Jancsi,azonosito:pp,kor:14,nem:f",
                        "id:3,nev:Margit,azonosito:tt,kor:21,nem:f",
                        "id:4,nev:Margit,azonosito:zz,kor:21,nem:l"
                    };
            Program.sortAll
                (
                    data,
                    0, 4,
                    new Ordering[]
                    {
                        new Ordering("kor", false),
                        new Ordering("nev", true),
                        new Ordering("nem", true),
                        new Ordering("azonosito", true)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 3,4,2,1 }, ExtractResult(data));
        }

        private static int[] ExtractResult(string[] data)
        {
            int[] res = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i] = Program.getAttr<int>(data[i], "id");
            }

            return res;
        }
    }
}
