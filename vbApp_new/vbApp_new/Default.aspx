<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="vbApp_new._Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Click below to see all the information"></asp:Label>
        </div>
        <div style="margin-top:20px;">
            <span style="margin:90px">
                <asp:Button ID="Button1" runat="server" Text="Show" />
                <asp:Button ID="ButtonText" runat="server" Text="Save to txt " Height="27px" style="margin-left: 118px; margin-right: 0px;" Width="128px" />
                <asp:Button ID="Button2" runat="server" Text="Go back" />
                <asp:Button ID="Button3" runat="server" Text="Send results by Email" />

            </span>
        </div><br />

        <div>
            <asp:Label ID="Label12" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label14" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label16" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label17" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label18" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label19" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label15" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label9" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label10" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label13" runat="server" Text=""></asp:Label>  <br />
            <asp:Label ID="Label21" runat="server" Text="Mail From:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label22" runat="server" Text="Mail To:"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server">dimitriskrem1996@gmail.com</asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server">eyan@aueb.gr</asp:TextBox><br />
            <br />
        </div>
    </form>
</html>
