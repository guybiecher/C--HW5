using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05
{
    class CollorsCollectionForm : Form
    {
        private Button m_ButtonPink;
        private Button m_ButtonRed;
        private Button m_ButtonGreen;
        private Button m_ButtonLightBlue;
        private Button m_ButtonBlue;
        private Button m_ButtonYellow;
        private Button m_ButtonBrown;
        private Button m_ButtonWhite;

        public CollorsCollectionForm()
        {
            m_ButtonPink = new Button();
            m_ButtonRed = new Button();
            m_ButtonGreen = new Button();
            m_ButtonLightBlue = new Button();
            m_ButtonBlue = new Button();
            m_ButtonYellow = new Button();
            m_ButtonBrown = new Button();
            m_ButtonWhite = new Button();

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
            this.ClientSize = new Size(276, 132);
            this.Controls.Add(this.m_ButtonPink);
            this.Controls.Add(this.m_ButtonRed);
            this.Controls.Add(this.m_ButtonGreen);
            this.Controls.Add(this.m_ButtonLightBlue);
            this.Controls.Add(this.m_ButtonBlue);
            this.Controls.Add(this.m_ButtonYellow);
            this.Controls.Add(this.m_ButtonBrown);
            this.Controls.Add(this.m_ButtonWhite);
            this.Name = "Collors Collection";
            this.Text = "Collors Collection";
            this.ResumeLayout(false);
        }

        private void InitColorsButtons()
        {
            /* m_ButtonPink */
            InitButton(Color.Pink, "Pink", m_ButtonPink);
            this.m_ButtonPink.Location = new Point(12, 12);

            /* m_ButtonRed */
            InitButton(Color.Red, "Red", m_ButtonRed);
            this.m_ButtonRed.Location = new Point(76, 12);

            /* m_ButtonGreen */
            InitButton(Color.Green, "Green", m_ButtonGreen);
            this.m_ButtonGreen.Location = new Point(140, 12);

            /* m_ButtonLightBlue */
            InitButton(Color.LightBlue, "LightBlue", m_ButtonLightBlue);
            this.m_ButtonLightBlue.Location = new Point(204, 12);

            /* m_ButtonBlue */
            InitButton(Color.Blue, "Blue", m_ButtonBlue);
            this.m_ButtonBlue.Location = new Point(12, 70);

            /* m_ButtonYellow */
            InitButton(Color.Yellow, "Yellow", m_ButtonYellow);
            this.m_ButtonYellow.Location = new Point(76, 70);

            /* m_ButtonBrown */
            InitButton(Color.Brown, "Brown", m_ButtonBrown);
            this.m_ButtonBrown.Location = new Point(140, 70);

            /* m_ButtonWhite */
            InitButton(Color.White, "White", m_ButtonWhite);
            this.m_ButtonWhite.Location = new Point(204, 70);

        }

        private void InitButton(Color i_Color, String i_Name, Button i_Button)
        {
            i_Button.Name = i_Name;
            i_Button.Size = new Size(58, 52);
            i_Button.TabIndex = 0;
            i_Button.BackColor = i_Color;
            i_Button.UseVisualStyleBackColor = true;
        }

    }
}
