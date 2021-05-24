using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    public partial class PolicyModification : Form
    {

        public IndexedValue policyChanged; //This attribute represents the policy we are currently modifying.
        public int numericUpDownValue { get { return (int)numericUpDown1.Value; } } //This numeric numericUpDownValue is the one we'll give to the IndexedValue numericUpDownValue

        /// <summary>
        /// Parameterized constructor of the class, helpful in the MouseDown method of the GameView class.
        /// </summary>
        /// <param name="policy"></param>
        public PolicyModification(IndexedValue policy)
        {
            InitializeComponent();
            policyChanged = policy;
            numericUpDown1.Value = policy.Value;
            numericUpDown1.Minimum = policy.MinValue;
            numericUpDown1.Maximum = policy.MaxValue;
        }
    }
}
