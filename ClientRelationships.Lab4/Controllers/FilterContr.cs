using ClientRelationships.Filtering;
using ClientRelationships.Managers;

namespace ClientRelationships.Controllers;

// Частный контроллер фильтрации (рис. 11 и 13 методички).
public sealed class FilterContr
{
    private readonly FirmMngr _sourceManager;
    public FilterContr(FirmMngr sourceManager)
    {
        _sourceManager = sourceManager ?? throw new ArgumentNullException(nameof(sourceManager));
    }

    public FirmMngr FirmRespond(IEnumerable<FilterCondition> conditions)
    {
        var rules = (conditions ?? Enumerable.Empty<FilterCondition>())
            .Select(condition =>
            {
                var field = _sourceManager.AvailableFields.FirstOrDefault(f => f.Id == condition.FieldId)
                    ?? throw new KeyNotFoundException("Поле для фильтрации не найдено: " + condition.FieldId);
                return field.CreateRule(condition);
            })
            .ToList();
        return _sourceManager.Filter(rules);
    }
}
