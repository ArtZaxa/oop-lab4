using System.Windows.Forms;
using ClientRelationships.Fields;

namespace ClientRelationships.Forms;

public partial class frmFields : Form
{
    public IReadOnlyList<string> SelectedFieldIds { get; private set; } = Array.Empty<string>();

    // Пустой конструктор нужен Visual Studio Designer.
    public frmFields()
    {
        InitializeComponent();
    }

    public frmFields(IEnumerable<Field> availableFields, IEnumerable<string> selectedIds) : this()
    {
        var selected = new HashSet<string>(selectedIds ?? Enumerable.Empty<string>());
        foreach (var field in availableFields ?? Enumerable.Empty<Field>())
        {
            var index = fieldsCheckedListBox.Items.Add(new FieldChoice(field));
            fieldsCheckedListBox.SetItemChecked(index, selected.Contains(field.Id));
        }
    }

    private void SaveFieldsButton_Click(object sender, EventArgs e)
    {
        SelectedFieldIds = fieldsCheckedListBox.CheckedItems
            .Cast<FieldChoice>()
            .Select(item => item.Field.Id)
            .ToList();
        DialogResult = DialogResult.OK;
        Close();
    }

    private sealed class FieldChoice
    {
        public Field Field { get; }
        public FieldChoice(Field field) => Field = field;
        public override string ToString() => Field.Name;
    }
}
