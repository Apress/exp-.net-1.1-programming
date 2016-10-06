using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apress.ExpertDotNet.GreetMeVSNet
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class GreetingControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button btnShowFlag;
		private System.Windows.Forms.Label greeting;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GreetingControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GreetingControl));
			this.btnShowFlag = new System.Windows.Forms.Button();
			this.greeting = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnShowFlag
			// 
			this.btnShowFlag.AccessibleDescription = ((string)(resources.GetObject("btnShowFlag.AccessibleDescription")));
			this.btnShowFlag.AccessibleName = ((string)(resources.GetObject("btnShowFlag.AccessibleName")));
			this.btnShowFlag.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnShowFlag.Anchor")));
			this.btnShowFlag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowFlag.BackgroundImage")));
			this.btnShowFlag.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnShowFlag.Dock")));
			this.btnShowFlag.Enabled = ((bool)(resources.GetObject("btnShowFlag.Enabled")));
			this.btnShowFlag.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnShowFlag.FlatStyle")));
			this.btnShowFlag.Font = ((System.Drawing.Font)(resources.GetObject("btnShowFlag.Font")));
			this.btnShowFlag.Image = ((System.Drawing.Image)(resources.GetObject("btnShowFlag.Image")));
			this.btnShowFlag.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnShowFlag.ImageAlign")));
			this.btnShowFlag.ImageIndex = ((int)(resources.GetObject("btnShowFlag.ImageIndex")));
			this.btnShowFlag.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnShowFlag.ImeMode")));
			this.btnShowFlag.Location = ((System.Drawing.Point)(resources.GetObject("btnShowFlag.Location")));
			this.btnShowFlag.Name = "btnShowFlag";
			this.btnShowFlag.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnShowFlag.RightToLeft")));
			this.btnShowFlag.Size = ((System.Drawing.Size)(resources.GetObject("btnShowFlag.Size")));
			this.btnShowFlag.TabIndex = ((int)(resources.GetObject("btnShowFlag.TabIndex")));
			this.btnShowFlag.Text = resources.GetString("btnShowFlag.Text");
			this.btnShowFlag.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnShowFlag.TextAlign")));
			this.btnShowFlag.Visible = ((bool)(resources.GetObject("btnShowFlag.Visible")));
			this.btnShowFlag.Click += new System.EventHandler(this.btnShowFlag_Click);
			// 
			// greeting
			// 
			this.greeting.AccessibleDescription = ((string)(resources.GetObject("greeting.AccessibleDescription")));
			this.greeting.AccessibleName = ((string)(resources.GetObject("greeting.AccessibleName")));
			this.greeting.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("greeting.Anchor")));
			this.greeting.AutoSize = ((bool)(resources.GetObject("greeting.AutoSize")));
			this.greeting.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("greeting.Dock")));
			this.greeting.Enabled = ((bool)(resources.GetObject("greeting.Enabled")));
			this.greeting.Font = ((System.Drawing.Font)(resources.GetObject("greeting.Font")));
			this.greeting.Image = ((System.Drawing.Image)(resources.GetObject("greeting.Image")));
			this.greeting.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("greeting.ImageAlign")));
			this.greeting.ImageIndex = ((int)(resources.GetObject("greeting.ImageIndex")));
			this.greeting.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("greeting.ImeMode")));
			this.greeting.Location = ((System.Drawing.Point)(resources.GetObject("greeting.Location")));
			this.greeting.Name = "greeting";
			this.greeting.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("greeting.RightToLeft")));
			this.greeting.Size = ((System.Drawing.Size)(resources.GetObject("greeting.Size")));
			this.greeting.TabIndex = ((int)(resources.GetObject("greeting.TabIndex")));
			this.greeting.Text = resources.GetString("greeting.Text");
			this.greeting.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("greeting.TextAlign")));
			this.greeting.Visible = ((bool)(resources.GetObject("greeting.Visible")));
			// 
			// GreetingControl
			// 
			this.AccessibleDescription = ((string)(resources.GetObject("$this.AccessibleDescription")));
			this.AccessibleName = ((string)(resources.GetObject("$this.AccessibleName")));
			this.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("$this.Anchor")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.greeting,
																		  this.btnShowFlag});
			this.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("$this.Dock")));
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.Name = "GreetingControl";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			this.TabIndex = ((int)(resources.GetObject("$this.TabIndex")));
			this.Visible = ((bool)(resources.GetObject("$this.Visible")));
			this.ResumeLayout(false);

		}
		#endregion

		private void btnShowFlag_Click(object sender, System.EventArgs e)
		{
			FlagDlg dlg = new FlagDlg();
			dlg.ShowDialog();
		}
	}
}
