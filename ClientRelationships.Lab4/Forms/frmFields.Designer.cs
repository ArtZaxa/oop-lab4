namespace ClientRelationships.Forms;

public partial class frmFields
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.CheckedListBox fieldsCheckedListBox;
    private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
    private System.Windows.Forms.Button saveFieldsButton;
    private System.Windows.Forms.Button cancelFieldsButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.fieldsCheckedListBox = new System.Windows.Forms.CheckedListBox();
        this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.saveFieldsButton = new System.Windows.Forms.Button();
        this.cancelFieldsButton = new System.Windows.Forms.Button();
        this.buttonsPanel.SuspendLayout();
        this.SuspendLayout();
        //
        // fieldsCheckedListBox
        //
        this.fieldsCheckedListBox.CheckOnClick = true;
        this.fieldsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.fieldsCheckedListBox.FormattingEnabled = true;
        this.fieldsCheckedListBox.Name = "fieldsCheckedListBox";
        this.fieldsCheckedListBox.IntegralHeight = false;
        //
        // buttonsPanel
        //
        this.buttonsPanel.Controls.Add(this.saveFieldsButton);
        this.buttonsPanel.Controls.Add(this.cancelFieldsButton);
        this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this.buttonsPanel.Name = "buttonsPanel";
        this.buttonsPanel.Padding = new System.Windows.Forms.Padding(6);
        this.buttonsPanel.WrapContents = false;
        this.buttonsPanel.Size = new System.Drawing.Size(364, 52);
        //
        // saveFieldsButton
        //
        this.saveFieldsButton.AutoSize = true;
        this.saveFieldsButton.Name = "saveFieldsButton";
        this.saveFieldsButton.Size = new System.Drawing.Size(92, 27);
        this.saveFieldsButton.Text = "Применить";
        this.saveFieldsButton.UseVisualStyleBackColor = true;
        this.saveFieldsButton.Click += new System.EventHandler(this.SaveFieldsButton_Click);
        //
        // cancelFieldsButton
        //
        this.cancelFieldsButton.AutoSize = true;
        this.cancelFieldsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelFieldsButton.Name = "cancelFieldsButton";
        this.cancelFieldsButton.Size = new System.Drawing.Size(73, 27);
        this.cancelFieldsButton.Text = "Отмена";
        this.cancelFieldsButton.UseVisualStyleBackColor = true;
        //
        // frmFields
        //
        this.AcceptButton = this.saveFieldsButton;
        this.CancelButton = this.cancelFieldsButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(364, 471);
        this.Controls.Add(this.fieldsCheckedListBox);
        this.Controls.Add(this.buttonsPanel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmFields";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Состав отображаемых полей";
        this.buttonsPanel.ResumeLayout(false);
        this.buttonsPanel.PerformLayout();
        this.ResumeLayout(false);
    }
}
