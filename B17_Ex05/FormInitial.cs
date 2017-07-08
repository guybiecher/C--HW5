using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B17_Ex05
{
    class InitialForm : Form
    {
        private const int k_MinStartGame = 4;
        private const string k_MessageChancesPattern = "Number of chances: {0}";
        private Button m_ButtonNumberOfChances = new Button();
        private Button m_ButtonStartGame = new Button();
        private int m_NumberOfChances = 0; 

        public Button ButtonStartGame { get => m_ButtonStartGame; }
        public Button ButtonNumberOfChances { get => m_ButtonNumberOfChances;}

        public InitialForm()
        {

            this.Size = new Size(150, 150);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            m_ButtonNumberOfChances.Click += new EventHandler(m_ButtonNumberOfChances_Click);
        }

        /// <summary>
        /// This method will be called once, just before the first time the form is displayed
        /// </summary>
        /// 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitControls();
        }

        private void InitControls()
        {
            // 
            //  Intail Button Number of chances 
            // 
            this.ButtonNumberOfChances.Location = new Point(30, 43);
            this.ButtonNumberOfChances.Name = "NumberOfChances";
            this.ButtonNumberOfChances.Size = new Size(382, 41);
            this.ButtonNumberOfChances.TabIndex = 0;
            this.ButtonNumberOfChances.Text = String.Format(k_MessageChancesPattern,k_MinStartGame);

            // 
            // Intail Button Start new Game
            this.ButtonStartGame.Location = new Point(255, 171);
            this.ButtonStartGame.Name = "StartNewGame";
            this.ButtonStartGame.Size = new Size(156, 42);
            this.ButtonStartGame.TabIndex = 1;
            this.ButtonStartGame.Text = "Start New Game";
            this.ButtonStartGame.UseVisualStyleBackColor = true;
            
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(443, 241);
            this.Controls.Add(this.ButtonStartGame);
            this.Controls.Add(this.ButtonNumberOfChances);
            this.Name = "InitialForm";
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);

        }

        private void m_ButtonNumberOfChances_Click(object sender, EventArgs e)
        {;
            m_NumberOfChances++;

            m_ButtonNumberOfChances.Text = String.Format(k_MessageChancesPattern, m_NumberOfChances % 7 + k_MinStartGame);
        }

    }
}
