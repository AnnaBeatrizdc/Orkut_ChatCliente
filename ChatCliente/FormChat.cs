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

        private Dictionary<string, List<(string texto, bool minhaMensagem)>> conversas =
            new Dictionary<string, List<(string texto, bool minhaMensagem)>>();

        private HashSet<string> conversasNaoLidas =
            new HashSet<string>();

        private HashSet<string> usuariosOnline =
            new HashSet<string>();

        private bool servidorOnline = true;

        private System.Windows.Forms.Timer timerServidor;

        public FormChat(string nome)
        {
            InitializeComponent();

            nomeUsuario = nome;
            lblNomeUsuario.Text = nomeUsuario;

            socket.Bind(new IPEndPoint(IPAddress.Any, 0));

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            threadReceber = new Thread(ReceberMensagens);
            threadReceber.IsBackground = true;
            threadReceber.Start();

            ConectarAoServidor();

            timerServidor = new System.Windows.Forms.Timer();
            timerServidor.Interval = 3000;

            timerServidor.Tick += async (s, args) =>
            {
                await VerificarServidorDuranteChat();
            };

            timerServidor.Start();
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
                            if (mensagem == "ERRO|NOME_EM_USO")
                            {
                                MessageBox.Show(
                                    "Esse nome já está sendo usado por outro usuário.",
                                    "Nome indisponível",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );

                                this.Close();
                            }

                            else if (mensagem.StartsWith("USUARIOS|"))
                            {
                                string[] partes = mensagem.Split('|');

                                usuariosOnline.Clear();

                                for (int i = 1; i < partes.Length; i++)
                                {
                                    string usuario = partes[i];

                                    if (usuario != nomeUsuario)
                                    {
                                        string usuarioExistente = null;

                                        foreach (var item in lstUsuarios.Items)
                                        {
                                            string nomeLista = item.ToString();

                                            if (nomeLista.Equals(
                                                usuario,
                                                StringComparison.OrdinalIgnoreCase
                                            ))
                                            {
                                                usuarioExistente = nomeLista;
                                                break;
                                            }
                                        }

                                        if (usuarioExistente == null)
                                        {
                                            lstUsuarios.Items.Add(usuario);
                                        }
                                        else
                                        {
                                            usuario = usuarioExistente;
                                        }

                                        usuariosOnline.Add(usuario);
                                    }
                                }

                                if (!lstUsuarios.Items.Contains("Chat Geral"))
                                {
                                    lstUsuarios.Items.Insert(0, "Chat Geral");
                                }

                                AtualizarStatusUsuarioSelecionado();
                            }

                            else if (mensagem.StartsWith("GERAL|"))
                            {
                                string[] partes = mensagem.Split('|', 3);

                                if (partes.Length == 3)
                                {
                                    string remetente = partes[1];
                                    string texto = partes[2];

                                    // Evita duplicar a própria mensagem,
                                    // porque ela já foi adicionada ao clicar em Enviar
                                    if (remetente != nomeUsuario)
                                    {
                                        string textoExibicao = remetente + ": " + texto;

                                        SalvarMensagem(
                                            "Chat Geral",
                                            textoExibicao,
                                            false
                                        );

                                        if (lstUsuarios.SelectedItem == null ||
                                            lstUsuarios.SelectedItem.ToString() != "Chat Geral")
                                        {
                                            conversasNaoLidas.Add("Chat Geral");
                                            lstUsuarios.Invalidate();
                                        }

                                        if (lstUsuarios.SelectedItem != null &&
                                            lstUsuarios.SelectedItem.ToString() == "Chat Geral")
                                        {
                                            AdicionarMensagem(
                                                textoExibicao,
                                                false
                                            );
                                        }
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

                                    remetente = ObterNomePadronizado(remetente);

                                    SalvarMensagem(remetente, texto, false);
                                    if (lstUsuarios.SelectedItem == null ||
                                        lstUsuarios.SelectedItem.ToString() != remetente)
                                    {
                                        conversasNaoLidas.Add(remetente);
                                        lstUsuarios.Invalidate();
                                    }

                                    if (lstUsuarios.SelectedItem != null &&
                                        lstUsuarios.SelectedItem.ToString() == remetente)
                                    {
                                        AdicionarMensagem(texto, false);
                                    }
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

        private async Task VerificarServidorDuranteChat()
        {
            bool estavaOnline = servidorOnline;

            servidorOnline = await Task.Run(() =>
            {
                try
                {
                    using (Socket socketTeste = new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Dgram,
                        ProtocolType.Udp))
                    {
                        socketTeste.ReceiveTimeout = 700;

                        byte[] dados =
                            Encoding.UTF8.GetBytes("PING");

                        socketTeste.SendTo(
                            dados,
                            servidor
                        );

                        byte[] resposta =
                            new byte[1024];

                        EndPoint remetente =
                            new IPEndPoint(
                                IPAddress.Any,
                                0
                            );

                        int quantidade =
                            socketTeste.ReceiveFrom(
                                resposta,
                                ref remetente
                            );

                        string resultado =
                            Encoding.UTF8.GetString(
                                resposta,
                                0,
                                quantidade
                            );

                        return resultado == "PONG";
                    }
                }
                catch
                {
                    return false;
                }
            });

            if (!servidorOnline)
            {
                usuariosOnline.Clear();

                AtualizarStatusUsuarioSelecionado();

                lstUsuarios.Invalidate();
            }

            if (!estavaOnline && servidorOnline)
            {
                ConectarAoServidor();
            }
        }

        private void SalvarMensagem(
            string usuario,
            string texto,
            bool minhaMensagem)
        {
            if (!conversas.ContainsKey(usuario))
            {
                conversas[usuario] =
                    new List<(string texto, bool minhaMensagem)>();
            }

            conversas[usuario].Add(
                (texto, minhaMensagem)
            );
        }

        private string ObterNomePadronizado(string usuario)
        {
            foreach (var item in lstUsuarios.Items)
            {
                string nomeLista = item.ToString();

                if (nomeLista.Equals(
                    usuario,
                    StringComparison.OrdinalIgnoreCase
                ))
                {
                    return nomeLista;
                }
            }

            return usuario;
        }

        private void CarregarConversa(string usuario)
        {
            pnlMensagens.Controls.Clear();

            if (!conversas.ContainsKey(usuario))
            {
                return;
            }

            foreach (var mensagem in conversas[usuario])
            {
                AdicionarMensagem(
                    mensagem.texto,
                    mensagem.minhaMensagem
                );
            }
        }

        private void AtualizarStatusUsuarioSelecionado()
        {
            if (lstUsuarios.SelectedItem == null)
                return;

            string usuario =
                lstUsuarios.SelectedItem.ToString();

            if (usuario == "Chat Geral")
            {
                lblStatusConversa.Text = "• Online";
                lblStatusConversa.ForeColor = Color.Green;

                return;
            }

            if (usuariosOnline.Contains(usuario))
            {
                lblStatusConversa.Text = "• Online";
                lblStatusConversa.ForeColor = Color.Green;
            }
            else
            {
                lblStatusConversa.Text = "• Offline";
                lblStatusConversa.ForeColor = Color.Gray;
            }
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

            if (!servidorOnline)
            {
                MessageBox.Show(
                    "O servidor está offline no momento.",
                    "Servidor offline",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

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

            if (destinatario != "Chat Geral" && !usuariosOnline.Contains(destinatario))
            {
                MessageBox.Show(
                    "Este usuário está offline no momento."
                );

                return;
            }

            SalvarMensagem(destinatario, mensagem, true);

            string mensagemEnviar;

            if (destinatario == "Chat Geral")
            {
                mensagemEnviar = "GERAL|" + mensagem;
            }
            else
            {
                mensagemEnviar =
                    "MENSAGEM|" + destinatario + "|" + mensagem;
            }

            byte[] dados = Encoding.UTF8.GetBytes(mensagemEnviar);

            socket.SendTo(dados, servidor);

            AdicionarMensagem(mensagem, true);

            txtMensagens.Clear();
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem != null)
            {
                if (lstUsuarios.SelectedItem != null)
                {
                    string usuarioSelecionado =
                        lstUsuarios.SelectedItem.ToString();

                    conversasNaoLidas.Remove(usuarioSelecionado);
                    lstUsuarios.Invalidate();

                    lblUsuarioConversa.Text = usuarioSelecionado;

                    AtualizarStatusUsuarioSelecionado();

                    CarregarConversa(usuarioSelecionado);
                }
            }
        }

        private void FormChat_Shown(object sender, EventArgs e)
        {

        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerServidor != null)
            {
                timerServidor.Stop();
            }
            try
            {
                string mensagem = "DESCONECTAR|" + nomeUsuario;

                byte[] dados = Encoding.UTF8.GetBytes(mensagem);

                socket.SendTo(dados, servidor);
            }
            catch
            {
                // Evita erro caso o servidor já esteja desligado
            }

            socket.Close();
        }

        private void pnlEnvio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstUsuarios_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();

            string nome = lstUsuarios.Items[e.Index].ToString();

            Brush corTexto = Brushes.Black;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                corTexto = Brushes.White;
            }

            e.Graphics.DrawString(
                nome,
                e.Font,
                corTexto,
                e.Bounds.Left + 3,
                e.Bounds.Top + 2
            );

            if (conversasNaoLidas.Contains(nome))
            {
                e.Graphics.DrawString(
                    "●",
                    e.Font,
                    Brushes.DarkGray,
                    e.Bounds.Right - 20,
                    e.Bounds.Top + 2
                );
            }

            e.DrawFocusRectangle();
        }
    }
}