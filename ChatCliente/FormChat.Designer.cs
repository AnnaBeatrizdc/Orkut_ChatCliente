namespace ChatCliente
{
    partial class FormChat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            lstUsuarios = new ListBox();
            btnEnvia = new ReaLTaiizor.Controls.HopeButton();
            pnlTopo = new Panel();
            pictureBox1 = new PictureBox();
            lblStatusConversa = new Label();
            lblUsuarioConversa = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            pnlLateral = new Panel();
            label1 = new Label();
            lblStatus = new Label();
            lblNomeUsuario = new Label();
            pictureBox2 = new PictureBox();
            pnlEnvio = new Panel();
            txtMensagens = new ReaLTaiizor.Controls.HopeTextBox();
            pnlMensagens = new FlowLayoutPanel();
            pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            pnlLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlEnvio.SuspendLayout();
            SuspendLayout();
            // 
            // lstUsuarios
            // 
            lstUsuarios.BackColor = Color.FromArgb(252, 240, 248);
            lstUsuarios.BorderStyle = BorderStyle.None;
            lstUsuarios.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstUsuarios.ForeColor = Color.FromArgb(31, 41, 55);
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.ItemHeight = 20;
            lstUsuarios.Location = new Point(5, 291);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.Size = new Size(230, 220);
            lstUsuarios.TabIndex = 8;
            lstUsuarios.SelectedIndexChanged += lstUsuarios_SelectedIndexChanged;
            // 
            // btnEnvia
            // 
            btnEnvia.BorderColor = Color.FromArgb(220, 223, 230);
            btnEnvia.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnEnvia.Cursor = Cursors.Hand;
            btnEnvia.DangerColor = Color.FromArgb(245, 108, 108);
            btnEnvia.DefaultColor = Color.FromArgb(255, 255, 255);
            btnEnvia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnvia.ForeColor = Color.White;
            btnEnvia.HoverTextColor = Color.FromArgb(214, 24, 126);
            btnEnvia.InfoColor = Color.FromArgb(144, 147, 153);
            btnEnvia.Location = new Point(401, 20);
            btnEnvia.Name = "btnEnvia";
            btnEnvia.PrimaryColor = Color.FromArgb(233, 30, 140);
            btnEnvia.Size = new Size(110, 48);
            btnEnvia.SuccessColor = Color.FromArgb(103, 194, 58);
            btnEnvia.TabIndex = 9;
            btnEnvia.Text = "ENVIAR";
            btnEnvia.TextColor = Color.White;
            btnEnvia.WarningColor = Color.FromArgb(230, 162, 60);
            btnEnvia.Click += btnEnvia_Click;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.White;
            pnlTopo.Controls.Add(pictureBox1);
            pnlTopo.Controls.Add(lblStatusConversa);
            pnlTopo.Controls.Add(lblUsuarioConversa);
            pnlTopo.Location = new Point(245, -4);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(532, 65);
            pnlTopo.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._21;
            pictureBox1.Location = new Point(10, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // lblStatusConversa
            // 
            lblStatusConversa.AutoSize = true;
            lblStatusConversa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusConversa.ForeColor = Color.Gray;
            lblStatusConversa.Location = new Point(77, 38);
            lblStatusConversa.Name = "lblStatusConversa";
            lblStatusConversa.Size = new Size(71, 21);
            lblStatusConversa.TabIndex = 14;
            lblStatusConversa.Text = "● Offline";
            // 
            // lblUsuarioConversa
            // 
            lblUsuarioConversa.AutoSize = true;
            lblUsuarioConversa.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuarioConversa.ForeColor = Color.FromArgb(31, 41, 55);
            lblUsuarioConversa.Location = new Point(77, 13);
            lblUsuarioConversa.Name = "lblUsuarioConversa";
            lblUsuarioConversa.Size = new Size(217, 25);
            lblUsuarioConversa.TabIndex = 14;
            lblUsuarioConversa.Text = "Selecione um usuario...";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(229, 231, 235);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(245, -16);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 634);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(229, 231, 235);
            panel2.Location = new Point(0, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(755, 23);
            panel2.TabIndex = 14;
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.FromArgb(252, 240, 248);
            pnlLateral.Controls.Add(panel1);
            pnlLateral.Controls.Add(label1);
            pnlLateral.Controls.Add(lblStatus);
            pnlLateral.Controls.Add(lblNomeUsuario);
            pnlLateral.Controls.Add(lstUsuarios);
            pnlLateral.Controls.Add(pictureBox2);
            pnlLateral.Location = new Point(0, -1);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(242, 522);
            pnlLateral.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(107, 114, 128);
            label1.Location = new Point(53, 245);
            label1.Name = "label1";
            label1.Size = new Size(137, 21);
            label1.TabIndex = 12;
            label1.Text = "AMIGOS ONLINE";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
            lblStatus.Location = new Point(81, 211);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(84, 25);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "● Online";
            // 
            // lblNomeUsuario
            // 
            lblNomeUsuario.AutoSize = true;
            lblNomeUsuario.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeUsuario.ForeColor = Color.FromArgb(31, 41, 55);
            lblNomeUsuario.Location = new Point(78, 181);
            lblNomeUsuario.Name = "lblNomeUsuario";
            lblNomeUsuario.Size = new Size(88, 30);
            lblNomeUsuario.TabIndex = 10;
            lblNomeUsuario.Text = "Usuario";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._3;
            pictureBox2.Location = new Point(7, -32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(235, 259);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // pnlEnvio
            // 
            pnlEnvio.BackColor = Color.White;
            pnlEnvio.Controls.Add(txtMensagens);
            pnlEnvio.Controls.Add(btnEnvia);
            pnlEnvio.Location = new Point(245, 438);
            pnlEnvio.Name = "pnlEnvio";
            pnlEnvio.Size = new Size(532, 83);
            pnlEnvio.TabIndex = 12;
            pnlEnvio.Paint += pnlEnvio_Paint;
            // 
            // txtMensagens
            // 
            txtMensagens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMensagens.BackColor = Color.White;
            txtMensagens.BaseColor = Color.LavenderBlush;
            txtMensagens.BorderColorA = Color.FromArgb(233, 30, 140);
            txtMensagens.BorderColorB = Color.FromArgb(220, 220, 230);
            txtMensagens.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMensagens.ForeColor = Color.FromArgb(48, 49, 51);
            txtMensagens.Hint = "Digite uma mensagem...   ";
            txtMensagens.Location = new Point(20, 20);
            txtMensagens.MaxLength = 32767;
            txtMensagens.Multiline = true;
            txtMensagens.Name = "txtMensagens";
            txtMensagens.PasswordChar = '\0';
            txtMensagens.ScrollBars = ScrollBars.None;
            txtMensagens.SelectedText = "";
            txtMensagens.SelectionLength = 0;
            txtMensagens.SelectionStart = 0;
            txtMensagens.Size = new Size(356, 48);
            txtMensagens.TabIndex = 10;
            txtMensagens.TabStop = false;
            txtMensagens.UseSystemPasswordChar = false;
            // 
            // pnlMensagens
            // 
            pnlMensagens.AutoScroll = true;
            pnlMensagens.FlowDirection = FlowDirection.TopDown;
            pnlMensagens.Location = new Point(248, 67);
            pnlMensagens.Name = "pnlMensagens";
            pnlMensagens.Size = new Size(529, 365);
            pnlMensagens.TabIndex = 13;
            pnlMensagens.WrapContents = false;
            // 
            // FormChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 251);
            ClientSize = new Size(775, 517);
            Controls.Add(pnlMensagens);
            Controls.Add(pnlEnvio);
            Controls.Add(pnlTopo);
            Controls.Add(pnlLateral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Orkut | Inicio";
            FormClosing += FormChat_FormClosing;
            Shown += FormChat_Shown;
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            pnlLateral.ResumeLayout(false);
            pnlLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlEnvio.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private TextBox txtMensagem;
        private ListBox lstUsuarios;
        private ReaLTaiizor.Controls.HopeButton btnEnvia;
        private Panel pnlTopo;
        private Panel pnlLateral;
        private Panel pnlEnvio;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
        private ReaLTaiizor.Controls.HopeTextBox txtMensagens;
        private Label lblNomeUsuario;
        private Label label1;
        private Label lblStatus;
        private Panel panel1;
        private Panel panel2;
        private FlowLayoutPanel pnlMensagens;
        private Label lblStatusConversa;
        private Label lblUsuarioConversa;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}