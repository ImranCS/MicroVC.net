<div id="footer" class="row">
    <div class="col-12">
        <span class="float-right">Built With <%=Configs.Credits.Value %></span>
        <%=ViewHelper.Copyright()%> <%=Configs.Company.Value%>. All Rights Unreserved!
    </div>
</div>
<div id="ads" class="row">
    <div class="col-3"><%=ConfigReader.Get("AdvertiseHere")%></div>
    <div class="col-9">
        <%=Ads.One()%>
    </div>
</div>
