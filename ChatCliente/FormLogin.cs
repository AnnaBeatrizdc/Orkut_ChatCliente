using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatCliente
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            //Fundo
            this.BackColor = Color.FromArgb(247, 247, 251);
        }

        private bool VerificarServidor()
        {
            try
            {
                using (Socket socketTeste = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Dgram,
                    ProtocolType.Udp))
                {
                    socketTeste.ReceiveTimeout = 1000;

                    IPEndPoint servidor = new IPEndPoint(
                        IPAddress.Parse("192.168.0.9"),
                        9060
                    );

                    byte[] dados = Encoding.UTF8.GetBytes("PING");

                    socketTeste.SendTo(dados, servidor);

                    byte[] resposta = new byte[1024];

                    EndPoint origem = new IPEndPoint(IPAddress.Any, 0);

                    int quantidade = socketTeste.ReceiveFrom(
                        resposta,
                        ref origem
                    );

                    string mensagem = Encoding.UTF8.GetString(
                        resposta,
                        0,
                        quantidade
                    );

                    return mensagem == "PONG";
                }
            }
            catch
            {
                return false;
            }
        }

        private bool NomeDisponivel(string nome)
        {
            try
            {
                using (Socket socket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Dgram,
                    ProtocolType.Udp))
                {
                    socket.ReceiveTimeout = 1500;

                    IPEndPoint servidor = new IPEndPoint(
                        IPAddress.Parse("192.168.0.9"),
                        9060
                    );

                    string mensagem =
                        "VERIFICAR_NOME|" + nome;

                    byte[] dados =
                        Encoding.UTF8.GetBytes(mensagem);

                    socket.SendTo(
                        dados,
                        servidor
                    );

                    byte[] resposta = new byte[1024];

                    EndPoint remetente =
                        new IPEndPoint(
                            IPAddress.Any,
                            0
                        );

                    int quantidade =
                        socket.ReceiveFrom(
                            resposta,
                            ref remetente
                        );

                    string resultado =
                        Encoding.UTF8.GetString(
                            resposta,
                            0,
                            quantidade
                        );

                    return resultado ==
                        "NOME_DISPONIVEL";
                }
            }
            catch
            {
                MessageBox.Show(
                    "Não foi possível verificar o nome. Verifique se o servidor está online.",
                    "Erro de conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            string nome =
        txtLogin.Text.Trim();

            if (nome == "")
            {
                MessageBox.Show(
                    "Digite seu nome."
                );

                return;
            }

            if (!NomeDisponivel(nome))
            {
                MessageBox.Show(
                    "Esse nome já está sendo usado.\nEscolha outro nome.",
                    "Nome indisponível",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLogin.Focus();
                txtLogin.SelectAll();

                return;
            }

            FormChat chat =
                new FormChat(nome);

            chat.Show();

            this.Hide();
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            if (VerificarServidor())
            {
                lblStatus.Text = "● Servidor Online";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "● Servidor Offline";
                lblStatus.ForeColor = Color.Gray;
            }
        }
    }
}
