
namespace MediaTekDocuments.view
{
    partial class FrmModifCmdLivre
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
            this.txbModifNumeroCommandeLivre = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.txbModifNbExemplairesCommandeLivre = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.txbModifMontantCommandeLivre = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.dtpModifDateCommandeLivre = new System.Windows.Forms.DateTimePicker();
            this.label63 = new System.Windows.Forms.Label();
            this.btnValidationModifCommande = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboModifEtapeSuiviCommandeLivre = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txbModifNumeroCommandeLivre
            // 
            this.txbModifNumeroCommandeLivre.Location = new System.Drawing.Point(166, 17);
            this.txbModifNumeroCommandeLivre.Name = "txbModifNumeroCommandeLivre";
            this.txbModifNumeroCommandeLivre.Size = new System.Drawing.Size(100, 20);
            this.txbModifNumeroCommandeLivre.TabIndex = 68;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(22, 20);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(108, 13);
            this.label76.TabIndex = 67;
            this.label76.Text = "Numéro du livre : ";
            // 
            // txbModifNbExemplairesCommandeLivre
            // 
            this.txbModifNbExemplairesCommandeLivre.Location = new System.Drawing.Point(166, 70);
            this.txbModifNbExemplairesCommandeLivre.Name = "txbModifNbExemplairesCommandeLivre";
            this.txbModifNbExemplairesCommandeLivre.Size = new System.Drawing.Size(100, 20);
            this.txbModifNbExemplairesCommandeLivre.TabIndex = 66;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(22, 45);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(61, 13);
            this.label61.TabIndex = 65;
            this.label61.Text = "Montant :";
            // 
            // txbModifMontantCommandeLivre
            // 
            this.txbModifMontantCommandeLivre.Location = new System.Drawing.Point(166, 44);
            this.txbModifMontantCommandeLivre.Name = "txbModifMontantCommandeLivre";
            this.txbModifMontantCommandeLivre.Size = new System.Drawing.Size(100, 20);
            this.txbModifMontantCommandeLivre.TabIndex = 64;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(22, 99);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(124, 13);
            this.label62.TabIndex = 63;
            this.label62.Text = "Date de commande :";
            // 
            // dtpModifDateCommandeLivre
            // 
            this.dtpModifDateCommandeLivre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifDateCommandeLivre.Location = new System.Drawing.Point(166, 97);
            this.dtpModifDateCommandeLivre.Name = "dtpModifDateCommandeLivre";
            this.dtpModifDateCommandeLivre.Size = new System.Drawing.Size(100, 20);
            this.dtpModifDateCommandeLivre.TabIndex = 62;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(22, 73);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(138, 13);
            this.label63.TabIndex = 61;
            this.label63.Text = "Nombre d\'exemplaires :";
            // 
            // btnValidationModifCommande
            // 
            this.btnValidationModifCommande.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidationModifCommande.Location = new System.Drawing.Point(105, 159);
            this.btnValidationModifCommande.Name = "btnValidationModifCommande";
            this.btnValidationModifCommande.Size = new System.Drawing.Size(75, 23);
            this.btnValidationModifCommande.TabIndex = 69;
            this.btnValidationModifCommande.Text = "Modifier";
            this.btnValidationModifCommande.UseVisualStyleBackColor = true;
            this.btnValidationModifCommande.Click += new System.EventHandler(this.btnValidationModifCommande_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Etape de suivi :";
            // 
            // cboModifEtapeSuiviCommandeLivre
            // 
            this.cboModifEtapeSuiviCommandeLivre.FormattingEnabled = true;
            this.cboModifEtapeSuiviCommandeLivre.Location = new System.Drawing.Point(166, 121);
            this.cboModifEtapeSuiviCommandeLivre.Name = "cboModifEtapeSuiviCommandeLivre";
            this.cboModifEtapeSuiviCommandeLivre.Size = new System.Drawing.Size(100, 21);
            this.cboModifEtapeSuiviCommandeLivre.TabIndex = 71;
            // 
            // FrmModifCmdLivre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 198);
            this.Controls.Add(this.cboModifEtapeSuiviCommandeLivre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnValidationModifCommande);
            this.Controls.Add(this.txbModifNumeroCommandeLivre);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.txbModifNbExemplairesCommandeLivre);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.txbModifMontantCommandeLivre);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.dtpModifDateCommandeLivre);
            this.Controls.Add(this.label63);
            this.Name = "FrmModifCmdLivre";
            this.Text = "Modification de la commande";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbModifNumeroCommandeLivre;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox txbModifNbExemplairesCommandeLivre;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox txbModifMontantCommandeLivre;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.DateTimePicker dtpModifDateCommandeLivre;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Button btnValidationModifCommande;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboModifEtapeSuiviCommandeLivre;
    }
}