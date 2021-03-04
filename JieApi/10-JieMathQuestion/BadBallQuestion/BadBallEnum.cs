using System.ComponentModel;

namespace JieMathQuestion.BadBallQuestion
{
    public enum BallWeightType
    {
        [Description("更轻")]
        Lighter = 0,
        [Description("更重")]
        Heavier = 1
    }
    public enum BadBallType
    {
        [Description("更轻")]
        Lighter = 0,
        [Description("更重")]
        Heavier = 1
    }
    public enum BallCompareResult
    {
        [Description("轻于")]
        Lighter = 0,
        [Description("同重于")]
        Equal = 1,
        [Description("重于")]
        Heavier = 2
    }
}
