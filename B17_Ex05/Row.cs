using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    class Row
    {
        protected const int k_ButtonSize = 50;
        protected const int k_FeedbackBtnSize = 15;
        internal const int k_ButtonMargin = k_ButtonSize + 10;
        protected const int k_StartXLocation = 12;
        protected const int k_FeedbackBtnMargin = 4;
        protected const int k_NumberOfButtons = 4;

        protected List<Button> m_ChoiceButtons;
        public List<Button> ChoiceButtons { get => m_ChoiceButtons; set => m_ChoiceButtons = value; }

        public Row(int i_YLocation)
        {
            m_ChoiceButtons = InitLine(i_YLocation);
        }

        private List<Button> InitLine(int i_YLocation)
        {
            List<Button> buttonList = new List<Button>();
            for (int i = 0; i < k_NumberOfButtons; i++)
            {
                Button button = InitButton();
                int XLocation = k_StartXLocation + i * k_ButtonMargin;
                button.Location = new Point(XLocation, i_YLocation);
                buttonList.Add(button);
            }
            return buttonList;
        }

        protected Button InitButton()
        {
            Button button = new Button()
            {
                Size = new Size(k_ButtonSize, k_ButtonSize),
                Enabled = false
            };
            return button;
        }

    }
}
