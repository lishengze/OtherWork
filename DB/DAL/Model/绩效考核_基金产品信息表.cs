using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_基金产品信息表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_基金产品信息表
	{
		public 绩效考核_基金产品信息表()
		{}

        public 绩效考核_基金产品信息表(string __产品名称)
        { 
            this._产品名称 = __产品名称;
        }
		#region Model
        private string _产品名称 = string.Empty;
		private double _佣金;
		private double _印花税;
		private double _过户费比例;
        private double _份额;
        private double _赎回份额;
        private double _基准日净值; 


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
		public double 佣金
		{
			set{ _佣金=value;}
			get{return _佣金;}
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
		public double 过户费比例
		{
			set{ _过户费比例=value;}
			get{return _过户费比例;}
		}
		/// <summary>
        /// 该属性来源于“绩效考核_基金份额历史表”
		/// </summary>
        public double 份额
		{
			set{ _份额=value;}
			get{return _份额;}
		}
        /// <summary>
		/// 
		/// </summary>
        public double 赎回份额
		{
            set { _赎回份额 = value; } 
            get { return _赎回份额; }
		}
       
        /// <summary>
		/// 
		/// </summary>
        public double 基准日净值
		{
            set { _基准日净值 = value; }
            get { return _基准日净值; }
		}

        /// <summary>
        /// added at 20151001
        /// </summary>
        private int _输出序号;
         /// <summary>
        /// added at 20151001
		/// </summary>
        public int 输出序号
		{
            set { _输出序号 = value; }
            get { return _输出序号; }
		} 

        
        
		#endregion Model

	}
}

