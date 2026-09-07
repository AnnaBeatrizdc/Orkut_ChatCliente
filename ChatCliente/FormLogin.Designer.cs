namespace ChatCliente
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            txtNome = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lblDescricao = new Label();
            btnEntra = new ReaLTaiizor.Controls.HopeButton();
            lblStatus = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.AnimateReadOnly = false;
            txtNome.AutoCompleteMode = AutoCompleteMode.None;
            txtNome.AutoCompleteSource = AutoCompleteSource.None;
            txtNome.BackgroundImageLayout = ImageLayout.None;
            txtNome.CharacterCasing = CharacterCasing.Normal;
            txtNome.Depth = 0;
            txtNome.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNome.HideSelection = true;
            txtNome.Hint = "Digite seu nome.";
            txtNome.LeadingIcon = null;
            txtNome.Location = new Point(162, 239);
            txtNome.MaxLength = 32767;
            txtNome.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtNome.Name = "txtNome";
            txtNome.PasswordChar = '\0';
            txtNome.PrefixSuffixText = null;
            txtNome.ReadOnly = false;
            txtNome.RightToLeft = RightToLeft.No;
            txtNome.SelectedText = "";
            txtNome.SelectionLength = 0;
            txtNome.SelectionStart = 0;
            txtNome.ShortcutsEnabled = true;
            txtNome.Size = new Size(330, 48);
            txtNome.TabIndex = 2;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // lblDescricao
            // 
            lblDescricao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescricao.ForeColor = Color.FromArgb(107, 114, 128);
            lblDescricao.Location = new Point(162, 168);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(330, 55);
            lblDescricao.TabIndex = 5;
            lblDescricao.Text = "Conecte-se e converse com seus amigos";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEntra
            // 
            btnEntra.BorderColor = Color.FromArgb(220, 223, 230);
            btnEntra.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnEntra.Cursor = Cursors.Hand;
            btnEntra.DangerColor = Color.FromArgb(245, 108, 108);
            btnEntra.DefaultColor = Color.FromArgb(255, 255, 255);
            btnEntra.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntra.ForeColor = Color.White;
            btnEntra.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnEntra.InfoColor = Color.FromArgb(144, 147, 153);
            btnEntra.Location = new Point(210, 319);
            btnEntra.Name = "btnEntra";
            btnEntra.PrimaryColor = Color.FromArgb(233, 30, 140);
            btnEntra.Size = new Size(230, 48);
            btnEntra.SuccessColor = Color.FromArgb(103, 194, 58);
            btnEntra.TabIndex = 8;
            btnEntra.Text = "ENTRAR";
            btnEntra.TextColor = Color.White;
            btnEntra.WarningColor = Color.FromArgb(230, 162, 60);
            btnEntra.Click += btnEntra_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
            lblStatus.Location = new Point(264, 401);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(112, 17);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "●  Servidor online";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._3;
            pictureBox2.Location = new Point(200, -23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(245, 229);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 251);
            ClientSize = new Size(671, 461);
            Controls.Add(lblStatus);
            Controls.Add(btnEntra);
            Controls.Add(lblDescricao);
            Controls.Add(txtNome);
            Controls.Add(pictureBox2);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Orkut | Login";
            Shown += FormLogin_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtNome;
        private ReaLTaiizor.Controls.MaterialButton btnEntrar;
        private Label lblDescricao;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
        private ReaLTaiizor.Controls.HopeButton btnEntra;
        private Label lblStatus;
        private PictureBox pictureBox2;
    }
}