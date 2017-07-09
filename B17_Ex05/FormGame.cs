using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace B17_Ex05

{
    public delegate void UserNumberOfChoices(int userNumberOfchoices);
    public delegate void UserSelection(List<Color> userSelection);

    public class FormGame : Form
    {
        public event UserSelection UserSelection;
        public event UserNumberOfChoices UserNumberOfChoices;

        private const int k_NumberOfButtons = 4;
        private const int k_StartYLocation = 12;
        private const int k_RowMargin = 60;

        private InitialForm m_FormLogin = new InitialForm();
        internal InitialForm FormLogin { get => m_FormLogin; }
        private ColorsCollectionForm m_ColorsCollectionForm = new ColorsCollectionForm();
        internal ColorsCollectionForm ColorsCollectionForm { get => m_ColorsCollectionForm; }

        private List<Color> m_UserColorsSelection = null;

        private List<BoardRow> m_BoardRows = new List<BoardRow>();
        private Button m_CurrentSelectionButton = null;

        private int m_CounterSelection = 0;
        private int m_CurrentLine = 0;

        public FormGame()
        {
            m_UserColorsSelection = new List<Color>();
            FormLogin.ButtonStartGame.Click += new EventHandler(ButtonStartGame_Click);
        }

        public void StartGame()
        {
            FormLogin.ShowDialog();
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            FormLogin.Close();
            InitializeComponent();
            ShowDialog();
        }

        private void InitializeComponent()
        {
            AutoSize = true;
            Name = "FormGame";
            ResumeLayout(false);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;

            if (UserNumberOfChoices != null)
            {
                UserNumberOfChoices.Invoke(m_FormLogin.GetNumberOfChances());
            }

            InitBoard(m_FormLogin.GetNumberOfChances());
        }

        private void InitBoard(int i_NumberOfLines)
        {
            for (int i = 0; i < i_NumberOfLines; i++)
            {
                int YLocation = k_StartYLocation + i * k_RowMargin;
                BoardRow boardrow = new BoardRow(YLocation);
                AddRowToContolsForm(boardrow.GetAllButtons());
                m_BoardRows.Add(boardrow);
            }
            EnableButtonLine(m_BoardRows[0].ChoiceButtons);
        }

        private void AddRowToContolsForm(List<Button> i_LineButtons)
        {
            foreach (Button button in i_LineButtons)
            {
                Controls.Add(button);
            }
        }

        private void EnableButtonLine(List<Button> i_ListButton)
        {
            foreach (Button button in i_ListButton)
            {
                button.Enabled = true;
                button.Click += new EventHandler(ButtonShowColorsPanel_Click);
            }
        }

        private void ButtonShowColorsPanel_Click(object sender, EventArgs e)
        {
            m_CurrentSelectionButton = sender as Button;

            foreach (KeyValuePair<Color, Button> colorButton in ColorsCollectionForm.Buttons)
            {
                colorButton.Value.Click += new EventHandler(ButtonSelectedColor_Click);
            }
            ColorsCollectionForm.ShowDialog();
        }

        private void ButtonSelectedColor_Click(object sender, EventArgs e)
        {
            ColorsCollectionForm.Close();
            m_CurrentSelectionButton.Enabled = false;
            m_CurrentSelectionButton.BackColor = (sender as Button).BackColor;
            m_UserColorsSelection.Add(m_CurrentSelectionButton.BackColor);

            m_CounterSelection++;

            if (m_CounterSelection == k_NumberOfButtons)
            {
                Button arrowButton = m_BoardRows[m_CurrentLine].ArrowButton;
                arrowButton.Click += ButtonArrow_Click;
                arrowButton.Enabled = true;
            }

            foreach (KeyValuePair<Color, Button> colorButton in ColorsCollectionForm.Buttons)
            {
                colorButton.Value.Click -= new EventHandler(ButtonSelectedColor_Click);
            }
        }

        private void ButtonArrow_Click(object sender, EventArgs e)
        {
            Button arrowButton = sender as Button;
            arrowButton.Enabled = false;

            if (UserSelection != null)
            {
                UserSelection.Invoke(m_UserColorsSelection);
            }
        }

        public void ExecuteNextStep(List<Color> i_ListResult)
        {
            PaintFeedbackButtons(i_ListResult);
            m_UserColorsSelection = new List<Color>();
            m_CurrentLine++;
            m_CounterSelection = 0;
            if(m_CurrentLine < m_FormLogin.GetNumberOfChances())
            {
                EnableButtonLine(m_BoardRows[m_CurrentLine].ChoiceButtons);
            }
        } 

        private void PaintFeedbackButtons(List<Color> i_ListResult)
        {
            List<Button> currentFeedbackButtons = m_BoardRows[m_CurrentLine].FeedBackButtons;
            int i = 0;
            foreach(Color color in i_ListResult)
            {
                currentFeedbackButtons[i].BackColor = color;
                i++;
            }
        }

    }
}
