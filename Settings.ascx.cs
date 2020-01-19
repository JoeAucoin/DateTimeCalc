using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.DateTimeCalc.Components;

namespace GIBS.Modules.DateTimeCalc
{
    public partial class Settings : ModuleSettingsBase
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
                    DateTimeCalcSettings settingsData = new DateTimeCalcSettings(this.TabModuleId);

                    if (settingsData.Template != null)
                    {
                        txtTemplate.Text = settingsData.Template;
                    }

                    if (settingsData.StartDate != null)
                    {
                        txtStartDate.Text = settingsData.StartDate;
                    }
                    if (settingsData.EndDate != null)
                    {
                        txtEndDate.Text = settingsData.EndDate;
                    }


                    if (settingsData.ShowYears != string.Empty)
                    {
                        bool showyears;
                        if (!bool.TryParse(settingsData.ShowYears, out showyears))
                        {
                            showyears = true; // Default to showing the description.
                        }
                        cbxShowYears.Checked = showyears;
                    }

                    if (settingsData.ShowWeeks != string.Empty)
                    {
                        bool showweeks;
                        if (!bool.TryParse(settingsData.ShowWeeks, out showweeks))
                        {
                            showweeks = true; // Default to showing the description.
                        }
                        cbxShowWeeks.Checked = showweeks;
                    }

                    {
                        bool showmonths;
                        if (!bool.TryParse(settingsData.ShowMonths, out showmonths))
                        {
                            showmonths = true; // Default to showing the description.
                        }
                        cbxShowMonths.Checked = showmonths;
                    }

                    {
                        bool showdays;
                        if (!bool.TryParse(settingsData.ShowDays, out showdays))
                        {
                            showdays = true; // Default to showing the description.
                        }
                        cbxShowDays.Checked = showdays;
                    }

                    {
                        bool showhours;
                        if (!bool.TryParse(settingsData.ShowHours, out showhours))
                        {
                            showhours = true; // Default to showing the description.
                        }
                        cbxShowHours.Checked = showhours;
                    }

                    {
                        bool showminutes;
                        if (!bool.TryParse(settingsData.ShowMinutes, out showminutes))
                        {
                            showminutes = true; // Default to showing the description.
                        }
                        cbxShowMinutes.Checked = showminutes;
                    }	

                    if (settingsData.ShowSeconds != string.Empty)
                    {
                        bool showseconds;
                        if (!bool.TryParse(settingsData.ShowSeconds, out showseconds))
                        {
                            showseconds = true; // Default to showing the description.
                        }
                        cbxShowSeconds.Checked = showseconds;
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
                DateTimeCalcSettings settingsData = new DateTimeCalcSettings(this.TabModuleId);
                settingsData.Template = txtTemplate.Text;
                settingsData.StartDate = txtStartDate.Text;
                settingsData.EndDate = txtEndDate.Text;

                settingsData.ShowYears = cbxShowYears.Checked.ToString();
                settingsData.ShowWeeks = cbxShowWeeks.Checked.ToString();
                settingsData.ShowSeconds = cbxShowSeconds.Checked.ToString();
                settingsData.ShowMonths = cbxShowMonths.Checked.ToString();
                settingsData.ShowMinutes = cbxShowMinutes.Checked.ToString();
                settingsData.ShowHours = cbxShowHours.Checked.ToString();
                settingsData.ShowDays = cbxShowDays.Checked.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}