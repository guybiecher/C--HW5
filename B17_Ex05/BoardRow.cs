using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    class BoardRow : Row
    {
        private List<Button> m_FeedBackButtons;
        private Button m_ArrowButton;
        public List<Button> FeedBackButtons { get => m_FeedBackButtons; }
        public Button ArrowButton { get => m_ArrowButton;}

        public BoardRow(int i_YLocation) : base(i_YLocation)
        {
            m_ArrowButton = CreateArrowButton(i_YLocation);
            m_FeedBackButtons = CreateFeedbackButtons(i_YLocation);
        }

        private List<Button> CreateFeedbackButtons(int i_HeightReference)
        {
            List<Button> buttons = new List<Button>();
            i_HeightReference += k_FeedbackBtnSize + (3 * k_FeedbackBtnMargin);
            for (int i = 0; i < 4; i++)
            {
                Button currentButton = new Button();
                currentButton.Size = new Size(k_FeedbackBtnSize, k_FeedbackBtnSize);

                if (i < 2)
                {
                    currentButton.Location = new Point((5 * k_ButtonMargin) + (i * k_FeedbackBtnSize + (i + 1) * k_FeedbackBtnMargin), i_HeightReference);
                }
                else
                {
                    currentButton.Location = new Point(
                        (5 * k_ButtonMargin) + ((i - 2) * k_FeedbackBtnSize + (i - 1) * k_FeedbackBtnMargin), i_HeightReference - k_FeedbackBtnSize - k_FeedbackBtnMargin);
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
    }
}
