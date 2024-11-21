using ConsoleAppTetsBot.org.example.service.logic;
using ConsoleAppTetsBot.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service;

public class ServiceManager
{
    private Dictionary<State, Func<string, TransmittedData, BotTextMessage>>
        _methods;

    private StartLogic startLogic;
    private FaqLogic faqLogic;

    public ServiceManager()
    {
        _methods =
            new Dictionary<State, Func<string, TransmittedData, BotTextMessage>>();
        startLogic = new StartLogic();
        faqLogic = new FaqLogic();

        // начало работы бота
        _methods.Add(State.WaitingCommandStart, startLogic.ProcessWaitingCommandStart);
        /*_methods.Add(State.WaitingQuestionsOrApplicationOrHistory,
            startLogic.ProcessWaitingQuestionsOrApplicationOrHistory);
        _methods.Add(State.WaitingQuestions, startLogic.ProcessWaitingQuestions);

        // просмотр комп
        _methods.Add(State.WaitingViewProblemComputer, faqLogic.ProcessWaitingViewProblemComputer);
        _methods.Add(State.WaitingFirstInfoProblemComputer, faqLogic.ProcessWaitingFirstInfoProblemComputer);
        _methods.Add(State.WaitingSecondInfoProblemComputer, faqLogic.ProcessWaitingSecondInfoProblemComputer);
        _methods.Add(State.WaitingThirdInfoProblemComputer, faqLogic.ProcessWaitingThirdInfoProblemComputer);

        // принтер
        _methods.Add(State.WaitingViewProblemPrinter, faqLogic.ProcessWaitingViewProblemPrinter);
        _methods.Add(State.WaitingFirstInfoProblemPrinter, faqLogic.ProcessWaitingFirstInfoProblemPrinter);
        _methods.Add(State.WaitingSecondInfoProblemPrinter, faqLogic.ProcessWaitingSecondInfoProblemPrinter);

        // проектор
        _methods.Add(State.WaitingViewProblemProjector, faqLogic.ProcessWaitingViewProblemProjector);
        _methods.Add(State.WaitingFirstInfoProblemProjector, faqLogic.ProcessWaitingFirstInfoProblemProjector);
        _methods.Add(State.WaitingSecondInfoProblemProjector, faqLogic.ProcessWaitingSecondInfoProblemProjector);
        _methods.Add(State.WaitingThirdInfoProblemProjector, faqLogic.ProcessWaitingThirdInfoProblemProjector);*/
    }

    public BotTextMessage ProcessBotUpdate(string textData, TransmittedData transmittedData)
    {
        var serviceMethod = _methods[transmittedData.State];

        return serviceMethod.Invoke(textData, transmittedData);
    }
}