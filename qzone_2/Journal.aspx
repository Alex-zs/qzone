<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Journal.aspx.cs" Inherits="Journal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <title>填写备忘录信息</title>  
    <script type="text/javascript">  
        function watermark(id, value) {
            var obj = document.getElementById(id);
            obj.value = value;
            obj.style.cssText = "color:Gray";
            //获取焦点事件  
            obj.onfocus = function () {
                this.style.cssText = "color:gainsboro";
                if (this.value == value) {
                    this.value = '';
                }
            };
            //失去焦点事件  
            obj.onblur = function () {
                if (this.value == "") {
                    this.value = value;
                    this.style.cssText = "color:Gray";
                }
                else {
                    this.style.cssText = "color:gainsboro";
                }
            };
        }
        window.onload = function () {
            var arr = [{ 'id': 'TextBox1', 'desc': '请输入您的备忘录标题...' }, { 'id': 'TextBox2', 'desc': '请输入备忘录内容...' }];
            for (var i = 0; i < arr.length; i++) {
                watermark(arr[i].id, arr[i].desc);
            }
        };
    </script>  
    <style type="text/css">  
        .css1{  
            width:500px;  
            height:26px;  
        }  
        .css2{  
            width:500px;  
            height:270px;  
        }  
      
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>  
        <table style="width:500px;height:400px" align="center">  
            <tr>  
                <td style="font-weight: bold;" align="center" class="css1">  
                    日志
                </td>  
            </tr>  
            <tr>  
                <td class="css1">  
                    <input id="biaoti" runat="server" placeholder="标题" class="css1"  />
  
                </td>  
            </tr>  
            <tr>  
                <td class="css2">  
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="css2"></asp:TextBox>  
                </td>  
            </tr>  
           
            <tr>  
                <td align="center" class="css1">  
                    <asp:Button ID="Button1" runat="server" Height="22px" Text="保存" OnClick="Button1_Click" />  
                </td>  
            </tr>  
        </table>  
    </div>  
</asp:Content>

