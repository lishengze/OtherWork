using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_基金经理信息表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 绩效考核_基金经理信息表
	{
		public 绩效考核_基金经理信息表()
		{
              _基金经理=string.Empty;
              _管理产品=string.Empty; 
        }

        public 绩效考核_基金经理信息表(string __基金经理, string ___管理产品)
        {
            this._基金经理 = __基金经理;
            this._管理产品 = ___管理产品;

        }

		#region Model
        private string _基金经理 = string.Empty;
        private string _管理产品 = string.Empty;
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
		public string 管理产品
		{
            set { _管理产品 = value; }
            get { return _管理产品; }
		}
		#endregion Model

	}
}

