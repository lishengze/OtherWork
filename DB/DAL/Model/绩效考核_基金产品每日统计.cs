using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_基金产品每日统计:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_基金产品每日统计
	{
		public 绩效考核_基金产品每日统计()
		{}
		#region Model
		private long _记录标识;
        private string _产品名称 = string.Empty;
		private double _资产总额;
		private double _资金余额;
        private string _资金资产比例 = string.Empty;
        private string _今年收益率 = string.Empty;
		private double _单位净值;
        private string _时间 = string.Empty;  
        private double _今年最大净值;
        private string _回撤率 = string.Empty;



        /// <summary>
        /// add by qhc
        /// </summary>
        private double _基金份额;
        /// <summary>
        /// add by qhc
        /// </summary>
        public double 基金份额
        {
            get { return _基金份额; }
            set { _基金份额 = value; }
        }


        /// <summary>
        /// add by qhc
        /// </summary>
        private double _基准日净值;
        /// <summary>
        /// add by qhc
        /// </summary>
        public double 基准日净值
        {
            get { return _基准日净值; }
            set { _基准日净值 = value; }
        }

        /// <summary>
        /// add by qhc
        /// </summary>
        private double _申购赎回调整数;

        /// <summary>
        /// add by qhc
        /// </summary>
        public double 申购赎回调整数
        {
            get { return _申购赎回调整数; }
            set { _申购赎回调整数 = value; }
        }

        /// <summary>
        /// add by qhc
        /// </summary>
        private double _股票资产总额;

        /// <summary>
        /// add by qhc
        /// </summary>
        public double 股票资产总额
        {
            get { return _股票资产总额; }
            set { _股票资产总额 = value; }
        }

        #region 期货属性

        /// <summary>
        /// add by qhc
        /// </summary>
        private double _期货资产总额;

        /// <summary>
        /// add by qhc
        /// </summary>
        public double 期货资产总额
        {
            get { return _期货资产总额; }
            set { _期货资产总额 = value; }
        }

         /// <summary>
        /// add by qhc
        /// </summary>
        private double _期货资金余额;

        /// <summary>
        /// add by qhc
        /// </summary>
        public double 期货资金余额
        {
            get { return _期货资金余额; }
            set { _期货资金余额 = value; }
        }

         /// <summary>
        /// add by qhc
        /// </summary>
        private double _期货今年收益率;

        /// <summary>
        /// add by qhc
        /// </summary>
        public double 期货今年收益率
        {
            get { return _期货今年收益率; }
            set { _期货今年收益率 = value; }
        } 
        #endregion
        
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
		public double 资产总额
		{
			set{ _资产总额=value;}
			get{return _资产总额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 资金余额
		{
			set{ _资金余额=value;}
			get{return _资金余额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 资金资产比例
		{
			set{ _资金资产比例=value;}
			get{return _资金资产比例;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string 今年收益率
		{
			set{ _今年收益率=value;}
			get{return _今年收益率;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double 单位净值
		{
			set{ _单位净值=value;}
			get{return _单位净值;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string 时间
		{
			set{ _时间=value;}
			get{return _时间;}
		}

        public double 今年最大净值
        {
            set { _今年最大净值 = value; }
            get { return _今年最大净值; }
        }
        public string 回撤率
        {
            set { _回撤率 = value; }
            get { return _回撤率; }
        } 
           
		#endregion Model

	}
}

