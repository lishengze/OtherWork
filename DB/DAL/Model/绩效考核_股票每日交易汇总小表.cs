using System;
namespace Maticsoft.Model
{
   
	/// <summary>
	/// 绩效考核_股票每日交易汇总小表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_股票每日交易汇总小表
	{
		public 绩效考核_股票每日交易汇总小表()
		{}
		#region Model
		private long _记录标识;
        private string _股票代码 = string.Empty;
        private string _基金经理 = string.Empty;
        private string _产品名称 = string.Empty;
        private string _股票名称 = string.Empty;
        private string _时间 = string.Empty;
		private long _今日买入股;
		private double _买入均价;
		private double _买入金额;
		private long _今日卖出股;
		private double _卖出均价;
		private double _卖出金额;
		private double _买入手续费;
		private double _买入过户费;
		private double _买入印花税;
		private double _卖出手续费;
		private double _卖出过户费;
		private double _卖出印花税;
		private double _买入清算金额;
		private double _卖出清算金额;
        private bool _是否为止损指令;

       
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
		public string 股票代码
		{
			set{ _股票代码=value;}
			get{return _股票代码;}
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
		public string 产品名称
		{
			set{ _产品名称=value;}
			get{return _产品名称;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 股票名称
		{
			set{ _股票名称=value;}
			get{return _股票名称;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string 时间
		{
			set{ _时间=value;}
			get{return _时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long 今日买入股
		{
			set{ _今日买入股=value;}
			get{return _今日买入股;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 买入均价
		{
			set{ _买入均价=value;}
			get{return _买入均价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 买入金额
		{
			set{ _买入金额=value;}
			get{return _买入金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long 今日卖出股
		{
			set{ _今日卖出股=value;}
			get{return _今日卖出股;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 卖出均价
		{
			set{ _卖出均价=value;}
			get{return _卖出均价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 卖出金额
		{
			set{ _卖出金额=value;}
			get{return _卖出金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 买入手续费
		{
			set{ _买入手续费=value;}
			get{return _买入手续费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 买入过户费
		{
			set{ _买入过户费=value;}
			get{return _买入过户费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 买入印花税
		{
			set{ _买入印花税=value;}
			get{return _买入印花税;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 卖出手续费
		{
			set{ _卖出手续费=value;}
			get{return _卖出手续费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 卖出过户费
		{
			set{ _卖出过户费=value;}
			get{return _卖出过户费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 卖出印花税
		{
			set{ _卖出印花税=value;}
			get{return _卖出印花税;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 买入清算金额
		{
			set{ _买入清算金额=value;}
			get{return _买入清算金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 卖出清算金额
		{
			set{ _卖出清算金额=value;}
			get{return _卖出清算金额;}
		}

        public bool 是否为止损指令
		{
            set { _是否为止损指令 = value; }
            get { return _是否为止损指令; }
		}
        
		#endregion Model

	}
}

