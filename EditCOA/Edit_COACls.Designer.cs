namespace EditCOA
{
    partial class Edit_COACls
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



        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenDoc = new Telerik.WinControls.UI.RadButton();
            this.lblPdfPath = new System.Windows.Forms.Label();
            this.btnOpenPdf = new Telerik.WinControls.UI.RadButton();
            this.lblWordPath = new System.Windows.Forms.Label();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOpenDoc.Location = new System.Drawing.Point(61, 36);
            this.btnOpenDoc.Name = "btnOpenDoc";
            // 
            // 
            // 
            this.btnOpenDoc.RootElement.AccessibleDescription = null;
            this.btnOpenDoc.RootElement.AccessibleName = null;
            this.btnOpenDoc.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 110, 24);
            this.btnOpenDoc.Size = new System.Drawing.Size(81, 85);
            this.btnOpenDoc.TabIndex = 0;
            this.btnOpenDoc.Text = "פתח מסמך";
            this.btnOpenDoc.Click += new System.EventHandler(this.OpenDoc_Click);
            // 
            // lblPdfPath
            // 
            this.lblPdfPath.AutoSize = true;
            this.lblPdfPath.Location = new System.Drawing.Point(163, 280);
            this.lblPdfPath.Name = "lblPdfPath";
            this.lblPdfPath.Size = new System.Drawing.Size(0, 13);
            this.lblPdfPath.TabIndex = 1;
            // 
            // btnOpenPdf
            // 
            this.btnOpenPdf.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOpenPdf.Location = new System.Drawing.Point(61, 179);
            this.btnOpenPdf.Name = "btnOpenPdf";
            // 
            // 
            // 
            this.btnOpenPdf.RootElement.AccessibleDescription = null;
            this.btnOpenPdf.RootElement.AccessibleName = null;
            this.btnOpenPdf.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 110, 24);
            this.btnOpenPdf.Size = new System.Drawing.Size(81, 85);
            this.btnOpenPdf.TabIndex = 2;
            this.btnOpenPdf.Text = "פתח מסמך";
            this.btnOpenPdf.Click += new System.EventHandler(this.btnOpenPdf_Click);
            // 
            // lblWordPath
            // 
            this.lblWordPath.AutoSize = true;
            this.lblWordPath.Location = new System.Drawing.Point(163, 139);
            this.lblWordPath.Name = "lblWordPath";
            this.lblWordPath.Size = new System.Drawing.Size(0, 13);
            this.lblWordPath.TabIndex = 3;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = true;
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Location = new System.Drawing.Point(61, 280);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.AccessibleDescription = null;
            this.radLabel1.RootElement.AccessibleName = null;
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel1.Size = new System.Drawing.Size(26, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "PDF";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = true;
            this.radLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel2.Location = new System.Drawing.Point(61, 134);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.AccessibleDescription = null;
            this.radLabel2.RootElement.AccessibleName = null;
            this.radLabel2.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel2.Size = new System.Drawing.Size(40, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "WORD";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // Edit_COACls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.lblWordPath);
            this.Controls.Add(this.btnOpenPdf);
            this.Controls.Add(this.lblPdfPath);
            this.Controls.Add(this.btnOpenDoc);
            this.Name = "Edit_COACls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(301, 319);
            this.Load += new System.EventHandler(this.Edit_COACls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Telerik.WinControls.UI.RadButton btnOpenDoc;
        private System.Windows.Forms.Label lblPdfPath;
        private Telerik.WinControls.UI.RadButton btnOpenPdf;
        private System.Windows.Forms.Label lblWordPath;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}