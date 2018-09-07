<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=Controller.GetTitle()%></title>
    <!-- #Include virtual="/Protected/Head.aspx" -->
</head>
<body>
    <div id="wrapper" class="container">
        <div id="header" class="row">
            <div id="logo" class="col-md-3 col-sm-12">
                <a href="/">
                    <img src="/assets/iviewer.png" alt="iviewer" height="32" width="32" /><%=Configs.Name.Value%></a>
            </div>
            <div class="col-md-9 col-sm-12">
                <!-- #Include virtual="/Protected/Header.aspx" -->
            </div>
        </div>
        <div id="wrap" class="row">
            <div id="menu" class="col-md-3 col-sm-12">
                <!-- #Include virtual="/Protected/Menu.aspx" -->
            </div>
            <div id="content" class="col-md-9 col-sm-12">
                <%=Controller.ExecutePage()%>
            </div>
        </div>
        <!-- #Include virtual="/Protected/Footer.aspx" -->
    </div>
</body>
</html>
