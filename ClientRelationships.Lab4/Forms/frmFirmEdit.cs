using System.Globalization;
using System.Windows.Forms;

namespace ClientRelationships.Forms;

public partial class frmFirmEdit : Form
{
    private Firm _firm;
    private IReadOnlyList<ContType> _contactTypes = Array.Empty<ContType>();
    private IReadOnlyList<string> _userFieldNames = Array.Empty<string>();
    private readonly Dictionary<string, TextBox> _userFields = new();
    private readonly List<Contact> _contacts = new();

    // Пустой конструктор нужен Visual Studio Designer.
    public frmFirmEdit()
    {
        InitializeComponent();
    }

    public frmFirmEdit(Firm firm, IReadOnlyList<ContType> contactTypes,
        IReadOnlyList<string> userFieldNames, bool isNew) : this()
    {
        _firm = firm ?? throw new ArgumentNullException(nameof(firm));
        _contactTypes = contactTypes ?? Array.Empty<ContType>();
        _userFieldNames = userFieldNames ?? Array.Empty<string>();
        _contacts.AddRange(_firm.MainContacts.Select(contact => contact.Clone()));

        Text = isNew ? "Добавление фирмы" : "Редактирование фирмы";
        PopulateUserFields();
        LoadFirmValues();
        RefreshContacts();
    }

    private void PopulateUserFields()
    {
        userFieldsPanel.SuspendLayout();
        userFieldsPanel.Controls.Clear();
        _userFields.Clear();

        for (var i = 0; i < Math.Min(5, _userFieldNames.Count); i++)
        {
            var fieldName = _userFieldNames[i];
            var fieldPanel = new Panel
            {
                Name = $"userFieldPanel_{i}",
                Width = 165,
                Height = 54,
                Margin = new Padding(4)
            };
            var label = new Label
            {
                Name = $"userFieldLabel_{i}",
                Text = fieldName,
                Dock = DockStyle.Top,
                Height = 20
            };
            var textBox = new TextBox
            {
                Name = $"userField_{i}",
                Dock = DockStyle.Bottom,
                Width = 155,
                Text = _firm.UserFields.TryGetValue(fieldName, out var value) ? value : string.Empty
            };
            _userFields[fieldName] = textBox;
            fieldPanel.Controls.Add(textBox);
            fieldPanel.Controls.Add(label);
            userFieldsPanel.Controls.Add(fieldPanel);
        }

        userFieldsPanel.ResumeLayout();
    }

    private void LoadFirmValues()
    {
        firmNameTextBox.Text = _firm.Name ?? string.Empty;
        firmCountryTextBox.Text = _firm.Country ?? string.Empty;
        firmRegionTextBox.Text = _firm.Region ?? string.Empty;
        firmTownTextBox.Text = _firm.Town ?? string.Empty;
        firmStreetTextBox.Text = _firm.Street ?? string.Empty;
        firmPostInxTextBox.Text = _firm.PostInx ?? string.Empty;
        firmDateInTextBox.Text = _firm.DateIn.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        firmEmailTextBox.Text = _firm.Email ?? string.Empty;
        firmWebTextBox.Text = _firm.Web ?? string.Empty;
    }

    private void AddContactButton_Click(object sender, EventArgs e)
    {
        if (_firm == null) return;
        using var dialog = new frmContactEdit(_contactTypes, null, true);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _contacts.Add(dialog.EditedContact.Clone());
            RefreshContacts();
        }
    }

    private void EditContactButton_Click(object sender, EventArgs e)
    {
        var index = SelectedContactIndex();
        if (index < 0) return;

        using var dialog = new frmContactEdit(_contactTypes, _contacts[index], false);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _contacts[index] = dialog.EditedContact.Clone();
            RefreshContacts();
        }
    }

    private void RemoveContactButton_Click(object sender, EventArgs e)
    {
        var index = SelectedContactIndex();
        if (index < 0) return;
        _contacts.RemoveAt(index);
        RefreshContacts();
    }

    private int SelectedContactIndex()
    {
        if (contactsListView.SelectedItems.Count == 0) return -1;
        var selected = contactsListView.SelectedItems[0].Tag as Contact;
        return selected == null ? -1 : _contacts.FindIndex(contact => ReferenceEquals(contact, selected));
    }

    private void RefreshContacts()
    {
        contactsListView.BeginUpdate();
        try
        {
            contactsListView.Items.Clear();
            foreach (var contact in _contacts.OrderByDescending(contact => contact.BeginDt))
            {
                var item = new ListViewItem(contact.BeginDt.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture))
                {
                    Tag = contact
                };
                item.SubItems.Add(contact.EndDt.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
                item.SubItems.Add(contact.CntType?.Name ?? string.Empty);
                item.SubItems.Add(contact.Descr ?? string.Empty);
                contactsListView.Items.Add(item);
            }
        }
        finally
        {
            contactsListView.EndUpdate();
        }
    }

    private void SaveFirmButton_Click(object sender, EventArgs e)
    {
        SaveFirm();
    }

    private void SaveFirm()
    {
        if (_firm == null) return;

        try
        {
            var name = firmNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Введите название фирмы.");

            if (!DateTime.TryParse(firmDateInTextBox.Text, CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out var dateIn))
                throw new FormatException("Дата ввода фирмы должна быть в формате ГГГГ-ММ-ДД ЧЧ:ММ.");

            _firm.Name = name;
            _firm.Country = firmCountryTextBox.Text.Trim();
            _firm.Region = firmRegionTextBox.Text.Trim();
            _firm.Town = firmTownTextBox.Text.Trim();
            _firm.Street = firmStreetTextBox.Text.Trim();
            _firm.PostInx = firmPostInxTextBox.Text.Trim();
            _firm.DateIn = dateIn;
            _firm.Email = firmEmailTextBox.Text.Trim();
            _firm.Web = firmWebTextBox.Text.Trim();

            foreach (var pair in _userFields)
                _firm.SetField(pair.Key, pair.Value.Text);

            _firm.ReplaceMainContacts(_contacts);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
