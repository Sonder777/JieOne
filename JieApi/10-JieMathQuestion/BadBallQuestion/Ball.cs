namespace JieMathQuestion.BadBallQuestion
{
    public class Ball
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string BallIndex{ set; get; }
        /// <summary>
        /// 是否正常球
        /// </summary>
        public bool? IsNormal{ set; get; }
        /// <summary>
        /// 重量，0或1
        /// </summary>
        public BallWeightType? Weight{ set; get; }
    }
}
