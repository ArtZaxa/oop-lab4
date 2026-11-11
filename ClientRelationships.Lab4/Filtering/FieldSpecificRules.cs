using ClientRelationships.Expressions;
using ClientRelationships.Fields;

namespace ClientRelationships.Filtering;

// Специализированные правила названы по полям, как на рис. 8 методички.
// Общая реализация сравнения остаётся в типизированных базовых правилах.
public sealed class NameRule : StrFieldRule { public NameRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class CountryRule : StrFieldRule { public CountryRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class RegionRule : StrFieldRule { public RegionRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class TownRule : StrFieldRule { public TownRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class PostInxRule : StrFieldRule { public PostInxRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class WebRule : StrFieldRule { public WebRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class UsrFieldRule : StrFieldRule { public UsrFieldRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class DateInRule : DateFieldRule { public DateInRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class DateBegRule : DateFieldRule { public DateBegRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class DateEndRule : DateFieldRule { public DateEndRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class ContCountRule : IntFieldRule { public ContCountRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class StreetRule : StrFieldRule { public StreetRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class EmailRule : StrFieldRule { public EmailRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class ContTypeRule : StrFieldRule { public ContTypeRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class ContDescrRule : StrFieldRule { public ContDescrRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
public sealed class ContDataInfoRule : StrFieldRule { public ContDataInfoRule(Field f, LogExpEnum op, string value) : base(f, op, value) { } }
