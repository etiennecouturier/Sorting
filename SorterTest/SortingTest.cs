using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sorter;

namespace SorterTest
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void TestSortByOneAttrAsc()
        {
            string[] data =
                    {
                        "id:1,nev:Margit",
                        "id:2,nev:Jancsi",
                        "id:3,nev:Robert"
                    };
            Sorting.sort
                (
                    data,
                    new Ordering[]
                    {
                        new Ordering("nev", true)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 2,1,3 }, ExtractResult(data));
        }

        [TestMethod]
        public void TestSortByOneAttrDesc()
        {
            string[] data =
                    {
                        "id:1,nev:Margit",
                        "id:2,nev:Jancsi",
                        "id:3,nev:Robert"
                    };
            Sorting.sort
                (
                    data,
                    new Ordering[]
                    {
                        new Ordering("nev", false)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 3, 1, 2 }, ExtractResult(data));
        }

        [TestMethod]
        public void TestSortByTwoAttrsTwoDirections()
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
            Sorting.sort
                (
                    data,
                    new Ordering[]
                    {
                        new Ordering("kor", true),
                        new Ordering("nev", false)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 1, 3, 5, 6, 2, 4 }, ExtractResult(data));
        }

        [TestMethod]
        public void TestSortByFourAttrsTwoDirections()
        {
            string[] data =
                    {
                        "id:1,nev:Jancsi,azonosito:tt,kor:12,nem:f",
                        "id:2,nev:Jancsi,azonosito:pp,kor:14,nem:f",
                        "id:3,nev:Margit,azonosito:tt,kor:21,nem:f",
                        "id:4,nev:Margit,azonosito:zz,kor:21,nem:l"
                    };
            Sorting.sort
                (
                    data,
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

        [TestMethod]
        public void TestCopmlexSort()
        {
            string[] data =
                    {
                        "id:1,nev:Jancsi,azonosito:pp,kor:8,nem:f",
                        "id:2,nev:Jancsi,azonosito:tt,kor:8,nem:f",
                        "id:3,nev:Margit,azonosito:bb,kor:21,nem:f",
                        "id:4,nev:Mark,azonosito:zz,kor:21,nem:l",
                        "id:5,nev:Margit,azonosito:aa,kor:21,nem:l",
                        "id:6,nev:Jancsi,azonosito:tt,kor:33,nem:f",
                        "id:7,nev:Jancsi,azonosito:pp,kor:33,nem:f",
                        "id:8,nev:Margit,azonosito:dd,kor:21,nem:f",
                        "id:9,nev:Margit,azonosito:cc,kor:21,nem:l",
                        "id:10,nev:Margit,azonosito:aa,kor:86,nem:l",
                        "id:11,nev:Mark,azonosito:zz,kor:11,nem:l"
                    };
            Sorting.sort
                (
                    data,
                    new Ordering[]
                    {
                        new Ordering("nev", true),
                        new Ordering("kor", false),
                        new Ordering("azonosito", true)
                    }
                );
            CollectionAssert.AreEqual(new int[] { 7,6,1,2,10,5,3,9,8,4,11 }, ExtractResult(data));
        }

        private static int[] ExtractResult(string[] data)
        {
            int[] res = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i] = data[i].Get<int>("id");
            }

            return res;
        }
    }
}
