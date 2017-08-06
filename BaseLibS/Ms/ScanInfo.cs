namespace BaseLibS.Ms {
    /// <summary>
    /// A collection of fields describing a scan. Information on scans is set in a device-dependent way.
    /// </summary>
	public class ScanInfo{
		public MsLevel msLevel;
		public bool isSim;
		public bool hasCentroid;
		public bool hasProfile;
		public bool positiveIonMode;
		public double min;  // minimum m/z
        public double max;  // minimum m/z
		public float agcFill;
		public float ionInjectionTime;
		public float basepeakIntensity;
		public float elapsedTime;
		public double ms2MonoMz;
		public double ms2ParentMz;
		public double ms3ParentMz;
		public FragmentationTypeEnum ms2FragType;
		public float tic;  // total ion current
		public float rt;  // retention time
		public int ionMobilityIndex;
		public double ms2IsolationMin;
		public double ms2IsolationMax;
        public MassAnalyzerEnum analyzer;
		public float resolution;
		public float summations;
		public float energy;
		public double intenseCompFactor;
		public double emIntenseComp;
		public double rawOvFtT;
	    public int nImsScans;
    }
}
