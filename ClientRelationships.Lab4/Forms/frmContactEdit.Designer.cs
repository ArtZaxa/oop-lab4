namespace ClientRelationships.Forms;

public partial class frmContactEdit
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TableLayoutPanel rootLayout;
    private System.Windows.Forms.Label beginDateLabel;
    private System.Windows.Forms.TextBox contactBeginDateTextBox;
    private System.Windows.Forms.Label endDateLabel;
    private System.Windows.Forms.TextBox contactEndDateTextBox;
    private System.Windows.Forms.Label descriptionLabel;
    private System.Windows.Forms.TextBox contactDescrTextBox;
    private System.Windows.Forms.Label dataInfoLabel;
    private System.Windows.Forms.TextBox contactDataInfoTextBox;
    private System.Windows.Forms.Label contactTypeLabel;
    private System.Windows.Forms.ComboBox contactTypeComboBox;
    private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
    private System.Windows.Forms.Button saveContactButton;
    private System.Windows.Forms.Button cancelContactButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        rootLayout = new TableLayoutPanel();
        beginDateLabel = new Label();
        contactBeginDateTextBox = new TextBox();
        endDateLabel = new Label();
        contactEndDateTextBox = new TextBox();
        descriptionLabel = new Label();
        contactDescrTextBox = new TextBox();
        dataInfoLabel = new Label();
        contactDataInfoTextBox = new TextBox();
        contactTypeLabel = new Label();
        contactTypeComboBox = new ComboBox();
        buttonsPanel = new FlowLayoutPanel();
        saveContactButton = new Button();
        cancelContactButton = new Button();
        rootLayout.SuspendLayout();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 2;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(beginDateLabel, 0, 0);
        rootLayout.Controls.Add(contactBeginDateTextBox, 1, 0);
        rootLayout.Controls.Add(endDateLabel, 0, 1);
        rootLayout.Controls.Add(contactEndDateTextBox, 1, 1);
        rootLayout.Controls.Add(descriptionLabel, 0, 2);
        rootLayout.Controls.Add(contactDescrTextBox, 1, 2);
        rootLayout.Controls.Add(dataInfoLabel, 0, 3);
        rootLayout.Controls.Add(contactDataInfoTextBox, 1, 3);
        rootLayout.Controls.Add(contactTypeLabel, 0, 4);
        rootLayout.Controls.Add(contactTypeComboBox, 1, 4);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(12);
        rootLayout.RowCount = 5;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.Size = new Size(534, 262);
        rootLayout.TabIndex = 0;
        // 
        // beginDateLabel
        // 
        beginDateLabel.Dock = DockStyle.Fill;
        beginDateLabel.Location = new Point(15, 12);
        beginDateLabel.Name = "beginDateLabel";
        beginDateLabel.Size = new Size(159, 44);
        beginDateLabel.TabIndex = 0;
        beginDateLabel.Text = "Дата начала";
        beginDateLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // contactBeginDateTextBox
        // 
        contactBeginDateTextBox.Dock = DockStyle.Fill;
        contactBeginDateTextBox.Location = new Point(180, 15);
        contactBeginDateTextBox.Name = "contactBeginDateTextBox";
        contactBeginDateTextBox.Size = new Size(339, 23);
        contactBeginDateTextBox.TabIndex = 1;
        // 
        // endDateLabel
        // 
        endDateLabel.Dock = DockStyle.Fill;
        endDateLabel.Location = new Point(15, 56);
        endDateLabel.Name = "endDateLabel";
        endDateLabel.Size = new Size(159, 44);
        endDateLabel.TabIndex = 2;
        endDateLabel.Text = "Дата завершения";
        endDateLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // contactEndDateTextBox
        // 
        contactEndDateTextBox.Dock = DockStyle.Fill;
        contactEndDateTextBox.Location = new Point(180, 59);
        contactEndDateTextBox.Name = "contactEndDateTextBox";
        contactEndDateTextBox.Size = new Size(339, 23);
        contactEndDateTextBox.TabIndex = 3;
        // 
        // descriptionLabel
        // 
        descriptionLabel.Dock = DockStyle.Fill;
        descriptionLabel.Location = new Point(15, 100);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(159, 44);
        descriptionLabel.TabIndex = 4;
        descriptionLabel.Text = "Описание для себя";
        descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // contactDescrTextBox
        // 
        contactDescrTextBox.Dock = DockStyle.Fill;
        contactDescrTextBox.Location = new Point(180, 103);
        contactDescrTextBox.Name = "contactDescrTextBox";
        contactDescrTextBox.Size = new Size(339, 23);
        contactDescrTextBox.TabIndex = 5;
        // 
        // dataInfoLabel
        // 
        dataInfoLabel.Dock = DockStyle.Fill;
        dataInfoLabel.Location = new Point(15, 144);
        dataInfoLabel.Name = "dataInfoLabel";
        dataInfoLabel.Size = new Size(159, 44);
        dataInfoLabel.TabIndex = 6;
        dataInfoLabel.Text = "Информация клиенту";
        dataInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // contactDataInfoTextBox
        // 
        contactDataInfoTextBox.Dock = DockStyle.Fill;
        contactDataInfoTextBox.Location = new Point(180, 147);
        contactDataInfoTextBox.Name = "contactDataInfoTextBox";
        contactDataInfoTextBox.Size = new Size(339, 23);
        contactDataInfoTextBox.TabIndex = 7;
        // 
        // contactTypeLabel
        // 
        contactTypeLabel.Dock = DockStyle.Fill;
        contactTypeLabel.Location = new Point(15, 188);
        contactTypeLabel.Name = "contactTypeLabel";
        contactTypeLabel.Size = new Size(159, 62);
        contactTypeLabel.TabIndex = 8;
        contactTypeLabel.Text = "Тип контакта";
        contactTypeLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // contactTypeComboBox
        // 
        contactTypeComboBox.Dock = DockStyle.Fill;
        contactTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        contactTypeComboBox.Location = new Point(180, 191);
        contactTypeComboBox.Name = "contactTypeComboBox";
        contactTypeComboBox.Size = new Size(339, 23);
        contactTypeComboBox.TabIndex = 9;
        // 
        // buttonsPanel
        // 
        buttonsPanel.Controls.Add(saveContactButton);
        buttonsPanel.Controls.Add(cancelContactButton);
        buttonsPanel.Dock = DockStyle.Bottom;
        buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
        buttonsPanel.Location = new Point(0, 262);
        buttonsPanel.Name = "buttonsPanel";
        buttonsPanel.Padding = new Padding(8);
        buttonsPanel.Size = new Size(534, 48);
        buttonsPanel.TabIndex = 1;
        buttonsPanel.WrapContents = false;
        // 
        // saveContactButton
        // 
        saveContactButton.AutoSize = true;
        saveContactButton.Location = new Point(440, 11);
        saveContactButton.Name = "saveContactButton";
        saveContactButton.Size = new Size(75, 25);
        saveContactButton.TabIndex = 0;
        saveContactButton.Text = "Сохранить";
        saveContactButton.UseVisualStyleBackColor = true;
        saveContactButton.Click += SaveContactButton_Click;
        // 
        // cancelContactButton
        // 
        cancelContactButton.AutoSize = true;
        cancelContactButton.DialogResult = DialogResult.Cancel;
        cancelContactButton.Location = new Point(359, 11);
        cancelContactButton.Name = "cancelContactButton";
        cancelContactButton.Size = new Size(75, 25);
        cancelContactButton.TabIndex = 1;
        cancelContactButton.Text = "Отмена";
        cancelContactButton.UseVisualStyleBackColor = true;
        // 
        // frmContactEdit
        // 
        AcceptButton = saveContactButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelContactButton;
        ClientSize = new Size(534, 310);
        Controls.Add(rootLayout);
        Controls.Add(buttonsPanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmContactEdit";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Редактирование контакта";
        rootLayout.ResumeLayout(false);
        rootLayout.PerformLayout();
        buttonsPanel.ResumeLayout(false);
        buttonsPanel.PerformLayout();
        ResumeLayout(false);
    }
}
