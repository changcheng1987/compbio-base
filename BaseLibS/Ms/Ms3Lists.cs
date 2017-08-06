using System.Collections.Generic;

namespace BaseLibS.Ms{
	public class Ms3Lists{
		public double massMin = double.MaxValue;
		public double massMax = double.MinValue;
		public int maxNumIms = 0;
		public List<int> prevMs2IndexList = new List<int>();
		public List<int> scansList = new List<int>();
		public List<float> rtList = new List<float>();
		public List<double> mz1List = new List<double>();
		public List<double> mz2List = new List<double>();
		public List<FragmentationTypeEnum> fragmentTypeList = new List<FragmentationTypeEnum>();
		public List<float> ionInjectionTimesList = new List<float>();
		public List<float> basepeakIntensityList = new List<float>();
		public List<float> elapsedTimesList = new List<float>();
		public List<float> energiesList = new List<float>();
		public List<float> summationsList = new List<float>();
		public List<double> monoisotopicMzList = new List<double>();
		public List<float> ticList = new List<float>();
		public List<bool> hasCentroidList = new List<bool>();
		public List<bool> hasProfileList = new List<bool>();
		public List<MassAnalyzerEnum> analyzerList = new List<MassAnalyzerEnum>();
		public List<double> minMassList = new List<double>();
		public List<double> maxMassList = new List<double>();
		public List<double> isolationMzMinList = new List<double>();
		public List<double> isolationMzMaxList = new List<double>();
		public List<float> resolutionList = new List<float>();
		public List<double> intenseCompFactor = new List<double>();
		public List<double> emIntenseComp = new List<double>();
		public List<double> rawOvFtT = new List<double>();
		public List<float> agcList = new List<float>();
		public List<float> agcFillList = new List<float>();
		public List<int> nImsScans = new List<int>();
	}
}