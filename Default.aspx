<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pagina de inicio</title>
    <style type="text/css">
      
        .style15
        {
            width: 310px;
            height: 411px;
        }
        .style16
        {
            width: 286px;
            height: 30px;
        }
    
        .style12
        {
            width: 286px;
            text-align: left;
        }
        .style14
        {
            background-color: #FF9933;
        }
    </style>
</head>
<body bgcolor="#6699ff">
    <form id="form1" runat="server">
     <table style="width:100%; height: 458px;">
        <tr>
            <td>
                <center>
                    <br />
                    <table background="Imagenes/Log.png" class="style15 ">
                        <tr>
                            <td class="style16">
                                <br />
                                <br />
                                <center>
                                    <asp:Image ID="Image2" runat="server" Height="131px"
                                ImageUrl="~/Imagenes/Logocuadrado.png" Width="134px"/></center></td>
                        </tr>
                        <tr>
                            <td class="style12">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp; &nbsp; <strong>
                                <span class="style14" style="background-color: #999999">Username:</span></strong><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="nombre" runat="server" Width="190px" BackColor="#CCCCCC"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombre"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <br />
                                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="style14"
                                    style="background-color: #999999">Password:</span></strong><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="contrasna" runat="server" TextMode="Password" Width="191px"
                                    BackColor="#CCCCCC"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="contrasna" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="MError" runat="server" BorderWidth="1px" ForeColor="Red"></asp:Label>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton
                                ID="ImageButton2" runat="server" Height="23px"
                                ImageUrl="~/Imagenes/loginbutton.png" Width="86px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style16">
                                <br />
&nbsp;
                                <br />
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>