using System;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05

{
    public class FormGame : Form
    {

        InitialForm m_FormLogin = new InitialForm();

        public FormGame()
        {
            m_FormLogin.ButtonStartGame.Click += new EventHandler(buttonStartGame_Click);
            m_FormLogin.ShowDialog();
        }


        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Console.WriteLine("I Was here");
            Console.WriteLine(m_FormLogin.ButtonNumberOfChances.Text);
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
