using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_现金替代物信息表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_现金替代物信息表
	{
		public 绩效考核_现金替代物信息表()
		{}
		#region Model
        private string _现金替代物代码 = string.Empty;
        private string _现金替代物名称 = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string 现金替代物代码
		{
			set{ _现金替代物代码=value;}
			get{return _现金替代物代码;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 现金替代物名称
		{
			set{ _现金替代物名称=value;}
			get{return _现金替代物名称;}
		}
		#endregion Model

	}
}

