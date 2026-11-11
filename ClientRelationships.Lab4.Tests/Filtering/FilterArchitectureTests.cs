using ClientRelationships.Controllers;
using ClientRelationships.Expressions;
using ClientRelationships.Fields;
using ClientRelationships.Filtering;
using ClientRelationships.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientRelationships.Lab4.Tests.Filtering;

[TestClass]
public class FilterArchitectureTests
{
    [TestMethod]
    public void TownField_CreatesItsOwnSpecializedRule()
    {
        var field = new TownField();

        var rule = field.CreateRule(
            new FilterCondition(field.Id, LogExpEnum.Contains, "Каз"));

        Assert.IsInstanceOfType(rule, typeof(TownRule));
    }

    [TestMethod]
    public void DateBeginField_CreatesDateRule()
    {
        var field = new DateBegField();

        var rule = field.CreateRule(
            new FilterCondition(field.Id, LogExpEnum.GE, "2026-11-01"));

        Assert.IsInstanceOfType(rule, typeof(DateBegRule));
    }

    [TestMethod]
    public void StringField_DoesNotAcceptNumericComparison()
    {
        var field = new TownField();
        var condition = new FilterCondition(field.Id, LogExpEnum.GT, "Казань");

        Assert.ThrowsException<ArgumentException>(() => field.CreateRule(condition));
    }

    [TestMethod]
    public void DateField_DoesNotAcceptContainsOperation()
    {
        var field = new DateBegField();
        var condition = new FilterCondition(field.Id, LogExpEnum.Contains, "2026");

        Assert.ThrowsException<ArgumentException>(() => field.CreateRule(condition));
    }

    [TestMethod]
    public void FilterController_AppliesSeveralConditionsUsingLogicalAnd()
    {
        var mainType = new SbFirmType("Основное подразделение", isMain: true);
        var factory = FirmFactory.Instance(mainType);
        var contactType = new ContType("Звонок");

        var matchingFirm = factory.Create("ООО Подходящая");
        matchingFirm.Town = "Казань";
        matchingFirm.AddContact(new Contact(
            new DateTime(2026, 11, 5, 9, 0, 0),
            new DateTime(2026, 11, 5, 10, 0, 0),
            "Звонок",
            "Подходит по дате и городу",
            contactType));

        var wrongDateFirm = factory.Create("ООО Неверная дата");
        wrongDateFirm.Town = "Казань";
        wrongDateFirm.AddContact(new Contact(
            new DateTime(2026, 10, 5, 9, 0, 0),
            new DateTime(2026, 10, 5, 10, 0, 0),
            "Звонок",
            "Не подходит по дате",
            contactType));

        var wrongTownFirm = factory.Create("ООО Другой город");
        wrongTownFirm.Town = "Москва";
        wrongTownFirm.AddContact(new Contact(
            new DateTime(2026, 11, 5, 9, 0, 0),
            new DateTime(2026, 11, 5, 10, 0, 0),
            "Звонок",
            "Не подходит по городу",
            contactType));

        var fields = FieldCatalog.Create(factory);
        var view = new FirmVw(fields);
        var manager = new FirmMngr(
            new[] { matchingFirm, wrongDateFirm, wrongTownFirm },
            view,
            fields);

        var filterController = new FilterContr(manager);
        var result = filterController.FirmRespond(new[]
        {
            new FilterCondition("Town", LogExpEnum.EQ, "Казань"),
            new FilterCondition("DateBeg", LogExpEnum.GE, "2026-11-01")
        });

        Assert.AreEqual(1, result.Firms.Count);
        Assert.AreSame(matchingFirm, result.Firms[0]);
    }
}
