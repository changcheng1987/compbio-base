using System.Collections.Generic;
using BaseLibS.Util;

namespace BaseLibS.Mol {
	public class FastaFileInfo {
		public readonly List<InputParameter> vals = new List<InputParameter> {
			new InputParameter<string>("fastaFilePath", "fastaFilePath"),
			new InputParameter<string>("identifierParseRule", "identifierParseRule"),
			new InputParameter<string>("descriptionParseRule", "descriptionParseRule"),
			new InputParameter<string>("taxonomyParseRule", "taxonomyParseRule"),
			new InputParameter<string>("variationParseRule", "variationParseRule"),
			new InputParameter<string>("modificationParseRule", "modificationParseRule"),
			new InputParameter<string>("taxonomyId", "taxonomyId")
		};

		public readonly Dictionary<string, InputParameter> map;

		public FastaFileInfo() {
			map = new Dictionary<string, InputParameter>();
			foreach (InputParameter val in vals) {
				map.Add(val.Name, val);
			}
		}

		public string fastaFilePath;
		public string identifierParseRule;
		public string descriptionParseRule;
		public string taxonomyParseRule;
		public string variationParseRule;
		public string modificationParseRule;
		public string taxonomyId;

		public FastaFileInfo(string fastaFilePath) : this(fastaFilePath, Tables.GetIdentifierParseRule(fastaFilePath),
			Tables.GetDescriptionParseRule(fastaFilePath), Tables.GetTaxonomyParseRule(fastaFilePath),
			Tables.GetVariationParseRule(fastaFilePath), Tables.GetModificationParseRule(fastaFilePath),
			Tables.GetTaxonomyId(fastaFilePath)) { }

		public FastaFileInfo(string fastaFilePath, string identifierParseRule, string descriptionParseRule,
			string taxonomyParseRule, string variationParseRule, string modificationParseRule, string taxonomyId) : this() {
			this.fastaFilePath = fastaFilePath;
			this.identifierParseRule = identifierParseRule;
			this.descriptionParseRule = descriptionParseRule;
			this.taxonomyParseRule = taxonomyParseRule;
			this.variationParseRule = variationParseRule;
			this.modificationParseRule = modificationParseRule;
			this.taxonomyId = taxonomyId;
		}

		public static string[] ToString(FastaFileInfo[] filePaths) {
			string[] result = new string[filePaths.Length];
			for (int i = 0; i < result.Length; i++) {
				result[i] = filePaths[i].fastaFilePath;
			}
			return result;
		}

		public static FastaFileInfo[] ToInfo(string[] filePaths) {
			FastaFileInfo[] result = new FastaFileInfo[filePaths.Length];
			for (int i = 0; i < result.Length; i++) {
				result[i] = new FastaFileInfo(filePaths[i]);
			}
			return result;
		}

		public override string ToString() {
			return fastaFilePath;
		}
	}
}