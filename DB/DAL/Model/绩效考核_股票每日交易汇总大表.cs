using System;
namespace Maticsoft.Model
{
    public enum 归属
    {
        成果库和临时库内容一致,
        属于成果库,
        属于临时库,
        成果库和临时库内容不一致
    }

    /// <summary>
    /// 绩效考核_股票每日交易汇总大表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 绩效考核_股票每日交易汇总大表 
    {
        public 绩效考核_股票每日交易汇总大表()
        { }
        #region Model
        private long _记录标识;
        private string _产品名称 = string.Empty;
        private string _基金经理 = string.Empty;
        private string _股票代码 = string.Empty;
        private string _股票名称 = string.Empty;
        private double _持股数量;
        private double _持股成本;
        private double _市场现价;
        private double _投资成本;
        private double _今日市值;
        private double _浮盈浮亏;
        private double _投资成本占比;
        private double _市值占比;
        private double _浮盈浮亏率;
        private double _本年净值贡献;

        private bool _是否修改过持股数量和持股成本 = false;
        /// <summary>
        /// 
        /// </summary>
        public bool 是否修改过持股数量和持股成本
        {
            set { _是否修改过持股数量和持股成本 = value; }
            get { return _是否修改过持股数量和持股成本; }
        }


        private 归属 _归属;
        public 归属 归属
        {
            get { return _归属; }
            set { _归属 = value; }
        }

        private 绩效考核_股票每日交易汇总大表 _昨日汇总大表;
        /// <summary>
        /// 
        /// </summary>
        public 绩效考核_股票每日交易汇总大表 昨日汇总大表
        {
            set { _昨日汇总大表 = value; }
            get { return _昨日汇总大表; }
        }

        private 绩效考核_股票每日交易汇总小表 _今日汇总小表;
        /// <summary>
        /// 
        /// </summary>
        public 绩效考核_股票每日交易汇总小表 今日汇总小表
        {
            set { _今日汇总小表 = value; }
            get { return _今日汇总小表; }
        }

        /// <summary>
        /// 指的是“当日实现盈亏（当日买卖盈亏）”
        /// </summary>
        private double _当日盈亏;
        private string _时间 = string.Empty;
        private double _买卖累计盈亏;
        private double _今日均价;


        /// <summary>
        /// 
        /// </summary>
        public long 记录标识
        {
            set { _记录标识 = value; }
            get { return _记录标识; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产品名称
        {
            set { _产品名称 = value; }
            get { return _产品名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 基金经理
        {
            set { _基金经理 = value; }
            get { return _基金经理; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 股票代码
        {
            set { _股票代码 = value; }
            get { return _股票代码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 股票名称
        {
            set { _股票名称 = value; }
            get { return _股票名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 持股数量
        {
            set { _持股数量 = value; }
            get { return _持股数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 持股成本
        {
            set { _持股成本 = value; }
            get { return _持股成本; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 市场现价
        {
            set { _市场现价 = value; }
            get { return _市场现价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 投资成本
        {
            set { _投资成本 = value; }
            get { return _投资成本; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 今日市值
        {
            set { _今日市值 = value; }
            get { return _今日市值; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 浮盈浮亏
        {
            set { _浮盈浮亏 = value; }
            get { return _浮盈浮亏; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 投资成本占比
        {
            set { _投资成本占比 = value; }
            get { return _投资成本占比; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 市值占比
        {
            set { _市值占比 = value; }
            get { return _市值占比; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 浮盈浮亏率
        {
            set { _浮盈浮亏率 = value; }
            get { return _浮盈浮亏率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 本年净值贡献
        {
            set { _本年净值贡献 = value; }
            get { return _本年净值贡献; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double 当日盈亏
        {
            set { _当日盈亏 = value; }
            get { return _当日盈亏; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 时间
        {
            set { _时间 = value; }
            get { return _时间; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double 买卖累计盈亏
        {
            set { _买卖累计盈亏 = value; }
            get { return _买卖累计盈亏; }
        }


        /// <summary>
        /// 
        /// </summary>
        public double 今日均价
        {
            set { _今日均价 = value; }
            get { return _今日均价; }
        }

        #endregion Model

        
    }
}

