using System;
using System.Collections.Generic;

namespace BaseLibS.Ms {
	[Serializable]
	public class PasefPrecursorInfo {
		public int Id { get; set; }
		public int Parent { get; set; }
		public double LargestPeakMz { get; set; }
		public double AverageMz { get; set; }
		public double MonoisotopicMz { get; set; }
		public int Charge { get; set; }
		public double ScanNumber { get; set; }
		public double Intensity { get; set; }
		public List<int> PasefMsmsInds { get; set; } = new List<int>();

		public PasefPrecursorInfo(int id, int parent, double largestPeakMz, double averageMz, double monoisotopicMz,
			int charge, double scanNumber, double intensity) {
			Id = id;
			Parent = parent;
			LargestPeakMz = largestPeakMz;
			AverageMz = averageMz;
			MonoisotopicMz = monoisotopicMz;
			Charge = charge;
			ScanNumber = scanNumber;
			Intensity = intensity;
		}
	}
}