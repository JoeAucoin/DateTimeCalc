using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace GIBS.DateTimeCalc.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class DateTimeCalcSettings
    {
        ModuleController controller;
        int tabModuleId;

        public DateTimeCalcSettings(int tabModuleId)
        {
            controller = new ModuleController();
            this.tabModuleId = tabModuleId;
        }

        protected T ReadSetting<T>(string settingName, T defaultValue)
        {
            Hashtable settings = controller.GetTabModuleSettings(this.tabModuleId);

            T ret = default(T);

            if (settings.ContainsKey(settingName))
            {
                System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                try
                {
                    ret = (T)tc.ConvertFrom(settings[settingName]);
                }
                catch
                {
                    ret = defaultValue;
                }
            }
            else
                ret = defaultValue;

            return ret;
        }

        protected void WriteSetting(string settingName, string value)
        {
            controller.UpdateTabModuleSetting(this.tabModuleId, settingName, value);
        }

        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user
        /// </summary>
        public string Template
        {
            get { return ReadSetting<string>("template", null); }
            set { WriteSetting("template", value); }
        }

        public string StartDate
        {
            get { return ReadSetting<string>("startdate", null); }
            set { WriteSetting("startdate", value); }
        }


        public string EndDate
        {
            get { return ReadSetting<string>("enddate", null); }
            set { WriteSetting("enddate", value); }
        }


        public string ShowYears
        {
            get { return ReadSetting<string>("showyears", null); }
            set { WriteSetting("showyears", value); }
        }

        public string ShowMonths
        {
            get { return ReadSetting<string>("showmonths", null); }
            set { WriteSetting("showmonths", value); }
        }

        public string ShowWeeks
        {
            get { return ReadSetting<string>("showweeks", null); }
            set { WriteSetting("showweeks", value); }
        }

        public string ShowDays
        {
            get { return ReadSetting<string>("showdays", null); }
            set { WriteSetting("showdays", value); }
        }

        public string ShowHours
        {
            get { return ReadSetting<string>("showhours", null); }
            set { WriteSetting("showhours", value); }
        }

        public string ShowMinutes
        {
            get { return ReadSetting<string>("showminutes", null); }
            set { WriteSetting("showminutes", value); }
        }

        public string ShowSeconds
        {
            get { return ReadSetting<string>("showseconds", null); }
            set { WriteSetting("showseconds", value); }
        }

        #endregion
    }
}
