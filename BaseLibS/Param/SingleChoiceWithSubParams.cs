﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BaseLibS.Param{
	[Serializable]
	public class SingleChoiceWithSubParams : ParameterWithSubParams<int>{
		public IList<string> Values { get; set; }
		public IList<Parameters> SubParams { get; set; }

        /// <summary>
        /// for xml serialization only
        /// </summary>
	    private SingleChoiceWithSubParams() : this("") { }

	    public SingleChoiceWithSubParams(string name) : this(name, 0){}

		public SingleChoiceWithSubParams(string name, int value) : base(name){
			TotalWidth = 1000F;
			ParamNameWidth = 250F;
			Value = value;
			Default = value;
			Values = new List<string>(new[] { "" });
			SubParams = new List<Parameters>(new[] { new Parameters() });
		}

		public override string StringValue{
			get { return Value.ToString(CultureInfo.InvariantCulture); }
			set { Value = int.Parse(value); }
		}

		public override void ResetSubParamValues(){
			Value = Default;
			foreach (Parameters p in SubParams){
				p.ResetValues();
			}
		}

		public override void ResetSubParamDefaults(){
			Default = Value;
			foreach (Parameters p in SubParams){
				p.ResetDefaults();
			}
		}

		public override bool IsModified{
			get{
				if (Value != Default){
					return true;
				}
				foreach (Parameters p in SubParams){
					if (p.IsModified){
						return true;
					}
				}
				return false;
			}
		}

		public string SelectedValue => Value < 0 || Value >= Values.Count ? null : Values[Value];

		public override Parameters GetSubParameters(){
			return Value < 0 || Value >= Values.Count ? null : SubParams[Value];
		}

		public override void Clear(){
			Value = 0;
			foreach (Parameters parameters in SubParams){
				parameters.Clear();
			}
		}

		public override float Height{
			get{
				float max = 0;
				foreach (Parameters param in SubParams){
					max = Math.Max(max, param.Height + 6);
				}
				return 44 + max;
			}
		}

		public void SetValueChangedHandlerForSubParams(ValueChangedHandler action){
			ValueChanged += action;
			foreach (Parameter p in GetSubParameters().GetAllParameters()){
				if (p is IntParam || p is DoubleParam){
					p.ValueChanged += action;
				} else{
					(p as SingleChoiceWithSubParams)?.SetValueChangedHandlerForSubParams(action);
				}
			}
		}
		public override ParamType Type => ParamType.Server;

	    public override void ReadXml(XmlReader reader)
	    {
	        base.ReadXml(reader);
	        Values = reader.ReadValues();
            var serializer = new XmlSerializer(SubParams.First().GetType());
	        reader.ReadToFollowing("SubParams");
	        var subParamTree = reader.ReadSubtree();
	        subParamTree.ReadToDescendant("Parameters");
            var subParams = new List<Parameters>();
	        while (true)
	        {
	            if (reader.NodeType == XmlNodeType.EndElement)
	            {
	                break;
	            }
	            var singleParamTree = subParamTree.ReadSubtree();
	            subParams.Add((Parameters) serializer.Deserialize(singleParamTree));
                singleParamTree.Close();
                subParamTree.ReadEndElement();
	        }
	        subParamTree.Close();
	        SubParams = subParams;
	    }

	    public override void WriteXml(XmlWriter writer)
	    {
	        base.WriteXml(writer);
            writer.WriteValues(Values);
            var serializer = new XmlSerializer(SubParams.First().GetType());
            writer.WriteStartElement("SubParams");
	        foreach (var parameters in SubParams)
	        {
                serializer.Serialize(writer, parameters);
	        }
            writer.WriteEndElement();
	    }
	}
}