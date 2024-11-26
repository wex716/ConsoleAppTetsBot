namespace ConsoleAppTetsBot.org.example.Buttons;

public class InlineButtonsStorage
{
    public static InlineButton MovePrevShow { get; } = new InlineButton("Назад", "MovePrevShow");

    public static InlineButton BackToMenu { get; } = new InlineButton("Главное меню", "BackToMenu");

    public static InlineButton ShowQuestionsStart { get; } = new InlineButton("Частые вопросы", "ShowQuestionsStart");

    public static InlineButton SubmitApplication { get; } = new InlineButton("Оставить заявку", "SubmitApplication");

    public static InlineButton SubmitHistory { get; } = new InlineButton("История заявок", "SubmitHistory");

    public static InlineButton ViewProblemComputer { get; } = new InlineButton("Компьютер", "ViewProblemComputer");
    public static InlineButton ViewProblemPrinter { get; } = new InlineButton("Принтер", "ViewProblemPrinter");

    public static InlineButton ViewProblemProjector { get; } = new InlineButton("Проектор", "ViewProblemProjector");


    public static InlineButton First { get; } = new InlineButton("1", "First");

    public static InlineButton Second { get; } = new InlineButton("2", "Second");

    public static InlineButton Third { get; } = new InlineButton("3", "Third");

    public static InlineButton YesSendPhoto { get; } = new InlineButton("Да", "YesSendPhoto");
    public static InlineButton NoSendPhoto { get; } = new InlineButton("Нет", "NoSendPhoto");
    public static InlineButton SendApplication { get; } = new InlineButton("Отправить", "SendApplication");
    public static InlineButton CancelApplication { get; } = new InlineButton("Отменить", "CancelApplication");


    public static InlineButton FirstAddressPlace { get; } = new InlineButton("Свобода 33", "FirstAddressPlace");
    public static InlineButton SecondAddressPlace { get; } = new InlineButton("Лодочная 7", "SecondAddressPlace");
    public static InlineButton ThirdAddressPlace { get; } = new InlineButton("Молдавская 5", "ThirdAddressPlace");
    public static InlineButton FourAddressPlace { get; } = new InlineButton("Просп. Буденного 35", "FourAddressPlace");

    public static InlineButton FiveAddressPlace { get; } =
        new InlineButton("Волгоградский проспект 42 корпус 5.", "FiveAddressPlace");
}