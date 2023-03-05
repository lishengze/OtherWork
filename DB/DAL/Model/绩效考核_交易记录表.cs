using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_交易记录表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_交易记录表
	{
		public 绩效考核_交易记录表()
		{}
		#region Model
		private long _记录标识;
        private string _产品名称 = string.Empty;
        private string _基金经理 = string.Empty;
        private string _股票代码 = string.Empty;
        private string _股票名称 = string.Empty;
        private string _交易方向 = string.Empty;
		private long _股数;
		private double _成交均价;
		private double _成交金额;
		private double _手续费;
		private double _过户费;
		private double _印花税;
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
		public string 股票代码
		{
			set{ _股票代码=value;}
			get{return _股票代码;}
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
		public string 交易方向
		{
			set{ _交易方向=value;}
			get{return _交易方向;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long 股数
		{
			set{ _股数=value;}
			get{return _股数;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 成交均价
		{
			set{ _成交均价=value;}
			get{return _成交均价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 成交金额
		{
			set{ _成交金额=value;}
			get{return _成交金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 手续费
		{
			set{ _手续费=value;}
			get{return _手续费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 过户费
		{
			set{ _过户费=value;}
			get{return _过户费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 印花税
		{
			set{ _印花税=value;}
			get{return _印花税;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string 时间
		{
			set{ _时间=value;}
			get{return _时间;}
		}
		#endregion Model

	}
     


}

