namespace GICTOFNC
{
    partial class App
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrammar = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textVars = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTerms = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.newGrammar = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(-3, 108);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(887, 38);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 111);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(139, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONVERTIR GIC A FNC";
            // 
            // txtGrammar
            // 
            this.txtGrammar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrammar.Location = new System.Drawing.Point(209, 337);
            this.txtGrammar.Name = "txtGrammar";
            this.txtGrammar.Size = new System.Drawing.Size(230, 173);
            this.txtGrammar.TabIndex = 3;
            this.txtGrammar.Text = "L->S\nS->aAa|bBb|D|x\nA->aAB|BAb|Db\nB->aS|Aa|x\nC->aAc|Cb|ba\nD->aaAb|abA|Da\nE->aF|bF" +
    "|bE|x\nF->bFb|bC|a";
            this.txtGrammar.TextChanged += new System.EventHandler(this.txtGrammar_TextChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConvert.Location = new System.Drawing.Point(367, 516);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(112, 46);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convertir";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.label2.Location = new System.Drawing.Point(61, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(586, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Digite su gramática de la siguiente forma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.label3.Location = new System.Drawing.Point(174, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "A->B|C|D (Sin espacios)";
            // 
            // textVars
            // 
            this.textVars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVars.Location = new System.Drawing.Point(85, 283);
            this.textVars.Name = "textVars";
            this.textVars.Size = new System.Drawing.Size(306, 36);
            this.textVars.TabIndex = 6;
            this.textVars.Text = "L,S,A,B,C,D,E,F";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.label4.Location = new System.Drawing.Point(174, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(423, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "B->aB|X  (A variable inicial y x lambda)";
            // 
            // txtTerms
            // 
            this.txtTerms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTerms.Location = new System.Drawing.Point(551, 283);
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.Size = new System.Drawing.Size(306, 36);
            this.txtTerms.TabIndex = 8;
            this.txtTerms.Text = "a,b,c";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.label5.Location = new System.Drawing.Point(606, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alfabeto de terminales";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.label6.Location = new System.Drawing.Point(143, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Alfabeto de variables";
            // 
            // newGrammar
            // 
            this.newGrammar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newGrammar.Location = new System.Drawing.Point(464, 337);
            this.newGrammar.Name = "newGrammar";
            this.newGrammar.Size = new System.Drawing.Size(230, 173);
            this.newGrammar.TabIndex = 11;
            this.newGrammar.Text = "";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.newGrammar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTerms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textVars);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtGrammar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIC TO FNC";
            this.Load += new System.EventHandler(this.App_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtGrammar;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox textVars;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtTerms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox newGrammar;
    }
}

