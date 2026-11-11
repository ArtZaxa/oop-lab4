using ClientRelationships.Fields;
using ClientRelationships.Filtering;
using ClientRelationships.Managers;

namespace ClientRelationships.Controllers;

// Основной контроллер: связывает главную форму, представление фирмы и менеджер фирм.
public sealed class MainContr
{
    private readonly FirmFactory _factory;
    private readonly ContTypeCol _contactTypes;
    private readonly List<Field> _availableFields;
    private readonly FirmMngr _allManager;
    private FirmMngr _currentManager;
    private List<FilterCondition> _activeConditions = new();

    public MainContr(FirmFactory factory, ContTypeCol contactTypes, IEnumerable<Firm> firms)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        _contactTypes = contactTypes ?? new ContTypeCol();
        _availableFields = FieldCatalog.Create(factory);
        var defaultFields = _availableFields.Where(f =>
            new[] { "Name", "Town", "Country", "DateBeg", "CountCont" }.Contains(f.Id)).ToList();
        var view = new FirmVw(defaultFields);
        _allManager = new FirmMngr(firms, view, _availableFields);
        _currentManager = new FirmMngr(_allManager.Firms, view, _availableFields);
    }

    public FirmMngr CurrentManager => _currentManager;
    public IReadOnlyList<Field> AvailableFields => _availableFields.AsReadOnly();
    public IReadOnlyList<ContType> ContactTypes => _contactTypes.Items;
    public IReadOnlyList<string> UserFieldNames => _factory.flds.Take(5).ToList().AsReadOnly();

    public Firm CreateNewFirm() => _factory.Create(string.Empty);

    public void AddFirm(Firm firm)
    {
        _allManager.Add(firm);
        ResetFilter();
    }

    public void RefreshFirm(Firm firm)
    {
        // Фирмы хранятся по ссылке; после редактирования достаточно пересобрать текущую выборку.
        if (firm == null) return;
        ReapplyCurrentFilter();
    }

    public void SetVisibleFields(IEnumerable<string> fieldIds)
    {
        var ids = new HashSet<string>(fieldIds ?? Enumerable.Empty<string>());
        var selected = _availableFields.Where(f => ids.Contains(f.Id)).ToList();
        if (selected.Count == 0) throw new InvalidOperationException("Выберите хотя бы одно поле для отображения.");
        var view = new FirmVw(selected);
        _allManager.SetView(view);
        ReapplyCurrentFilter();
    }

    public void ApplyFilter(IEnumerable<FilterCondition> conditions)
    {
        _activeConditions = (conditions ?? Enumerable.Empty<FilterCondition>()).ToList();
        ReapplyCurrentFilter();
    }

    public void ResetFilter()
    {
        _activeConditions.Clear();
        _currentManager = new FirmMngr(_allManager.Firms, _allManager.View, _availableFields);
    }

    private void ReapplyCurrentFilter()
    {
        if (_activeConditions.Count == 0)
        {
            _currentManager = new FirmMngr(_allManager.Firms, _allManager.View, _availableFields);
            return;
        }
        var filterController = new FilterContr(_allManager);
        _currentManager = filterController.FirmRespond(_activeConditions);
    }
}
