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
    public partial class GameView : Form
    {
        private readonly WorldState theWorld;
        List<IndexedValueView> polViews;

        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
        }

        /// <summary>
        /// Method called by the controler whenever some text should be displayed
        /// </summary>
        /// <param name="s"></param>
        public void WriteLine(string s)
        {
            List<string> strs = s.Split('\n').ToList();
            strs.ForEach(str => outputListBox.Items.Add(str));
            if (outputListBox.Items.Count > 0)
            {
                outputListBox.SelectedIndex = outputListBox.Items.Count - 1;
            }
            outputListBox.Refresh();
        }

        /// <summary>
        /// Method called by the controler whenever a confirmation should be asked
        /// </summary>
        /// <returns>Yes iff confirmed</returns>
        public bool ConfirmDialog()
        {
            string message = "Confirmer ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, "", buttons) == DialogResult.Yes;
        }
        #region Event handling
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true; // Or beep.
                GameController.Interpret(inputTextBox.Text);
            }
        }

        private void GameView_Paint(object sender, PaintEventArgs e)
        {
            diffLabel.Text = "Difficulté : " + theWorld.TheDifficulty;
            turnLabel.Text = "Tour " + (theWorld.Turns + 1); //ou turns + 1 ?
            moneyLabel.Text = "Trésor : " + theWorld.Money + " pièces d'or";
            gloryLabel.Text = "Gloire : " + theWorld.Glory;
            nextButton.Visible = true;
        }
        #endregion

        private void NextButton_Click(object sender, EventArgs e)
        {
            GameController.Interpret("suivant");
        }

        /// <summary>
        /// Method called from the GameController class used to display a MessageBox in a Losing situation.
        /// </summary>
        /// <param name="indexedValue"></param>
        public void LoseDialog(IndexedValue indexedValue)
        {
            if (indexedValue == null)
            {
                MessageBox.Show("Partie perdue : dette insurmontable.");
            }
            else
            {
                MessageBox.Show("Partie perdue : "
                + indexedValue.CompletePresentation());
            }
            nextButton.Enabled = false;
        }

        /// <summary>
        /// Method called from the GameController class used to display a MessageBox in a wining situation.
        /// </summary>
        public void WinDialog()
        {
            MessageBox.Show("Partie gagnée.");
            nextButton.Enabled = false;
        }

        private void gloryLabel_Click(object sender, EventArgs e)
        {

        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        #region Initialization of the lists and screen display of the IndexedValueViews

        /// <summary>
        /// Method called to add all the IndexedValues of a category
        /// to a list of IndexedValueViews so that we can manage the display with the ther methods.
        /// </summary>
        public void ListInitialization()
        {
            // PolRectangle:0,600,2100,300; w:80, h:80, margin:10
            Rectangle PolRectangle = new Rectangle(10, 10, 80, 80);
            int margin = 10, w = 80, h = 80;
            int x = PolRectangle.X + margin, y = PolRectangle.Y + margin;
            polViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Policies)
            {
                polViews.Add(new IndexedValueView(p, new Point(x, y)));
                x += w + margin;
                if (x > PolRectangle.Right)
                {
                    x = PolRectangle.X;
                    y += h + margin;
                }

            }
        }

        public void IndexedScreenDisplay(PaintEventArgs e)
        {
            foreach (IndexedValueView q in polViews)
            {
                q.IndexedValueView_Draw(e);
            }
        }

        #endregion

        private void moneyLabel_Click(object sender, EventArgs e)
        {

        }
    }
}