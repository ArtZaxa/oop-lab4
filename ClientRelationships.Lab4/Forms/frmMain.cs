using System.Drawing;
using System.Windows.Forms;
using ClientRelationships.Controllers;
using ClientRelationships.Fields;

namespace ClientRelationships.Forms;

public partial class frmMain : Form
{
    private MainContr _controller;

    // Пустой конструктор нужен Visual Studio Designer.
    public frmMain()
    {
        InitializeComponent();
    }

    public frmMain(MainContr controller) : this()
    {
        _controller = controller ?? throw new ArgumentNullException(nameof(controller));
        RefreshFirmList();
    }

    private void AddFirmButton_Click(object sender, EventArgs e)
    {
        if (_controller != null) AddFirm();
    }

    private void EditFirmButton_Click(object sender, EventArgs e)
    {
        if (_controller != null) EditSelectedFirm();
    }

    private void SelectFieldsButton_Click(object sender, EventArgs e)
    {
        if (_controller != null) SelectFields();
    }

    private void FilterButton_Click(object sender, EventArgs e)
    {
        if (_controller != null) OpenFilter();
    }

    private void ResetFilterButton_Click(object sender, EventArgs e)
    {
        if (_controller != null) ResetFilter();
    }

    private void FirmsListView_DoubleClick(object sender, EventArgs e)
    {
        if (_controller != null) EditSelectedFirm();
    }

    private void AddFirm()
    {
        var firm = _controller.CreateNewFirm();
        using var dialog = new frmFirmEdit(firm, _controller.ContactTypes, _controller.UserFieldNames, true);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _controller.AddFirm(firm);
            RefreshFirmList();
        }
    }

    private void EditSelectedFirm()
    {
        if (firmsListView.SelectedItems.Count == 0)
        {
            MessageBox.Show(this, "Сначала выберите фирму.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (firmsListView.SelectedItems[0].Tag is not Firm firm) return;

        using var dialog = new frmFirmEdit(firm, _controller.ContactTypes, _controller.UserFieldNames, false);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _controller.RefreshFirm(firm);
            RefreshFirmList();
        }
    }

    private void SelectFields()
    {
        using var dialog = new frmFields(_controller.AvailableFields, _controller.CurrentManager.View.Fields.Select(f => f.Id));
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                _controller.SetVisibleFields(dialog.SelectedFieldIds);
                RefreshFirmList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Состав полей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void OpenFilter()
    {
        using var dialog = new frmFilter(_controller.AvailableFields);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                _controller.ApplyFilter(dialog.Conditions);
                RefreshFirmList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Фильтрация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void ResetFilter()
    {
        _controller.ResetFilter();
        RefreshFirmList();
    }

    private void RefreshFirmList()
    {
        if (_controller == null) return;

        firmsListView.BeginUpdate();
        try
        {
            firmsListView.Items.Clear();
            firmsListView.Columns.Clear();

            foreach (var field in _controller.CurrentManager.View.Fields)
            {
                var width = Math.Max(130, TextRenderer.MeasureText(field.Name, firmsListView.Font).Width + 35);
                firmsListView.Columns.Add(field.Name, width);
            }

            foreach (var firm in _controller.CurrentManager.Firms)
            {
                var values = _controller.CurrentManager.View.GetValues(firm);
                if (values.Length == 0) continue;

                var item = new ListViewItem(values[0]) { Tag = firm };
                for (var i = 1; i < values.Length; i++)
                    item.SubItems.Add(values[i]);
                firmsListView.Items.Add(item);
            }

            statusLabel.Text = $"Фирм отображается: {_controller.CurrentManager.Firms.Count}";
        }
        finally
        {
            firmsListView.EndUpdate();
        }
    }
}
