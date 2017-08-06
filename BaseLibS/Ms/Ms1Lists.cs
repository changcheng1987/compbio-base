using System.Collections.Generic;

namespace BaseLibS.Ms{
	public class Ms1Lists{
		public double massMin = double.MaxValue;
		public double massMax = double.MinValue;
		public int maxNumIms = 0;
		public List<int> scans = new List<int>();
		public List<float> rts = new List<float>();
		public List<float> ionInjectionTimes = new List<float>();
		public List<float> basepeakIntensities = new List<float>();
		public List<float> elapsedTimes = new List<float>();
		public List<float> tics = new List<float>();
		public List<bool> hasCentroids = new List<bool>();
		public List<bool> hasProfiles = new List<bool>();
		public List<MassAnalyzerEnum> massAnalyzer = new List<MassAnalyzerEnum>();
		public List<double> minMasses = new List<double>();
		public List<double> maxMasses = new List<double>();
		public List<float> resolutions = new List<float>();
		public List<double> intenseCompFactors = new List<double>();
		public List<double> emIntenseComp = new List<double>();
		public List<double> rawOvFtT = new List<double>();
		public List<float> agcFillList = new List<float>();
		public List<int> nImsScans = new List<int>();
		public List<bool> isSim = new List<bool>();
	}
}