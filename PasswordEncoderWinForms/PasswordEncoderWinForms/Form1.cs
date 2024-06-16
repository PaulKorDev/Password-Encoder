using PasswordEnscriptor;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordEncoderWinForms
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string[] texts;
            
            int cInt = Convert.ToInt32(textBox3.Text);
            int lInt = Convert.ToInt32(textBox6.Text);
            int p1Int = Convert.ToInt32(textBox4.Text);
            int p2Int = Convert.ToInt32(textBox5.Text);
            

            if (radioButton1.Checked)
            {
                texts = (textBox1.Text.Contains('\n')) ? textBox1.Text.Split('\n') : new string[1] { textBox1.Text };
                for (int i = 0; i < texts.Length; i++)
                {
                    if (texts[i].Any(char.IsWhiteSpace))
                        texts[i] = texts[i].Replace("\r", "");
                }

                if (texts.Length > 1)
                {
                    string textLogin = texts[0];
                    string textPas = texts[1];
                    var encodedText = EncoderManager.EncodeLoginAndPassword(textLogin, textPas, cInt, lInt, p1Int, p2Int);
                    //start Both void
                    textBox2.Text = encodedText[0] + Environment.NewLine + encodedText[1];
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    EncoderManager.EncodeLogin(texts[0], cInt, lInt);
                }
            } else
            {
                texts = textBox1.Text.Split(' ');
                StringBuilder stringBuilder = new StringBuilder();

                if (radioButton2.Checked)
                {
                    foreach (var text in texts)
                    {
                        stringBuilder.Append(EncoderManager.EncodeLogin(text, cInt, lInt));
                    }
                }
                else if (radioButton3.Checked)
                {
                    foreach (var text in texts)
                    {
                        stringBuilder.Append(EncoderManager.EncodePassword(text, p1Int, p2Int));
                    }
                } 
                textBox2.Text = stringBuilder.ToString();
                
            }
            
        }
    }
}
