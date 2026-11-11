namespace ClientRelationships.Forms;

public partial class frmMain
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.FlowLayoutPanel toolbarPanel;
    private System.Windows.Forms.Button addFirmButton;
    private System.Windows.Forms.Button editFirmButton;
    private System.Windows.Forms.Button selectFieldsButton;
    private System.Windows.Forms.Button filterButton;
    private System.Windows.Forms.Button resetFilterButton;
    private System.Windows.Forms.ListView firmsListView;
    private System.Windows.Forms.Label statusLabel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.toolbarPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.addFirmButton = new System.Windows.Forms.Button();
        this.editFirmButton = new System.Windows.Forms.Button();
        this.selectFieldsButton = new System.Windows.Forms.Button();
        this.filterButton = new System.Windows.Forms.Button();
        this.resetFilterButton = new System.Windows.Forms.Button();
        this.firmsListView = new System.Windows.Forms.ListView();
        this.statusLabel = new System.Windows.Forms.Label();
        this.toolbarPanel.SuspendLayout();
        this.SuspendLayout();
        //
        // toolbarPanel
        //
        this.toolbarPanel.AutoScroll = true;
        this.toolbarPanel.Controls.Add(this.addFirmButton);
        this.toolbarPanel.Controls.Add(this.editFirmButton);
        this.toolbarPanel.Controls.Add(this.selectFieldsButton);
        this.toolbarPanel.Controls.Add(this.filterButton);
        this.toolbarPanel.Controls.Add(this.resetFilterButton);
        this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.toolbarPanel.Name = "toolbarPanel";
        this.toolbarPanel.Padding = new System.Windows.Forms.Padding(8, 7, 8, 5);
        this.toolbarPanel.WrapContents = false;
        this.toolbarPanel.Size = new System.Drawing.Size(1084, 48);
        //
        // addFirmButton
        //
        this.addFirmButton.AutoSize = true;
        this.addFirmButton.Name = "addFirmButton";
        this.addFirmButton.Size = new System.Drawing.Size(120, 28);
        this.addFirmButton.TabIndex = 0;
        this.addFirmButton.Text = "Добавить фирму";
        this.addFirmButton.UseVisualStyleBackColor = true;
        this.addFirmButton.Click += new System.EventHandler(this.AddFirmButton_Click);
        //
        // editFirmButton
        //
        this.editFirmButton.AutoSize = true;
        this.editFirmButton.Name = "editFirmButton";
        this.editFirmButton.Size = new System.Drawing.Size(100, 28);
        this.editFirmButton.TabIndex = 1;
        this.editFirmButton.Text = "Изменить";
        this.editFirmButton.UseVisualStyleBackColor = true;
        this.editFirmButton.Click += new System.EventHandler(this.EditFirmButton_Click);
        //
        // selectFieldsButton
        //
        this.selectFieldsButton.AutoSize = true;
        this.selectFieldsButton.Name = "selectFieldsButton";
        this.selectFieldsButton.Size = new System.Drawing.Size(110, 28);
        this.selectFieldsButton.TabIndex = 2;
        this.selectFieldsButton.Text = "Состав полей";
        this.selectFieldsButton.UseVisualStyleBackColor = true;
        this.selectFieldsButton.Click += new System.EventHandler(this.SelectFieldsButton_Click);
        //
        // filterButton
        //
        this.filterButton.AutoSize = true;
        this.filterButton.Name = "filterButton";
        this.filterButton.Size = new System.Drawing.Size(80, 28);
        this.filterButton.TabIndex = 3;
        this.filterButton.Text = "Фильтр";
        this.filterButton.UseVisualStyleBackColor = true;
        this.filterButton.Click += new System.EventHandler(this.FilterButton_Click);
        //
        // resetFilterButton
        //
        this.resetFilterButton.AutoSize = true;
        this.resetFilterButton.Name = "resetFilterButton";
        this.resetFilterButton.Size = new System.Drawing.Size(125, 28);
        this.resetFilterButton.TabIndex = 4;
        this.resetFilterButton.Text = "Сбросить фильтр";
        this.resetFilterButton.UseVisualStyleBackColor = true;
        this.resetFilterButton.Click += new System.EventHandler(this.ResetFilterButton_Click);
        //
        // firmsListView
        //
        this.firmsListView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.firmsListView.FullRowSelect = true;
        this.firmsListView.GridLines = true;
        this.firmsListView.HideSelection = false;
        this.firmsListView.MultiSelect = false;
        this.firmsListView.Name = "firmsListView";
        this.firmsListView.UseCompatibleStateImageBehavior = false;
        this.firmsListView.View = System.Windows.Forms.View.Details;
        this.firmsListView.DoubleClick += new System.EventHandler(this.FirmsListView_DoubleClick);
        //
        // statusLabel
        //
        this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.statusLabel.Name = "statusLabel";
        this.statusLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.statusLabel.Size = new System.Drawing.Size(1084, 26);
        this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // frmMain
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1084, 611);
        this.Controls.Add(this.firmsListView);
        this.Controls.Add(this.statusLabel);
        this.Controls.Add(this.toolbarPanel);
        this.MinimumSize = new System.Drawing.Size(850, 500);
        this.Name = "frmMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Система взаимоотношений с клиентами";
        this.toolbarPanel.ResumeLayout(false);
        this.toolbarPanel.PerformLayout();
        this.ResumeLayout(false);
    }
}
