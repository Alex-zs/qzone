<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeInformation.aspx.cs" Inherits="ChangeInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   昵称：<asp:TextBox ID="userName" runat="server"></asp:TextBox><br />
   
    性别：<select id="sexselect" runat="server" class="select_small">
													<option value="男">男</option>
													<option value="女">女</option>
												</select>

    <br />
    生日： 
        <asp:DropDownList ID="Year" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="Month" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="Day" runat="server">
        </asp:DropDownList>
	 <script type="text/javascript">
         var bigArray = new Array(1, 3, 5, 7, 8, 10, 12);
         function OnSelectChange(year, month, day) {
             if (month.value == 2)//选中的月份为2月
             {
                 if (checkYear(year.value))//闰年
                 {
                     fillDay(day, 29);
                 }
                 else {
                     fillDay(day, 28);
                 }
             }
             else {
                 if (inArray(month.value, bigArray)) {
                     fillDay(day, 31);
                 }
                 else {
                     fillDay(day, 30);
                 }
             }
         }
         function checkYear(year) {
             return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) ? 1 : 0;
         }
         function fillDay(day, days) {
             while (day.options.length > 0) {
                 day.remove(0);
             }
             for (i = 1; i <= days; i++) {
                 var oOption = document.createElement("OPTION");
                 if (i < 10) {
                     oOption.innerText = "0" + i;
                 }
                 else {
                     oOption.innerText = i;
                 }
                 oOption.value = i;
                 day.appendChild(oOption);
             }
         }
         function inArray(oObj, oArray) {
             for (i = 0; i < oArray.length; i++) {
                 if (oObj == oArray[i]) {
                     return true;
                 }
             }
             return false;
         }
         </script>
    <br />
    星座：<asp:Label ID="star" Text="根据生日自动选择" runat="server"></asp:Label><br />
    现居地： 

    <input type="text"  runat="server" id="adress" placeholder="请输入详细地址" />
    <br />
    故乡：
    <input type="text" id="hometown" runat="server" placeholder="请输入详细地址" />
    <br />

    婚姻状况：<select id="marry" class="select_medium" runat="server">
												    <option value="0">----</option>
													<option value="单身">单身</option>
													<option value="恋爱中">恋爱中</option>
													<option value="已订婚">已订婚</option>
													<option value="已婚">已婚</option>
													<option value="分居">分居</option>
													<option value="离异">离异</option>
													<option value="保密">保密</option>
												</select>

    <br />
    血型：<select id="blood_select" class="select_medium" runat="server">
													<option value="A"> A </option>
													<option value="B"> B </option>
													<option value="O"> O </option>
													<option value="AB"> AB </option>
													<option value="其他">其他</option>
												</select>
    <br />
    工作：<asp:TextBox ID="job" runat="server"></asp:TextBox>
    <br />
    爱好：<input type="text" id="hobby" placeholder="请输入你的爱好"  runat="server"/>
    <br />
    <asp:Button ID="submit" Text="提交" runat="server" OnClick="submit_Click" />
   
</asp:Content>

