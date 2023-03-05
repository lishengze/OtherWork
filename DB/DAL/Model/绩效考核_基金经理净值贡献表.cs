using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_基金经理净值贡献表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_基金经理净值贡献表
	{
		public 绩效考核_基金经理净值贡献表()
		{}

        public 绩效考核_基金经理净值贡献表(string __基金经理,string __时间,string __基金产品,double __本年净值贡献 )
		{
               _基金经理 = __基金经理;
               _时间 = __时间;
               _基金产品 = __基金产品;
               _本年净值贡献 = __本年净值贡献; 
         }
		#region Model
        private string _基金经理 = string.Empty;
        private string _时间 = string.Empty;
        private string _基金产品 = string.Empty;
		private double _本年净值贡献;

       
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
		public string 时间
		{
			set{ _时间=value;}
			get{return _时间;}
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
		public double 本年净值贡献
		{
			set{ _本年净值贡献=value;}
			get{return _本年净值贡献;}
		}
		#endregion Model

	}
}

