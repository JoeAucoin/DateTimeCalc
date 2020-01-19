<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.DateTimeCalc.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="ModuleName1 Settings Design Table">
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblStartDate" runat="server" controlname="txtStartDate" suffix=":"></dnn:label></td>
        <td><asp:TextBox id="txtStartDate" cssclass="NormalTextBox" width="390" runat="server"></asp:TextBox></td>
    </tr>
	
	
	<tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblEndDate" runat="server" controlname="txtEndDate" suffix=":"></dnn:label></td>
        <td><asp:TextBox id="txtEndDate" cssclass="NormalTextBox" width="390" runat="server"></asp:TextBox></td>
    </tr>    
    
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowYears" runat="server" ControlName="cbxShowYears" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowYears" runat="server" /></td>
</tr>
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowMonths" runat="server" ControlName="cbxShowMonths" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowMonths" runat="server" /></td>
</tr>
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowWeeks" runat="server" ControlName="cbxShowWeeks" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowWeeks" runat="server" /></td>
</tr>
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowDays" runat="server" ControlName="cbxShowDays" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowDays" runat="server" /></td>
</tr>
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowHours" runat="server" ControlName="cbxShowHours" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowHours" runat="server" /></td>
</tr>
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowMinutes" runat="server" ControlName="cbxShowMinutes" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowMinutes" runat="server" /></td>
</tr>
<tr>
        <td class="SubHead" width="150"><dnn:Label ID="lblShowSeconds" runat="server" ControlName="cbxShowSeconds" Suffix=":"></dnn:Label></td>
        <td><asp:CheckBox id="cbxShowSeconds" runat="server" /></td>
</tr>

    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblTemplate" runat="server" controlname="txtTemplate" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtTemplate" cssclass="NormalTextBox" width="390" columns="30" textmode="MultiLine" rows="10" maxlength="2000" runat="server" />
        </td>
    </tr>
</table>