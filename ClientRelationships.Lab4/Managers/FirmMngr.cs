using ClientRelationships.Fields;
using ClientRelationships.Filtering;

namespace ClientRelationships.Managers;

public sealed class FirmMngr
{
    private readonly List<Firm> _firms;
    private readonly List<Field> _availableFields;
    public IReadOnlyList<Firm> Firms => _firms.AsReadOnly();
    public IReadOnlyList<Field> AvailableFields => _availableFields.AsReadOnly();
    public FirmVw View { get; private set; }

    public FirmMngr(IEnumerable<Firm> firms, FirmVw view, IEnumerable<Field> availableFields = null)
    {
        _firms = (firms ?? Enumerable.Empty<Firm>()).Where(f => f != null).ToList();
        View = view?.Clone() ?? throw new ArgumentNullException(nameof(view));
        _availableFields = (availableFields ?? View.Fields).Select(f => f.Clone()).ToList();
    }

    public void Add(Firm firm)
    {
        if (firm == null) throw new ArgumentNullException(nameof(firm));
        _firms.Add(firm);
    }

    public void SetView(FirmVw view) => View = view?.Clone() ?? throw new ArgumentNullException(nameof(view));

    public FirmMngr Filter(IEnumerable<FilterRule> rules)
    {
        var ruleList = (rules ?? Enumerable.Empty<FilterRule>()).ToList();
        var result = _firms.Where(firm => ruleList.All(rule => rule.IsMatch(firm)));
        return new FirmMngr(result, View, _availableFields);
    }
}
