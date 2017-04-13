using System;

namespace BaseLibS.Num.Matrix{
	[Serializable]
	public class BoolMatrixIndexer : IBoolMatrixIndexer{
		private bool[,] vals;

		private BoolMatrixIndexer(bool[,] vals){
			this.vals = vals;
		}

		internal BoolMatrixIndexer(){}

		public void Init(int nrows, int ncols){
			vals = new bool[nrows, ncols];
		}

		public IBoolMatrixIndexer Transpose(){
			return vals == null ? new BoolMatrixIndexer() : new BoolMatrixIndexer(ArrayUtils.Transpose(vals));
		}

		public void TransposeInPlace(){
			vals = ArrayUtils.Transpose(vals);
		}

		public void Set(bool[,] value){
			vals = value;
		}

		public bool[,] Get(){
			return vals;
		}

		public bool[] GetRow(int row){
			bool[] result = new bool[ColumnCount];
			for (int i = 0; i < result.Length; i++){
				result[i] = vals[row, i];
			}
			return result;
		}

		public bool[] GetColumn(int col){
			bool[] result = new bool[RowCount];
			for (int i = 0; i < result.Length; i++){
				result[i] = vals[i, col];
			}
			return result;
		}

		public bool IsInitialized(){
			return vals != null;
		}

		public void ExtractRowsInPlace(int[] rows){
			if (vals != null){
				vals = ArrayUtils.ExtractRows(vals, rows);
			}
		}

		public void ExtractColumnsInPlace(int[] columns){
			if (vals != null){
				vals = ArrayUtils.ExtractColumns(vals, columns);
			}
		}

		public IBoolMatrixIndexer ExtractRows(int[] rows){
			return new BoolMatrixIndexer(ArrayUtils.ExtractRows(vals, rows));
		}

		public IBoolMatrixIndexer ExtractColumns(int[] columns){
			return new BoolMatrixIndexer(ArrayUtils.ExtractColumns(vals, columns));
		}

		public int RowCount => vals.GetLength(0);
		public int ColumnCount => vals.GetLength(1);

		public bool this[int i, int j]{
			get { return vals[i, j]; }
			set { vals[i, j] = value; }
		}

		public void Dispose(){
			vals = null;
		}

		public object Clone(){
			return vals == null ? new BoolMatrixIndexer(null) : new BoolMatrixIndexer((bool[,]) vals.Clone());
		}
	}
}