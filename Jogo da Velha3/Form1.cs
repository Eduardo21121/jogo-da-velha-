namespace Jogo_da_Velha3
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && !jogo_final)
            {
                btn.Text = turno ? "X" : "O";
                texto[buttonIndex] = btn.Text;
                rodadas++;
                checagem(turno ? 1 : 2);
                turno = !turno;
            }
        }

        void Vencedor(int PlayerQueGanhou)
        {
            jogo_final = true;

            if (PlayerQueGanhou == 1)
            {
                Xplayer++;
                Xpontos.Text = Xplayer.ToString();
                MessageBox.Show("Jogador X ganhou!");
            }
            else
            {
                Oplayer++;
                Opontos.Text = Oplayer.ToString();
                MessageBox.Show("Jogador O ganhou!");
            }
            turno = true;
        }

        void checagem(int checagemPlayer)
        {
            string suporte = checagemPlayer == 1 ? "X" : "O";

            // Checagem horizontal
            for (int horizontal = 0; horizontal < 9; horizontal += 3)
            {
                if (texto[horizontal] == suporte && texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                {
                    Vencedor(checagemPlayer);
                    return;
                }
            }

            // Checagem vertical
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (texto[vertical] == suporte && texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                {
                    Vencedor(checagemPlayer);
                    return;
                }
            }

            // Checagem diagonal principal e secundária
            if ((texto[0] == suporte && texto[0] == texto[4] && texto[0] == texto[8]) ||
                (texto[2] == suporte && texto[2] == texto[4] && texto[2] == texto[6]))
            {
                Vencedor(checagemPlayer);
                return;
            }

            // Checagem de empate
            if (rodadas == 9 && !jogo_final)
            {
                empatesPontos++;
                empates.Text = empatesPontos.ToString();
                MessageBox.Show("Empate!");
                jogo_final = true;
            }
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            // Limpa o array texto e redefine variáveis de controle
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }

            // Limpa o texto de todos os botões do jogo
            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            

            // Reinicia variáveis do jogo
            rodadas = 0;
            jogo_final = false;
            turno = true;
        }
    }
}