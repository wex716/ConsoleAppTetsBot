namespace ConsoleAppTetsBot.org.example.statemachine;

public enum State
{
    #region начальное состояние

    WaitingCommandStart,
    WaitingQuestionsOrApplicationOrHistory,
    WaitingQuestions,
    WaitingSubmitApplication,
    WaitingApplication,

    #endregion

    #region просмотр компьютера

    WaitingViewProblemComputer,
    WaitingFirstInfoProblemComputer,
    WaitingSecondInfoProblemComputer,
    WaitingThirdInfoProblemComputer,

    #endregion

    #region просмотр принтера

    WaitingViewProblemPrinter,
    WaitingFirstInfoProblemPrinter,
    WaitingSecondInfoProblemPrinter,

    #endregion
    
    #region просмотр проектора

    WaitingViewProblemProjector,
    WaitingFirstInfoProblemProjector,
    WaitingSecondInfoProblemProjector,
    WaitingThirdInfoProblemProjector,

    #endregion

    #region заявка

    WaitingInputCabinetNumber,
    WaitingInputFullName,
    WaitingInputNumberPhone,
    WaitingDescriptionProblem,
    WaitingQuestionAddPhoto,
    WaitingPhoto,
    WaitingDataVerification,
    WaitingReadApplication

    #endregion
}