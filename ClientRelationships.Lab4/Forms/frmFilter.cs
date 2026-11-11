using System.Drawing;
using System.Windows.Forms;
using ClientRelationships.Expressions;
using ClientRelationships.Fields;
using ClientRelationships.Filtering;

namespace ClientRelationships.Forms;

public partial class frmFilter : Form
{
    private readonly List<Field> _fields = new();
    private int _nextIndex;

    public IReadOnlyList<FilterCondition> Conditions { get; private set; } = Array.Empty<FilterCondition>();

    // Пустой конструктор нужен Visual Studio Designer.
    public frmFilter()
    {
        InitializeComponent();
    }

    public frmFilter(IEnumerable<Field> fields) : this()
    {
        _fields.AddRange((fields ?? Enumerable.Empty<Field>()).Select(field => field.Clone()));
        AddConditionRow();
    }

    private void AddConditionButton_Click(object sender, EventArgs e)
    {
        AddConditionRow();
    }

    private void ApplyFilterButton_Click(object sender, EventArgs e)
    {
        ApplyConditions();
    }

    private void AddConditionRow()
    {
        var index = _nextIndex++;
        var row = new Panel
        {
            Name = $"conditionRow_{index}",
            Width = Math.Max(800, filterRowsPanel.ClientSize.Width - 30),
            Height = 42,
            Margin = new Padding(2)
        };

        var fieldBox = new ComboBox
        {
            Name = $"field_{index}",
            Left = 0,
            Top = 5,
            Width = 230,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        foreach (var field in _fields)
            fieldBox.Items.Add(new FieldOption(field));
        if (fieldBox.Items.Count > 0)
            fieldBox.SelectedIndex = 0;

        var operatorBox = new ComboBox
        {
            Name = $"operator_{index}",
            Left = 240,
            Top = 5,
            Width = 175,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        var valueBox = new TextBox
        {
            Name = $"value_{index}",
            Left = 425,
            Top = 5,
            Width = 300,
            PlaceholderText = "Значение"
        };
        var removeButton = new Button
        {
            Name = $"removeCondition_{index}",
            Text = "Удалить",
            Left = 735,
            Top = 4,
            Width = 85,
            Height = 27
        };

        fieldBox.SelectedIndexChanged += (_, _) => FillOperators(fieldBox, operatorBox);
        removeButton.Click += (_, _) => filterRowsPanel.Controls.Remove(row);

        row.Controls.Add(fieldBox);
        row.Controls.Add(operatorBox);
        row.Controls.Add(valueBox);
        row.Controls.Add(removeButton);
        filterRowsPanel.Controls.Add(row);
        FillOperators(fieldBox, operatorBox);
    }

    private static void FillOperators(ComboBox fieldBox, ComboBox operatorBox)
    {
        var field = (fieldBox.SelectedItem as FieldOption)?.Field;
        var previous = (operatorBox.SelectedItem as OperatorOption)?.Value;
        operatorBox.Items.Clear();

        var operators = field?.SupportedOperations ?? Array.Empty<LogExpEnum>();
        foreach (var operation in operators)
            operatorBox.Items.Add(new OperatorOption(operation));

        if (operators.Count == 0)
        {
            operatorBox.SelectedIndex = -1;
            return;
        }

        var previousIndex = operators.ToList().FindIndex(operation => operation == previous);
        operatorBox.SelectedIndex = previousIndex >= 0 ? previousIndex : 0;
    }

    private void ApplyConditions()
    {
        try
        {
            var result = new List<FilterCondition>();
            foreach (Panel row in filterRowsPanel.Controls)
            {
                var fieldBox = row.Controls.OfType<ComboBox>().FirstOrDefault(control => control.Name.StartsWith("field_", StringComparison.Ordinal));
                var operatorBox = row.Controls.OfType<ComboBox>().FirstOrDefault(control => control.Name.StartsWith("operator_", StringComparison.Ordinal));
                var valueBox = row.Controls.OfType<TextBox>().FirstOrDefault(control => control.Name.StartsWith("value_", StringComparison.Ordinal));

                if (fieldBox?.SelectedItem is not FieldOption fieldOption ||
                    operatorBox?.SelectedItem is not OperatorOption operatorOption)
                    continue;

                var value = valueBox?.Text?.Trim() ?? string.Empty;
                if (value.Length == 0) continue;

                var condition = new FilterCondition(fieldOption.Field.Id, operatorOption.Value, value);
                // Проверяем корректность значения до закрытия диалога.
                fieldOption.Field.CreateRule(condition);
                result.Add(condition);
            }

            if (result.Count == 0)
            {
                MessageBox.Show(this, "Заполните хотя бы одно условие фильтрации.", "Фильтр", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Conditions = result;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Ошибка условия", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private sealed class FieldOption
    {
        public Field Field { get; }
        public FieldOption(Field field) => Field = field;
        public override string ToString() => Field.Name;
    }

    private sealed class OperatorOption
    {
        public LogExpEnum Value { get; }
        public OperatorOption(LogExpEnum value) => Value = value;
        public override string ToString() => Value switch
        {
            LogExpEnum.EQ => "Равно",
            LogExpEnum.NoEQ => "Не равно",
            LogExpEnum.LT => "Меньше",
            LogExpEnum.LE => "Меньше или равно",
            LogExpEnum.GT => "Больше",
            LogExpEnum.GE => "Больше или равно",
            LogExpEnum.Contains => "Содержит",
            LogExpEnum.NoContains => "Не содержит",
            _ => Value.ToString()
        };
    }
}
