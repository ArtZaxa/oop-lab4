using System.Globalization;
using System.Windows.Forms;

namespace ClientRelationships.Forms;

public partial class frmContactEdit : Form
{
    private IReadOnlyList<ContType> _types = Array.Empty<ContType>();

    public Contact EditedContact { get; private set; }

    // Пустой конструктор нужен Visual Studio Designer.
    public frmContactEdit()
    {
        InitializeComponent();
    }

    public frmContactEdit(IReadOnlyList<ContType> types, Contact source, bool isNew) : this()
    {
        _types = types ?? Array.Empty<ContType>();
        Text = isNew ? "Добавление контакта" : "Редактирование контакта";

        foreach (var type in _types)
            contactTypeComboBox.Items.Add(type);

        var contact = source?.Clone();
        contactBeginDateTextBox.Text = contact?.BeginDt.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
            ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        contactEndDateTextBox.Text = contact?.EndDt.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
            ?? DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        contactDescrTextBox.Text = contact?.Descr ?? string.Empty;
        contactDataInfoTextBox.Text = contact?.DataInfo ?? string.Empty;

        if (contact?.CntType != null)
        {
            var index = _types.ToList().FindIndex(type => type.Name == contact.CntType.Name);
            if (index >= 0) contactTypeComboBox.SelectedIndex = index;
        }
        if (contactTypeComboBox.SelectedIndex < 0 && contactTypeComboBox.Items.Count > 0)
            contactTypeComboBox.SelectedIndex = 0;
    }

    private void SaveContactButton_Click(object sender, EventArgs e)
    {
        if (!DateTime.TryParse(contactBeginDateTextBox.Text, CultureInfo.InvariantCulture,
                DateTimeStyles.AllowWhiteSpaces, out var begin))
        {
            ShowValidationMessage("Дата начала должна быть в формате ГГГГ-ММ-ДД ЧЧ:ММ.");
            return;
        }

        if (!DateTime.TryParse(contactEndDateTextBox.Text, CultureInfo.InvariantCulture,
                DateTimeStyles.AllowWhiteSpaces, out var end))
        {
            ShowValidationMessage("Дата завершения должна быть в формате ГГГГ-ММ-ДД ЧЧ:ММ.");
            return;
        }

        if (end < begin)
        {
            ShowValidationMessage("Дата завершения не может быть раньше даты начала.");
            return;
        }

        EditedContact = new Contact(begin, end, contactDescrTextBox.Text,
            contactDataInfoTextBox.Text, contactTypeComboBox.SelectedItem as ContType);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void ShowValidationMessage(string message)
    {
        MessageBox.Show(this, message, "Контакт", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
