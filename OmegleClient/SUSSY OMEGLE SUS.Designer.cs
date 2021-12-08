namespace OmegleSus
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.txbIpAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txbMessage = new System.Windows.Forms.RichTextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboxHost = new System.Windows.Forms.CheckBox();
            this.chatDisplay = new System.Windows.Forms.RichTextBox();
            this.cboxYeetIndians = new System.Windows.Forms.CheckBox();
            this.btnOpenBrowser = new System.Windows.Forms.Button();
            this.txbInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.BackColor = System.Drawing.Color.Gray;
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Location = new System.Drawing.Point(375, 374);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(101, 64);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "SEND";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.BackColor = System.Drawing.Color.Gray;
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkip.Location = new System.Drawing.Point(702, 6);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(86, 52);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "SKIP";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(119, 38);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(149, 20);
            this.txbPort.TabIndex = 3;
            // 
            // txbIpAddress
            // 
            this.txbIpAddress.Location = new System.Drawing.Point(119, 12);
            this.txbIpAddress.Name = "txbIpAddress";
            this.txbIpAddress.Size = new System.Drawing.Size(149, 20);
            this.txbIpAddress.TabIndex = 4;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(12, 9);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(101, 24);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "IP Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(70, 33);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(43, 24);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port";
            // 
            // txbMessage
            // 
            this.txbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMessage.BackColor = System.Drawing.Color.Gray;
            this.txbMessage.Location = new System.Drawing.Point(8, 374);
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(371, 64);
            this.txbMessage.TabIndex = 7;
            this.txbMessage.Text = "";
            this.txbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMessage_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Gray;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(274, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(113, 46);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboxHost
            // 
            this.cboxHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxHost.AutoSize = true;
            this.cboxHost.BackColor = System.Drawing.Color.Gray;
            this.cboxHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHost.Location = new System.Drawing.Point(725, 64);
            this.cboxHost.Name = "cboxHost";
            this.cboxHost.Size = new System.Drawing.Size(62, 24);
            this.cboxHost.TabIndex = 9;
            this.cboxHost.Text = "Host";
            this.cboxHost.UseVisualStyleBackColor = false;
            this.cboxHost.CheckedChanged += new System.EventHandler(this.cboxHost_CheckedChanged);
            // 
            // chatDisplay
            // 
            this.chatDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.chatDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatDisplay.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.chatDisplay.Location = new System.Drawing.Point(8, 141);
            this.chatDisplay.Name = "chatDisplay";
            this.chatDisplay.ReadOnly = true;
            this.chatDisplay.Size = new System.Drawing.Size(468, 227);
            this.chatDisplay.TabIndex = 10;
            this.chatDisplay.Text = "";
            // 
            // cboxYeetIndians
            // 
            this.cboxYeetIndians.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxYeetIndians.AutoSize = true;
            this.cboxYeetIndians.BackColor = System.Drawing.Color.Gray;
            this.cboxYeetIndians.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxYeetIndians.Location = new System.Drawing.Point(663, 94);
            this.cboxYeetIndians.Name = "cboxYeetIndians";
            this.cboxYeetIndians.Size = new System.Drawing.Size(124, 24);
            this.cboxYeetIndians.TabIndex = 11;
            this.cboxYeetIndians.Text = "ANTI-INDIAN";
            this.cboxYeetIndians.UseVisualStyleBackColor = false;
            // 
            // btnOpenBrowser
            // 
            this.btnOpenBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenBrowser.BackColor = System.Drawing.Color.Gray;
            this.btnOpenBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenBrowser.Location = new System.Drawing.Point(663, 121);
            this.btnOpenBrowser.Name = "btnOpenBrowser";
            this.btnOpenBrowser.Size = new System.Drawing.Size(125, 65);
            this.btnOpenBrowser.TabIndex = 12;
            this.btnOpenBrowser.Text = "START SESSION";
            this.btnOpenBrowser.UseVisualStyleBackColor = false;
            this.btnOpenBrowser.Click += new System.EventHandler(this.btnOpenBrowser_Click);
            // 
            // txbInfo
            // 
            this.txbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.txbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbInfo.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbInfo.Location = new System.Drawing.Point(8, 68);
            this.txbInfo.Name = "txbInfo";
            this.txbInfo.Size = new System.Drawing.Size(468, 72);
            this.txbInfo.TabIndex = 13;
            this.txbInfo.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbInfo);
            this.Controls.Add(this.btnOpenBrowser);
            this.Controls.Add(this.cboxYeetIndians);
            this.Controls.Add(this.chatDisplay);
            this.Controls.Add(this.cboxHost);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txbIpAddress);
            this.Controls.Add(this.txbPort);
            this.Controls.Add(this.btnSkip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Main";
            this.Text = "SUSSY OMEGLE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.TextBox txbIpAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.RichTextBox txbMessage;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox cboxHost;
        private System.Windows.Forms.RichTextBox chatDisplay;
        private System.Windows.Forms.CheckBox cboxYeetIndians;
        private System.Windows.Forms.Button btnOpenBrowser;
        private System.Windows.Forms.RichTextBox txbInfo;
    }
}

