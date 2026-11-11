namespace ClientRelationships.Fields;

internal static class ContactFieldHelper
{
    // Единая стратегия отображения: последний контакт основного подразделения по дате начала.
    public static Contact LastMainContact(Firm firm) =>
        firm?.MainContacts.OrderByDescending(c => c.BeginDt).FirstOrDefault();
}
