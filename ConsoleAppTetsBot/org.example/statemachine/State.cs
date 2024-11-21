namespace ConsoleAppTetsBot.org.example.statemachine;

public enum State
{
    WaitingCommandStart,
    WaitingQuestionsOrApplicationOrHistory,
    WaitingQuestions,
    WaitingViewProblemComputer,
    WaitingFirstInfoProblemComputer,
    WaitingSecondInfoProblemComputer,
    WaitingThirdInfoProblemComputer,
    WaitingViewProblemPrinter,
    WaitingFirstInfoProblemPrinter,
    WaitingSecondInfoProblemPrinter,
    WaitingViewProblemProjector,
    WaitingFirstInfoProblemProjector,
    WaitingSecondInfoProblemProjector,
    WaitingThirdInfoProblemProjector
}