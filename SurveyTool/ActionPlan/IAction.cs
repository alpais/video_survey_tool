namespace SurveyTool.ActionPlan
{
    public interface IAction
    {
        string RatingFile { get; }
        bool AlreadyRated { get; }
    }
}
