using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_基金经理_产品份额表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_基金经理_产品份额表
	{
		public 绩效考核_基金经理_产品份额表()
		{}
		#region Model
        private string _基金经理 = string.Empty;
        private string _基金产品 = string.Empty;
     //   private string _修改时间;
        private double _申购赎回调整数;
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
		public string 基金产品
		{
			set{ _基金产品=value;}
			get{return _基金产品;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double 申购赎回调整数
		{ 
            set { _申购赎回调整数 = value; }
            get { return _申购赎回调整数; }
		}
        ///// <summary>
        ///// 
        ///// </summary>
        //public double 开放日单位净值
        //{ 
        //    set { _开放日单位净值 = value; }
        //    get { return _开放日单位净值; }
        //}
        
		#endregion Model

	}
}

