///////////////////////////////////////////////////////////////////////////////
//文件名：User.cs
//Copyright © 2014 中科九度（北京）空间信息技术有限责任公司 空间信息业务部
//创建人：李民权
//日期：2014年6月16日15:25:21
//描述：用户类，当前用户全局只有一个实例
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using DB; 
//using 产品分发保障.Commands;
//using 产品分发保障.Common;


namespace 基金管理
{
    [DataContractAttribute]
    public class User //: NotifyPropertyBase
    {
        ///// <summary>
        ///// 当前user，全局只有一个实例，默认为空
        ///// </summary>
        //public static User CurrectUser = null;

        //[DataMember]
        //private List<Authority> AuthorityCommands = null;

        //[DataMember]
        //private jn_product_users _userInfo;
        //public jn_product_users UserInfo
        //{
        //    get { return _userInfo; }
        //}


        //public int ID
        //{
        //    get
        //    {
        //        return _userInfo.ID;
        //    }
        //    set
        //    {
        //        _userInfo.ID = value;
        //        NotifyPropertyChanged("ID");
        //    }
        //}

        //public int? AuthorityId
        //{
        //    get
        //    {
        //        return _userInfo.AuthorityId;
        //    }
        //    set
        //    {
        //        _userInfo.AuthorityId = value;
        //        ClearError("AuthorityId");
        //        NotifyPropertyChanged("AuthorityId");
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return _userInfo.Name;
        //    }
        //    set
        //    {
        //        _userInfo.Name = value;
        //        ClearError("Name");
        //        NotifyPropertyChanged("Name");
        //    }
        //}

        //public string PassWord
        //{
        //    get
        //    {
        //        return _userInfo.ReallyPassord;
        //    }
        //    set
        //    {
        //        _userInfo.ReallyPassord = value;
        //        _userInfo.PassWord = MD5Helper.MD5Convert(value);
        //        ClearError("PassWord");
        //        NotifyPropertyChanged("PassWord");
        //    }
        //}

        //private string _verifyPassWord = string.Empty;
        //public string VerifyPassWord
        //{
        //    get
        //    {
        //        return _verifyPassWord;
        //    }
        //    set
        //    {
        //        _verifyPassWord = value;
        //        ClearError("VerifyPassWord");
        //        if (PassWord!=value)
        //        {
        //            this.SetError("VerifyPassWord", "两次输入的密码不一致！");
        //        }
        //        NotifyPropertyChanged("VerifyPassWord");
        //    }
        //}

        //public int? GroupId
        //{
        //    get
        //    {
        //        return _userInfo.GroupId;
        //    }
        //    set
        //    {
        //        _userInfo.GroupId = value;
        //        ClearError("GroupId");
        //        NotifyPropertyChanged("GroupId");
        //    }
        //}

        //public User(jn_product_users userinfo)
        //{
        //    this._userInfo = userinfo;
        //    this._verifyPassWord = userinfo.ReallyPassord;
        //    AuthorityCommands = Authority.GetAuthorityCommadnsByUser(userinfo);
        //}


        //public bool Validate()
        //{
        //    bool isValid = true;
        //    this.ClearAllErrors();
        //    if (CheckUserIsExist(this.Name, this.ID))
        //    {
        //        isValid = false;
        //        this.SetError("Name", "用户名已经存在！");
        //    }
        //    if (string.IsNullOrEmpty(this.PassWord))
        //    {
        //        isValid = false;
        //        this.SetError("PassWord", "密码不能为空！");
        //    }
        //    if (PassWord != VerifyPassWord)
        //    {
        //        isValid = false;
        //        this.SetError("VerifyPassWord", "两次输入的密码不一致！");
        //    }
        //    if (AuthorityId == null)
        //    {
        //        isValid = false;
        //        this.SetError("AuthorityId", "权限不能为空！");
        //    }
        //    if (GroupId == null)
        //    {
        //        isValid = false;
        //        this.SetError("GroupId", "组不能为空！");
        //    }
        //    return isValid;
        //}

        ///// <summary>
        ///// 检测用户名是否存在
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //private bool CheckUserIsExist(string userName, int id)
        //{
        //    bool isExist = false;
        //    using (ProductEntities PE = new ProductEntities())
        //    {
        //        if (PE.jn_product_users.FirstOrDefault(u => u.ID != id && u.Name.Equals(userName)) != null)
        //        {
        //            isExist = true;
        //        }
        //    }
        //    return isExist;
        //}

        ///// <summary>
        ///// 登陆函数
        ///// </summary>
        ///// <param name="userName">用户名</param>
        ///// <param name="passWord">密码</param>
        ///// <returns></returns>
        //public static bool Login(string userName, string passWord)
        //{
        //    bool isLongin = false;
        //    passWord = MD5Helper.MD5Convert(passWord);

        //    using (ProductEntities PE = new ProductEntities())
        //    {
        //        jn_product_users userinfo = PE.jn_product_users.FirstOrDefault(u => u.State == 0 && u.Name.Equals(userName) && u.PassWord.Equals(passWord));
        //        if (userinfo == null)
        //        {
        //            isLongin = false;
        //        }
        //        else
        //        {
        //            CurrectUser = new User(userinfo);
        //            isLongin = true;
        //        }
        //    }

        //    return isLongin;
        //}

        ///// <summary>
        ///// 获取所有用户
        ///// </summary>
        ///// <returns></returns>
        //public static ObservableCollection<User> GetUserList()
        //{
        //    ObservableCollection<User> resultUserList = null;
        //    try
        //    {
        //        using (ProductEntities PE = new ProductEntities())
        //        {
        //            foreach (var item in PE.jn_product_users.Where(u => u.State == 0).ToList())
        //            {
        //                if (resultUserList == null)
        //                {
        //                    resultUserList = new ObservableCollection<User>();
        //                }
        //                resultUserList.Add(new User(item));
        //            }
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message);
        //    }
        //    return resultUserList;
        //}

        ///// <summary>
        ///// 注销
        ///// </summary>
        //public static void LogOut()
        //{
        //    User.CurrectUser = null;
        //    if (System.IO.File.Exists(Config.Instance.AutoSaveUserPath))
        //    {
        //        //删除自动保存文件
        //        System.IO.File.Delete(Config.Instance.AutoSaveUserPath);
        //    }
        //}

        public static void Serializer(string path)
        {
            // Create a new instance of a StreamWriter
            // to read and write the data.
            FileStream fs = new FileStream(path,
            FileMode.Create,FileAccess.Write);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(fs);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(User));

            ser.WriteObject(writer, DataConvertor.Pub_登录用户信息);
            Console.WriteLine("Finished writing object.");
            writer.Close();
            fs.Close();
        }

        public static void DeSerializer(string path)
        {
            // from an XML file. First create an instance of the 
            // XmlDictionaryReader.
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateBinaryReader(fs, new XmlDictionaryReaderQuotas());

            // Create the DataContractSerializer instance.
            DataContractSerializer ser =
                new DataContractSerializer(typeof(User));

            // Deserialize the data and read it from the instance.
            DataConvertor.Pub_登录用户信息 = (Maticsoft.Model.绩效考核_用户信息表)ser.ReadObject(reader);
            Console.WriteLine("Reading this object:");
            //Console.WriteLine(String.Format("{0}, ID: {1}",
            //newPerson.Name, newPerson.ID));
            reader.Close();
            fs.Close();
        }
    }
}
