using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace R11546004FuzzySetNamespace
{
    public class TsukamotoFuzzySystem : IFuzzySystem
    {
        TsukamotoRule[] rules;
        public Weighted_Type WeightedInfereceType { get; set; } = Weighted_Type.WeigtedAverage;
        public string SystemType { get => typeof(TsukamotoFuzzySystem).Name; }
        public void ConstructRule(DataGridView dgv)
        {
            // Construct rules
            int idx = 0;
            rules = new TsukamotoRule[dgv.RowCount];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                List<FuzzySet> ant = new List<FuzzySet>();
                for (int i = 0; i < dgv.ColumnCount - 1; i++)
                {
                    ant.Add((FuzzySet)row.Cells[i].Value);
                }
                FuzzySet conclusion = (FuzzySet)row.Cells[dgv.ColumnCount - 1].Value;
                rules[idx] = new TsukamotoRule(ant, conclusion);
                idx++;
                //  rules.Add(rule);
            }
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            double[] resultArr = new double[rules.Length];
            double[] strengthArr = new double[rules.Length];
            for (int i = 0; i < rules.Length; i++)
            {
                resultArr[i] = rules[i].CrispInCrispOutInferencing(conditions, out double strength);
                strengthArr[i] = strength;
            }
            double weightedResult = 0.0;
            for (int i = 0; i < rules.Length; i++)
            {
                weightedResult += resultArr[i] * strengthArr[i];
            }

            if (WeightedInfereceType == Weighted_Type.WeigtedAverage)
            {
                return weightedResult / strengthArr.Sum();
            }
            else if (WeightedInfereceType == Weighted_Type.Average)
            {
                return resultArr.Sum() / resultArr.Length;
            }
            else if (WeightedInfereceType == Weighted_Type.WeigtedSum)
            {
                return weightedResult;
            }
            return weightedResult / strengthArr.Sum();
        }
        public void Save(StreamWriter sw)
        {
            int index = Array.IndexOf(Enum.GetValues(WeightedInfereceType.GetType()), WeightedInfereceType);
            sw.WriteLine($"TsukamotoWeightedTypeIndex:{ WeightedInfereceType}");

            sw.WriteLine($"RuleNumber:{rules.Length}");
            for (int i = 0; i < rules.Length; i++)
            {
                rules[i].Save(sw);
            }
        }
        public void Open(StreamReader sr, List<FuzzySet> allFSs, DataGridView dataGridView_Rule)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            int idx = Convert.ToInt32(items[1]);
            WeightedInfereceType = (Weighted_Type)(Enum.GetValues(WeightedInfereceType.GetType())).GetValue(idx);

            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            rules = new TsukamotoRule[num];
            for (int i = 0; i < rules.Length; i++)
            {
                rules[i] = new TsukamotoRule();
                rules[i].Open(sr, allFSs, dataGridView_Rule);
            }
        }
    }
}