using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using GIBS.DateTimeCalc.Components;

namespace GIBS.Modules.DateTimeCalc
{
    public partial class ViewDateTimeCalc : PortalModuleBase
    {
        public DateTime vStartDate;
        public DateTime vEndDate;
        public bool vShowYears = false;
        public bool vShowMonths = false;
        public bool vShowWeeks = false;
        public bool vShowDays = false;
        public bool vShowHours = false;
        public bool vShowMinutes = false;
        public bool vShowSeconds = false; 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    

                    LoadSettings();

                    TimeSpan span = vEndDate.Subtract(vStartDate);
                    string weeks  = String.Format("{0:0.00}", span.TotalDays / 7); 
                    // int weeks = (int) span.TotalDays / 7;
                    string months = String.Format("{0:0.00}", span.TotalDays / 31);
                    string years = String.Format("{0:0.00}", span.TotalDays / 365); 


                    if (vShowYears == true)
                    {
                        lblContent.Text += years + " years!<br>";
                    }

                    if (vShowMonths == true)
                    {
                        lblContent.Text += months + " months!<br>";
                    }
                    
                    if (vShowWeeks == true)
                    {
                        // lblContent.Text += weeks + " weeks!<br>";
                        lblContent.Text += String.Format("{0:0,0.##}", weeks) + " weeks!<br>";
                    }

                    if (vShowDays == true)
                    {
                        lblContent.Text += String.Format("{0:0,0.##}", span.TotalDays) + " days!<br>";
                    }

                    if (vShowHours == true)
                    {
                        lblContent.Text += String.Format("{0:0,0.##}", span.TotalHours) + " hours!<br>";
                    }

                    if (vShowMinutes == true)
                    {
                        lblContent.Text += String.Format("{0:0,0}", span.TotalMinutes) + " minutes!<br>";
                    }

                    if (vShowSeconds == true)
                    {
                        lblContent.Text += String.Format("{0:0,0}", span.TotalSeconds) + " seconds!<br>";
                    }
 


                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        public void LoadSettings()
        {
            try
            {

                DateTimeCalcSettings settingsData = new DateTimeCalcSettings(this.TabModuleId);

                if (string.IsNullOrEmpty(settingsData.StartDate))
                {
                    vStartDate = DateTime.Now;
                }
                else
                {
                    vStartDate = Convert.ToDateTime(settingsData.StartDate);
                }


                if (string.IsNullOrEmpty(settingsData.EndDate))
                {
                    vEndDate = DateTime.Now;
                }
                else
                {
                    vEndDate = Convert.ToDateTime(settingsData.EndDate);
                }



                if (settingsData.ShowYears != string.Empty)
                {
                    vShowYears = Convert.ToBoolean(settingsData.ShowYears);
                }
                if (settingsData.ShowMonths != string.Empty)
                {
                    vShowMonths = Convert.ToBoolean(settingsData.ShowMonths);
                }
                if (settingsData.ShowWeeks != string.Empty)
                {
                    vShowWeeks = Convert.ToBoolean(settingsData.ShowWeeks);
                }
                if (settingsData.ShowDays != string.Empty)
                {
                    vShowDays = Convert.ToBoolean(settingsData.ShowDays);
                }
                if (settingsData.ShowHours != string.Empty)
                {
                    vShowHours = Convert.ToBoolean(settingsData.ShowHours);
                }
                if (settingsData.ShowMinutes != string.Empty)
                {
                    vShowMinutes = Convert.ToBoolean(settingsData.ShowMinutes);
                }
                if (settingsData.ShowSeconds != string.Empty)
                {
                    vShowSeconds = Convert.ToBoolean(settingsData.ShowSeconds);
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


    }
}