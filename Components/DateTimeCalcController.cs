using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.DateTimeCalc.Components
{
    public class DateTimeCalcController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the DateTimeCalcInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<DateTimeCalcInfo> GetDateTimeCalcs(int moduleId)
        {
            return CBO.FillCollection<DateTimeCalcInfo>(DataProvider.Instance().GetDateTimeCalcs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public DateTimeCalcInfo GetDateTimeCalc(int moduleId, int itemId)
        {
            return (DateTimeCalcInfo)CBO.FillObject(DataProvider.Instance().GetDateTimeCalc(moduleId, itemId), typeof(DateTimeCalcInfo));
        }


        /// <summary>
        /// Adds a new DateTimeCalcInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddDateTimeCalc(DateTimeCalcInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddDateTimeCalc(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateDateTimeCalc(DateTimeCalcInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateDateTimeCalc(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteDateTimeCalc(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteDateTimeCalc(moduleId, itemId);
        }


        #endregion

        #region ISearchable Members

        /// <summary>
        /// Implements the search interface required to allow DNN to index/search the content of your
        /// module
        /// </summary>
        /// <param name="modInfo"></param>
        /// <returns></returns>
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        {
            SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

            List<DateTimeCalcInfo> infos = GetDateTimeCalcs(modInfo.ModuleID);

            foreach (DateTimeCalcInfo info in infos)
            {
                SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.Content, info.CreatedByUser, info.CreatedDate,
                                                    modInfo.ModuleID, info.ItemId.ToString(), info.Content, "Item=" + info.ItemId.ToString());
                searchItems.Add(searchInfo);
            }

            return searchItems;
        }

        #endregion

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            List<DateTimeCalcInfo> infos = GetDateTimeCalcs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<DateTimeCalcs>");
                foreach (DateTimeCalcInfo info in infos)
                {
                    sb.Append("<DateTimeCalc>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</DateTimeCalc>");
                }
                sb.Append("</DateTimeCalcs>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "DateTimeCalcs");

            foreach (XmlNode info in infos.SelectNodes("DateTimeCalc"))
            {
                DateTimeCalcInfo DateTimeCalcInfo = new DateTimeCalcInfo();
                DateTimeCalcInfo.ModuleId = ModuleID;
                DateTimeCalcInfo.Content = info.SelectSingleNode("content").InnerText;
                DateTimeCalcInfo.CreatedByUser = UserID;

                AddDateTimeCalc(DateTimeCalcInfo);
            }
        }

        #endregion
    }
}
