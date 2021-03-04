using JieBaseHelper.ValidateHelper;
using JieMathQuestion.BadBallQuestion;
using System.Collections.Generic;
using System.Linq;

namespace JieApi.BadBallQuestion
{


    public class BadBallQuestion
    {
        public int? AllQty { get; protected set; }
        public int? BadQty { get; protected set; }
        protected BadBallType? BadBallType { get; set; }
        public Dictionary<int,int> BadIndexs { get; protected set; }
        public int? CompareTimes { get; protected set; }
        protected List<Ball> AllBalls { get; set; }
        public string Result { get; protected set; }
        public ValidateResult InitBalls()
        {
            if (!ValidateBase().Validate)
            {
                return ValidateResult.Error("总球个数与坏球个数不得为空！");
            }
            for (int i=0;i<AllQty;i++)
            {
                var ball = new Ball();
                ball.BallIndex = (i + 1).ToString();
                ball.IsNormal = !BadIndexs.Values.Contains(i+1);
                ball.Weight = (BallWeightType)BadBallType;
                AllBalls.Add(ball);
            }
            return ValidateResult.Success();
        }
        protected ValidateResult ValidateBase() 
        {
            if (!AllQty.HasValue || !BadQty.HasValue)
            {
                return ValidateResult.Error("总球个数与坏球个数不得为空！");
            }
            if (BadQty > AllQty || BadQty == 0 || BadIndexs.Count != BadQty)
            {
                return ValidateResult.Error("坏球存在个数不合理！");
            }
            if (BadIndexs.Values.Max() > AllQty)
            {
                return ValidateResult.Error("坏球下标超出总球个数！");
            }
            return ValidateResult.Success();
        }
        protected void BeforeCalculate()
        {
            Result += $"{AllQty}个球重量依次分别如下:";
            for (int i=0;i<AllBalls.Count;i++)
            {
                Result += $"第{i}个球重量为{AllBalls[i]}\t";
            }
            Result += $"比较过程:\n";
        }
        public virtual void Calculate()
        { 
        
        }

        protected BallCompareResult Compare(int a, int b)
        {
            if (a > b)
            {
                return BallCompareResult.Heavier;
            }
            if (a < b)
            {
                return BallCompareResult.Lighter;
            }
            return BallCompareResult.Equal;
        }
    }
}
