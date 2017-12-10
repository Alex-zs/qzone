<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="qzone.aspx.cs" Inherits="qzone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    发布说说：  <br />
        <textarea id="textbox" runat="server" style="width:200px;height:80px;resize:none" ></textarea>
     
        <asp:Button ID="btnSubmit" runat="server" Text="发表" OnClick="btnSubmit_Click" />
        <br />
                    <asp:Repeater ID="talklist" runat="server" OnItemCommand="talklist_ItemCommand" OnItemDataBound="talklist_ItemDataBound">
          
            <ItemTemplate>
               
                <asp:Label ID="talkid" Text='<%# Eval("talkID") %>' runat="server" Visible="false"></asp:Label>
           <h2>   <asp:Image ID="userhead" runat="server" Width="50px" Height="50px" ImageUrl ='<%# Eval("picture") %>' />
                   <asp:LinkButton ID="userheadpic" runat="server" Text='<%#Eval("userName") %>'  CommandName="friendQzone" CommandArgument='<%# Eval("userId") %>'></asp:LinkButton></h2>
                 <h8>   <%# Eval("time") %> </h8>                                                   
             <h4><%# Eval("text") %>  </h4>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="True" UpdateMode="Conditional">
            <ContentTemplate>
              评论：  <asp:Repeater ID="replys" runat="server" OnItemCommand="replys_ItemCommand">
                   <ItemTemplate>
                       <h5>  <asp:Image ID="head" runat="server" Width="30px" Height="30px" ImageUrl='<%# Eval("picture") %>' />
                     <%# Eval("userName") %>
                       <%# Eval("time") %></h5>
                   <h5>  <%# Eval("text") %></h5> 
                      

                   </ItemTemplate>
              </asp:Repeater>
            
                <asp:LinkButton ID="reply" runat="server" Text="回复" CommandName="reply" CommandArgument='<%#Eval("userId") %>'></asp:LinkButton><br />
                <asp:TextBox ID="replyEdit" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="submit" runat="server" Text="发表" OnClick="submit_Click"   Visible="false" />
                <asp:Button ID="back" runat="server" Text="取消" OnClick="back_Click" Visible="false" />
           </ContentTemplate>
        </asp:UpdatePanel>
                
                <br /><br /><br /><br />
                </ItemTemplate>
        </asp:Repeater>
        <br />
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="43px" Width="137px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="42px" Width="134px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="46px" style="margin-top: 0px" Width="102px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="45px" Width="98px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="38px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="43px" Width="83px"/>
</asp:Content>
   

