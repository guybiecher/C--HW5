using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace B17_Ex05

{
    public class FormGame : Form
    {

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

    }
}
