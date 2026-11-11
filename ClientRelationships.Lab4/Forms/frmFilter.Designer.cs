namespace ClientRelationships.Forms;

public partial class frmFilter
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label hintLabel;
    private System.Windows.Forms.FlowLayoutPanel filterRowsPanel;
    private System.Windows.Forms.FlowLayoutPanel bottomPanel;
    private System.Windows.Forms.Button addConditionButton;
    private System.Windows.Forms.Button applyFilterButton;
    private System.Windows.Forms.Button cancelFilterButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        hintLabel = new Label();
        filterRowsPanel = new FlowLayoutPanel();
        bottomPanel = new FlowLayoutPanel();
        addConditionButton = new Button();
        applyFilterButton = new Button();
        cancelFilterButton = new Button();
        bottomPanel.SuspendLayout();
        SuspendLayout();
        // 
        // hintLabel
        // 
        hintLabel.Dock = DockStyle.Top;
        hintLabel.Location = new Point(0, 0);
        hintLabel.Name = "hintLabel";
        hintLabel.Padding = new Padding(10, 8, 10, 4);
        hintLabel.Size = new Size(884, 48);
        hintLabel.TabIndex = 2;
        hintLabel.Text = "Добавьте условия фильтрации. Все заполненные условия объединяются логическим И.";
        // 
        // filterRowsPanel
        // 
        filterRowsPanel.AutoScroll = true;
        filterRowsPanel.Dock = DockStyle.Fill;
        filterRowsPanel.FlowDirection = FlowDirection.TopDown;
        filterRowsPanel.Location = new Point(0, 48);
        filterRowsPanel.Name = "filterRowsPanel";
        filterRowsPanel.Padding = new Padding(8);
        filterRowsPanel.Size = new Size(884, 291);
        filterRowsPanel.TabIndex = 0;
        filterRowsPanel.WrapContents = false;
        // 
        // bottomPanel
        // 
        bottomPanel.Controls.Add(addConditionButton);
        bottomPanel.Controls.Add(applyFilterButton);
        bottomPanel.Controls.Add(cancelFilterButton);
        bottomPanel.Dock = DockStyle.Bottom;
        bottomPanel.Location = new Point(0, 339);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Padding = new Padding(8);
        bottomPanel.Size = new Size(884, 52);
        bottomPanel.TabIndex = 1;
        bottomPanel.WrapContents = false;
        // 
        // addConditionButton
        // 
        addConditionButton.AutoSize = true;
        addConditionButton.Location = new Point(11, 11);
        addConditionButton.Name = "addConditionButton";
        addConditionButton.Size = new Size(132, 27);
        addConditionButton.TabIndex = 0;
        addConditionButton.Text = "Добавить условие";
        addConditionButton.UseVisualStyleBackColor = true;
        addConditionButton.Click += AddConditionButton_Click;
        // 
        // applyFilterButton
        // 
        applyFilterButton.AutoSize = true;
        applyFilterButton.Location = new Point(149, 11);
        applyFilterButton.Name = "applyFilterButton";
        applyFilterButton.Size = new Size(92, 27);
        applyFilterButton.TabIndex = 1;
        applyFilterButton.Text = "Применить";
        applyFilterButton.UseVisualStyleBackColor = true;
        applyFilterButton.Click += ApplyFilterButton_Click;
        // 
        // cancelFilterButton
        // 
        cancelFilterButton.AutoSize = true;
        cancelFilterButton.DialogResult = DialogResult.Cancel;
        cancelFilterButton.Location = new Point(247, 11);
        cancelFilterButton.Name = "cancelFilterButton";
        cancelFilterButton.Size = new Size(73, 27);
        cancelFilterButton.TabIndex = 2;
        cancelFilterButton.Text = "Отмена";
        cancelFilterButton.UseVisualStyleBackColor = true;
        // 
        // frmFilter
        // 
        AcceptButton = applyFilterButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelFilterButton;
        ClientSize = new Size(884, 391);
        Controls.Add(filterRowsPanel);
        Controls.Add(bottomPanel);
        Controls.Add(hintLabel);
        MinimumSize = new Size(760, 330);
        Name = "frmFilter";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Настройка фильтра";
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
        ResumeLayout(false);
    }
}
