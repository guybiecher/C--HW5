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
        private Button m_ButtonPink;
        private Button m_ButtonRed;
        private Button m_ButtonGreen;
        private Button m_ButtonLightBlue;
        private Button m_ButtonBlue;
        private Button m_ButtonYellow;
        private Button m_ButtonBrown;
        private Button m_ButtonWhite;

        public ColorsCollectionForm()
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
            this.Name = "Colors Collection";
            this.Text = "Colors Collection";
            this.ResumeLayout(false);
        }

        private void InitColorsButtons()
        {
            /* m_ButtonPink */

            this.m_ButtonPink.Location = new Point(12, 12);
            this.m_ButtonPink.Name = "Pink";
            this.m_ButtonPink.Size = new Size(58, 52);
            this.m_ButtonPink.TabIndex = 0;
            this.m_ButtonPink.BackColor = Color.HotPink;
            this.m_ButtonPink.UseVisualStyleBackColor = true;

            /* m_ButtonRed */

            this.m_ButtonRed.Location = new Point(76, 12);
            this.m_ButtonRed.Name = "Red";
            this.m_ButtonRed.Size = new Size(58, 52);
            this.m_ButtonRed.TabIndex = 0;
            this.m_ButtonRed.BackColor = Color.Red;
            this.m_ButtonRed.UseVisualStyleBackColor = true;

            /* m_ButtonGreen */

            this.m_ButtonGreen.Location = new Point(140, 12);
            this.m_ButtonGreen.Name = "Green";
            this.m_ButtonGreen.Size = new Size(58, 52);
            this.m_ButtonGreen.TabIndex = 0;
            this.m_ButtonGreen.BackColor = Color.Green;
            this.m_ButtonGreen.UseVisualStyleBackColor = true;

            /* m_ButtonLightBlue */

            this.m_ButtonLightBlue.Location = new Point(204, 12);
            this.m_ButtonLightBlue.Name = "Light Blue";
            this.m_ButtonLightBlue.Size = new Size(58, 52);
            this.m_ButtonLightBlue.TabIndex = 0;
            this.m_ButtonLightBlue.BackColor = Color.LightBlue;
            this.m_ButtonLightBlue.UseVisualStyleBackColor = true;

            /* m_ButtonBlue */

            this.m_ButtonBlue.Location = new Point(12, 70);
            this.m_ButtonBlue.Name = "Blue";
            this.m_ButtonBlue.Size = new Size(58, 52);
            this.m_ButtonBlue.TabIndex = 0;
            this.m_ButtonBlue.BackColor = Color.Blue;
            this.m_ButtonBlue.UseVisualStyleBackColor = true;

            /* m_ButtonYellow */

            this.m_ButtonYellow.Location = new Point(76, 70);
            this.m_ButtonYellow.Name = "Yellow";
            this.m_ButtonYellow.Size = new Size(58, 52);
            this.m_ButtonYellow.TabIndex = 0;
            this.m_ButtonYellow.BackColor = Color.Yellow;
            this.m_ButtonYellow.UseVisualStyleBackColor = true;

            /* m_ButtonBrown */

            this.m_ButtonBrown.Location = new Point(140, 70);
            this.m_ButtonBrown.Name = "Brown";
            this.m_ButtonBrown.Size = new Size(58, 52);
            this.m_ButtonBrown.TabIndex = 0;
            this.m_ButtonBrown.BackColor = Color.Brown;
            this.m_ButtonBrown.UseVisualStyleBackColor = true;

            /* m_ButtonWhite */

            this.m_ButtonWhite.Location = new Point(204, 70);
            this.m_ButtonWhite.Name = "White";
            this.m_ButtonWhite.Size = new Size(58, 52);
            this.m_ButtonWhite.TabIndex = 0;
            this.m_ButtonWhite.BackColor = Color.White;
            this.m_ButtonWhite.UseVisualStyleBackColor = true;
        }
    }
}
