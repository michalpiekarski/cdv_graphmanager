using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs
{
    public class Matrix<T>
    {
        private List<List<T>> rows;
        public Matrix()
        {
            this.rows = new List<List<T>>();
        }
        public Matrix(Matrix<T> matrix)
        {
            this.rows = matrix.rows;
        }
        #region Indexers
        /// <summary>
        /// <c>Get</c> or <c>Set</c> matrix row with specified index == <paramref name="rowIndex"/>.
        /// </summary>
        /// <param name="rowIndex">Accessed row index.</param>
        /// <remarks>Makes <c>this[x][y]</c> also possible.</remarks>
        protected List<T> this[int rowIndex]
        {
            get
            {
                return this.rows[rowIndex];
            }
            set
            {
                this.rows[rowIndex] = value;
            }
        }
        /// <summary>
        /// <c>Get</c> or <c>Set</c> matrix element at specified <paramref name="rowIndex"/> and <paramref name="columnIndex"/>.
        /// </summary>
        /// <param name="rowIndex">Accessed elements row index.</param>
        /// <param name="columnIndex">Accesed elements column index.</param>
        /// <remarks>Can throw out of bound exception</remarks>
        protected T this[int rowIndex, int columnIndex]
        {
            get
            {
                return this.rows[rowIndex][columnIndex];
            }
            set
            {
                this.rows[rowIndex][columnIndex] = value;
            }
        }
        #endregion Indexers
        #region Properties
        public int RowCount
        {
            get
            {
                return this.rows.Count;
            }
        }
        /// <summary>
        /// Check if matrix is not empty and not jagged.
        /// </summary>
        /// <returns>
        /// If matrix is empty or jagged, return <c>false</c> (otherwise returns <c>true</c>.
        /// </returns>
        public bool IsRectangular
        {
            get
            {
                bool isRectangular = true;
                int rowCount = this.RowCount;
                if (rowCount == 0)
                {
                    isRectangular = false;
                }
                else
                {
                    int firstRowColumns = this[0].Count;
                    for (int i = 1; i < rowCount; i++)
                    {
                        if (this[i].Count != firstRowColumns)
                        {
                            isRectangular = false;
                            break;
                        }
                    }
                }
                return isRectangular;
            }
        }
        /// <summary>
        /// Check if matrix is square.
        /// </summary>
        /// <returns>
        /// If matrix is rectangular and width == height, return <c>true</c> (otherwise return <c>false</c>).
        /// </returns>
        public bool IsSquare
        {
            get
            {
                bool isSquare = false;
                Tuple<bool, int> columnCount = this.ColumnCount;
                if(columnCount.Item1 == true && columnCount.Item2 == this.RowCount)
                {
                    isSquare = true;
                }
                return isSquare;
            }
        }
        /// <summary>
        /// If matrix is rectangular returns <c>Tuple&lt;true, columnCount&gt;</c>.
        /// Otherwise returns <c>Tuple&lt;false, -1&gt;</c>.
        /// </summary>
        /// <remarks>
        /// Counting columns is only possible for rectangular matrix.
        /// </remarks>
        public Tuple<bool, int> ColumnCount
        {
            get
            {
                bool isRectangular = this.IsRectangular;
                if (isRectangular)
                {
                    return new Tuple<bool, int>(isRectangular, this[0].Count);
                }
                else
                {
                    return new Tuple<bool, int>(isRectangular, -1);
                }
            }
        }
        /// <summary>
        /// If matrix is square returns <c>Tuple&lt;true, rowCount, columnCount&gt;</c>.
        /// Otherwise returns <c>Tuple&lt;false, rowCount, -1&gt;</c>.
        /// </summary>
        /// <remarks>
        /// Only rectangular matrix can return width and height.
        /// Jagged matrix can't calculate its width.
        /// </remarks>
        public Tuple<bool, int, int> Size
        {
            get
            {
                Tuple<bool, int> columnCount = this.ColumnCount;
                return new Tuple<bool, int, int>(columnCount.Item1, this.RowCount, columnCount.Item2);
            }
        }
        #endregion Properties
        #region Row Manipulation
        /// <summary>
        /// Gets row at specified index == <paramref name="rowIndex"/>.
        /// </summary>
        /// <param name="rowIndex">Index of the row to return.</param>
        /// <returns>
        /// If specified index == <paramref name="rowIndex"/> doesn't exist return <c>null</c> (otherwise returns the row).
        /// </returns>
        public List<T> GetRow(int rowIndex)
        {
            int rowCount = this.RowCount;
            if (rowIndex < rowCount)
            {
                return this[rowIndex];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Replaces a row at index == <paramref name="rowIndex"/> with passed <paramref name="row"/> if the specified row exists.
        /// </summary>
        /// <param name="rowIndex">Index of the row to replace.</param>
        /// <param name="row">New row to replace the specified row with.</param>
        /// <returns>
        /// If the specified row at index <paramref name="rowIndex"/> doesn't exist, return <c>false</c> (otherwise <c>true</c>).
        /// </returns>
        public bool ReplaceRow(int rowIndex, List<T> row)
        {
            int rowCount = this.RowCount;
            if (rowIndex < rowCount)
            {
                this[rowIndex] = row;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Adds passed <paramref name="newRow"/> at the end of the matrix
        /// </summary>
        /// <param name="newRow">New row to add to matrix.</param>
        public void AddRow(List<T> newRow)
        {
            this.rows.Add(newRow);
        }
        /// <summary>
        /// Removes a row at specified index == <paramref name="rowIndex"/> if it exists.
        /// If specified index doesn't exist returns <c>false</c> (<c>true</c> otherwise)
        /// </summary>
        /// <param name="rowIndex">Index of the row to remove from matrix.</param>
        /// <returns>
        /// <c>True</c> if row has been removed.
        /// <c>False</c> if specified row index doesn't exist.
        /// </returns>
        public bool RemoveRow(int rowIndex)
        {
            if (rowIndex < this.rows.Count)
            {
                this.rows.RemoveAt(rowIndex);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Replaces row at index == <paramref name="rowIndexA"/> with row at index == <paramref name="rowIndexB"/>, and vice versa.
        /// </summary>
        /// <param name="rowIndexA">Index of the first row to swap.</param>
        /// <param name="rowIndexB">Index of the second row to swap.</param>
        /// <returns>
        /// Returns <c>true</c> if both specified rows exist in the matrix.
        /// Otherwise returns <c>false</c>.
        /// </returns>
        public bool SwapRows(int rowIndexA, int rowIndexB)
        {
            int rowCount = this.RowCount;
            if (rowIndexA < rowCount &&
                rowIndexB < rowCount)
            {
                List<T> tmpRow = this[rowIndexA];
                this[rowIndexB] = this[rowIndexA];
                this[rowIndexB] = tmpRow;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Row Manipulation
        #region Column Manipulation
        /// <summary>
        /// <c>Get</c> the column at index == <paramref name="columnIndex"/> if it exists.
        /// </summary>
        /// <param name="columnIndex">Index of the column to return.</param>
        /// <returns>
        /// If the column at index == <paramref name="columnIndex"/> doesn't exist, return <c>null</c> (otherwise returns specified column).
        /// </returns>
        public List<T> GetColumn(int columnIndex)
        {
            Tuple<bool, int> columnCount = this.ColumnCount;
            if (columnCount.Item1 == true &&
                columnIndex < columnCount.Item2)
            {
                List<T> column = new List<T>(this.RowCount);
                foreach (List<T> row in this.rows)
                {
                    column.Add(row[columnIndex]);
                }
                return column;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Replaces the matrix column at index == <paramref name="columnIndex"/> with passed <paramref name="column"/> if it exists.
        /// </summary>
        /// <param name="columnIndex">Index of the matrix column to replace.</param>
        /// <param name="column">New column to replace the specified column with.</param>
        /// <returns>
        /// If specified column doesn't exist returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        /// <remarks>Replacing a column is only possible if the matrix is square.</remarks>
        public bool ReplaceColumn(int columnIndex, List<T> column)
        {
            Tuple<bool, int> columnCount = this.ColumnCount;
            if (columnCount.Item1 == true &&
                columnIndex < columnCount.Item2)
            {
                int columnElementIndex = 0;
                foreach (List<T> row in this.rows)
                {
                    row[columnIndex] = column[columnElementIndex];
                    columnElementIndex++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Removes a column at specified index == <paramref name="columnIndex"/> if it exists.
        /// </summary>
        /// <param name="columnIndex">Index of a column to remove.</param>
        /// <returns>
        /// If a column at specified <paramref name="columnIndex"/> doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public bool RemoveColumn(int columnIndex)
        {
            Tuple<bool, int> columnCount = this.ColumnCount;
            if(columnCount.Item1 == true && columnIndex < columnCount.Item2)
            {
                foreach (List<T> row in this.rows)
                {
                    row.RemoveAt(columnIndex);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Adds passed <paramref name="column"/> at the end of the matrix.
        /// </summary>
        /// <param name="column">New column to be added to the matrix.</param>
        /// <returns>
        /// If matrix is not rectangular return <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        /// <remarks>
        /// Adding columns is only possible if the matrix is rectangular.
        /// New added <paramref name="column"/> can make the matrix jagged but it'll be always added from the top.
        /// If the passed <paramref name="column"/> is taller than the matrix itself, the remaining items at the end won't be added.
        /// </remarks>
        public bool AddColumn(List<T> column)
        {
            Tuple<bool, int> columnCount = this.ColumnCount;
            if (columnCount.Item1 == true)
            {
                int columnElementIndex = 0;
                for (int i = 0; i < column.Count && i < this.RowCount; i++)
                {
                    this[i].Add(column[columnElementIndex]);
                    columnElementIndex++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Replaces the column at index == <paramref name="columnIndexA"/> with column at index == <paramref name="columnIndexB"/>, and vice versa.
        /// </summary>
        /// <param name="columnIndexA">Index of the first column to swap.</param>
        /// <param name="columnIndexB">Index of the second column to swap.</param>
        /// <returns>
        /// If matrix is not square or any of the two specified columns doesn't exist, return <c>false</c> (otherwise return <c>true</c>).
        /// </returns>
        /// <remarks>Swaping columns is only possible if matrix is square.</remarks>
        public bool SwapColumns(int columnIndexA, int columnIndexB)
        {
            Tuple<bool, int> columnCount = this.ColumnCount;
            if (columnCount.Item1 == true &&
                columnIndexA < columnCount.Item2 &&
                columnIndexB < columnCount.Item2)
            {
                List<T> tmpColumn = this.GetColumn(columnIndexA);
                this.ReplaceColumn(columnIndexA, this.GetColumn(columnIndexB));
                this.ReplaceColumn(columnIndexB, tmpColumn);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Column Manipulation
        /// <summary>
        /// Create a transposed matrix if its rectangular.
        /// </summary>
        /// <returns>
        /// New <c>Matrix&lt;T&gt;</c> with the same <c>T</c> type, which is a trasposition of calling matrix.
        /// If the calling matrix is not rectangular, returns <c>null</c>.
        /// </returns>
        public Matrix<T> Transpose()
        {
            Matrix<T> transposedMatrix = null;
            bool isRectangular = this.IsRectangular;
            if(isRectangular == true)
            {
                Tuple<bool, int> columnCount = this.ColumnCount;
                transposedMatrix = new Matrix<T>();
                for (int i = 0; i < columnCount.Item2; i++)
                {
                    transposedMatrix.AddRow(this.GetColumn(i));
                }
            }
            return transposedMatrix;
        }
        /// <summary>
        /// Returns the identity matrix of specified <paramref name="size"/>.
        /// </summary>
        /// <param name="size">Width and height of the identity matrix to create.</param>
        public static Matrix<int> IdentityMatrix(int size)
        {
            Matrix<int> identityMatrix = new Matrix<int>();
            List<int> row = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(0);
                    }
                }
                identityMatrix.AddRow(row);
                row.Clear();
            }
            return identityMatrix;
        }
    }
}
