namespace denemedeneme
{
    partial class ProductsForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.denemeDBDataSet = new denemedeneme.DenemeDBDataSet();
            this.productTBLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTBLTableAdapter = new denemedeneme.DenemeDBDataSetTableAdapters.ProductTBLTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denemeDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTBLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 201);
            this.dataGridView1.TabIndex = 0;
            // 
            // denemeDBDataSet
            // 
            this.denemeDBDataSet.DataSetName = "DenemeDBDataSet";
            this.denemeDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTBLBindingSource
            // 
            this.productTBLBindingSource.DataMember = "ProductTBL";
            this.productTBLBindingSource.DataSource = this.denemeDBDataSet;
            // 
            // productTBLTableAdapter
            // 
            this.productTBLTableAdapter.ClearBeforeFill = true;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 223);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denemeDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTBLBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DenemeDBDataSet denemeDBDataSet;
        private System.Windows.Forms.BindingSource productTBLBindingSource;
        private DenemeDBDataSetTableAdapters.ProductTBLTableAdapter productTBLTableAdapter;
    }
}