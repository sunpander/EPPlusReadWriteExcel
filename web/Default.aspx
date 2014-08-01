<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="System.Collections.Generic" %>

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
        
        <h1>Selection Memory</h1>
        <p>This example shows how to maintance selection between paging</p>
        
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
        
        <ext:GridPanel
            ID="GridPanel1"
            runat="server" 
            StoreID="Store1"
            Title="Company List"
            Collapsible="true"
            Width="600"
            Height="350">
            <ColumnModel runat="server">
		        <Columns>
                    <ext:Column runat="server" Text="Company" DataIndex="Name" Flex="1" />
                    <ext:Column runat="server" Text="Price" Width="75" DataIndex="Price">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:Column runat="server" Text="Change" Width="75" DataIndex="Change">
                        <Renderer Fn="change" />
                    </ext:Column>
                    <ext:Column runat="server" Text="Change" Width="75" DataIndex="PctChange">
                        <Renderer Fn="pctChange" />
                    </ext:Column>
		        </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CheckboxSelectionModel runat="server" Mode="Multi" />                   
            </SelectionModel>
            <View>
                <ext:GridView runat="server" StripeRows="true" />
            </View>
            
            <BottomBar>
                <ext:PagingToolbar runat="server" />
            </BottomBar>
        </ext:GridPanel>
        
        <ext:Button runat="server" Text="PostBack" AutoPostBack="true" />

        <ext:Button ID="Button1" runat="server" Text="test" OnDirectClick= "Button1_DirectClick" />
    </form>
  </body>
</html>

