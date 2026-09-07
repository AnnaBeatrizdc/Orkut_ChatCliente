using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatCliente
{
    public partial class FormChat : Form
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPEndPoint servidor = new IPEndPoint(
            IPAddress.Parse("192.168.0.9"), 9060
        );

        Thread threadReceber;

        private string nomeUsuario;

        public FormChat(string nome)
        {
            InitializeComponent();

            nomeUsuario = nome;
            lblNomeUsuario.Text = nomeUsuario;

            socket.Bind(new IPEndPoint(IPAddress.Any, 0));

            threadReceber = new Thread(ReceberMensagens);
            threadReceber.IsBackground = true;
            threadReceber.Start();

            ConectarAoServidor();
        }

        private void ReceberMensagens()
        {
            while (true)
            {
                try
                {
                    byte[] dados = new byte[1024];

                    EndPoint remetente = new IPEndPoint(
                        IPAddress.Any,
                        0
                    );

                    int quantidade = socket.ReceiveFrom(
                        dados,
                        ref remetente
                    );

                    string mensagem = Encoding.UTF8.GetString(
                        dados,
                        0,
                        quantidade
                    );

                    if (IsHandleCreated && !IsDisposed)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            if (mensagem.StartsWith("USUARIOS|"))
                            {
                                string[] partes = mensagem.Split('|');

                                lstUsuarios.Items.Clear();

                                for (int i = 1; i < partes.Length; i++)
                                {
                                    if (partes[i] != nomeUsuario)
                                    {
                                        lstUsuarios.Items.Add(partes[i]);
                                    }
                                }
                            }
                            else if (mensagem.StartsWith("MENSAGEM|"))
                            {
                                string[] partes = mensagem.Split('|', 3);

                                if (partes.Length == 3)
                                {
                                    string remetente = partes[1];
                                    string texto = partes[2];

                                    AdicionarMensagem(texto, false);
                                }
                            }
                        }));
                    }
                }
                catch (SocketException)
                {
                    // Evita que o programa seja encerrado caso ocorra
                    // alguma interrupção temporária na comunicação.
                }
                catch (ObjectDisposedException)
                {
                    // O socket foi fechado ao encerrar o programa.
                    break;
                }
            }
        }

        private void ConectarAoServidor()
        {
            string mensagem = "CONECTAR|" + nomeUsuario;

            byte[] dados = Encoding.UTF8.GetBytes(mensagem);

            socket.SendTo(dados, servidor);
        }

        private void AdicionarMensagem(string texto, bool minhaMensagem)
        {
            // Painel que ocupa a largura da conversa
            Panel linha = new Panel();

            linha.Width = pnlMensagens.ClientSize.Width - 25;
            linha.Height = 60;

            // Label que será o balão
            Label balao = new Label();

            balao.Text = texto;
            balao.AutoSize = true;

            balao.MaximumSize = new Size(350, 0);

            balao.Padding = new Padding(12, 8, 12, 8);

            balao.Font = new Font("Segoe UI", 10);

            // Verifica se a mensagem foi enviada ou recebida
            if (minhaMensagem)
            {
                balao.BackColor = Color.FromArgb(255, 225, 240);
                balao.ForeColor = Color.FromArgb(80, 50, 70);

                // Coloca do lado direito
                balao.Location = new Point(
                    linha.Width - balao.PreferredWidth - 15,
                    5
                );
            }
            else
            {
                balao.BackColor = Color.FromArgb(240, 240, 245);
                balao.ForeColor = Color.FromArgb(50, 50, 50);

                // Coloca do lado esquerdo
                balao.Location = new Point(15, 5);
            }

            linha.Controls.Add(balao);

            pnlMensagens.Controls.Add(linha);

            // Rola automaticamente para a última mensagem
            pnlMensagens.ScrollControlIntoView(linha);
        }



        private void btnEnvia_Click(object sender, EventArgs e)
        {
            // Verifica se um usuário foi selecionado
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um usuário para enviar a mensagem.");
                return;
            }

            string mensagem = txtMensagens.Text.Trim();

            if (mensagem == "")
            {
                MessageBox.Show("Digite uma mensagem.");
                return;
            }

            string destinatario = lstUsuarios.SelectedItem.ToString();

            // Monta a mensagem que será enviada ao servidor
            string mensagemEnviar =
                "MENSAGEM|" + destinatario + "|" + mensagem;

            byte[] dados = Encoding.UTF8.GetBytes(mensagemEnviar);

            socket.SendTo(dados, servidor);

            AdicionarMensagem(mensagem, true);

            txtMensagens.Clear();
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem != null)
            {
                lblUsuarioConversa.Text = lstUsuarios.SelectedItem.ToString();

                lblStatusConversa.Text = "● Online";
                lblStatusConversa.ForeColor = Color.Green;
            }
        }

        private void FormChat_Shown(object sender, EventArgs e)
        {

        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Close();
        }

        private void pnlEnvio_Paint(object sender, PaintEventArgs e)
        {

        }



        //private void btnConectar_Click(object sender, EventArgs e)
        //{
        //    string nome = txtUsuario.Text.Trim();

        //    if (nome == "")
        //    {
        //        MessageBox.Show("Digite seu nome.");
        //        return;
        //    }

        //    string mensagem = "CONECTAR|" + nome;

        //    byte[] dados = Encoding.UTF8.GetBytes(mensagem);

        //    socket.SendTo(dados, servidor);

        //    MessageBox.Show("Conectado como " + nome);

        //    txtUsuario.Enabled = false;
        //    btnConectar.Enabled = false;
        //}
    }
}