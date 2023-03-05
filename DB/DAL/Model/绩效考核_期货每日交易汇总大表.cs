using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_期货每日交易汇总大表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary> 
    [Serializable]
	public partial class 绩效考核_期货每日交易汇总大表
	{
		public 绩效考核_期货每日交易汇总大表()
		{}

		
        #region Model
	 
        private long _记录标识;
        private string _产品名称 = string.Empty;
        private string _基金经理 = string.Empty;
        private string _期货代码 = string.Empty;
        private string _期货名称 = string.Empty;
        private double _卖持量;
		private double _卖持仓成本;
		private double _市场现价;
		private double _合约成本;
		private double _持仓保证金; 
		private double _当日盈亏;
        private double _总盈亏;
        private double _实现盈亏;
        private string _时间 = string.Empty;


		/// <summary>
		/// 
		/// </summary>
		public long 记录标识
		{
			set{ _记录标识=value;}
			get{return _记录标识;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 产品名称
		{
			set{ _产品名称=value;}
			get{return _产品名称;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 基金经理
		{
			set{ _基金经理=value;}
			get{return _基金经理;}
		}
      
		/// <summary>
		/// 
		/// </summary>
		public string 期货代码
		{
			set{ _期货代码=value;}
			get{return _期货代码;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 期货名称
		{
			set{ _期货名称=value;}
			get{return _期货名称;}
		}
       
		/// <summary>
		/// 
		/// </summary>
        public double 卖持量
		{
			set{ _卖持量=value;}
			get{return _卖持量;}
		}
		/// <summary>
		///  
		/// </summary>
		public double 卖持仓成本
		{
			set{ _卖持仓成本=value;}
			get{return _卖持仓成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 市场现价
		{
			set{ _市场现价=value;}
			get{return _市场现价;}
		}
          
		/// <summary>
		/// 
		/// </summary>
		public double 合约成本
		{
			set{ _合约成本=value;}
			get{return _合约成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 持仓保证金
		{
			set{ _持仓保证金=value;}
			get{return _持仓保证金;}
		} 
		/// <summary>
		/// 
		/// </summary>
		public double 当日盈亏
		{
			set{ _当日盈亏=value;}
			get{return _当日盈亏;}
		}

        /// <summary>
		/// 
		/// </summary>
		public double 总盈亏
		{
			set{ _总盈亏=value;}
			get{return _总盈亏;}
		}

        /// <summary>
        /// 
        /// </summary>
        public double 实现盈亏
        {
            set { _实现盈亏 = value; }
            get { return _实现盈亏; }
        }

		/// <summary>
		/// 
		/// </summary>
        public string 时间
		{
			set{ _时间=value;}
			get{return _时间;}
		}
 
        #region 
        //private 绩效考核_期货每日交易汇总大表 _昨日汇总大表;
        ///// <summary>
        ///// 
        ///// </summary>
        //public 绩效考核_期货每日交易汇总大表 昨日汇总大表
        //{
        //    set { _昨日汇总大表 = value; }
        //    get { return _昨日汇总大表; }
        //}

        //private 绩效考核_期货每日交易汇总小表 _今日汇总小表;
        ///// <summary>
        ///// 
        ///// </summary>
        //public 绩效考核_期货每日交易汇总小表 今日汇总小表
        //{
        //    set { _今日汇总小表 = value; }
        //    get { return _今日汇总小表; }
        //} 
         
        #endregion
        #endregion Model

    }
}

