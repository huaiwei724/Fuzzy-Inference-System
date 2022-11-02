using R11546004FuzzySetNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R11546004FuzzySetNamespace
{
    public class TsukamotoRule
    {
        private FuzzySet[] antecedents;
        private FuzzySet conclusion;

        public TsukamotoRule()
        {
        }
        public TsukamotoRule(List<FuzzySet> antecedents, FuzzySet conclusion)
        {
            this.antecedents = new FuzzySet[antecedents.Count];
            for (int i = 0; i < this.antecedents.Length; i++)
            {
                this.antecedents[i] = antecedents[i];
            }
            this.conclusion = conclusion;
        }
        public double CrispInCrispOutInferencing(double[] conditions, out double strength)
        {
            if (antecedents.Length != conditions.Length)
            {
                Console.WriteLine(antecedents.Length);
                Console.WriteLine(conditions.Length);
                throw new Exception("Number not consistent");
            }
            // determine firing strength
            // evalute output value
            // return weighted (strengthed) output value and strength
            double min = double.MaxValue;
            for (int i = 0; i < conditions.Length; i++)
            {
                double w = antecedents[i].GetMemberShipDegree(conditions[i]);
                if (w < min)
                    min = w;
            }
            double value = conclusion.GetUniverseValueForADegree(min);
            strength = min;
            return value;
        }

        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"NumOfAntecedents:{ antecedents.Length}");
            for (int i = 0; i < antecedents.Length; i++)
            {
                sw.WriteLine($"Antecedent{i + 1}HashCode:{antecedents[i].GetHashCode()}");
            }
            sw.WriteLine($"*OutputFSHashCode:{conclusion.GetHashCode()}");
        }

        internal void Open(StreamReader sr, List<FuzzySet> allFSs, DataGridView dataGridView_Rule)
        {
            string[] items;
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            antecedents = new FuzzySet[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                int fsCode = Convert.ToInt32(items[1]);
                foreach (FuzzySet fs in allFSs)
                {
                    if (fs.SavedHashCode == fsCode)
                    {
                        antecedents[i] = fs;
                        break;
                    }
                }
            }
            items = sr.ReadLine().Split(':');
            int conclusionCode = Convert.ToInt32(items[1]);
            foreach (FuzzySet fs in allFSs)
            {
                if (fs.SavedHashCode == conclusionCode)
                {
                    conclusion = fs;
                    break;
                }
            }
            dataGridView_Rule.Rows.Add();
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dataGridView_Rule.ColumnCount - 1; i++)
            {
                dataGridView_Rule.Rows[dataGridView_Rule.RowCount-1].Cells[i].Value = antecedents[i];
                dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
            }
            dataGridView_Rule.Rows[dataGridView_Rule.RowCount -1].Cells[dataGridView_Rule.ColumnCount - 1].Value = conclusion;
            dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
        }
    }
    public class SugenoRule
    {
        private FuzzySet[] antecedents;
        private int conclusionEQid;
        public SugenoRule()
        {
        }
        public SugenoRule(List<FuzzySet> antecedents, int conclusionEQid)
        {
            this.antecedents = new FuzzySet[antecedents.Count];
            for (int i = 0; i < this.antecedents.Length; i++)
            {
                this.antecedents[i] = antecedents[i];
            }
            this.conclusionEQid = conclusionEQid;
        }
        public double CrispInCrispOutInferencing(double[] conditions, out double strength)
        {
            if (antecedents.Length != conditions.Length)
            {
                Console.WriteLine(antecedents.Length);
                Console.WriteLine(conditions.Length);
                throw new Exception("Number not consistent");
            }
            // determine firing strength
            // evalute output value
            // return weighted (strengthed) output value and strength
            double min = double.MaxValue;
            for (int i = 0; i < conditions.Length; i++)
            {
                double w = antecedents[i].GetMemberShipDegree(conditions[i]);
                if (w<min)
                    min = w;
            }
            double value = GetOutputValue(conditions, conclusionEQid);
            strength = min;
            return value;
        }

        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"NumOfAntecedents:{ antecedents.Length}");
            for (int i = 0; i < antecedents.Length; i++)
            {
                sw.WriteLine($"*Antecedent{i + 1}HashCode:{antecedents[i].GetHashCode()}");
            }
            sw.WriteLine($"*OutputConclusionEQid:{conclusionEQid}");
        }

        internal void Open(StreamReader sr, List<FuzzySet> allFSs, DataGridView dataGridView_Rule)
        { 
            string[] items;
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            antecedents = new FuzzySet[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                int fsCode = Convert.ToInt32(items[1]);
                foreach (FuzzySet fs in allFSs)
                {
                    if (fs.SavedHashCode == fsCode)
                    {
                        antecedents[i] = fs;
                        break;
                    }
                }
            }
            items = sr.ReadLine().Split(':');
            conclusionEQid = Convert.ToInt32(items[1]);

            dataGridView_Rule.Rows.Add();
            for (int i = 0; i < dataGridView_Rule.ColumnCount - 1; i++)
            {
                dataGridView_Rule.Rows[dataGridView_Rule.RowCount-1].Cells[i].Value = antecedents[i];
                dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
            }
            dataGridView_Rule.Rows[dataGridView_Rule.RowCount-1].Cells[dataGridView_Rule.ColumnCount - 1].Value
                = GetEQString(conclusionEQid);
            dataGridView_Rule.Rows[dataGridView_Rule.RowCount-1].Cells[dataGridView_Rule.ColumnCount - 1].Tag
                = conclusionEQid;
            dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
        }
        public static string GetEQString(int equationID)
        {
            switch (equationID)
            {
                case 0: // Y=0.1X+6.4
                    return "Y = 0.1X + 6.4";
                case 1: // Y=-0.5X+4
                    return "Y = -0.5X + 4";
                case 2: // Y=X-2
                    return "Y = X - 2";
                case 3: // Z = -X + Y + 1
                    return "Z = -X + Y + 1";
                case 4: // Z = -Y+3
                    return "Z = -Y + 3";
                case 5: // Z = -X+3
                    return "Z = -X + 3";
                case 6: // Z = X+Y+2
                    return "Z = X + Y + 2";
            }
            return "1.0";
        }
        public static double GetOutputValue(double[] inputs, int equationID)
        {
            switch (equationID)
            {
                case 0: // Y=0.1X+6.4
                    return 0.1 * inputs[0] + 6.4;
                case 1: // Y=-0.5X+4
                    return -0.5 * inputs[0] + 4;
                case 2: // Y=X-2
                    return inputs[0] - 2;
                case 3: // Z = -X + Y + 1
                    return 1 - inputs[0] + inputs[1];
                case 4: // Z = -Y+3
                    return 3 - inputs[1];
                case 5: // Z = -X+3
                    return 3 - inputs[0];
                case 6: // Z = X+Y+2
                    return inputs[0] + inputs[1] + 2;
            }
            return 1.0;
        }
    }
    public class MamdaniRule
    {
        private FuzzySet[] antecedents;
        private FuzzySet conclusion;
        public MamdaniRule()
        {
        }
        public MamdaniRule(List<FuzzySet> antecedents, FuzzySet conclusion)
        {
            this.antecedents = new FuzzySet[ antecedents.Count];
            for(int i = 0; i < this.antecedents.Length; i++)
            {
                this.antecedents[i] = antecedents[i];
            }
            this.conclusion = conclusion;
        }
        public FuzzySet FuzzyInFuzzyOutInferencing(FuzzySet[] conditions, bool isCut = true
            , FireStrengthComputeType FireStrengthCompute = FireStrengthComputeType.Min
            , CompositionType Composition= CompositionType.MaxMin)
        {
            if (antecedents.Length != conditions.Length)
            {
                Console.WriteLine(antecedents.Length);
                Console.WriteLine(conditions.Length);
                throw new Exception("Number not consistent");
            }

            double fireStrength = double.MaxValue;
            switch (Composition)
            {
                case CompositionType.MaxMin:
                    fireStrength = double.MaxValue;
                    break;
                case CompositionType.MaxProduct:
                    fireStrength = 1;
                    break;
            }
            for (int i = 0; i < antecedents.Length; i++)
            {
                double strength = 1.0 ;
                switch (FireStrengthCompute)
                {
                    case FireStrengthComputeType.Min:
                        strength = (antecedents[i] & conditions[i]).MaxDegree;
                        break;
                    case FireStrengthComputeType.Max:
                        strength = (antecedents[i] | conditions[i]).MaxDegree;
                        break;
                    case FireStrengthComputeType.AlgebraicSum:
                        strength = (antecedents[i] % conditions[i]).MaxDegree;
                        break;
                    case FireStrengthComputeType.AlgebraicProduct:
                        strength = (antecedents[i] ^ conditions[i]).MaxDegree;
                        break;
                }
                switch (Composition)
                {
                    case CompositionType.MaxMin:

                        if (fireStrength >= strength)
                            fireStrength = strength;
                        break;
                    case CompositionType.MaxProduct:

                        fireStrength *= strength;
                        break;
                }
            }
            if (isCut) return fireStrength - conclusion;
            else return fireStrength * conclusion;
        }

        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"NumOfAntecedents:{ antecedents.Length}");
            for (int i = 0; i < antecedents.Length; i++)
            {
                sw.WriteLine($"Antecedent{i+1}HashCode:{antecedents[i].GetHashCode()}");
            }
            sw.WriteLine($"*OutputFSHashCode:{conclusion.GetHashCode()}");
        }

        internal void Open(StreamReader sr, List<FuzzySet> allFSs, DataGridView dataGridView_Rule)
        {
            string[] items;
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            antecedents = new FuzzySet[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                int fsCode = Convert.ToInt32(items[1]);
                foreach(FuzzySet fs in allFSs)
                {
                    if (fs.SavedHashCode == fsCode)
                    {
                        antecedents[i] = fs;
                        break;
                    }
                }
            }
            items = sr.ReadLine().Split(':');
            int conclusionCode = Convert.ToInt32(items[1]);
            foreach (FuzzySet fs in allFSs)
            {
                if (fs.SavedHashCode == conclusionCode)
                {
                    conclusion = fs;
                    break;
                }
            }
            dataGridView_Rule.Rows.Add();
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < num; i++)
            {
                dataGridView_Rule.Rows[dataGridView_Rule.RowCount-1].Cells[i].Value = antecedents[i];
                dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
            }
            dataGridView_Rule.Rows[dataGridView_Rule.RowCount-1].Cells[dataGridView_Rule.ColumnCount - 1].Value = conclusion;
            dataGridView_Rule.Rows[dataGridView_Rule.Rows.Count - 1].HeaderCell.Value = (dataGridView_Rule.Rows.Count).ToString();
        }

        public FuzzySet CrispInFuzzyOutInferencing(double[] conditions, bool isCut = true
            , FireStrengthComputeType FireStrengthCompute = FireStrengthComputeType.Min
            , CompositionType Composition = CompositionType.MaxMin)
        {
            if (antecedents.Length != conditions.Length)
            {
                Console.WriteLine(antecedents.Length);
                Console.WriteLine(conditions.Length);
                throw new Exception("Number not consistent");
            }

            double fireStrength = double.MaxValue;
            switch (Composition)
            {
                case CompositionType.MaxMin:
                    fireStrength = double.MaxValue;
                    break;
                case CompositionType.MaxProduct:
                    fireStrength = 1;
                    break;
            }
            for (int i = 0; i < antecedents.Length; i++)
            {
                double strength = 1.0;
                switch (FireStrengthCompute)
                {
                    case FireStrengthComputeType.Min:
                        strength = antecedents[i].GetMemberShipDegree(conditions[i]);
                        break;
                    case FireStrengthComputeType.Max:
                        strength = 1;
                        break;
                    case FireStrengthComputeType.AlgebraicSum:
                        strength = 1;
                        break;
                    case FireStrengthComputeType.AlgebraicProduct:
                        strength = antecedents[i].GetMemberShipDegree(conditions[i]);
                        break;
                }
                switch (Composition)
                {
                    case CompositionType.MaxMin:

                        if (fireStrength >= strength)
                            fireStrength = strength;
                        break;
                    case CompositionType.MaxProduct:

                        fireStrength *= strength;
                        break;
                }
            }
            if (isCut) return fireStrength - conclusion;
            else return fireStrength * conclusion;
        }
    }
}