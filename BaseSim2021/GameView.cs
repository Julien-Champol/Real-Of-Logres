using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaseSim2021
{
    public partial class GameView : Form
    {
        private readonly WorldState theWorld;
        List<IndexedValueView> polViews;
        List<IndexedValueView> groupsViews;
        List<IndexedValueView> perksViews;
        List<IndexedValueView> crisisViews;
        List<IndexedValueView> indicatorsViews;

        /// <summary>
        /// The necessary attributes to display the links between the value.
        /// </summary>
        public IndexedValue MouseValue { get; set; }
        List<IndexedValueView> linkedValues = new List<IndexedValueView>();
        private bool actuallyDrawing;
        private Point startingPoint;
        private List<IndexedValueView> linkedPoints = new List<IndexedValueView>();
        private Pen linksPen = new Pen(Color.Black);

        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
            ListInitialization();
            actuallyDrawing = false;
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

        /// <summary>
        /// The method handling the MouseDown event of the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameView_MouseDown(object sender, MouseEventArgs e)
        {
            actuallyDrawing = false;
            if (e.Button == MouseButtons.Left) //If the cursor is placed on one of the IndexedValueView displayed.
            {
                IndexedValue actualSelection = Sélection(e.Location)?.IndexedValue;
                if (theWorld.Policies.Contains(actualSelection) && actualSelection.Active == true)
                {
                    PolicyModification policyModification = new PolicyModification(actualSelection);
                    if (policyModification.ShowDialog() == DialogResult.OK)
                    {
                        GameController.ApplyPolicyChanges(actualSelection.Name + ' ' + policyModification.numericUpDownValue);
                        Refresh();
                    }

                }
                else if (!theWorld.Policies.Contains(actualSelection) && actualSelection?.Active == true || actualSelection?.AvailableAt <= theWorld.Turns)
                {
                    var description = MessageBox.Show(actualSelection.Description, actualSelection.Name, MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Returns the actualSelection corresponding to the mouse's location, null if there 
        /// is no such actualSelection.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private IndexedValueView Sélection(Point p)
        {
            if (polViews.FirstOrDefault(c => c.Contient(p)) != null)
            {
                return polViews.FirstOrDefault(c => c.Contient(p));
            }
            else if (indicatorsViews.FirstOrDefault(c => c.Contient(p)) != null)
            {
                return indicatorsViews.FirstOrDefault(c => c.Contient(p));
            }
            else if (crisisViews.FirstOrDefault(c => c.Contient(p)) != null)
            {
                return crisisViews.FirstOrDefault(c => c.Contient(p));
            }
            else if (perksViews.FirstOrDefault(c => c.Contient(p)) != null)
            {
                return perksViews.FirstOrDefault(c => c.Contient(p));
            }
            else if (groupsViews.FirstOrDefault(c => c.Contient(p)) != null)
            {
                return groupsViews.FirstOrDefault(c => c.Contient(p));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The paint method of the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameView_Paint(object sender, PaintEventArgs e)
        {
            diffLabel.Text = "Difficulté : " + theWorld.TheDifficulty;
            turnLabel.Text = "Tour " + (theWorld.Turns + 1); //ou turns + 1 ?
            moneyLabel.Text = "Trésor : " + theWorld.Money + " pièces d'or";
            gloryLabel.Text = "Gloire : " + theWorld.Glory;
            nextButton.Visible = true;
            ViewsDisplay(e.Graphics);

            if (actuallyDrawing == true)
            {
                foreach (IndexedValueView link in linkedPoints)
                {
                    if (MouseValue.OutputWeights.ContainsKey(link.IndexedValue))
                    {
                        if (MouseValue?.OutputWeights[link.IndexedValue] < 0)
                        {
                            linksPen = new Pen(Color.Red);
                            linksPen.Width = 2.5F;
                            linksPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        }
                        else if (MouseValue?.OutputWeights[link.IndexedValue] > 0
                            && MouseValue.OutputWeights[link.IndexedValue].ToString().Contains("0,00"))
                        {
                            linksPen = new Pen(Color.Orange);
                            linksPen.Width = 2.5F;
                            linksPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        }
                        else if (MouseValue?.OutputWeights[link.IndexedValue] > 0
                            && MouseValue.OutputWeights[link.IndexedValue].ToString().Contains("0,0"))
                        {
                            linksPen = new Pen(Color.Purple);
                            linksPen.Width = 2.5F;
                            linksPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        }
                        else if (MouseValue?.OutputWeights[link.IndexedValue] > 0
                            && MouseValue.OutputWeights[link.IndexedValue].ToString().Contains("0,"))
                        {
                            linksPen = new Pen(Color.Green);
                            linksPen.Width = 2.5F;
                            linksPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        }
                        Point thePoint = new Point(link.X + 40, link.Y + 40);
                        e.Graphics.DrawLine(linksPen, startingPoint, thePoint);
                    }
                }
            }
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

        #region Initialization of the lists and screen display of the IndexedValueViews

        /// <summary>
        /// Method called to add all the IndexedValues of a category
        /// to a list of IndexedValueViews so that the coordinates giving is managed here.
        /// </summary>
        public void ListInitialization()
        {
            // POLITICS
            // PolRectangle:0,20, 800, 641; w:135, h:70, margin:10
            Rectangle PolRectangle = new Rectangle(0, 20, 800, 100);
            int margin = 10, w = 135, h = 70;
            int x = PolRectangle.X + margin, y = PolRectangle.Y + margin;
            polViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Policies)
            {
                polViews.Add(new IndexedValueView(p, new Point(x, y), Color.Blue));
                x += w + margin;
                if (x > PolRectangle.Right)
                {
                    x = PolRectangle.X + margin;
                    y += h + margin;
                }
            }

            //GROUPS
            // GroupsRectangle:1000,20, 800, 641; w:135, h:70, margin:10
            Rectangle GroupsRectangle = new Rectangle(1000, 20, 800, 641);
            int groupsMargin = 10, groupsW = 135, groupsH = 70;
            int groupsX = GroupsRectangle.X + groupsMargin, groupsY = GroupsRectangle.Y + groupsMargin;
            groupsViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Groups)
            {
                groupsViews.Add(new IndexedValueView(p, new Point(groupsX, groupsY), Color.Red));
                groupsX += groupsW + groupsMargin;
                if (groupsX > GroupsRectangle.Right)
                {
                    groupsX = GroupsRectangle.X + groupsMargin;
                    groupsY += groupsH + groupsMargin;
                }
            }

            //PERKS
            // Perksrectangle:0,370, 500, 641; w:80, h:80, margin:10
            Rectangle PerksRectangle = new Rectangle(0, 370, 500, 641);
            int perksMargin = 10, perksW = 135, perksH = 70;
            int perksX = PerksRectangle.X + perksMargin, perksY = PerksRectangle.Y + perksMargin;
            perksViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Perks)
            {
                perksViews.Add(new IndexedValueView(p, new Point(perksX, perksY), Color.Black));
                perksX += perksW + perksMargin;
                if (perksX > PerksRectangle.Right)
                {
                    perksX = PerksRectangle.X + perksMargin;
                    perksY += perksH + perksMargin;
                }
            }

            //CRISIS
            // CrisisRectangle:1000,120, 400, 100; w:80, h:80, margin:10
            Rectangle CrisisRectangle = new Rectangle(1000, 120, 400, 100);
            int criseMargin = 10, criseW = 135, criseH = 70;
            int criseX = CrisisRectangle.X + criseMargin, criseY = CrisisRectangle.Y + criseMargin;
            crisisViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Crises)
            {
                crisisViews.Add(new IndexedValueView(p, new Point(criseX, criseY), Color.Brown));
                criseX += criseW + criseMargin;
                if (criseX > CrisisRectangle.Right)
                {
                    criseX = CrisisRectangle.X + criseMargin;
                    criseY += criseH + criseMargin;
                }
            }

            //INDICATORS
            // Indicatorsrectangle:1300,120, 400, 200; w:80, h:80, margin:10
            Rectangle IndicatorsRectangle = new Rectangle(1000, 320, 400, 100);
            int indicatorsMargin = 10, indicatorsW = 135, indicatorsH = 70;
            int indicatorsX = IndicatorsRectangle.X + indicatorsMargin, indicatorsY = IndicatorsRectangle.Y + indicatorsMargin;
            indicatorsViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Indicators)
            {
                indicatorsViews.Add(new IndexedValueView(p, new Point(indicatorsX, indicatorsY), Color.BlueViolet));
                indicatorsX += indicatorsW + indicatorsMargin;
                if (indicatorsX > IndicatorsRectangle.Right)
                {
                    indicatorsX = IndicatorsRectangle.X + indicatorsMargin;
                    indicatorsY += indicatorsH + indicatorsMargin;
                }
            }
        }

        /// <summary>
        /// Method used to display all the indexed values on screen.
        /// </summary>
        /// <param name="g"></param>
        public void ViewsDisplay(Graphics g)
        {
            foreach (IndexedValueView q in polViews)
            {
                if ((q.IndexedValue.Active == true || q.IndexedValue.AvailableAt <= theWorld.Turns)
                    && (MouseValue != null && MouseValue.OutputWeights.Keys.Contains(q.IndexedValue)
                    || (MouseValue != null && MouseValue.Equals(q.IndexedValue)) || MouseValue == null
                    || MouseValue.OutputWeights == null))
                {
                    q.IndexedValueView_Draw(g);
                }
            }

            foreach (IndexedValueView q in groupsViews)
            {
                if ((q.IndexedValue.Active == true || q.IndexedValue.AvailableAt <= theWorld.Turns)
                    && (MouseValue != null && MouseValue.OutputWeights.Keys.Contains(q.IndexedValue)
                    || (MouseValue != null && MouseValue.Equals(q.IndexedValue)) || MouseValue == null
                    || MouseValue.OutputWeights == null))
                {
                    q.IndexedValueView_Draw(g);
                }
            }

            foreach (IndexedValueView q in perksViews)
            {
                if ((q.IndexedValue.Active == true || q.IndexedValue.AvailableAt <= theWorld.Turns)
                    && (MouseValue != null && MouseValue.OutputWeights.Keys.Contains(q.IndexedValue)
                    || (MouseValue != null && MouseValue.Equals(q.IndexedValue)) || MouseValue == null
                    || MouseValue.OutputWeights == null))
                {
                    q.IndexedValueView_Draw(g);
                }
            }
            foreach (IndexedValueView q in crisisViews)
            {
                if ((q.IndexedValue.Active == true || q.IndexedValue.AvailableAt <= theWorld.Turns)
                    && (MouseValue != null && MouseValue.OutputWeights.Keys.Contains(q.IndexedValue)
                    || (MouseValue != null && MouseValue.Equals(q.IndexedValue)) || MouseValue == null
                    || MouseValue.OutputWeights == null))
                {
                    q.IndexedValueView_Draw(g);
                }
            }
            foreach (IndexedValueView q in indicatorsViews)
            {
                if ((q.IndexedValue.Active == true || q.IndexedValue.AvailableAt <= theWorld.Turns)
                    && (MouseValue != null && MouseValue.OutputWeights.Keys.Contains(q.IndexedValue)
                    || (MouseValue != null && MouseValue.Equals(q.IndexedValue)) || MouseValue == null
                    || MouseValue.OutputWeights == null))
                {
                    q.IndexedValueView_Draw(g);
                }
            }
        }

        /// <summary>
        /// The Mouse_Move event handler of the main window, method where we save the value of the IndexedValue
        /// where the mouse is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameView_MouseMove(object sender, MouseEventArgs e)
        {
            actuallyDrawing = true;
            if (Sélection(e.Location)?.IndexedValue.Active == true || Sélection(e.Location)?.IndexedValue.AvailableAt <= theWorld.Turns)
            { MouseValue = Sélection(e.Location)?.IndexedValue; }

            if (MouseValue != null && theWorld.Policies.Contains(MouseValue))
            {
                linkedPoints.Clear();
                linkedValues.Clear();
                if (MouseValue.OutputWeights != null && MouseValue.OutputWeights.Count > 0)
                {
                    foreach (IndexedValue q in MouseValue.OutputWeights.Keys)
                    {
                        linkedValues.Add(crisisViews.FirstOrDefault(ac => ac.IndexedValue.Equals(q)));
                        linkedValues.Add(perksViews.FirstOrDefault(ac => ac.IndexedValue.Equals(q)));
                        linkedValues.Add(indicatorsViews.FirstOrDefault(ac => ac.IndexedValue.Equals(q)));
                        linkedValues.Add(groupsViews.FirstOrDefault(ac => ac.IndexedValue.Equals(q)));
                    }
                }

                foreach (IndexedValueView r in linkedValues)
                {
                    if (r != null && r.IndexedValue.Active == true)
                    {
                        startingPoint =
                            new Point(polViews.FirstOrDefault(ac => ac.IndexedValue.Equals(MouseValue)).X + 40,
                            polViews.FirstOrDefault(ac => ac.IndexedValue.Equals(MouseValue)).Y + 40);
                        linkedPoints.Add(r);
                    }
                }

                if (Sélection(e.Location)?.IndexedValue != MouseValue)
                {
                    actuallyDrawing = false;
                    MouseValue = null;
                }
                Refresh();
            }

        }



        /// <summary>
        /// The method handling the MouseUp event of the main window. Useful to display the links between the IndexedValues.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameView_MouseUp(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}