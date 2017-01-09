var onlyOpenTitle = "主页";//不允许关闭的标签的标题
$(function () {
    tabClose();
    tabCloseEven();
})

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    $('#mm').menu({
        onClick: function (item) {
            closeTab(item.id);
        }
    });
    return false;
}

//创建/移除tab
var index = 0;
function addTab(subtitle, url, icon) {
    index++;
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: ''
        });
    } else {
        $('#tabs').tabs('select', subtitle);
        $('#mm-tabupdate').click();
    }
    tabClose();
}
function removeTab() {
    var tab = $('#tabs').tabs('getSelected');
    if (tab) {
        var index = $('#tabs').tabs('getTabIndex', tab);
        $('#tabs').tabs('close', index);
    }
}
//创建Frame
function createFrame(url) {
    var s = '<iframe scrolling="auto" frameborder="0" scrolling="no" src="' + url + '" style="width:100%;height:100%;margin:0;"></iframe>';
    return s;
}

function getIcon(menuid) {
    var icon = 'icon ';
    $.each(_menus.menus, function (i, n) {
        $.each(n.menus, function (j, o) {
            if (o.menuid == menuid) {
                icon += o.icon;
            }
        })
    })

    return icon;
}

//关闭tab
function closeTab(action) {
    var alltabs = $('#tabs').tabs('tabs');
    var currentTab = $('#tabs').tabs('getSelected');
    var allTabtitle = [];
    $.each(alltabs, function (i, n) {
        allTabtitle.push($(n).panel('options').title);
    })
    switch (action) {
        case "refresh":
            var iframe = $(currentTab.panel('options').content);
            var src = iframe.attr('src');
            $('#tabs').tabs('update', {
                tab: currentTab,
                options: {
                    content: createFrame(src)
                }
            })
            break;
        case "close":
            var currtab_title = currentTab.panel('options').title;
            $('#tabs').tabs('close', currtab_title);
            break;
        case "closeall":
            $.each(allTabtitle, function (i, n) {
                if (n != onlyOpenTitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break;
        case "closeother":
            var currtab_title = currentTab.panel('options').title;
            $.each(allTabtitle, function (i, n) {
                if (n != currtab_title && n != onlyOpenTitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break;
        case "closeright":
            var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);

            if (tabIndex == alltabs.length - 1) {
                alert('亲，后边没有啦 ^@^!!');
                return false;
            }
            $.each(allTabtitle, function (i, n) {
                if (i > tabIndex) {
                    if (n != onlyOpenTitle) {
                        $('#tabs').tabs('close', n);
                    }
                }
            });
            break;
        case "closeleft":
            var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);
            if (tabIndex == 1) {
                alert('亲，前边那个上头有人，咱惹不起哦。 ^@^!!');
                return false;
            }
            $.each(allTabtitle, function (i, n) {
                if (i < tabIndex) {
                    if (n != onlyOpenTitle) {
                        $('#tabs').tabs('close', n);
                    }
                }
            });
            break;
        case "exit":
            $('#closeMenu').menu('hide');
            break;
    }
}


Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(), //day
        "h+": this.getHours(), //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}
function myformatter(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
}
function myparser(s) {
    if (!s) return new Date();
    var ss = (s.split('-'));
    var y = parseInt(ss[0], 10);
    var m = parseInt(ss[1], 10);
    var d = parseInt(ss[2], 10);
    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
        return new Date(y, m - 1, d);
    } else {
        return new Date();
    }
}

$.extend($.fn.datagrid.methods, {
    getExcelXml: function (jq, param) {
        var worksheet = this.createWorksheet(jq, param);
        //alert($(jq).datagrid('getColumnFields'));
        var totalWidth = 0;
        var cfs = $(jq).datagrid('getColumnFields');
        for (var i = 1; i < cfs.length; i++) {
            totalWidth += $(jq).datagrid('getColumnOption', cfs[i]).width;
        }
        //var totalWidth = this.getColumnModel().getTotalWidth(includeHidden);
        return '<?xml version="1.0" encoding="utf-8"?>' +//xml申明有问题，以修正，注意是utf-8编码，如果是gb2312，需要修改动态页文件的写入编码
    '<ss:Workbook xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:o="urn:schemas-microsoft-com:office:office">' +
    '<o:DocumentProperties><o:Title>' + param.title + '</o:Title></o:DocumentProperties>' +
    '<ss:ExcelWorkbook>' +
    '<ss:WindowHeight>' + worksheet.height + '</ss:WindowHeight>' +
    '<ss:WindowWidth>' + worksheet.width + '</ss:WindowWidth>' +
    '<ss:ProtectStructure>False</ss:ProtectStructure>' +
    '<ss:ProtectWindows>False</ss:ProtectWindows>' +
    '</ss:ExcelWorkbook>' +
    '<ss:Styles>' +
    '<ss:Style ss:ID="Default">' +
    '<ss:Alignment ss:Vertical="Top"  />' +
    '<ss:Font ss:FontName="arial" ss:Size="10" />' +
    '<ss:Borders>' +
    '<ss:Border  ss:Weight="1" ss:LineStyle="Continuous" ss:Position="Top" />' +
    '<ss:Border  ss:Weight="1" ss:LineStyle="Continuous" ss:Position="Bottom" />' +
    '<ss:Border  ss:Weight="1" ss:LineStyle="Continuous" ss:Position="Left" />' +
    '<ss:Border ss:Weight="1" ss:LineStyle="Continuous" ss:Position="Right" />' +
    '</ss:Borders>' +
    '<ss:Interior />' +
    '<ss:NumberFormat />' +
    '<ss:Protection />' +
    '</ss:Style>' +
    '<ss:Style ss:ID="title">' +
    '<ss:Borders />' +
    '<ss:Font />' +
    '<ss:Alignment  ss:Vertical="Center" ss:Horizontal="Center" />' +
    '<ss:NumberFormat ss:Format="@" />' +
    '</ss:Style>' +
    '<ss:Style ss:ID="headercell">' +
    '<ss:Font ss:Bold="1" ss:Size="10" />' +
    '<ss:Alignment  ss:Horizontal="Center" />' +
    '<ss:Interior ss:Pattern="Solid"  />' +
    '</ss:Style>' +
    '<ss:Style ss:ID="even">' +
    '<ss:Interior ss:Pattern="Solid"  />' +
    '</ss:Style>' +
    '<ss:Style ss:Parent="even" ss:ID="evendate">' +
    '<ss:NumberFormat ss:Format="yyyy-mm-dd" />' +
    '</ss:Style>' +
    '<ss:Style ss:Parent="even" ss:ID="evenint">' +
    '<ss:NumberFormat ss:Format="0" />' +
    '</ss:Style>' +
    '<ss:Style ss:Parent="even" ss:ID="evenfloat">' +
    '<ss:NumberFormat ss:Format="0.00" />' +
    '</ss:Style>' +
    '<ss:Style ss:ID="odd">' +
    '<ss:Interior ss:Pattern="Solid"  />' +
    '</ss:Style>' +
    '<ss:Style ss:Parent="odd" ss:ID="odddate">' +
    '<ss:NumberFormat ss:Format="yyyy-mm-dd" />' +
    '</ss:Style>' +
    '<ss:Style ss:Parent="odd" ss:ID="oddint">' +
    '<ss:NumberFormat ss:Format="0" />' +
    '</ss:Style>' +
    '<ss:Style ss:Parent="odd" ss:ID="oddfloat">' +
    '<ss:NumberFormat ss:Format="0.00" />' +
    '</ss:Style>' +
    '</ss:Styles>' +
    worksheet.xml +
    '</ss:Workbook>';
    },
    createWorksheet: function (jq, param) {
        // Calculate cell data types and extra class names which affect formatting
        var cellType = [];
        var cellTypeClass = [];
        //var cm = this.getColumnModel();
        var totalWidthInPixels = 0;
        var colXml = '';
        var headerXml = '';
        var visibleColumnCountReduction = 0;
        var cfs = $(jq).datagrid('getColumnFields');
        var colCount = cfs.length;
        for (var i = 1; i < colCount; i++) {
            if (cfs[i] != '') {
                var w = $(jq).datagrid('getColumnOption', cfs[i]).width;
                var type = $(jq).datagrid('getColumnOption', cfs[i]).type;
                totalWidthInPixels += w;
                if (cfs[i] === "") {
                    cellType.push("None");
                    cellTypeClass.push("");
                    ++visibleColumnCountReduction;
                }
                else {
                    colXml += '<ss:Column ss:AutoFitWidth="1" ss:Width="130" />';
                    headerXml += '<ss:Cell ss:StyleID="headercell">' +
                '<ss:Data ss:Type="String">' + $(jq).datagrid('getColumnOption', cfs[i]).title + '</ss:Data>' +
                '<ss:NamedCell ss:Name="Print_Titles" /></ss:Cell>';
                    if (type == "DateTime") {
                        cellType.push("DateTime");
                    }
                    else
                        cellType.push("String");
                    cellTypeClass.push("");
                }

            }
        }
        var visibleColumnCount = cellType.length - visibleColumnCountReduction;
        var result = {
            height: 9000,
            width: Math.floor(totalWidthInPixels * 30) + 50
        };
        var rows = $(jq).datagrid('getRows');
        // Generate worksheet header details.
        var t = '<ss:Worksheet ss:Name="' + param.title + '">' +
    '<ss:Names>' +
    '<ss:NamedRange ss:Name="Print_Titles" ss:RefersTo="=\'' + param.title + '\'!R1:R2" />' +
    '</ss:Names>' +
    '<ss:Table x:FullRows="1" x:FullColumns="1"' +
    ' ss:ExpandedColumnCount="' + (visibleColumnCount + 2) +
    '" ss:ExpandedRowCount="' + (rows.length + 2) + '">' +
    colXml +
    '<ss:Row ss:AutoFitHeight="1">' +
    headerXml +
    '</ss:Row>';
        // Generate the data rows from the data in the Store
        //for (var i = 0, it = this.store.data.items, l = it.length; i < l; i++) {
        for (var i = 0, it = rows, l = it.length; i < l; i++) {
            t += '<ss:Row>';
            var cellClass = (i & 1) ? 'odd' : 'even';
            r = it[i];
            var k = 0;
            for (var j = 1; j < colCount; j++) {
                //if ((cm.getDataIndex(j) != '')
                if (cfs[j] != '') {
                    //var v = r[cm.getDataIndex(j)];
                    var v = r[cfs[j]];
                    if (cellType[k] !== "None") {
                        t += '<ss:Cell ss:StyleID="' + cellClass + cellTypeClass[k] + '"><ss:Data ss:Type="' + "String" + '">';
                        if (cellType[k] == 'DateTime') {
                            var date = new Date(parseInt(v.substr(6)));
                            var v = date.format("yyyy-MM-dd hh:mm");
                            t += v;
                            // t += v.format('Y-m-d');
                        } else {
                            t += v;
                        }
                        t += '</ss:Data></ss:Cell>';
                    }
                    k++;
                }
            }
            t += '</ss:Row>';
        }
        result.xml = t + '</ss:Table>' +
    '<x:WorksheetOptions>' +
    '<x:PageSetup>' +
    '<x:Layout x:CenterHorizontal="1" x:Orientation="Landscape" />' +
    '<x:Footer x:Data="Page &P of &N" x:Margin="0.5" />' +
    '<x:PageMargins x:Top="0.5" x:Right="0.5" x:Left="0.5" x:Bottom="0.8" />' +
    '</x:PageSetup>' +
    '<x:FitToPage />' +
    '<x:Print>' +
    '<x:PrintErrors>Blank</x:PrintErrors>' +
    '<x:FitWidth>1</x:FitWidth>' +
    '<x:FitHeight>32767</x:FitHeight>' +
    '<x:ValidPrinterInfo />' +
    '<x:VerticalResolution>600</x:VerticalResolution>' +
    '</x:Print>' +
    '<x:Selected />' +
    '<x:DoNotDisplayGridlines />' +
    '<x:ProtectObjects>False</x:ProtectObjects>' +
    '<x:ProtectScenarios>False</x:ProtectScenarios>' +
    '</x:WorksheetOptions>' +
    '</ss:Worksheet>';
        return result;
    }
});

var common = function () {
    
}