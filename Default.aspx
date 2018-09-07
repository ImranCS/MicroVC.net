<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=Controller.GetTitle()%></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- #Include virtual="/Protected/Menu.aspx" -->
        </div>
        <div>
            <%=Controller.ExecutePage()%>
        </div>
    </form>
</body>
</html>
