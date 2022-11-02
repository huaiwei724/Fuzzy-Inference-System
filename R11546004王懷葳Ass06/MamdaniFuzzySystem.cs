using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R11546004FuzzySetNamespace
{
    public class MamdaniFuzzySystem :IFuzzySystem
    {
        MamdaniRule[] rules;
        public bool CutInferecing { get; set; } = true;
        public DefuzzificationType Defuzzification { get; set; } = DefuzzificationType.COA;
        public FireStrengthComputeType FireStrengthCompute { get; set; } = FireStrengthComputeType.Min;
        public CompositionType Composition { get; set; } = CompositionType.MaxMin;

        public string SystemType { get => typeof(MamdaniFuzzySystem).Name; }
        public void ConstructRule(DataGridView dgv)
        {
            // Construct rules
            int idx = 0;
            rules = new MamdaniRule[dgv.RowCount];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                List<FuzzySet> ant = new List<FuzzySet>();
                for (int i = 0; i < dgv.ColumnCount - 1; i++)
                {
                    ant.Add((FuzzySet)row.Cells[i].Value);
                }
                FuzzySet conclusion = (FuzzySet)row.Cells[dgv.ColumnCount - 1].Value;
                rules[idx] = new MamdaniRule(ant, conclusion);
                idx++;
              //  rules.Add(rule);
            }
        }
        // construct rules from datagridview control
        public FuzzySet FuzzyInFuzzyOutInferencing(FuzzySet[] conditions)
        {
            // Infer
            FuzzySet inferencedResult;
            if (conditions == null)
                Console.WriteLine("conditions");
            inferencedResult = rules[0].FuzzyInFuzzyOutInferencing(conditions, CutInferecing, FireStrengthCompute, Composition);
            for (int i = 0; i < rules.Length; i++)
            {
                inferencedResult |= rules[i].FuzzyInFuzzyOutInferencing(conditions, CutInferecing, FireStrengthCompute, Composition);
            }

            return inferencedResult;
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            FuzzySet inferencedResult;
            inferencedResult = rules[0].CrispInFuzzyOutInferencing(conditions, CutInferecing, FireStrengthCompute, Composition);
            for (int i = 0; i < rules.Length; i++)
            {
                inferencedResult |= rules[i].CrispInFuzzyOutInferencing(conditions, CutInferecing, FireStrengthCompute, Composition);
            }

            switch (Defuzzification)
            {
                case DefuzzificationType.COA:
                    return inferencedResult.COACrispvalue;
                case DefuzzificationType.BOA:
                    return inferencedResult.BOACrispvalue;
                case DefuzzificationType.MOM:
                    return inferencedResult.MOMCrispvalue;
                case DefuzzificationType.SOM:
                    return inferencedResult.SOMCrispvalue;
                case DefuzzificationType.LOM:
                    return inferencedResult.LOMCrispvalue;
            }
            return -1.0;

        }
        public double Get_Defuzzification(FuzzySet inferencedResult)
        {
            switch (Defuzzification)
            {
                case DefuzzificationType.COA:
                    return inferencedResult.COACrispvalue;
                case DefuzzificationType.BOA:
                    return inferencedResult.BOACrispvalue;
                case DefuzzificationType.MOM:
                    return inferencedResult.MOMCrispvalue;
                case DefuzzificationType.SOM:
                    return inferencedResult.SOMCrispvalue;
                case DefuzzificationType.LOM:
                    return inferencedResult.LOMCrispvalue;
            }
            return -1.0;
        }
        public void Save(StreamWriter sw)
        {
            //Save CutInferecing Defuzzification   FireStrengthCompute   Composition 
            sw.WriteLine($"MamdaniCutInferecing:{ CutInferecing}");
            int index = Array.IndexOf(Enum.GetValues(Defuzzification.GetType()), Defuzzification);
            sw.WriteLine($"MamdaniDefuzzificationIndex:{ index}");
            index = Array.IndexOf(Enum.GetValues(FireStrengthCompute.GetType()), FireStrengthCompute);
            sw.WriteLine($"MamdaniFireStrengthComputeIndex:{ index}");
            index = Array.IndexOf(Enum.GetValues(Composition.GetType()), Composition);
            sw.WriteLine($"MamdaniCompositionIndex:{ index}");
            //save rule
            sw.WriteLine($"RuleNumber:{rules.Length}");
            for(int i = 0; i< rules.Length; i++)
            {
                rules[i].Save(sw);
            }
        }
        public void Open(StreamReader sr, List<FuzzySet> allFSs, DataGridView dataGridView_Rule)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            CutInferecing = Convert.ToBoolean(items[1]);

            items = sr.ReadLine().Split(':');
            int idx = Convert.ToInt32(items[1]);
            Defuzzification = (DefuzzificationType)(Enum.GetValues(Defuzzification.GetType())).GetValue(idx);

            items = sr.ReadLine().Split(':');
            idx = Convert.ToInt32(items[1]);
            FireStrengthCompute = (FireStrengthComputeType)(Enum.GetValues(FireStrengthCompute.GetType())).GetValue(idx);

            items = sr.ReadLine().Split(':');
            idx = Convert.ToInt32(items[1]);
            Composition = (CompositionType)(Enum.GetValues(Composition.GetType())).GetValue(idx);
            // open rule
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            rules = new MamdaniRule[num];
            for (int i = 0; i < rules.Length; i++)
            {
                rules[i] = new MamdaniRule();
                rules[i].Open(sr, allFSs, dataGridView_Rule);
            }
        }
    }
}
