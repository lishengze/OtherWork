using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_基金份额历史表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_基金份额历史表
	{
		public 绩效考核_基金份额历史表()
		{}
		#region Model
      
        private long _序号 ;
        private string _产品名称 = string.Empty;
        private double _基金份额;
        private string _修改时间 = string.Empty;
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
        public double 基金份额
		{
            set { _基金份额 = value; }
            get { return _基金份额; }
		}
        /// <summary>
        ///  
        /// </summary>
        public string 修改时间
        {
            set { _修改时间 = value; }
            get { return _修改时间; }
        }
		#endregion Model

	}
}

