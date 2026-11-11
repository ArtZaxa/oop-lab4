using System.Windows.Forms;
using ClientRelationships.Controllers;
using ClientRelationships.Forms;

namespace ClientRelationships;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var mainType = new SbFirmType("Основное", true);
        var factory = FirmFactory.Instance(mainType);
        var contactTypes = new ContTypeCol();
        contactTypes.Add(new ContType("Звонок", "Телефонный разговор"));
        contactTypes.Add(new ContType("Письмо", "Электронная почта"));
        contactTypes.Add(new ContType("Встреча", "Личная встреча"));

        var firms = new List<Firm>();
        var firm1 = factory.Create("ООО Ромашка");
        firm1.Town = "Москва";
        firm1.Country = "Россия";
        firm1.Email = "info@romashka.example";
        firm1.AddContact(new Contact(DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-2).AddHours(1),
            "Первичный звонок", "Обсудили сотрудничество", contactTypes[0]));
        firms.Add(firm1);

        var firm2 = factory.Create("ЗАО Лютик");
        firm2.Town = "Санкт-Петербург";
        firm2.Country = "Россия";
        firm2.AddContact(new Contact(DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-10).AddHours(1),
            "Отправили предложение", "Коммерческое предложение", contactTypes[1]));
        firms.Add(firm2);

        var controller = new MainContr(factory, contactTypes, firms);
        Application.Run(new frmMain(controller));
    }
}
