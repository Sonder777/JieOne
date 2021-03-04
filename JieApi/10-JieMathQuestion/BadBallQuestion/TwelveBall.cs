using System;

namespace JieApi.BadBallQuestion
{
    //新思路：12个球，12个具有权重的结点，又可否看成12条边？，权值边求异

    /// <summary>
    /// 
    /// </summary>
    public class TwelveBall:BadBallQuestion
    {
        public override void Calculate()
        {
            InitProperties();
            var vr=base.ValidateBase();
            if (!vr.Validate)
            {
                Result = vr.ErrorMessage;
                return;
            }
            BeforeCalculate();
            DoCalculate();
        }

        private void InitProperties()
        {
            AllQty = 12;
            BadQty = 1;
            CompareTimes = 3;
            var randon = new Random();
            var index = randon.Next(1, 12);
            BadIndexs.Add(1, index);
            var badBallType = randon.Next(0,1);
            BadBallType = (BadBallType)badBallType;
            Result = string.Empty;
            BallAArr = new int[AllQty];
            var badBallValue = badBallType;
            var normalBallValue = 1- badBallType;
            Result += "12个球重量为:";
            for (int i=0;i<AllQty;i++)
            {
                if (i == index-1)
                {
                    //badBaall
                    BallAArr[i] = badBallValue;
                }
                else
                {
                    BallAArr[i] = normalBallValue;
                }
                Result += $"{BallAArr[i]}\t";
            }
        }
        private void DoCalculate()
        {
            
            Result += "将球依次等分为3组，每组4个球，取前两组称重比较\n";
            var AArr = new int[4];
            var BArr = new int[4];
            var CArr = new int[4];
            Array.ConstrainedCopy(BallAArr, 0, AArr, 0, 3);
            Array.ConstrainedCopy(BallAArr, 4, BArr, 0, 3);
            Array.ConstrainedCopy(BallAArr, 8, CArr, 0, 3);
            Result += "";
            var compareResult = Compare((int)GetArrSum(AArr), (int)GetArrSum(BArr));
            if (compareResult==BallCompareResult.Equal)
            {
                Result += "两组球等重，坏球在第三组";
            }
            else 
            {
                if (compareResult==BallCompareResult.Heavier)
                {
                    Result += "一组比二组重，第三组球正常球";
                }
                else 
                {
                    Result += "一组比二组轻，第三组球正常球";
                }
            }
        }

        
    }
}
