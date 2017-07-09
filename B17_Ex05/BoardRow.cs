using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    class BoardRow : Row
    {
        private const int k_NumOfFeedbackBtns = 4;
        private List<Button> m_FeedBackButtons;
        private Button m_ArrowButton;
        public List<Button> FeedBackButtons { get => m_FeedBackButtons; }
        public Button ArrowButton { get => m_ArrowButton; }

        public BoardRow(int i_YLocation) : base(i_YLocation)
        {
            m_ArrowButton = CreateArrowButton(i_YLocation);
            m_FeedBackButtons = CreateFeedbackButtons(i_YLocation);
        }

        private List<Button> CreateFeedbackButtons(int i_HeightReference)
        {
            List<Button> buttons = new List<Button>();
            i_HeightReference += (k_FeedbackBtnMargin + (k_FeedbackBtnMargin / 2));
            for (int i = 0; i < k_NumOfFeedbackBtns; i++)
            {
                Button currentButton = new Button();
                currentButton.Size = new Size(k_FeedbackBtnSize, k_FeedbackBtnSize);

                if (i < 2)
                {
                    currentButton.Location = CalcFeedbackBtnTopRowPosition(i, i_HeightReference);
                }
                else
                {
                    currentButton.Location = CalcFeedbackBtnBottomRowPosition(i, i_HeightReference);
                }
                buttons.Add(currentButton);
            }
            return buttons;
        }

        private Button CreateArrowButton(int i_HeightReference)
        {
            Button arrowButton = new Button()
            {
                Text = "-->>",
                Size = new Size(k_ButtonSize, 20),
                Location = new Point(4 * k_ButtonMargin + 5, i_HeightReference + 15),
                Enabled = false
            };
            return arrowButton;
        }

        public List<Button> GetAllButtons()
        {
            List<Button> allButtons = new List<Button>();
            allButtons.AddRange(m_ChoiceButtons);
            allButtons.Add(m_ArrowButton);
            allButtons.AddRange(m_FeedBackButtons);

            return allButtons;
        }

        private Point CalcFeedbackBtnTopRowPosition(int i_Scalar, int i_HeightReference)
        {
            return new Point
                (
                    (5 * k_ButtonMargin)
                    + (i_Scalar * k_FeedbackBtnSize + (i_Scalar + 1) * k_FeedbackBtnMargin),
                    i_HeightReference
                );
        }

        private Point CalcFeedbackBtnBottomRowPosition(int i_Scalar, int i_HeightReference)
        {
            return new Point
                (
                    (5 * k_ButtonMargin)
                    + ((i_Scalar - 2) * k_FeedbackBtnSize + (i_Scalar - 1) * k_FeedbackBtnMargin),
                    i_HeightReference + k_FeedbackBtnSize + k_FeedbackBtnMargin
                );
        }
    }
}
