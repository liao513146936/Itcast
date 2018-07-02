﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Shop.Model;
namespace Shop.BLL
{
	/// <summary>
	/// BookInfo
	/// </summary>
	public partial class BookInfo
	{
		private readonly Shop.DAL.BookInfo dal=new Shop.DAL.BookInfo();
		public BookInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Bid)
		{
			return dal.Exists(Bid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.BookInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.BookInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Bid)
		{
			
			return dal.Delete(Bid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Bidlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Bidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.BookInfo GetModel(int Bid)
		{
			
			return dal.GetModel(Bid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.BookInfo GetModelByCache(int Bid)
		{
			
			string CacheKey = "BookInfoModel-" + Bid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Bid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.BookInfo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.BookInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.BookInfo> DataTableToList(DataTable dt)
		{
			List<Shop.Model.BookInfo> modelList = new List<Shop.Model.BookInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.BookInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

