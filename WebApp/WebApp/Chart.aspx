<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="WebApp.Chart" %>
 
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void ReloadData(object sender, DirectEventArgs e)
    {
        this.Chart1.GetStore().DataBind();
    }
</script>    

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Mixed Charts - Ext.NET Examples</title>
    <%--<link href="/resources/css/examples.css" rel="stylesheet" />
--%>
    <script>
        var saveChart = function (btn) {
            Ext.MessageBox.confirm('Confirm Download', 'Would you like to download the chart as an image?', function (choice) {
                if (choice == 'yes') {
                    btn.up('panel').down('chart').save({
                        type: 'image/png'
                    });
                }
            });
        };
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <h1>Mixed Charts Example</h1>

        <p>Display 3 sets of random data using a line, bar, and scatter series. Reload data will randomly generate a new set of data in the store.</p>

        <ext:Panel ID="Panel1" 
            runat="server"
            Title="Mixed Charts"
            Width="800"
            Height="600"
            Layout="FitLayout">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="Button1" 
                            runat="server" 
                            Text="Reload Data" 
                            Icon="ArrowRefresh" 
                            OnDirectClick="ReloadData" 
                            />

                        <ext:Button ID="Button2" 
                            runat="server" 
                            Text="Animate" 
                            Icon="ShapesManySelect" 
                            EnableToggle="true" 
                            Pressed="true">
                            <Listeners>
                                <Toggle Handler="#{Chart1}.animate = pressed ? {easing: 'ease', duration: 500} : false;" />
                            </Listeners>
                        </ext:Button>

                        <ext:Button ID="Button3" 
                            runat="server" 
                            Text="Save Chart" 
                            Icon="Disk"
                            Handler="saveChart"
                            />
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:Chart 
                    ID="Chart1" 
                    runat="server"
                    StyleSpec="background:#fff;"                   
                    StandardTheme="Category1"
                    Animate="true">
                    <Store>
                        <ext:Store ID="Store1" 
                            runat="server" 
                            Data="<%# Ext.Net.Examples.ChartData.GenerateData(8) %>" 
                            AutoDataBind="true">                           
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="Name" />
                                        <ext:ModelField Name="Data1" />
                                        <ext:ModelField Name="Data2" />
                                        <ext:ModelField Name="Data3" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Axes>
                        <ext:NumericAxis Fields="Data1,Data2,Data3" Title="Number of Hits" Grid="true" />
                        <ext:CategoryAxis Position="Bottom" Fields="Name" Title="Month of the Year" />
                    </Axes>
                    <Series>
                        <ext:ColumnSeries Axis="Left" XField="Name" YField="Data1" />
                        <ext:ScatterSeries Axis="Left" XField="Name" YField="Data2">
                            <MarkerConfig Type="Circle" Size="5" />
                        </ext:ScatterSeries>
                        <ext:LineSeries Axis="Left" Smooth="3" Fill="true" XField="Name" YField="Data3" />
                    </Series>
                </ext:Chart>
            </Items>
        </ext:Panel>
    </form>    
</body>
</html>
