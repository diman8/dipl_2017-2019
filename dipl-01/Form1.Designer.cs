namespace dipl_01
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.buttonEval = new System.Windows.Forms.Button();
            this.buttonLoadProblem = new System.Windows.Forms.Button();
            this.buttonCross = new System.Windows.Forms.Button();
            this.buttonMutate = new System.Windows.Forms.Button();
            this.buttonHC = new System.Windows.Forms.Button();
            this.buttonInitList = new System.Windows.Forms.Button();
            this.groupManualControl = new System.Windows.Forms.GroupBox();
            this.buttonInitAlg = new System.Windows.Forms.Button();
            this.buttonAutoCalculate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonGetAll = new System.Windows.Forms.RadioButton();
            this.radioButtonGetBest = new System.Windows.Forms.RadioButton();
            this.radioButtonGetFirst = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupManualControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            resources.ApplyResources(this.logBox, "logBox");
            this.logBox.Name = "logBox";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // buttonEval
            // 
            resources.ApplyResources(this.buttonEval, "buttonEval");
            this.buttonEval.Name = "buttonEval";
            this.buttonEval.UseVisualStyleBackColor = true;
            this.buttonEval.Click += new System.EventHandler(this.buttonEval_Click);
            // 
            // buttonLoadProblem
            // 
            resources.ApplyResources(this.buttonLoadProblem, "buttonLoadProblem");
            this.buttonLoadProblem.Name = "buttonLoadProblem";
            this.buttonLoadProblem.UseVisualStyleBackColor = true;
            this.buttonLoadProblem.Click += new System.EventHandler(this.buttonLoadProblem_Click);
            // 
            // buttonCross
            // 
            resources.ApplyResources(this.buttonCross, "buttonCross");
            this.buttonCross.Name = "buttonCross";
            this.buttonCross.UseVisualStyleBackColor = true;
            this.buttonCross.Click += new System.EventHandler(this.buttonCross_Click);
            // 
            // buttonMutate
            // 
            resources.ApplyResources(this.buttonMutate, "buttonMutate");
            this.buttonMutate.Name = "buttonMutate";
            this.buttonMutate.UseVisualStyleBackColor = true;
            this.buttonMutate.Click += new System.EventHandler(this.buttonMutate_Click);
            // 
            // buttonHC
            // 
            resources.ApplyResources(this.buttonHC, "buttonHC");
            this.buttonHC.Name = "buttonHC";
            this.buttonHC.UseVisualStyleBackColor = true;
            this.buttonHC.Click += new System.EventHandler(this.buttonHC_Click);
            // 
            // buttonInitList
            // 
            resources.ApplyResources(this.buttonInitList, "buttonInitList");
            this.buttonInitList.Name = "buttonInitList";
            this.buttonInitList.UseVisualStyleBackColor = true;
            this.buttonInitList.Click += new System.EventHandler(this.buttonInitList_Click);
            // 
            // groupManualControl
            // 
            this.groupManualControl.Controls.Add(this.buttonInitAlg);
            this.groupManualControl.Controls.Add(this.buttonInitList);
            this.groupManualControl.Controls.Add(this.buttonCross);
            this.groupManualControl.Controls.Add(this.buttonEval);
            this.groupManualControl.Controls.Add(this.buttonMutate);
            this.groupManualControl.Controls.Add(this.buttonHC);
            resources.ApplyResources(this.groupManualControl, "groupManualControl");
            this.groupManualControl.Name = "groupManualControl";
            this.groupManualControl.TabStop = false;
            // 
            // buttonInitAlg
            // 
            resources.ApplyResources(this.buttonInitAlg, "buttonInitAlg");
            this.buttonInitAlg.Name = "buttonInitAlg";
            this.buttonInitAlg.UseVisualStyleBackColor = true;
            this.buttonInitAlg.Click += new System.EventHandler(this.buttonInitAlg_Click);
            // 
            // buttonAutoCalculate
            // 
            resources.ApplyResources(this.buttonAutoCalculate, "buttonAutoCalculate");
            this.buttonAutoCalculate.Name = "buttonAutoCalculate";
            this.buttonAutoCalculate.UseVisualStyleBackColor = true;
            this.buttonAutoCalculate.Click += new System.EventHandler(this.buttonAutoCalculate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonGetAll);
            this.groupBox1.Controls.Add(this.radioButtonGetBest);
            this.groupBox1.Controls.Add(this.radioButtonGetFirst);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioButtonGetAll
            // 
            resources.ApplyResources(this.radioButtonGetAll, "radioButtonGetAll");
            this.radioButtonGetAll.Checked = true;
            this.radioButtonGetAll.Name = "radioButtonGetAll";
            this.radioButtonGetAll.TabStop = true;
            this.radioButtonGetAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonGetBest
            // 
            resources.ApplyResources(this.radioButtonGetBest, "radioButtonGetBest");
            this.radioButtonGetBest.Name = "radioButtonGetBest";
            this.radioButtonGetBest.UseVisualStyleBackColor = true;
            // 
            // radioButtonGetFirst
            // 
            resources.ApplyResources(this.radioButtonGetFirst, "radioButtonGetFirst");
            this.radioButtonGetFirst.Name = "radioButtonGetFirst";
            this.radioButtonGetFirst.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupManualControl);
            this.Controls.Add(this.buttonAutoCalculate);
            this.Controls.Add(this.buttonLoadProblem);
            this.Controls.Add(this.logBox);
            this.Name = "Form1";
            this.groupManualControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button buttonEval;
        private System.Windows.Forms.Button buttonLoadProblem;
        private System.Windows.Forms.Button buttonCross;
        private System.Windows.Forms.Button buttonMutate;
        private System.Windows.Forms.Button buttonHC;
        private System.Windows.Forms.Button buttonInitList;
        private System.Windows.Forms.GroupBox groupManualControl;
        private System.Windows.Forms.Button buttonAutoCalculate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonGetAll;
        private System.Windows.Forms.RadioButton radioButtonGetBest;
        private System.Windows.Forms.RadioButton radioButtonGetFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonInitAlg;
    }
}

