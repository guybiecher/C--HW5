using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace B17_Ex05

{
    public class FormGame : Form
    {
        private const int k_ButtonSize = 50;
        private const int k_ButtonsMargin = k_ButtonSize + 10;
        private const int k_FeedbackBtnSize = 10;

        InitialForm m_FormLogin = new InitialForm();
        List<Label> m_Labels = new List<Label>();

        public FormGame()
        {
            m_FormLogin.ButtonStartGame.Click += new EventHandler(buttonStartGame_Click);
            m_FormLogin.ShowDialog();
        }


        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            this.m_FormLogin.Close(); //check if we need to close
            this.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormGame
            // 
            this.ClientSize = new Size(349, 286);
            this.Name = "FormGame";
            this.ResumeLayout(false);

        }

        private Button AddArrowButton(int i_HeightReference)
        {
            Button buttonArrow = new Button();
            buttonArrow.Size = new Size(k_ButtonSize, 20);
            buttonArrow.Location = new Point(4 * k_ButtonsMargin, i_HeightReference - 15);

            return buttonArrow;
        }

        private Button[] AddFeedbackButtons(int i_HeightReference)
        {
            Button[] feedBackButtonsArray = new Button[4];

            for (int i = 0; i < 2 ; i++)
            {
               feedBackButtonsArray[i] = new Button();
                feedBackButtonsArray[i].Size = new Size(k_FeedbackBtnSize, k_FeedbackBtnSize);
                feedBackButtonsArray[i].Location = new Point((5 * k_ButtonsMargin) + (i * k_FeedbackBtnSize), i_HeightReference - 2);

            }

            for (int i = 2; i < 4; i++)
            {
                feedBackButtonsArray[i] = new Button();
                feedBackButtonsArray[i].Size = new Size(k_FeedbackBtnSize, k_FeedbackBtnSize);
                feedBackButtonsArray[i].Location = new Point((5 * k_ButtonsMargin) + ((i - 2) * k_FeedbackBtnSize), i_HeightReference - k_FeedbackBtnSize - 4);

            }

            return feedBackButtonsArray;
        }

        private Button CreateArrowButton()
        {
            Button arrowButton = new Button();
            arrowButton.Text = "-->>";
            arrowButton.Enabled = false;

            return arrowButton;
        }
    }
}
