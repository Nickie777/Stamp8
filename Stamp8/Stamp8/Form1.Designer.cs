namespace Stamp8
{
    partial class Form1
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pdfViewer1 = new PdfiumViewer.PdfViewer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.установитьПечатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимРедактированияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимПросмотраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.служебныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заполнитьКнопкиПечатейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.radioButtonChangeSize = new System.Windows.Forms.RadioButton();
            this.labelCurrentImage = new System.Windows.Forms.Label();
            this.trackBarChange = new System.Windows.Forms.TrackBar();
            this.labelCurrentPage = new System.Windows.Forms.Label();
            this.numericUpDownCurrentPage = new System.Windows.Forms.NumericUpDown();
            this.textBoxEditMode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxChangeObject = new System.Windows.Forms.ComboBox();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentPage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1015, 450);
            this.panelMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pdfViewer1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 450);
            this.splitContainer1.SplitterDistance = 671;
            this.splitContainer1.TabIndex = 0;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 24);
            this.pdfViewer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(671, 426);
            this.pdfViewer1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem,
            this.служебныеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.установитьПечатиToolStripMenuItem,
            this.режимРедактированияToolStripMenuItem,
            this.режимПросмотраToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // установитьПечатиToolStripMenuItem
            // 
            this.установитьПечатиToolStripMenuItem.Name = "установитьПечатиToolStripMenuItem";
            this.установитьПечатиToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.установитьПечатиToolStripMenuItem.Text = "Установить печати";
            this.установитьПечатиToolStripMenuItem.Click += new System.EventHandler(this.установитьПечатиToolStripMenuItem_Click);
            // 
            // режимРедактированияToolStripMenuItem
            // 
            this.режимРедактированияToolStripMenuItem.Name = "режимРедактированияToolStripMenuItem";
            this.режимРедактированияToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.режимРедактированияToolStripMenuItem.Text = "Режим редактирования";
            this.режимРедактированияToolStripMenuItem.Click += new System.EventHandler(this.режимРедактированияToolStripMenuItem_Click);
            // 
            // режимПросмотраToolStripMenuItem
            // 
            this.режимПросмотраToolStripMenuItem.Name = "режимПросмотраToolStripMenuItem";
            this.режимПросмотраToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.режимПросмотраToolStripMenuItem.Text = "Режим просмотра";
            this.режимПросмотраToolStripMenuItem.Click += new System.EventHandler(this.режимПросмотраToolStripMenuItem_Click);
            // 
            // служебныеToolStripMenuItem
            // 
            this.служебныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заполнитьКнопкиПечатейToolStripMenuItem,
            this.тестToolStripMenuItem});
            this.служебныеToolStripMenuItem.Name = "служебныеToolStripMenuItem";
            this.служебныеToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.служебныеToolStripMenuItem.Text = "Служебные";
            // 
            // заполнитьКнопкиПечатейToolStripMenuItem
            // 
            this.заполнитьКнопкиПечатейToolStripMenuItem.Name = "заполнитьКнопкиПечатейToolStripMenuItem";
            this.заполнитьКнопкиПечатейToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.заполнитьКнопкиПечатейToolStripMenuItem.Text = "Заполнить кнопки печатей";
            this.заполнитьКнопкиПечатейToolStripMenuItem.Click += new System.EventHandler(this.заполнитьКнопкиПечатейToolStripMenuItem_Click);
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            this.тестToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.тестToolStripMenuItem.Text = "Тест";
            this.тестToolStripMenuItem.Click += new System.EventHandler(this.тестToolStripMenuItem_ClickAsync);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxChangeObject);
            this.splitContainer2.Panel1.Controls.Add(this.radioButtonChangeSize);
            this.splitContainer2.Panel1.Controls.Add(this.labelCurrentImage);
            this.splitContainer2.Panel1.Controls.Add(this.trackBarChange);
            this.splitContainer2.Panel1.Controls.Add(this.labelCurrentPage);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownCurrentPage);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxEditMode);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(340, 450);
            this.splitContainer2.SplitterDistance = 163;
            this.splitContainer2.TabIndex = 0;
            // 
            // radioButtonChangeSize
            // 
            this.radioButtonChangeSize.AutoSize = true;
            this.radioButtonChangeSize.Location = new System.Drawing.Point(174, 38);
            this.radioButtonChangeSize.Name = "radioButtonChangeSize";
            this.radioButtonChangeSize.Size = new System.Drawing.Size(122, 19);
            this.radioButtonChangeSize.TabIndex = 7;
            this.radioButtonChangeSize.TabStop = true;
            this.radioButtonChangeSize.Text = "Изменить размер";
            this.radioButtonChangeSize.UseVisualStyleBackColor = true;
            this.radioButtonChangeSize.CheckedChanged += new System.EventHandler(this.radioButtonChangeSize_CheckedChanged);
            // 
            // labelCurrentImage
            // 
            this.labelCurrentImage.AutoSize = true;
            this.labelCurrentImage.Location = new System.Drawing.Point(3, 74);
            this.labelCurrentImage.Name = "labelCurrentImage";
            this.labelCurrentImage.Size = new System.Drawing.Size(107, 15);
            this.labelCurrentImage.TabIndex = 4;
            this.labelCurrentImage.Text = "Текущая картинка";
            // 
            // trackBarChange
            // 
            this.trackBarChange.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarChange.Location = new System.Drawing.Point(0, 118);
            this.trackBarChange.Maximum = 100;
            this.trackBarChange.Name = "trackBarChange";
            this.trackBarChange.Size = new System.Drawing.Size(340, 45);
            this.trackBarChange.TabIndex = 3;
            this.trackBarChange.Scroll += new System.EventHandler(this.trackBarChange_Scroll);
            // 
            // labelCurrentPage
            // 
            this.labelCurrentPage.AutoSize = true;
            this.labelCurrentPage.Location = new System.Drawing.Point(3, 38);
            this.labelCurrentPage.Name = "labelCurrentPage";
            this.labelCurrentPage.Size = new System.Drawing.Size(108, 15);
            this.labelCurrentPage.TabIndex = 2;
            this.labelCurrentPage.Text = "Текущая страница";
            // 
            // numericUpDownCurrentPage
            // 
            this.numericUpDownCurrentPage.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.numericUpDownCurrentPage.Location = new System.Drawing.Point(117, 38);
            this.numericUpDownCurrentPage.Name = "numericUpDownCurrentPage";
            this.numericUpDownCurrentPage.Size = new System.Drawing.Size(41, 23);
            this.numericUpDownCurrentPage.TabIndex = 1;
            this.numericUpDownCurrentPage.Tag = "";
            this.numericUpDownCurrentPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCurrentPage.ValueChanged += new System.EventHandler(this.numericUpDownCurrentPage_ValueChanged);
            // 
            // textBoxEditMode
            // 
            this.textBoxEditMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxEditMode.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxEditMode.Location = new System.Drawing.Point(0, 0);
            this.textBoxEditMode.Name = "textBoxEditMode";
            this.textBoxEditMode.Size = new System.Drawing.Size(340, 35);
            this.textBoxEditMode.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 283);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(340, 283);
            this.splitContainer3.SplitterDistance = 97;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основная печать";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(334, 75);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Size = new System.Drawing.Size(340, 182);
            this.splitContainer4.SplitterDistance = 91;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Печать без подписи";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 69);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 87);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Подпись";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(334, 65);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // comboBoxChangeObject
            // 
            this.comboBoxChangeObject.FormattingEnabled = true;
            this.comboBoxChangeObject.Items.AddRange(new object[] {
            "Печать",
            "Подпись"});
            this.comboBoxChangeObject.Location = new System.Drawing.Point(117, 71);
            this.comboBoxChangeObject.Name = "comboBoxChangeObject";
            this.comboBoxChangeObject.Size = new System.Drawing.Size(121, 23);
            this.comboBoxChangeObject.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "Form1";
            this.Text = "Установщик факсимиле / печати Вастэко";
            this.panelMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentPage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMain;
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem установитьПечатиToolStripMenuItem;
        private SplitContainer splitContainer2;
        private ToolStripMenuItem служебныеToolStripMenuItem;
        private ToolStripMenuItem заполнитьКнопкиПечатейToolStripMenuItem;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private ToolStripMenuItem тестToolStripMenuItem;
        private PdfiumViewer.PdfViewer pdfViewer1;
        private ToolStripMenuItem режимРедактированияToolStripMenuItem;
        private TextBox textBoxEditMode;
        private NumericUpDown numericUpDownCurrentPage;
        private Label labelCurrentPage;
        private TrackBar trackBarChange;
        private Label labelCurrentImage;
        private ToolStripMenuItem режимПросмотраToolStripMenuItem;
        private RadioButton radioButtonChangeSize;
        private ComboBox comboBoxChangeObject;
    }
}