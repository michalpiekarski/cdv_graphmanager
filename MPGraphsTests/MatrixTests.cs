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
                if(item != 1)
                {
                    allOne = false;
                    break;
                }
            }
            Assert.IsTrue(allOne);
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
            m.ReplaceColumn(2, new List<int>(new int[] { 9, 9, 9 }));
            column = m.GetColumn(2);
            Assert.IsTrue(column[0] == 9 && column[1] == 9 && column[2] == 9);
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
                    if(i == j)
                    {
                        if(testedRow[j] == 0)
                        {
                            isIdentity = false;
                            break;
                        }
                    }
                    else
                    {
                        if(testedRow[j] == 1)
                        {
                            isIdentity = false;
                            break;
                        }
                    }
                }
            }
            Assert.IsTrue(isIdentity);
        }
    }
}