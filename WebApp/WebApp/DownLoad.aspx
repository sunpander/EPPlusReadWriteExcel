<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownLoad.aspx.cs" Inherits="WebApp.Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="/resources/css/examples.css" rel="stylesheet" />
    <script>
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return Ext.String.format(template, (value > 0) ? "green" : "red", value);
        }

        var pctChange = function (value) {
            return Ext.String.format(template, (value > 0) ? "green" : "red", value + "%");
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager runat="server" />
    <h1>
        Selection Memory</h1>
    <p>
        This example shows how to maintance selection between paging</p>
    <ext:Store ID="Store1" runat="server" PageSize="10">
        <Model>
            <ext:Model runat="server" IDProperty="ID">
                <Fields>
                    <ext:ModelField Name="ID" />
                    <ext:ModelField Name="Name" />
                    <ext:ModelField Name="Price" />
                    <ext:ModelField Name="Change" />
                    <ext:ModelField Name="PctChange" />
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:GridPanel ID="GridPanel1" runat="server" StoreID="Store1" Title="Company List"
        Collapsible="true" Width="600" Height="350">
        <ColumnModel runat="server">
            <Columns>
                <ext:Column runat="server" Text="Company" DataIndex="Name" Flex="1" />
                <ext:Column runat="server" Text="Price" Width="75" DataIndex="Price">
                </ext:Column>
                <ext:Column runat="server" Text="Change" Width="75" DataIndex="Change">
                </ext:Column>
                <ext:Column runat="server" Text="Change" Width="75" DataIndex="PctChange">
                </ext:Column>
            </Columns>
        </ColumnModel>
        <View>
            <ext:GridView runat="server" StripeRows="true" />
        </View>
         <SelectionModel>
             <ext:RowSelectionModel></ext:RowSelectionModel>               
         </SelectionModel>
        <BottomBar>
            <ext:PagingToolbar runat="server" />
        </BottomBar>
    </ext:GridPanel>
    <ext:Button ID="Button1" runat="server" Text="OnDirectClick" OnDirectClick="Button1_DirectClick" />

     <ext:Button ID="Button3" runat="server" Text="Export_DirectClick" OnDirectClick="Export_DirectClick" IsUpload="true"  />
      <ext:Button ID="Button4" runat="server" Text="Export_DirectClick2" OnDirectClick="Export_DirectClick2" />

         <ext:Button ID="Button5" runat="server" Text="正确写法" >
         <DirectEvents>
         <Click OnEvent="Export_DirectClick3" IsUpload=true></Click>
         </DirectEvents>
         
         </ext:Button>

    <ext:Button ID="Button2" runat="server" Text="OnClick不是ajax调用,会出发pageload" AutoPostBack="true" OnClick="Button2_Click" />
    </form>
</body>
</html>
