using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.DateTimeCalc.Components;

namespace GIBS.Modules.DateTimeCalc
{
    public partial class Settings : DateTimeCalcSettings
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    //     DateTimeCalcSettings settingsData = new DateTimeCalcSettings(this.TabModuleId);

                    if (Template != null)
                    {
                        txtTemplate.Text = Template;
                    }

                    if (StartDate != null)
                    {
                        txtStartDate.Text = StartDate;
                    }

                    if (EndDate != null)
                    {
                        txtEndDate.Text = EndDate;
                    }

                    if (ShowYears != null)
                    {
                        if (ShowYears.ToString().Length > 0)
                        {
                            cbxShowYears.Checked = Convert.ToBoolean(ShowYears.ToString());
                        }
                    }

                    if (ShowWeeks != null)
                    {
                        if (ShowWeeks.ToString().Length > 0)
                        {
                            cbxShowWeeks.Checked = Convert.ToBoolean(ShowWeeks.ToString());
                        }
                    }

                    if (ShowMonths != null)
                    {
                        if (ShowMonths.ToString().Length > 0)
                        {
                            cbxShowMonths.Checked = Convert.ToBoolean(ShowMonths.ToString());
                        }
                    }

                    if (ShowDays != null)
                    {
                        if (ShowDays.ToString().Length > 0)
                        {
                            cbxShowDays.Checked = Convert.ToBoolean(ShowDays.ToString());
                        }
                    }

                    if (ShowHours != null)
                    {
                        if (ShowHours.ToString().Length > 0)
                        {
                            cbxShowHours.Checked = Convert.ToBoolean(ShowHours.ToString());
                        }
                    }


                    if (ShowMinutes != null)
                    {
                        if (ShowMinutes.ToString().Length > 0)
                        {
                            cbxShowMinutes.Checked = Convert.ToBoolean(ShowMinutes.ToString());
                        }
                    }

                    if (ShowSeconds != null)
                    {
                        if (ShowSeconds.ToString().Length > 0)
                        {
                            cbxShowSeconds.Checked = Convert.ToBoolean(ShowSeconds.ToString());
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                modules.UpdateModuleSetting(ModuleId, "Template", txtTemplate.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "StartDate", txtStartDate.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "EndDate", txtEndDate.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowYears", cbxShowYears.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowWeeks", cbxShowWeeks.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowSeconds", cbxShowSeconds.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowMonths", cbxShowMonths.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowMinutes", cbxShowMinutes.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowHours", cbxShowHours.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "ShowDays", cbxShowDays.Checked.ToString());



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}