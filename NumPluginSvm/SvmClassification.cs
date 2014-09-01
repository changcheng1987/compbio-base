﻿using System;
using System.Collections.Generic;
using BaseLib.Num.Api;
using BaseLib.Param;
using BaseLib.Util;
using NumPluginBase.Kernel;
using NumPluginSvm.Svm;

namespace NumPluginSvm{
    public class SvmClassification : IClassificationMethod{
        public ClassificationModel Train(float[][] x, int[][] y, int ngroups, Parameters param, int nthreads){
            string err = CheckInput(x, y, ngroups);
            if (err != null){
                throw new Exception(err);
            }
            SingleChoiceWithSubParams kernelParam = param.GetSingleChoiceWithSubParams("Kernel");
            SvmParameter sp = new SvmParameter{
                kernelFunction = KernelFunctions.GetKernelFunction(kernelParam.Value, kernelParam.GetSubParameters()),
                svmType = SvmType.CSvc,
                c = param.GetDoubleParam("C").Value
            };
            bool[] invert;
            SvmProblem[] problems = CreateProblems(x, y, ngroups, out invert);
            SvmModel[] models = new SvmModel[problems.Length];
            for (int i = 0; i < models.Length; i++){
                models[i] = SvmMain.SvmTrain(problems[i], sp);
            }
            return new SvmClassificationModel(models, invert);
        }

        internal static string CheckInput(float[][] x, int[][] y, int ngroups){
            if (ngroups < 2){
                return "Number of groups has to be at least two.";
            }
            foreach (int[] ints in y){
                if (ints.Length == 0){
                    return "There are unassigned items";
                }
                Array.Sort(ints);
            }
            int[] vals = ArrayUtils.UniqueValues(ArrayUtils.Concat(y));
            for (int i = 0; i < vals.Length; i++){
                if (vals[i] != i){
                    return "At least one group has no training example.";
                }
            }
            return null;
        }

        private static SvmProblem[] CreateProblems(IList<float[]> x, IList<int[]> y, int ngroups, out bool[] invert){
            if (ngroups == 2){
                invert = new bool[1];
                return new[]{CreateProblem(x, y, 0, out invert[0])};
            }
            SvmProblem[] result = new SvmProblem[ngroups];
            invert = new bool[ngroups];
            for (int i = 0; i < ngroups; i ++){
                result[i] = CreateProblem(x, y, i, out invert[i]);
            }
            return result;
        }

        private static SvmProblem CreateProblem(IList<float[]> x, IList<int[]> y, int index, out bool invert){
            float[] y1 = new float[y.Count];
            for (int i = 0; i < y.Count; i++){
                if (Array.BinarySearch(y[i], index) >= 0){
                    y1[i] = 1;
                } else{
                    y1[i] = 0;
                }
            }
            invert = Array.BinarySearch(y[0], index) < 0;
            return new SvmProblem(x, y1);
        }

        public Parameters Parameters { get { return new Parameters(new Parameter[]{KernelFunctions.GetKernelParameters(), new DoubleParam("C", 10)}); } }
        public string Name { get { return "Support vector machine"; } }
        public string Description { get { return ""; } }
        public float DisplayRank { get { return 0; } }
        public bool IsActive { get { return true; } }
    }
}