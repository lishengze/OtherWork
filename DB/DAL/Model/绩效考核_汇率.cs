using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_汇率:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_汇率
	{
		
		#region Model
        private string _时间 = string.Empty;
        private double _买入汇率;
        private double _卖出汇率;
         
        public 绩效考核_汇率()
        { }

        public 绩效考核_汇率(string 时间, double 买入汇率, double 卖出汇率)
        {
            this._时间 = 时间;
            this._买入汇率 = 买入汇率;
            this._卖出汇率 = 卖出汇率;
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
        public double 卖出汇率
		{
            set { _卖出汇率 = value; }
            get { return _卖出汇率; }
		}


        /// <summary>
        /// 
        /// </summary>
        public double 买入汇率
        {
            set { _买入汇率 = value; }
            get { return _买入汇率; }
        }
		#endregion Model

	}
}

