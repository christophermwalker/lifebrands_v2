$(function () {
    $("#jqGrid").jqGrid({
        url: "/Product/GetProducts",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['idProduct', 'Name', 'Cost', 'Wholesale Cost', 'Retail Price'],
        colModel: [
            { key: true, hidden: true, name: 'idProduct', index: 'ID', editable: true },
            { key: false, name: 'Name', index: 'name', editable: true },
            { key: false, name: 'Cost', index: 'cost', editable: true },
            { key: false, name: 'Wholesale Cost', index: 'wholesale_cost', editable: true},
            { key: false, name: 'Retail Price', index: 'retail_price', editable: true }],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Students Records',
        emptyrecords: 'No Products Records are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    });
}); 