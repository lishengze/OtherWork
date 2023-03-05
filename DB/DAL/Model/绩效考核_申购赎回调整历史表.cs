using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_申购赎回调整历史表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_申购赎回调整历史表
	{
		public 绩效考核_申购赎回调整历史表()
		{}
		#region Model
      
        private long _序号 ;
        private string _产品名称 = string.Empty;
        private string _基金经理 = string.Empty;
        private double _申购赎回调整数; 
        private string _赎回时间 = string.Empty;
        private long _基金份额历史表序号;
		/// <summary>
		/// 
		/// </summary>
        public long 序号
		{
			set{ _序号=value;}
			get{return _序号;}
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
        public double 申购赎回调整数
		{
            set { _申购赎回调整数 = value; }
            get { return _申购赎回调整数; }
		}
        /// <summary>
        ///  
        /// </summary>
        public string 赎回时间
        { 
            set { _赎回时间 = value; }
            get { return _赎回时间; }
        }
        /// <summary>
		/// 
		/// </summary>
        public long 基金份额历史表序号
		{
            set { _基金份额历史表序号 = value; }
            get { return _基金份额历史表序号; }
		}
        
		#endregion Model

	}
}

