namespace ConsoleAppTetsBot.org.example.Buttons;

public class InlineButtonsStorage
{
    public static InlineButton MovePrevShow { get; } = new InlineButton("Назад", "MovePrevShow");
    
    public static InlineButton BackToMenu { get; } = new InlineButton("Главное меню", "BackToMenu");
    
    public static InlineButton ShowQuestionsStart { get; } = new InlineButton("Частые вопросы", "ShowQuestionsStart");
    
    public static InlineButton SubmitApplication { get; } = new InlineButton("Оставить заявку", "SubmitApplication");
    
    public static InlineButton SubmitHistory { get; } = new InlineButton("История заявок", "SubmitHistory");
    
    public static InlineButton ViewProblemComputer { get; } = new InlineButton("Компьютер", "ViewProblemComputer");
    
    public static InlineButton First { get; } = new InlineButton("1", "First");
    
    public static InlineButton Second { get; } = new InlineButton("2", "Second");
    
    public static InlineButton Third { get; } = new InlineButton("3", "Third");
    
    public static InlineButton ViewProblemPrinter { get; } = new InlineButton("Принтер", "ViewProblemPrinter");
    
    public static InlineButton ViewProblemProjector { get; } = new InlineButton("Проектор", "ViewProblemProjector");
}