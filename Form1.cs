/// <Copyright>
/// 
///  Пример визуализации в виде дерева иерархии XML-файла
/// 
///                (c)2005 WondeRu 
///  
///   http://www.wonderu.com
///   e-mail: wonderu@mail.ru
///   
/// </Copyright>

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;

namespace XML
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(376, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Open";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(360, 416);
			this.treeView1.TabIndex = 1;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "XML|*.xml|All files|*.*";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 422);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "XML Visualization";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		/// <summary>
		/// Рекурсивное построение дерева
		/// </summary>
		private void build(XmlNode xx, TreeNode tt)
		{
			tt.ForeColor = Color.Blue;
			//Атрибуты
			if (xx.Attributes != null)
				for(int i=0;i < xx.Attributes.Count; i++)
				{
					TreeNode tn = tt.Nodes.Add(xx.Attributes[i].LocalName + '=' + xx.Attributes[i].Value);
					tn.ForeColor = Color.CadetBlue;
				}

            //Дочерние узлы
			foreach(XmlNode x1 in xx.ChildNodes)
			{
				build(x1, tt.Nodes.Add(x1.LocalName));
			};
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				treeView1.Nodes.Clear();
				try
				{
					XmlDocument xmldoc = new XmlDocument();
					xmldoc.Load(openFileDialog1.FileName);
					//Построение дерева
					build(xmldoc, treeView1.Nodes.Add(openFileDialog1.FileName));
				}
				catch(Exception e1)
				{
					MessageBox.Show(e1.ToString());
				};
			};

		}

	}
}
