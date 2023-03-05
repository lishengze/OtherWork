using System;
namespace Maticsoft.Model
{
	/// <summary>
	///  绩效考核_股票每日价格记录表
	/// </summary>
	[Serializable]
	public partial class 绩效考核_股票每日价格记录表
	{
        public 绩效考核_股票每日价格记录表()
		{}

        public 绩效考核_股票每日价格记录表(string __股票代码,string __股票名称,string __时间, double __收盘价)
        {
            this._股票代码 = __股票代码;
            this._股票名称 = __股票名称;
            this._时间 = __时间;
            this._收盘价 = __收盘价;
        }
		#region Model
        private string _股票代码 = string.Empty;
        private string _股票名称 = string.Empty;
        private string _时间= string.Empty;
        private double _收盘价;
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
        /// <summary>
        /// 
        /// </summary>
        public string 时间
        {
            set { _时间 = value; }
            get { return _时间; }
        }
        /// <summary>
        ///  
        /// </summary>
        public double 收盘价
        {
            set { _收盘价 = value; }
            get { return _收盘价; }
        }
		#endregion Model

	}
}

