using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.Tests
{
    [TestClass()]
    public class MatrixTests
    {

        [TestMethod()]
        public void AddRowTest()
        {
            Matrix<int> m = new Matrix<int>();
            m.AddRow(new List<int>(2));
            Assert.IsTrue(m.RowCount == 1 && m.ColumnCount.Item2 == 0);
            m.AddRow(new List<int>(2));
            Assert.IsTrue(m.RowCount == 2 && m.ColumnCount.Item2 == 0);
        }
        [TestMethod()]
        public void GetRowTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            List<int> returnedRow = m.GetRow(1);
            bool allOne = true;
            foreach (int item in returnedRow)
            {
                if (item != 1)
                {
                    allOne = false;
                    break;
                }
            }
            Assert.IsTrue(allOne);
            Assert.IsNull(m.GetRow(5));
        }

        [TestMethod()]
        public void ReplaceRowTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            Assert.IsTrue(m.RowCount == 3);
            List<int> newRow = new List<int>(new int[] { 9, 9, 9 });
            m.ReplaceRow(1, newRow);
            Assert.IsTrue(m.RowCount == 3 && m.GetRow(1)[0] == 9 && m.GetRow(1)[2] == 9);
            Assert.IsFalse(m.ReplaceRow(10, newRow));
        }

        [TestMethod()]
        public void RemoveRowTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            Assert.IsTrue(m.RowCount == 3 && m.GetRow(1)[0] == 1);
            m.RemoveRow(1);
            Assert.IsTrue(m.RowCount == 2 && m.GetRow(1)[0] == 2);
            Assert.IsFalse(m.RemoveRow(5));
        }

        [TestMethod()]
        public void SwapRowsTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            Assert.IsTrue(m.RowCount == 3 && m.GetRow(0)[0] == 0 && m.GetRow(2)[0] == 2);
            m.SwapRows(0, 2);
            Assert.IsTrue(m.RowCount == 3 && m.GetRow(0)[0] == 2 && m.GetRow(2)[0] == 0);
            Assert.IsFalse(m.SwapRows(1, 20));
            Assert.IsFalse(m.SwapRows(10, 2));
            Assert.IsFalse(m.SwapRows(10, 20));
        }

        [TestMethod()]
        public void GetColumnTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            List<int> column = m.GetColumn(2);
            Assert.IsTrue(column[0] == 0 && column[1] == 1 && column[2] == 2);
            Assert.IsNull(m.GetColumn(5));
            m = new Matrix<int>();
            Assert.IsNull(m.GetColumn(0));
        }

        [TestMethod()]
        public void ReplaceColumnTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            List<int> column = m.GetColumn(2);
            Assert.IsTrue(column[0] == 0 && column[1] == 1 && column[2] == 2);
            List<int> newColumn = new List<int>(new int[] { 9, 9, 9 });
            m.ReplaceColumn(2, newColumn);
            column = m.GetColumn(2);
            Assert.IsTrue(column[0] == 9 && column[1] == 9 && column[2] == 9);
            Assert.IsFalse(m.ReplaceColumn(10, newColumn));
        }

        [TestMethod()]
        public void RemoveColumnTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add(i);
                }
                m.AddRow(row);
            }
            Assert.IsTrue(m.ColumnCount.Item2 == 3);
            m.RemoveColumn(1);
            Assert.IsTrue(m.ColumnCount.Item2 == 2);
            Assert.IsFalse(m.RemoveColumn(10));
        }

        [TestMethod()]
        public void AddColumnTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> column = new List<int>();
                for (int j = 0; j < 2; j++)
                {
                    column.Add(i);
                }
                m.AddColumn(column);
            }
            Assert.IsTrue(m.RowCount == 2 && m.ColumnCount.Item2 == 3);
            List<int> testList = new List<int>(new int[] { 9, 9, 9, 9 });
            m.AddRow(testList);
            Assert.IsFalse(m.IsRectangular);
            Assert.IsFalse(m.AddColumn(testList));
        }

        [TestMethod()]
        public void SwapColumnsTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> column = new List<int>();
                for (int j = 0; j < 2; j++)
                {
                    column.Add(i);
                }
                m.AddColumn(column);
            }
            Assert.IsTrue(m.GetColumn(0)[0] == 0 && m.GetColumn(2)[0] == 2);
            m.SwapColumns(0, 2);
            Assert.IsTrue(m.GetColumn(0)[0] == 2 && m.GetColumn(2)[0] == 0);
            Assert.IsFalse(m.SwapColumns(1, 20));
            Assert.IsFalse(m.SwapColumns(10, 2));
            Assert.IsFalse(m.SwapColumns(10, 20));
        }

        [TestMethod()]
        public void TransposeTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 2; i++)
            {
                List<int> newRow = new List<int>(3);
                for (int j = 0; j < 3; j++)
                {
                    newRow.Add(i);
                }
                m.AddRow(newRow);
            }
            List<int> testedRow = m.GetRow(0);
            Assert.IsTrue(m.RowCount == 2 && m.ColumnCount.Item2 == 3);
            Assert.IsTrue(testedRow[0] == 0 && testedRow[1] == 0 && testedRow[2] == 0);
            m = m.Transpose();
            testedRow = m.GetRow(0);
            Assert.IsTrue(m.RowCount == 3 && m.ColumnCount.Item2 == 2);
            Assert.IsTrue(testedRow[0] == 0 && testedRow[1] == 1);
            m = new Matrix<int>();
            for (int i = 0; i < 2; i++)
            {
                List<int> newRow = new List<int>(3);
                for (int j = 0; j <= i; j++)
                {
                    newRow.Add(i);
                }
                m.AddRow(newRow);
            }
            Assert.IsNull(m.Transpose());
        }

        [TestMethod()]
        public void IdentityMatrixTest()
        {
            Matrix<int> m = Matrix<int>.IdentityMatrix(3);
            int rowCount = m.RowCount;
            int columnCount = m.ColumnCount.Item2;
            Assert.IsTrue(rowCount == 3 && columnCount == 3);
            bool isIdentity = true;
            for (int i = 0; i < rowCount; i++)
            {
                List<int> testedRow = m.GetRow(i);
                for (int j = 0; j < columnCount; j++)
                {
                    if (i == j)
                    {
                        if (testedRow[j] == 0)
                        {
                            isIdentity = false;
                            break;
                        }
                    }
                    else
                    {
                        if (testedRow[j] == 1)
                        {
                            isIdentity = false;
                            break;
                        }
                    }
                }
            }
            Assert.IsTrue(isIdentity);
        }

        [TestMethod()]
        public void MatrixTest()
        {
            Matrix<int> m1 = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> newRow = new List<int>();
                for (int j = 0; j < 2; j++)
                {
                    newRow.Add(i);
                }
                m1.AddRow(newRow);
            }
            Matrix<int> m2 = new Matrix<int>(m1);
            Assert.IsTrue(m2.RowCount == 3 && m2.ColumnCount.Item2 == 2);
        }
        [TestMethod()]
        public void IsRectangularTest()
        {
            Matrix<int> m = new Matrix<int>();
            Assert.IsTrue(m.IsRectangular);
            for (int i = 0; i < 3; i++)
            {
                List<int> newRow = new List<int>();
                for (int j = 0; j < 2; j++)
                {
                    newRow.Add(i);
                }
                m.AddRow(newRow);
            }
            Assert.IsTrue(m.IsRectangular);
            m.AddRow(new List<int>(new int[] { 9, 9, 9, 9 }));
            Assert.IsFalse(m.IsRectangular);
        }
        [TestMethod()]
        public void IsSquaredTest()
        {
            Matrix<int> m = new Matrix<int>();
            Assert.IsTrue(m.IsSquare);
            for (int i = 0; i < 3; i++)
            {
                List<int> newRow = new List<int>();
                for (int j = 0; j < 2; j++)
                {
                    newRow.Add(i);
                }
                m.AddRow(newRow);
            }
            Assert.IsTrue(m.IsRectangular);
            Assert.IsFalse(m.IsSquare);
            m.AddColumn(new List<int>(new int[] { 9, 9, 9}));
            Assert.IsTrue(m.IsSquare);
        }
        [TestMethod]
        public void SizeTest()
        {
            Matrix<int> m = new Matrix<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> newRow = new List<int>();
                for (int j = 0; j < 2; j++)
                {
                    newRow.Add(i);
                }
                m.AddRow(newRow);
            }
            Tuple<bool, int, int> size = m.Size;
            Assert.IsTrue(size.Item1 == true && size.Item2 == 3 && size.Item3 == 2);
            m.AddRow(new List<int>(new int[] { 9, 9, 9, 9 }));
            size = m.Size;
            Assert.IsTrue(size.Item1 == false && size.Item2 == 4 && size.Item3 == -1);
        }
    }
}