using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace B17_Ex05

{
    public class FormGame : Form
    {
        public event EventHandler UserSelection;

        private const int k_ButtonSize = 50;
        private const int k_ButtonMargin = k_ButtonSize + 10;
        private const int k_LabelMargin = k_ButtonSize + 10;
        private const int k_StartXLocation = 12;
        private const int k_StartYLocation = 12;
        private const string k_ButtonId = "button-{0}.{1}";
        private const int k_NumberOfButtons = 4; 

        private InitialForm m_FormLogin = new InitialForm();
        internal InitialForm FormLogin { get => m_FormLogin; }
        private ColorsCollectionForm m_ColorsCollectionForm = new ColorsCollectionForm();
        internal ColorsCollectionForm ColorsCollectionForm { get => m_ColorsCollectionForm; }
       
        private List<Color> m_UserColorsSelection = null;

        private List<List<Button>> m_GameButtons = new List<List<Button>>();
        private Button m_CurrentSelectionButton = null;

        private int m_CounterSelection = 0;
        private int m_CurrentLine = 0;
        

        public FormGame()
        {
            m_UserColorsSelection = new List<Color>();
            FormLogin.ButtonStartGame.Click += new EventHandler(buttonStartGame_Click);
        }

        public void StartGame()
        {
            FormLogin.ShowDialog();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            this.FormLogin.Close();
            InitializeComponent();
            this.ShowDialog();
        }

        private void InitializeComponent()
        {
            // 
            // FormGame
            // 
            this.ClientSize = new Size(349, 286);
            this.Name = "FormGame";
            this.ResumeLayout(false);
            InitBoard(FormLogin.GetNumberOfChances());

        }

        private void InitBoard(int i_NumberOfLines)
        {
            for (int i = 0; i < i_NumberOfLines; i++)
            {
                int YLocation = k_StartYLocation + i * k_LabelMargin;
                m_GameButtons.Add(InitLine(i, YLocation));
            }
            EnableButtionLine(m_GameButtons[0]);
        }

        private List<Button> InitLine(int i_NumberOfLine, int i_YLocation)
        {
            List<Button> buttonList = new List<Button>();
            for (int i = 0; i < k_NumberOfButtons; i++)
            {
                Button button = InitButton(i_NumberOfLine, i);
                int XLocation = k_StartXLocation + i * k_ButtonMargin;
                button.Location = new Point(XLocation, i_YLocation);
                Controls.Add(button);
                buttonList.Add(button);
            }
            return buttonList;
            
        }

        private Button InitButton(int i_LineNumber , int i_ButtonNumber)
        {
            Button button = new Button()
            {
                Name = string.Format(k_ButtonId, i_ButtonNumber, i_ButtonNumber),
                Size = new Size(k_ButtonSize, k_ButtonSize),
                Enabled = false               
            };
            return button;
        }

        private void EnableButtionLine(List<Button> i_ListButton)
        {
            foreach(Button button in i_ListButton)
            {
                button.Enabled = true;
                button.Click += new EventHandler(buttonShowColorsPanel_Click);
            }
        }

        private void buttonShowColorsPanel_Click(object sender, EventArgs e)
        {
            m_CurrentSelectionButton = sender as Button;
        
            foreach (KeyValuePair<Color,Button> colorButton in ColorsCollectionForm.Buttons)
            {
                colorButton.Value.Click += new EventHandler(buttonSelectedColor_Click);
            }
            ColorsCollectionForm.ShowDialog();
        }

        private void buttonSelectedColor_Click(object sender, EventArgs e)
        {
            ColorsCollectionForm.Close();
            m_CurrentSelectionButton.Enabled = false;
            m_CurrentSelectionButton.BackColor = (sender as Button).BackColor;
            m_UserColorsSelection.Add(m_CurrentSelectionButton.BackColor);

            Console.WriteLine(m_CounterSelection);
            m_CounterSelection++;
            if (m_CounterSelection == k_NumberOfButtons)
            {
                m_CurrentLine++;
                UserChoicesEventArgs userChoicesEventArgs = new UserChoicesEventArgs(m_UserColorsSelection);
                UserSelection.Invoke(this, userChoicesEventArgs);
            }

            foreach (KeyValuePair<Color, Button> colorButton in ColorsCollectionForm.Buttons)
            {
                colorButton.Value.Click -= new EventHandler(buttonSelectedColor_Click);
            }
            
        }

    }
}
