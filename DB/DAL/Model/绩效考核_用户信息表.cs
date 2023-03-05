using System;
using System.Runtime.Serialization;
namespace Maticsoft.Model
{
	/// <summary>
	/// 绩效考核_用户信息表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
     [Serializable]
	public  class 绩效考核_用户信息表
	{
		
		#region Model
        private string _用户名 = string.Empty;
        private string _用户密码 = string.Empty;
        private string _用户姓名 = string.Empty;
        private string _角色 = string.Empty;
        public 绩效考核_用户信息表()
        { }

        public 绩效考核_用户信息表(string 用户名, string 用户密码, string 用户姓名,string 角色)
        {
            this._用户名 = 用户名;
            this._用户密码 = 用户密码;
            this._用户姓名 = 用户姓名;
            this._角色 =角色; 
        } 
		/// <summary>
		/// 
		/// </summary>
        public string 用户名
		{ 
            set { _用户名 = value; }
            get { return _用户名; }
		}
		/// <summary>
		///  
		/// </summary>
        public string 用户密码
		{
            set { _用户密码 = value; }
            get { return _用户密码; }
		}


        /// <summary>
        ///  
        /// </summary>
        public string 用户姓名
        {
            set { _用户姓名 = value; }
            get { return _用户姓名; }
        }

        /// <summary>
        ///   
        /// </summary>
        public string 角色
        {
            set { _角色 = value; }
            get { return _角色; }
        }

        //private bool _登录状态;
        //public bool 登录状态
        //{
        //    get { return _登录状态; }
        //    set { _登录状态 = value; }
        //}
		#endregion Model

	}
}

