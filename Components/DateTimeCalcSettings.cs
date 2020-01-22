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
    public class DateTimeCalcSettings : ModuleSettingsBase
    {
        //    ModuleController controller;
        //    int tabModuleId;

        //public DateTimeCalcSettings(int tabModuleId)
        //{
        //    controller = new ModuleController();
        //    this.tabModuleId = tabModuleId;
        //}

        //protected T ReadSetting<T>(string settingName, T defaultValue)
        //{
        //    Hashtable settings = controller.GetTabModuleSettings(this.tabModuleId);

        //    T ret = default(T);

        //    if (settings.ContainsKey(settingName))
        //    {
        //        System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        //        try
        //        {
        //            ret = (T)tc.ConvertFrom(settings[settingName]);
        //        }
        //        catch
        //        {
        //            ret = defaultValue;
        //        }
        //    }
        //    else
        //        ret = defaultValue;

        //    return ret;
        //}

        //protected void WriteSetting(string settingName, string value)
        //{
        //    controller.UpdateTabModuleSetting(this.tabModuleId, settingName, value);
        //}

        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user
        /// </summary>
        /// 

        public string Template
        {
            get
            {
                if (Settings.Contains("Template"))
                    return Settings["Template"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Template", value.ToString());
            }
        }

        public string StartDate
        {
            get
            {
                if (Settings.Contains("StartDate"))
                    return Settings["StartDate"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "StartDate", value.ToString());
            }
        }

        public string EndDate
        {
            get
            {
                if (Settings.Contains("EndDate"))
                    return Settings["EndDate"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EndDate", value.ToString());
            }
        }

        public string ShowYears
        {
            get
            {
                if (Settings.Contains("ShowYears"))
                    return Settings["ShowYears"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowYears", value.ToString());
            }
        }


        public string ShowMonths
        {
            get
            {
                if (Settings.Contains("ShowMonths"))
                    return Settings["ShowMonths"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowMonths", value.ToString());
            }
        }

        public string ShowWeeks
        {
            get
            {
                if (Settings.Contains("ShowWeeks"))
                    return Settings["ShowWeeks"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowWeeks", value.ToString());
            }
        }

        public string ShowDays
        {
            get
            {
                if (Settings.Contains("ShowDays"))
                    return Settings["ShowDays"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowDays", value.ToString());
            }
        }

        public string ShowHours
        {
            get
            {
                if (Settings.Contains("ShowHours"))
                    return Settings["ShowHours"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowHours", value.ToString());
            }
        }

        public string ShowMinutes
        {
            get
            {
                if (Settings.Contains("ShowMinutes"))
                    return Settings["ShowMinutes"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowMinutes", value.ToString());
            }
        }

        public string ShowSeconds
        {
            get
            {
                if (Settings.Contains("ShowSeconds"))
                    return Settings["ShowSeconds"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowSeconds", value.ToString());
            }
        }



        #endregion
    }
}
