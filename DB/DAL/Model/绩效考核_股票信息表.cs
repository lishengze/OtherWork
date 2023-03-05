using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_股票信息表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_股票信息表
	{
		public 绩效考核_股票信息表()
		{}

        public 绩效考核_股票信息表(string 股票代码, string 股票名称)
        {
            _股票代码 = 股票代码;
            _股票名称 = 股票名称; 
        }
		#region Model
        private string _股票代码 = string.Empty;
        private string _股票名称 = string.Empty;
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
		#endregion Model

	}
}

