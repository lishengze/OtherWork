using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// 绩效考核_股票每日交易汇总小表
    /// </summary>
    public partial class 绩效考核_股票每日交易汇总小表
    {
        private readonly Maticsoft.DAL.绩效考核_股票每日交易汇总小表 dal = new Maticsoft.DAL.绩效考核_股票每日交易汇总小表();
        public 绩效考核_股票每日交易汇总小表()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 记录标识)
        {
            return dal.Exists(记录标识);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public long Exists(string 股票代码, string 基金经理, string 产品名称, string 开始时间)
        {
            return dal.Exists(股票代码, 基金经理, 产品名称, 开始时间);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.绩效考核_股票每日交易汇总小表 model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.绩效考核_股票每日交易汇总小表 model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long 记录标识)
        {

            return dal.Delete(记录标识);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string 记录标识list)
        {
            return dal.DeleteList(记录标识list);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.绩效考核_股票每日交易汇总小表 GetModel(long 记录标识)
        {

            return dal.GetModel(记录标识);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.绩效考核_股票每日交易汇总小表 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
                    if (dt.Rows[n]["记录标识"] != null && dt.Rows[n]["记录标识"].ToString() != "")
                    {
                        model.记录标识 = long.Parse(dt.Rows[n]["记录标识"].ToString());
                    }
                    if (dt.Rows[n]["股票代码"] != null && dt.Rows[n]["股票代码"].ToString() != "")
                    {
                        model.股票代码 = dt.Rows[n]["股票代码"].ToString();
                    }
                    if (dt.Rows[n]["基金经理"] != null && dt.Rows[n]["基金经理"].ToString() != "")
                    {
                        model.基金经理 = dt.Rows[n]["基金经理"].ToString();
                    }
                    if (dt.Rows[n]["产品名称"] != null && dt.Rows[n]["产品名称"].ToString() != "")
                    {
                        model.产品名称 = dt.Rows[n]["产品名称"].ToString();
                    }
                    if (dt.Rows[n]["股票名称"] != null && dt.Rows[n]["股票名称"].ToString() != "")
                    {
                        model.股票名称 = dt.Rows[n]["股票名称"].ToString();
                    }
                    if (dt.Rows[n]["时间"] != null && dt.Rows[n]["时间"].ToString() != "")
                    {
                        model.时间 = dt.Rows[n]["时间"].ToString();
                    }
                    if (dt.Rows[n]["今日买入股"] != null && dt.Rows[n]["今日买入股"].ToString() != "")
                    {
                        model.今日买入股 = long.Parse(dt.Rows[n]["今日买入股"].ToString());
                    }
                    if (dt.Rows[n]["买入均价"] != null && dt.Rows[n]["买入均价"].ToString() != "")
                    {
                        model.买入均价 = double.Parse(dt.Rows[n]["买入均价"].ToString());
                    }
                    if (dt.Rows[n]["买入金额"] != null && dt.Rows[n]["买入金额"].ToString() != "")
                    {
                        model.买入金额 = double.Parse(dt.Rows[n]["买入金额"].ToString());
                    }
                    if (dt.Rows[n]["今日卖出股"] != null && dt.Rows[n]["今日卖出股"].ToString() != "")
                    {
                        model.今日卖出股 = long.Parse(dt.Rows[n]["今日卖出股"].ToString());
                    }
                    if (dt.Rows[n]["卖出均价"] != null && dt.Rows[n]["卖出均价"].ToString() != "")
                    {
                        model.卖出均价 = double.Parse(dt.Rows[n]["卖出均价"].ToString());
                    }
                    if (dt.Rows[n]["卖出金额"] != null && dt.Rows[n]["卖出金额"].ToString() != "")
                    {
                        model.卖出金额 = double.Parse(dt.Rows[n]["卖出金额"].ToString());
                    }
                    if (dt.Rows[n]["买入手续费"] != null && dt.Rows[n]["买入手续费"].ToString() != "")
                    {
                        model.买入手续费 = double.Parse(dt.Rows[n]["买入手续费"].ToString());
                    }
                    if (dt.Rows[n]["买入过户费"] != null && dt.Rows[n]["买入过户费"].ToString() != "")
                    {
                        model.买入过户费 = double.Parse(dt.Rows[n]["买入过户费"].ToString());
                    }
                    if (dt.Rows[n]["买入印花税"] != null && dt.Rows[n]["买入印花税"].ToString() != "")
                    {
                        model.买入印花税 = double.Parse(dt.Rows[n]["买入印花税"].ToString());
                    }
                    if (dt.Rows[n]["卖出手续费"] != null && dt.Rows[n]["卖出手续费"].ToString() != "")
                    {
                        model.卖出手续费 = double.Parse(dt.Rows[n]["卖出手续费"].ToString());
                    }
                    if (dt.Rows[n]["卖出过户费"] != null && dt.Rows[n]["卖出过户费"].ToString() != "")
                    {
                        model.卖出过户费 = double.Parse(dt.Rows[n]["卖出过户费"].ToString());
                    }
                    if (dt.Rows[n]["卖出印花税"] != null && dt.Rows[n]["卖出印花税"].ToString() != "")
                    {
                        model.卖出印花税 = double.Parse(dt.Rows[n]["卖出印花税"].ToString());
                    }
                    if (dt.Rows[n]["买入清算金额"] != null && dt.Rows[n]["买入清算金额"].ToString() != "")
                    {
                        model.买入清算金额 = double.Parse(dt.Rows[n]["买入清算金额"].ToString());
                    }
                    if (dt.Rows[n]["卖出清算金额"] != null && dt.Rows[n]["卖出清算金额"].ToString() != "")
                    {
                        model.卖出清算金额 = double.Parse(dt.Rows[n]["卖出清算金额"].ToString());
                    }
                    if (dt.Rows[n]["是否为止损指令"] != null && dt.Rows[n]["是否为止损指令"].ToString() != "")
                    {
                        bool flag = false;
                        bool.TryParse(dt.Rows[n]["是否为止损指令"].ToString(), out flag);
                        model.是否为止损指令 = flag;
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
         

        #endregion  Method
    }
}

