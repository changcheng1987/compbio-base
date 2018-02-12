using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BaseLibS.Mol {
	public class FastaFileInfo : IXmlSerializable {
		public string fastaFilePath;
		public string identifierParseRule;
		public string descriptionParseRule;
		public string taxonomyParseRule;
		public string variationParseRule;
		public string modificationParseRule;
		public string taxonomyId;

		public FastaFileInfo() { }

		public FastaFileInfo(string fastaFilePath) : this(fastaFilePath, Tables.GetIdentifierParseRule(fastaFilePath),
			Tables.GetDescriptionParseRule(fastaFilePath), Tables.GetTaxonomyParseRule(fastaFilePath),
			Tables.GetVariationParseRule(fastaFilePath), Tables.GetModificationParseRule(fastaFilePath),
			Tables.GetTaxonomyId(fastaFilePath)) { }

		public FastaFileInfo(string fastaFilePath, string identifierParseRule, string descriptionParseRule,
			string taxonomyParseRule, string variationParseRule, string modificationParseRule, string taxonomyId) {
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

		public XmlSchema GetSchema() => null;
		
		private const string ElementName = "fastaFileInfo";
		private const string FastaFilePathName = "fastaFile";
		private const string IdentifierParseRuleName = "identifierParseRule";
		private const string DescriptionParseRuleName = "descriptionParseRule";
		private const string TaxonomyParseRuleName = "taxonomyParseRule";
		private const string VariationParseRuleName = "variationParseRule";
		private const string ModificationParseRuleName = "modificationParseRule";
		private const string TaxonomyIdName = "taxonomyId";

		public void ReadXml(XmlReader reader) {
			reader.ReadStartElement();
			fastaFilePath = reader.ReadElementContentAsString(FastaFilePathName, "");
			identifierParseRule = reader.ReadElementContentAsString(IdentifierParseRuleName, "");
			descriptionParseRule = reader.ReadElementContentAsString(DescriptionParseRuleName, "");
			taxonomyParseRule = reader.ReadElementContentAsString(TaxonomyParseRuleName, "");
			variationParseRule = reader.ReadElementContentAsString(VariationParseRuleName, "");
			modificationParseRule = reader.ReadElementContentAsString(ModificationParseRuleName, "");
			taxonomyId = reader.ReadElementContentAsString(TaxonomyIdName, "");
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer) {
			writer.WriteStartElement(ElementName);
			writer.WriteElementString(FastaFilePathName, fastaFilePath);
			writer.WriteElementString(IdentifierParseRuleName, identifierParseRule);
			writer.WriteElementString(DescriptionParseRuleName, descriptionParseRule);
			writer.WriteElementString(TaxonomyParseRuleName, taxonomyParseRule);
			writer.WriteElementString(VariationParseRuleName, variationParseRule);
			writer.WriteElementString(ModificationParseRuleName, modificationParseRule);
			writer.WriteElementString(TaxonomyIdName, taxonomyId);
			writer.WriteEndElement();
		}
	}
}