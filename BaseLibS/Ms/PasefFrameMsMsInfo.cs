using System;

namespace BaseLibS.Ms{
	[Serializable]
	public class PasefFrameMsMsInfo{
		public double CollisionEnergy { get; set; }
		public int Frame { get; set; }
		public double IsolationWidth { get; set; }
		public int Parent { get; set; }
		public double PeakIntensity { get; set; }
		public double PeakScanNumber { get; set; }
		public int Precursor { get; set; }
		public int PrecursorCharge { get; set; }
		public int ScanNumBegin { get; set; }
		public int ScanNumEnd { get; set; }
		public double TriggerMass { get; set; }
		public PasefFrameMsMsInfo(int frame, int precursor, int scanNumBegin, int scanNumEnd, double triggerMass,
			double isolationWidth, int precursorCharge, double collisionEnergy, double peakScanNumber, double peakIntensity,
			int parent){
			Frame = frame;
			Precursor = precursor;
			ScanNumBegin = scanNumBegin;
			ScanNumEnd = scanNumEnd;
			TriggerMass = triggerMass;
			IsolationWidth = isolationWidth;
			PrecursorCharge = precursorCharge;
			CollisionEnergy = collisionEnergy;
			PeakScanNumber = peakScanNumber;
			PeakIntensity = peakIntensity;
			Parent = parent;
		}
	}
}