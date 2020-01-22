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
        public string vTemplate = "";
        
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
                    //string months = String.Format("{0:0.00}", span.TotalDays / 31);
                    //Period period = Period.Between(start, end, PeriodUnits.Months);
                    double months = vEndDate.Subtract(vStartDate).Days / (365.25 / 12);

                    // vEndDate
                    string years = String.Format("{0:0.00}", span.TotalDays / 365); 


                    if (vShowYears == true)
                    {
                        lblContent.Text += years + " years!<br>";
                    }

                    if (vShowMonths == true)
                    {
                        lblContent.Text += Math.Round(months, 2).ToString() + " months!<br>";
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

                    if (vTemplate.ToString().Length > 0)

                    {
                        string tempContent = vTemplate.ToString();
                        tempContent = FixTokens(tempContent.ToString(), "[YEARS]", years);
                        tempContent = FixTokens(tempContent.ToString(), "[MONTHS]", Math.Round(months, 2).ToString());
                        tempContent = FixTokens(tempContent.ToString(), "[WEEKS]", String.Format("{0:0,0.##}", weeks));
                        tempContent = FixTokens(tempContent.ToString(), "[DAYS]", String.Format("{0:0,0.##}", span.TotalDays));
                        tempContent = FixTokens(tempContent.ToString(), "[HOURS]", String.Format("{0:0,0.##}", span.TotalHours));
                        tempContent = FixTokens(tempContent.ToString(), "[MINUTES]", String.Format("{0:0,0}", span.TotalMinutes));
                        tempContent = FixTokens(tempContent.ToString(), "[SECONDS]", String.Format("{0:0,0}", span.TotalSeconds));


                        LiteralContent.Text = tempContent.ToString();
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

                //    DateTimeCalcSettings settingsData = new DateTimeCalcSettings(this.TabModuleId);

                if (Settings.Contains("StartDate"))
                {
                    if (string.IsNullOrEmpty(Settings["StartDate"].ToString()))
                    {
                        vStartDate = DateTime.Now;
                    }
                    else
                    {
                        vStartDate = Convert.ToDateTime(Settings["StartDate"].ToString());
                    }
                }
                else
                {
                    vStartDate = DateTime.Now;
                }
                
                if (Settings.Contains("EndDate"))
                {
                    
                    if (string.IsNullOrEmpty(Settings["EndDate"].ToString()))
                    {
                        vEndDate = DateTime.Now;
                    }
                    else
                    {
                        vEndDate = Convert.ToDateTime(Settings["EndDate"].ToString());
                    }
                }
                else
                {
                    vEndDate = DateTime.Now;
                }


                if (Settings.Contains("ShowYears"))
                {
                    if (Settings["ShowYears"].ToString() != string.Empty)
                    {
                        vShowYears = Convert.ToBoolean(Settings["ShowYears"].ToString());
                    }
                }

                if (Settings.Contains("ShowMonths"))
                {
                    if (Settings["ShowMonths"].ToString() != string.Empty)
                    {
                        vShowMonths = Convert.ToBoolean(Settings["ShowMonths"].ToString());
                    }
                }

                if (Settings.Contains("ShowWeeks"))
                {
                    if (Settings["ShowWeeks"].ToString() != string.Empty)
                    {
                        vShowWeeks = Convert.ToBoolean(Settings["ShowWeeks"].ToString());
                    }
                }

                if (Settings.Contains("ShowDays"))
                {
                    if (Settings["ShowDays"].ToString() != string.Empty)
                    {
                        vShowDays = Convert.ToBoolean(Settings["ShowDays"].ToString());
                    }
                }

                if (Settings.Contains("ShowHours"))
                {
                    if (Settings["ShowHours"].ToString() != string.Empty)
                    {
                        vShowHours = Convert.ToBoolean(Settings["ShowHours"].ToString());
                    }
                }

                if (Settings.Contains("ShowMinutes"))
                {
                    if (Settings["ShowMinutes"].ToString() != string.Empty)
                    {
                        vShowMinutes = Convert.ToBoolean(Settings["ShowMinutes"].ToString());
                    }
                }

                if (Settings.Contains("ShowSeconds"))
                {
                    if (Settings["ShowSeconds"].ToString() != string.Empty)
                    {
                        vShowSeconds = Convert.ToBoolean(Settings["ShowSeconds"].ToString());
                    }
                }

                if (Settings.Contains("Template"))
                {
                    if (Settings["Template"].ToString() != string.Empty)
                    {
                        vTemplate = Settings["Template"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        public string FixTokens(string _myOriginal, string _myToken, string _myReplacement)
        {

            try
            {
                string _ReturnValue = "";

                _ReturnValue = _myOriginal.ToString().Replace(_myToken, _myReplacement.ToString()).ToString();

                return _ReturnValue;
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
                return ex.ToString();
            }
        }


    }
}