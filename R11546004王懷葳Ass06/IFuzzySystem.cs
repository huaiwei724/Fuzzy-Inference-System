using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R11546004FuzzySetNamespace
{
    public interface IFuzzySystem
    {
        string SystemType { get ; }
        void ConstructRule(DataGridView dgv);
        double CrispInCrispOutInferencing(double[] conditions);
        void Save(StreamWriter sw);
        void Open(StreamReader sr, List<FuzzySet> allFSs, DataGridView dataGridView_Rule);
    }
}