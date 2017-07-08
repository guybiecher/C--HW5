using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05
{
    class ColorsCollectionForm : Form
    {
        private const int k_StartX = 12;
        private const int k_StartY = 12;
        private const int k_ButtonSize = 50;
        private const int k_ButtonsMargin = k_ButtonSize + 10;
        private Dictionary<Color, Button> m_Buttons;
        private List<Color> m_Colors = new List<Color> {
            Color.HotPink,
            Color.Red,
            Color.Green,
            Color.LightBlue,
            Color.Blue,
            Color.Yellow,
            Color.Brown,
            Color.White
        };

        public List<Color> Colors { get => m_Colors; set => m_Colors = value; }

        public ColorsCollectionForm()
        {
            m_Buttons = new Dictionary<Color, Button>();
            this.InitColorsButtons();
            this.InitForm();

        }

        private void InitForm()
        {
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(260, 130);

            foreach (KeyValuePair<Color, Button> pair in m_Buttons)
            {
                this.Controls.Add(pair.Value);
            }

            this.Name = "Colors Collection";
            this.Text = "Colors Collection";
            this.ResumeLayout(false);
        }

        private void InitColorsButtons()
        {
            int i = 0;
            foreach (Color color in Colors)
            {
                Button currentButton = InitButton(color);
                currentButton.Location = setButtonLocation(i);
                m_Buttons.Add(color, currentButton);
                i++;
            }

        }

        private Button InitButton(Color i_Color)
        {
            return new Button()
            {
                Name = i_Color.ToString(),
                Size = new Size(k_ButtonSize, k_ButtonSize),
                TabIndex = 0,
                BackColor = i_Color,
                UseVisualStyleBackColor = true
            };
        }

        private Point setButtonLocation(int i_Index)
        {
            Point point;

            if (i_Index < 4)
            {
                point = new Point((k_StartX + (i_Index * k_ButtonsMargin)), k_StartY);
            }
            else
            {
                i_Index -= 4;
                point = new Point((k_StartX + i_Index * k_ButtonsMargin), (k_StartY + k_ButtonsMargin));
            }

            return point;
        }

    }
}
