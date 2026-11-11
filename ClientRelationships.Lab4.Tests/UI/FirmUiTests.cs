using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using FlaApplication = FlaUI.Core.Application;

namespace ClientRelationships.Lab4.Tests.UI;

[TestClass]
public class FirmUiTests
{
    private FlaApplication _app;
    private UIA3Automation _automation;
    private Window _main;

    [TestInitialize]
    public void StartApplication()
    {
        var path = Environment.GetEnvironmentVariable("CLIENT_RELATIONSHIPS_EXE");
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            Assert.Fail("Перед запуском тестов задайте переменную CLIENT_RELATIONSHIPS_EXE с полным путём к ClientRelationships.Lab4.exe.");

        _app = FlaApplication.Launch(path);
        _automation = new UIA3Automation();
        _main = _app.GetMainWindow(_automation);
        Assert.IsNotNull(_main, "Главная форма не открылась.");
    }

    [TestCleanup]
    public void StopApplication()
    {
        try { _app?.Close(); } catch { }
        _app?.Dispose();
        _automation?.Dispose();
    }

    [TestMethod]
    public void AddNewFirm_ThroughGraphicalInterface_FirmAppearsInList()
    {
        Click(_main, "addFirmButton");
        var edit = WaitForWindow("Добавление фирмы");
        SetText(edit, "firmNameTextBox", "ООО Автотест добавление");
        SetText(edit, "firmTownTextBox", "Казань");
        Click(edit, "saveFirmButton");

        Assert.IsTrue(WaitForListItem("ООО Автотест добавление"), "Добавленная фирма не появилась в главном списке.");
    }

    [TestMethod]
    public void FilterByTownAndContactBeginDate_ThroughGraphicalInterface_ReturnsMatchingFirm()
    {
        Click(_main, "addFirmButton");
        var edit = WaitForWindow("Добавление фирмы");
        SetText(edit, "firmNameTextBox", "ООО Автотест фильтрация");
        SetText(edit, "firmTownTextBox", "Москва");

        Click(edit, "addContactButton");
        var contact = WaitForWindow("Добавление контакта");
        SetText(contact, "contactBeginDateTextBox", "2026-11-09 10:00");
        SetText(contact, "contactEndDateTextBox", "2026-11-09 11:00");
        SetText(contact, "contactDescrTextBox", "Контакт для UI-теста");
        SetText(contact, "contactDataInfoTextBox", "Проверка даты начала контакта");
        SelectCombo(contact, "contactTypeComboBox", "Звонок");
        Click(contact, "saveContactButton");
        Click(edit, "saveFirmButton");

        Click(_main, "filterButton");
        var filter = WaitForWindow("Настройка фильтра");
        SelectCombo(filter, "field_0", "Город");
        SelectCombo(filter, "operator_0", "Равно");
        SetText(filter, "value_0", "Москва");
        Click(filter, "addConditionButton");
        SelectCombo(filter, "field_1", "Дата начала контакта");
        SelectCombo(filter, "operator_1", "Больше или равно");
        SetText(filter, "value_1", "2026-11-01");
        Click(filter, "applyFilterButton");

        Assert.IsTrue(WaitForListItem("ООО Автотест фильтрация"), "Фирма, удовлетворяющая условиям по городу и дате контакта, не найдена.");
    }

    private Window WaitForWindow(string titlePart)
    {
        for (var i = 0; i < 40; i++)
        {
            var window = _app.GetAllTopLevelWindows(_automation).FirstOrDefault(w => w.Title.Contains(titlePart, StringComparison.OrdinalIgnoreCase));
            if (window != null) return window;
            Thread.Sleep(150);
        }
        Assert.Fail("Не открылась форма: " + titlePart);
        return null;
    }

    private bool WaitForListItem(string text)
    {
        for (var i = 0; i < 30; i++)
        {
            var list = _main.FindFirstDescendant(cf => cf.ByAutomationId("firmsListView"));
            var items = list?.FindAllDescendants(cf => cf.ByControlType(ControlType.ListItem)) ?? Array.Empty<AutomationElement>();
            if (items.Any(item => item.Name.Contains(text, StringComparison.OrdinalIgnoreCase))) return true;
            Thread.Sleep(150);
        }
        return false;
    }

    private static void Click(AutomationElement window, string automationId)
    {
        var element = window.FindFirstDescendant(cf => cf.ByAutomationId(automationId));
        Assert.IsNotNull(element, "Не найден элемент интерфейса: " + automationId);
        element.AsButton().Invoke();
    }

    private static void SetText(AutomationElement window, string automationId, string value)
    {
        var element = window.FindFirstDescendant(cf => cf.ByAutomationId(automationId));
        Assert.IsNotNull(element, "Не найдено поле ввода: " + automationId);
        element.AsTextBox().Text = value;
    }

    private static void SelectCombo(AutomationElement window, string automationId, string value)
    {
        var element = window.FindFirstDescendant(cf => cf.ByAutomationId(automationId));
        Assert.IsNotNull(element, "Не найден список: " + automationId);
        element.AsComboBox().Select(value);
    }
}
