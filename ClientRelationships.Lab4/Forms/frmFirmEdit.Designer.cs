namespace ClientRelationships.Forms;

public partial class frmFirmEdit
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TableLayoutPanel rootLayout;
    private System.Windows.Forms.GroupBox firmGroupBox;
    private System.Windows.Forms.TableLayoutPanel firmFieldsLayout;
    private System.Windows.Forms.Label firmNameLabel;
    private System.Windows.Forms.TextBox firmNameTextBox;
    private System.Windows.Forms.Label firmCountryLabel;
    private System.Windows.Forms.TextBox firmCountryTextBox;
    private System.Windows.Forms.Label firmRegionLabel;
    private System.Windows.Forms.TextBox firmRegionTextBox;
    private System.Windows.Forms.Label firmTownLabel;
    private System.Windows.Forms.TextBox firmTownTextBox;
    private System.Windows.Forms.Label firmStreetLabel;
    private System.Windows.Forms.TextBox firmStreetTextBox;
    private System.Windows.Forms.Label firmPostInxLabel;
    private System.Windows.Forms.TextBox firmPostInxTextBox;
    private System.Windows.Forms.Label firmDateInLabel;
    private System.Windows.Forms.TextBox firmDateInTextBox;
    private System.Windows.Forms.Label firmEmailLabel;
    private System.Windows.Forms.TextBox firmEmailTextBox;
    private System.Windows.Forms.Label firmWebLabel;
    private System.Windows.Forms.TextBox firmWebTextBox;
    private System.Windows.Forms.GroupBox userFieldsGroupBox;
    private System.Windows.Forms.FlowLayoutPanel userFieldsPanel;
    private System.Windows.Forms.GroupBox contactsGroupBox;
    private System.Windows.Forms.ListView contactsListView;
    private System.Windows.Forms.FlowLayoutPanel contactButtonsPanel;
    private System.Windows.Forms.Button addContactButton;
    private System.Windows.Forms.Button editContactButton;
    private System.Windows.Forms.Button removeContactButton;
    private System.Windows.Forms.FlowLayoutPanel bottomPanel;
    private System.Windows.Forms.Button saveFirmButton;
    private System.Windows.Forms.Button cancelFirmButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        rootLayout = new TableLayoutPanel();
        firmGroupBox = new GroupBox();
        firmFieldsLayout = new TableLayoutPanel();
        firmNameLabel = new Label();
        firmNameTextBox = new TextBox();
        firmCountryLabel = new Label();
        firmCountryTextBox = new TextBox();
        firmRegionLabel = new Label();
        firmRegionTextBox = new TextBox();
        firmTownLabel = new Label();
        firmTownTextBox = new TextBox();
        firmStreetLabel = new Label();
        firmStreetTextBox = new TextBox();
        firmPostInxLabel = new Label();
        firmPostInxTextBox = new TextBox();
        firmDateInLabel = new Label();
        firmDateInTextBox = new TextBox();
        firmEmailLabel = new Label();
        firmEmailTextBox = new TextBox();
        firmWebLabel = new Label();
        firmWebTextBox = new TextBox();
        userFieldsGroupBox = new GroupBox();
        userFieldsPanel = new FlowLayoutPanel();
        contactsGroupBox = new GroupBox();
        contactsListView = new ListView();
        contactButtonsPanel = new FlowLayoutPanel();
        addContactButton = new Button();
        editContactButton = new Button();
        removeContactButton = new Button();
        bottomPanel = new FlowLayoutPanel();
        saveFirmButton = new Button();
        cancelFirmButton = new Button();
        rootLayout.SuspendLayout();
        firmGroupBox.SuspendLayout();
        firmFieldsLayout.SuspendLayout();
        userFieldsGroupBox.SuspendLayout();
        contactsGroupBox.SuspendLayout();
        contactButtonsPanel.SuspendLayout();
        bottomPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(firmGroupBox, 0, 0);
        rootLayout.Controls.Add(userFieldsGroupBox, 0, 1);
        rootLayout.Controls.Add(contactsGroupBox, 0, 2);
        rootLayout.Controls.Add(bottomPanel, 0, 3);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(10);
        rootLayout.RowCount = 4;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        rootLayout.Size = new Size(964, 711);
        rootLayout.TabIndex = 0;
        // 
        // firmGroupBox
        // 
        firmGroupBox.Controls.Add(firmFieldsLayout);
        firmGroupBox.Dock = DockStyle.Fill;
        firmGroupBox.Location = new Point(13, 13);
        firmGroupBox.Name = "firmGroupBox";
        firmGroupBox.Padding = new Padding(8);
        firmGroupBox.Size = new Size(938, 214);
        firmGroupBox.TabIndex = 0;
        firmGroupBox.TabStop = false;
        firmGroupBox.Text = "Данные фирмы";
        // 
        // firmFieldsLayout
        // 
        firmFieldsLayout.ColumnCount = 4;
        firmFieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
        firmFieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        firmFieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
        firmFieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        firmFieldsLayout.Controls.Add(firmNameLabel, 0, 0);
        firmFieldsLayout.Controls.Add(firmNameTextBox, 1, 0);
        firmFieldsLayout.Controls.Add(firmCountryLabel, 2, 0);
        firmFieldsLayout.Controls.Add(firmCountryTextBox, 3, 0);
        firmFieldsLayout.Controls.Add(firmRegionLabel, 0, 1);
        firmFieldsLayout.Controls.Add(firmRegionTextBox, 1, 1);
        firmFieldsLayout.Controls.Add(firmTownLabel, 2, 1);
        firmFieldsLayout.Controls.Add(firmTownTextBox, 3, 1);
        firmFieldsLayout.Controls.Add(firmStreetLabel, 0, 2);
        firmFieldsLayout.Controls.Add(firmStreetTextBox, 1, 2);
        firmFieldsLayout.Controls.Add(firmPostInxLabel, 2, 2);
        firmFieldsLayout.Controls.Add(firmPostInxTextBox, 3, 2);
        firmFieldsLayout.Controls.Add(firmDateInLabel, 0, 3);
        firmFieldsLayout.Controls.Add(firmDateInTextBox, 1, 3);
        firmFieldsLayout.Controls.Add(firmEmailLabel, 2, 3);
        firmFieldsLayout.Controls.Add(firmEmailTextBox, 3, 3);
        firmFieldsLayout.Controls.Add(firmWebLabel, 0, 4);
        firmFieldsLayout.Controls.Add(firmWebTextBox, 1, 4);
        firmFieldsLayout.Dock = DockStyle.Fill;
        firmFieldsLayout.Location = new Point(8, 24);
        firmFieldsLayout.Name = "firmFieldsLayout";
        firmFieldsLayout.Padding = new Padding(4);
        firmFieldsLayout.RowCount = 5;
        firmFieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        firmFieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        firmFieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        firmFieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        firmFieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        firmFieldsLayout.Size = new Size(922, 182);
        firmFieldsLayout.TabIndex = 0;
        // 
        // firmNameLabel
        // 
        firmNameLabel.Dock = DockStyle.Fill;
        firmNameLabel.Location = new Point(7, 4);
        firmNameLabel.Name = "firmNameLabel";
        firmNameLabel.Size = new Size(99, 34);
        firmNameLabel.TabIndex = 0;
        firmNameLabel.Text = "Название";
        firmNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmNameTextBox
        // 
        firmNameTextBox.Dock = DockStyle.Fill;
        firmNameTextBox.Location = new Point(112, 7);
        firmNameTextBox.Name = "firmNameTextBox";
        firmNameTextBox.Size = new Size(346, 23);
        firmNameTextBox.TabIndex = 1;
        // 
        // firmCountryLabel
        // 
        firmCountryLabel.Dock = DockStyle.Fill;
        firmCountryLabel.Location = new Point(464, 4);
        firmCountryLabel.Name = "firmCountryLabel";
        firmCountryLabel.Size = new Size(99, 34);
        firmCountryLabel.TabIndex = 2;
        firmCountryLabel.Text = "Страна";
        firmCountryLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmCountryTextBox
        // 
        firmCountryTextBox.Dock = DockStyle.Fill;
        firmCountryTextBox.Location = new Point(569, 7);
        firmCountryTextBox.Name = "firmCountryTextBox";
        firmCountryTextBox.Size = new Size(346, 23);
        firmCountryTextBox.TabIndex = 3;
        // 
        // firmRegionLabel
        // 
        firmRegionLabel.Dock = DockStyle.Fill;
        firmRegionLabel.Location = new Point(7, 38);
        firmRegionLabel.Name = "firmRegionLabel";
        firmRegionLabel.Size = new Size(99, 34);
        firmRegionLabel.TabIndex = 4;
        firmRegionLabel.Text = "Регион";
        firmRegionLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmRegionTextBox
        // 
        firmRegionTextBox.Dock = DockStyle.Fill;
        firmRegionTextBox.Location = new Point(112, 41);
        firmRegionTextBox.Name = "firmRegionTextBox";
        firmRegionTextBox.Size = new Size(346, 23);
        firmRegionTextBox.TabIndex = 5;
        // 
        // firmTownLabel
        // 
        firmTownLabel.Dock = DockStyle.Fill;
        firmTownLabel.Location = new Point(464, 38);
        firmTownLabel.Name = "firmTownLabel";
        firmTownLabel.Size = new Size(99, 34);
        firmTownLabel.TabIndex = 6;
        firmTownLabel.Text = "Город";
        firmTownLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmTownTextBox
        // 
        firmTownTextBox.Dock = DockStyle.Fill;
        firmTownTextBox.Location = new Point(569, 41);
        firmTownTextBox.Name = "firmTownTextBox";
        firmTownTextBox.Size = new Size(346, 23);
        firmTownTextBox.TabIndex = 7;
        // 
        // firmStreetLabel
        // 
        firmStreetLabel.Dock = DockStyle.Fill;
        firmStreetLabel.Location = new Point(7, 72);
        firmStreetLabel.Name = "firmStreetLabel";
        firmStreetLabel.Size = new Size(99, 34);
        firmStreetLabel.TabIndex = 8;
        firmStreetLabel.Text = "Улица";
        firmStreetLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmStreetTextBox
        // 
        firmStreetTextBox.Dock = DockStyle.Fill;
        firmStreetTextBox.Location = new Point(112, 75);
        firmStreetTextBox.Name = "firmStreetTextBox";
        firmStreetTextBox.Size = new Size(346, 23);
        firmStreetTextBox.TabIndex = 9;
        // 
        // firmPostInxLabel
        // 
        firmPostInxLabel.Dock = DockStyle.Fill;
        firmPostInxLabel.Location = new Point(464, 72);
        firmPostInxLabel.Name = "firmPostInxLabel";
        firmPostInxLabel.Size = new Size(99, 34);
        firmPostInxLabel.TabIndex = 10;
        firmPostInxLabel.Text = "Индекс";
        firmPostInxLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmPostInxTextBox
        // 
        firmPostInxTextBox.Dock = DockStyle.Fill;
        firmPostInxTextBox.Location = new Point(569, 75);
        firmPostInxTextBox.Name = "firmPostInxTextBox";
        firmPostInxTextBox.Size = new Size(346, 23);
        firmPostInxTextBox.TabIndex = 11;
        // 
        // firmDateInLabel
        // 
        firmDateInLabel.Dock = DockStyle.Fill;
        firmDateInLabel.Location = new Point(7, 106);
        firmDateInLabel.Name = "firmDateInLabel";
        firmDateInLabel.Size = new Size(99, 34);
        firmDateInLabel.TabIndex = 12;
        firmDateInLabel.Text = "Дата ввода";
        firmDateInLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmDateInTextBox
        // 
        firmDateInTextBox.Dock = DockStyle.Fill;
        firmDateInTextBox.Location = new Point(112, 109);
        firmDateInTextBox.Name = "firmDateInTextBox";
        firmDateInTextBox.Size = new Size(346, 23);
        firmDateInTextBox.TabIndex = 13;
        // 
        // firmEmailLabel
        // 
        firmEmailLabel.Dock = DockStyle.Fill;
        firmEmailLabel.Location = new Point(464, 106);
        firmEmailLabel.Name = "firmEmailLabel";
        firmEmailLabel.Size = new Size(99, 34);
        firmEmailLabel.TabIndex = 14;
        firmEmailLabel.Text = "Email";
        firmEmailLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmEmailTextBox
        // 
        firmEmailTextBox.Dock = DockStyle.Fill;
        firmEmailTextBox.Location = new Point(569, 109);
        firmEmailTextBox.Name = "firmEmailTextBox";
        firmEmailTextBox.Size = new Size(346, 23);
        firmEmailTextBox.TabIndex = 15;
        // 
        // firmWebLabel
        // 
        firmWebLabel.Dock = DockStyle.Fill;
        firmWebLabel.Location = new Point(7, 140);
        firmWebLabel.Name = "firmWebLabel";
        firmWebLabel.Size = new Size(99, 38);
        firmWebLabel.TabIndex = 16;
        firmWebLabel.Text = "Сайт";
        firmWebLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // firmWebTextBox
        // 
        firmFieldsLayout.SetColumnSpan(firmWebTextBox, 3);
        firmWebTextBox.Dock = DockStyle.Fill;
        firmWebTextBox.Location = new Point(112, 143);
        firmWebTextBox.Name = "firmWebTextBox";
        firmWebTextBox.Size = new Size(803, 23);
        firmWebTextBox.TabIndex = 17;
        // 
        // userFieldsGroupBox
        // 
        userFieldsGroupBox.Controls.Add(userFieldsPanel);
        userFieldsGroupBox.Dock = DockStyle.Fill;
        userFieldsGroupBox.Location = new Point(13, 233);
        userFieldsGroupBox.Name = "userFieldsGroupBox";
        userFieldsGroupBox.Padding = new Padding(8);
        userFieldsGroupBox.Size = new Size(938, 114);
        userFieldsGroupBox.TabIndex = 1;
        userFieldsGroupBox.TabStop = false;
        userFieldsGroupBox.Text = "Пользовательские поля";
        // 
        // userFieldsPanel
        // 
        userFieldsPanel.AutoScroll = true;
        userFieldsPanel.Dock = DockStyle.Fill;
        userFieldsPanel.Location = new Point(8, 24);
        userFieldsPanel.Name = "userFieldsPanel";
        userFieldsPanel.Size = new Size(922, 82);
        userFieldsPanel.TabIndex = 0;
        // 
        // contactsGroupBox
        // 
        contactsGroupBox.Controls.Add(contactsListView);
        contactsGroupBox.Controls.Add(contactButtonsPanel);
        contactsGroupBox.Dock = DockStyle.Fill;
        contactsGroupBox.Location = new Point(13, 353);
        contactsGroupBox.Name = "contactsGroupBox";
        contactsGroupBox.Padding = new Padding(8);
        contactsGroupBox.Size = new Size(938, 297);
        contactsGroupBox.TabIndex = 2;
        contactsGroupBox.TabStop = false;
        contactsGroupBox.Text = "Контакты основного подразделения";
        // 
        // contactsListView
        // 
        contactsListView.Dock = DockStyle.Fill;
        contactsListView.FullRowSelect = true;
        contactsListView.GridLines = true;
        contactsListView.Location = new Point(8, 24);
        contactsListView.MultiSelect = false;
        contactsListView.Name = "contactsListView";
        contactsListView.Size = new Size(922, 227);
        contactsListView.TabIndex = 0;
        contactsListView.UseCompatibleStateImageBehavior = false;
        contactsListView.View = View.Details;
        // 
        // contactButtonsPanel
        // 
        contactButtonsPanel.Controls.Add(addContactButton);
        contactButtonsPanel.Controls.Add(editContactButton);
        contactButtonsPanel.Controls.Add(removeContactButton);
        contactButtonsPanel.Dock = DockStyle.Bottom;
        contactButtonsPanel.Location = new Point(8, 251);
        contactButtonsPanel.Name = "contactButtonsPanel";
        contactButtonsPanel.Size = new Size(922, 38);
        contactButtonsPanel.TabIndex = 1;
        contactButtonsPanel.WrapContents = false;
        // 
        // addContactButton
        // 
        addContactButton.AutoSize = true;
        addContactButton.Location = new Point(3, 3);
        addContactButton.Name = "addContactButton";
        addContactButton.Size = new Size(114, 25);
        addContactButton.TabIndex = 0;
        addContactButton.Text = "Добавить контакт";
        addContactButton.UseVisualStyleBackColor = true;
        addContactButton.Click += AddContactButton_Click;
        // 
        // editContactButton
        // 
        editContactButton.AutoSize = true;
        editContactButton.Location = new Point(123, 3);
        editContactButton.Name = "editContactButton";
        editContactButton.Size = new Size(116, 25);
        editContactButton.TabIndex = 1;
        editContactButton.Text = "Изменить контакт";
        editContactButton.UseVisualStyleBackColor = true;
        editContactButton.Click += EditContactButton_Click;
        // 
        // removeContactButton
        // 
        removeContactButton.AutoSize = true;
        removeContactButton.Location = new Point(245, 3);
        removeContactButton.Name = "removeContactButton";
        removeContactButton.Size = new Size(106, 25);
        removeContactButton.TabIndex = 2;
        removeContactButton.Text = "Удалить контакт";
        removeContactButton.UseVisualStyleBackColor = true;
        removeContactButton.Click += RemoveContactButton_Click;
        // 
        // bottomPanel
        // 
        bottomPanel.Controls.Add(saveFirmButton);
        bottomPanel.Controls.Add(cancelFirmButton);
        bottomPanel.Dock = DockStyle.Fill;
        bottomPanel.FlowDirection = FlowDirection.RightToLeft;
        bottomPanel.Location = new Point(13, 656);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Padding = new Padding(4);
        bottomPanel.Size = new Size(938, 42);
        bottomPanel.TabIndex = 3;
        bottomPanel.WrapContents = false;
        // 
        // saveFirmButton
        // 
        saveFirmButton.AutoSize = true;
        saveFirmButton.Location = new Point(852, 7);
        saveFirmButton.Name = "saveFirmButton";
        saveFirmButton.Size = new Size(75, 25);
        saveFirmButton.TabIndex = 0;
        saveFirmButton.Text = "Сохранить";
        saveFirmButton.UseVisualStyleBackColor = true;
        saveFirmButton.Click += SaveFirmButton_Click;
        // 
        // cancelFirmButton
        // 
        cancelFirmButton.AutoSize = true;
        cancelFirmButton.DialogResult = DialogResult.Cancel;
        cancelFirmButton.Location = new Point(771, 7);
        cancelFirmButton.Name = "cancelFirmButton";
        cancelFirmButton.Size = new Size(75, 25);
        cancelFirmButton.TabIndex = 1;
        cancelFirmButton.Text = "Отмена";
        cancelFirmButton.UseVisualStyleBackColor = true;
        // 
        // frmFirmEdit
        // 
        AcceptButton = saveFirmButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelFirmButton;
        ClientSize = new Size(964, 711);
        Controls.Add(rootLayout);
        MinimumSize = new Size(820, 650);
        Name = "frmFirmEdit";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Редактирование фирмы";
        rootLayout.ResumeLayout(false);
        firmGroupBox.ResumeLayout(false);
        firmFieldsLayout.ResumeLayout(false);
        firmFieldsLayout.PerformLayout();
        userFieldsGroupBox.ResumeLayout(false);
        contactsGroupBox.ResumeLayout(false);
        contactButtonsPanel.ResumeLayout(false);
        contactButtonsPanel.PerformLayout();
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
        ResumeLayout(false);
    }

}
