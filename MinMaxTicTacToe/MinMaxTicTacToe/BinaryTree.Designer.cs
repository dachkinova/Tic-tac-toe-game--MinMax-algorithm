namespace MinMaxTicTacToe
{
    partial class BinaryTree
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
            this.BinaryTreePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BinaryTreePanel
            // 
            this.BinaryTreePanel.Location = new System.Drawing.Point(4, 5);
            this.BinaryTreePanel.Name = "BinaryTreePanel";
            this.BinaryTreePanel.Size = new System.Drawing.Size(1000, 800);
            this.BinaryTreePanel.TabIndex = 0;
            this.BinaryTreePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BinaryTreePanel_Paint);
            // 
            // BinaryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 803);
            this.Controls.Add(this.BinaryTreePanel);
            this.Name = "BinaryTree";
            this.Text = "BinaryTree";
            this.Load += new System.EventHandler(this.BinaryTree_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BinaryTree_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BinaryTreePanel;
    }
}