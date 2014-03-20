﻿using System;
using System.Drawing;
using BaseLib.Num.Api;
using BaseLib.Num.Vector;
using BaseLib.Param;

namespace BaseLib.Num.Kernel{
    [Serializable]
    public class RbfKernelFunction : IKernelFunction{
        private double Sigma { get; set; }
        public RbfKernelFunction() : this(1) {}

        public RbfKernelFunction(double sigma){
            Sigma = sigma;
        }

        public bool UsesSquares{
            get { return true; }
        }

        public string Name{
            get { return "RBF"; }
        }

        public Parameters Parameters{
            get { return new Parameters(new Parameter[]{new DoubleParam("Sigma", Sigma)}); }
            set { Sigma = value.GetDoubleParam("Sigma").Value; }
        }

        public double Evaluate(BaseVector xi, BaseVector xj, double xSquarei, double xSquarej){
            return Math.Exp(-(xSquarei + xSquarej - 2*xi.Dot(xj))/2.0/xi.Length/Sigma/Sigma);
        }

        public object Clone(){
            return new RbfKernelFunction(Sigma);
        }
        public string Description { get { return ""; } }
        public float DisplayOrder { get { return 0; } }
        public bool IsActive { get { return true; } }
        public Bitmap DisplayImage { get { return null; } }
    }
}