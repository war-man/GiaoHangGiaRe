$(function() {
    kendoUI.autocomplete_widget(), kendoUI.calendar_widget(), kendoUI.color_picker_widget(), kendoUI.combobox_widget(), kendoUI.datepicker_widget(), kendoUI.datetimepicker_widget(), kendoUI.dropdownList_widget(), kendoUI.masked_input_widget(), kendoUI.menu_widget(), kendoUI.multiselect_widget(), kendoUI.numeric_textbox_widget(), kendoUI.panelbar_widget(), kendoUI.timepicker_widget(), kendoUI.toolbar_widget(), kendoUI.window_widget()
}

),
kendoUI= {
    autocomplete_widget:function() {
        var e=$("#kUI_automplete");
        if(e.length)var t=["Albania",
        "Andorra",
        "Armenia",
        "Austria",
        "Azerbaijan",
        "Belarus",
        "Belgium",
        "Bosnia & Herzegovina",
        "Bulgaria",
        "Croatia",
        "Cyprus",
        "Czech Republic",
        "Denmark",
        "Estonia",
        "Finland",
        "France",
        "Georgia",
        "Germany",
        "Greece",
        "Hungary",
        "Iceland",
        "Ireland",
        "Italy",
        "Kosovo",
        "Latvia",
        "Liechtenstein",
        "Lithuania",
        "Luxembourg",
        "Macedonia",
        "Malta",
        "Moldova",
        "Monaco",
        "Montenegro",
        "Netherlands",
        "Norway",
        "Poland",
        "Portugal",
        "Romania",
        "Russia",
        "San Marino",
        "Serbia",
        "Slovakia",
        "Slovenia",
        "Spain",
        "Sweden",
        "Switzerland",
        "Turkey",
        "Ukraine",
        "United Kingdom",
        "Vatican City"],
        a=new kendo.data.DataSource( {
            data: t
        }
        ),
        n=function(e) {
            var t=[];
            t.push(e);
            var a=o.value().split(", ");
            return a.pop(),
            $.each(a, function(e, a) {
                t.push( {
                    field: "", ignoreCase: !0, operator: "neq", value: a
                }
                )
            }
            ),
            t
        }
        ,
        o=e.kendoAutoComplete( {
            filter:"startswith", placeholder:"Select country...", separator:", ", dataSource: {
                transport: {
                    read:function(e, t) {
                        a.read(), a.filter( {
                            logic: "and", filters: n(e.data.filter.filters[0])
                        }
                        ), e.success(a.view())
                    }
                }
                , serverFiltering:!0
            }
        }
        ).data("kendoAutoComplete");
        var i=$("#kUI_automplete_template");
        i.length&&i.kendoAutoComplete( {
            minLength:2, dataTextField:"ContactName", template:'<div class="k-list-wrapper"><span class="k-state-default k-list-wrapper-addon"><img src="assets/img/avatars/avatar_#:data.CustomerID#_tn.png" alt="#:data.CustomerID#" /></span><span class="k-state-default k-list-wrapper-content"><p>#: data.ContactName #</p><span class="uk-text-muted uk-text-small">#: data.CompanyName #</span></span></div>', dataSource: {
                transport: {
                    read: {
                        dataType: "json", url: "data/kUI_users_data.min.json"
                    }
                }
            }
            , height:204
        }
        ).data("kendoAutoComplete")
    }
    ,
    calendar_widget:function() {
        var e=$("#kUI_calendar");
        e.length&&e.kendoCalendar()
    }
    ,
    color_picker_widget:function() {
        function e(e) {
            $(".icon_preview").find(".material-icons").css("color", e.value)
        }
        var t=$("#kUI_color_palette");
        t.length&&t.kendoColorPalette( {
            columns:5, tileSize: {
                width: 24, height: 16
            }
            , palette:["#e53935", "#d81b60", "#8e24aa", "#5e35b1", "#3949ab", "#1e88e5", "#039be5", "#00acc1", "#00897b", "#43a047", "#7cb342", "#c0ca33", "#fdd835", "#ffb300", "#fb8c00", "#f4511e", "#6d4c41", "#757575", "#546e7a"], change:e
        }
        );
        var a=$("#kUI_color_picker");
        a.length&&a.kendoColorPicker( {
            value: "#fff", buttons: !1, select: e
        }
        )
    }
    ,
    combobox_widget:function() {
        var e=$("#kUI_combobox_input");
        if(e.length) {
            e.kendoComboBox( {
                dataTextField:"text", dataValueField:"value", dataSource:[ {
                    text: "Cotton", value: "1"
                }
                , {
                    text: "Polyester", value: "2"
                }
                , {
                    text: "Cotton/Polyester", value: "3"
                }
                , {
                    text: "Rib Knit", value: "4"
                }
                ], filter:"contains", suggest:!0, index:3
            }
            ).data("kendoComboBox")
        }
        var t=$("#kUI_combobox_select");
        if(t.length) {
            t.kendoComboBox();
            {
                $("#size").data("kendoComboBox")
            }
        }
        var a=$("#kUI_combobox_cascade_a"),
        n=$("#kUI_combobox_cascade_b"),
        o=$("#kUI_combobox_cascade_c");
        a.length&&n.length&&o.length&&(a.kendoComboBox( {
            dataTextField:"name", dataValueField:"id", dataSource:[ {
                name: "Parent1", id: 1
            }
            , {
                name: "Parent2", id: 2
            }
            ]
        }
        ), n.kendoComboBox( {
            cascadeFrom:"kUI_combobox_cascade_a", cascadeFromField:"parentId", dataTextField:"name", dataValueField:"id", dataSource:[ {
                name: "Child1_1", id: 1, parentId: 1
            }
            , {
                name: "Child1_2", id: 2, parentId: 1
            }
            , {
                name: "Child2_1", id: 3, parentId: 2
            }
            , {
                name: "Child2_2", id: 4, parentId: 2
            }
            ]
        }
        ), o.kendoComboBox( {
            cascadeFrom:"kUI_combobox_cascade_b", cascadeFromField:"parentId", dataTextField:"name", dataValueField:"id", dataSource:[ {
                name: "Child1_1_1", id: 1, parentId: 1
            }
            , {
                name: "Child1_1_2", id: 3, parentId: 1
            }
            , {
                name: "Child1_2_1", id: 3, parentId: 2
            }
            , {
                name: "Child1_2_2", id: 4, parentId: 2
            }
            , {
                name: "Child2_1_1", id: 5, parentId: 3
            }
            , {
                name: "Child2_1_2", id: 6, parentId: 3
            }
            , {
                name: "Child2_2_1", id: 7, parentId: 4
            }
            , {
                name: "Child2_2_2", id: 8, parentId: 4
            }
            ]
        }
        ))
    }
    ,
    datepicker_widget:function() {
        var e=$("#kUI_datepicker_a");
        e.length&&e.kendoDatePicker( {
            format: "d-MM-yyyy"
        }
        );
        var t=$("#kUI_datepicker_b");
        t.length&&t.kendoDatePicker( {
            start: "year", depth: "year", format: "MMMM yyyy"
        }
        )
    }
    ,
    datetimepicker_widget:function() {
        function e() {
            var e=d.value(),
            t=r.value();
            e?(e=new Date(e), e.setDate(e.getDate()), r.min(e)): t?d.max(new Date(t)): (t=new Date, d.max(t), r.min(t))
        }
        function t() {
            var e=r.value(),
            t=d.value();
            e?(e=new Date(e), e.setDate(e.getDate()), d.max(e)): t?r.min(new Date(t)): (e=new Date, d.max(e), r.min(e))
        }
        var a=$("#kUI_datetimepicker_basic");
        a.length&&a.kendoDateTimePicker( {
            value: new Date
        }
        );
        var n=$("#kUI_datetimepicker_range_start"),
        o=$("#kUI_datetimepicker_range_end");
        if(n.length&&o.length) {
            var i=kendo.date.today(),
            d=n.kendoDateTimePicker( {
                value: i, change: e, parseFormats: ["MM/dd/yyyy"]
            }
            ).data("kendoDateTimePicker"),
            r=o.kendoDateTimePicker( {
                value: i, change: t, parseFormats: ["MM/dd/yyyy"]
            }
            ).data("kendoDateTimePicker");
            d.max(r.value()),
            r.min(d.value())
        }
    }
    ,
    dropdownList_widget:function() {
        var e=$("#kUI_dropdown_basic_input");
        if(e.length) {
            var t=[ {
                text: "Black", value: "1"
            }
            ,
            {
                text: "Orange", value: "2"
            }
            ,
            {
                text: "Grey", value: "3"
            }
            ];
            e.kendoDropDownList( {
                dataTextField: "text", dataValueField: "value", dataSource: t, index: 0
            }
            )
        }
        var a=$("#kUI_dropdown_basic_select");
        a.length&&a.kendoDropDownList()
    }
    ,
    masked_input_widget:function() {
        var e=$("#kUI_masked_phone");
        e.length&&e.kendoMaskedTextBox( {
            mask: "(999) 000-0000"
        }
        );
        var t=$("#kUI_masked_credit_card");
        t.length&&t.kendoMaskedTextBox( {
            mask: "0000 0000 0000 0000"
        }
        );
        var a=$("#kUI_masked_ssn");
        a.length&&a.kendoMaskedTextBox( {
            mask: "000-00-0000"
        }
        );
        var n=$("#kUI_masked_postcode");
        n.length&&n.kendoMaskedTextBox( {
            mask: "L0L 0LL"
        }
        )
    }
    ,
    menu_widget:function() {
        var e=$("#kUI_menu");
        e.length&&e.kendoMenu()
    }
    ,
    multiselect_widget:function() {
        var e=$("#kUI_multiselect_basic_1, #kUI_multiselect_basic_2, #kUI_multiselect_basic_3, #kUI_multiselect_basic_4, #kUI_multiselect_basic_5, #kUI_multiselect_basic_6, #kUI_multiselect_basic_7, #kUI_multiselect_basic_9, #kUI_multiselect_basic_8, #kUI_multiselect_basic_10");
        e.length&&e.kendoMultiSelect();
        var t=$("#kUI_multiselect_custom_template");
        t.length&&t.kendoMultiSelect( {
            dataTextField:"ContactName", dataValueField:"CustomerID", itemTemplate:'<div class="k-list-wrapper"><span class="k-state-default k-list-wrapper-addon"><img src="assets/img/avatars/avatar_#:data.CustomerID#_tn.png" alt="#:data.CustomerID#" /></span><span class="k-state-default k-list-wrapper-content"><p>#: data.ContactName #</p><span class="uk-text-muted uk-text-small">#: data.CompanyName #</span></span></div>', tagTemplate:'<img class="k-tag-image" src="assets/img/avatars/avatar_#:data.CustomerID#_tn.png" alt="${data.CustomerID}" />#: data.ContactName #', dataSource: {
                transport: {
                    read: {
                        dataType: "json", url: "data/kUI_users_data.min.json"
                    }
                }
            }
            , value:[ {
                ContactName: "William Block", CustomerID: 3
            }
            ], height:204
        }
        ).data("kendoMultiSelect")
    }
    ,
    numeric_textbox_widget:function() {
        var e=$("#kUI_numeric_price");
        e.length&&e.kendoNumericTextBox( {
            format: "c", decimals: 3
        }
        );
        var t=$("#kUI_numeric_price_discount");
        t.length&&t.kendoNumericTextBox( {
            format: "p0", min: 0, max: .1, step: .01
        }
        );
        var a=$("#kUI_numeric_weight");
        a.length&&a.kendoNumericTextBox( {
            format: "#.00 kg"
        }
        );
        var n=$("#kUI_numeric_stock");
        n.length&&n.kendoNumericTextBox()
    }
    ,
    panelbar_widget:function() {
        var e=$("#kUI_panelbar");
        e.length&&e.kendoPanelBar()
    }
    ,
    timepicker_widget:function() {
        function e() {
            var e=o.value();
            e&&(e=new Date(e), i.max(e), e.setMinutes(e.getMinutes()+this.options.interval), i.min(e), i.value(e))
        }
        var t=$("#kUI_timepicker");
        t.length&&t.kendoTimePicker();
        var a=$("#kUI_timepicker_range_start"),
        n=$("#kUI_timepicker_range_end");
        if(a.length&&n.length) {
            var o=a.kendoTimePicker( {
                change: e
            }
            ).data("kendoTimePicker"),
            i=n.kendoTimePicker().data("kendoTimePicker");
            o.min("8:00 AM"),
            o.max("6:00 PM"),
            i.min("8:00 AM"),
            i.max("7:30 AM")
        }
    }
    ,
    toolbar_widget:function() {
        var e=$("#kUI_toolBar");
        e.length&&(e.kendoToolBar( {
            items:[ {
                type: "button", text: "Button"
            }
            , {
                type: "button", text: "Toggle Button", togglable: !0
            }
            , {
                type:"splitButton", text:"Insert", menuButtons:[ {
                    text: "Insert above", icon: "insert-n"
                }
                , {
                    text: "Insert between", icon: "insert-m"
                }
                , {
                    text: "Insert below", icon: "insert-s"
                }
                ]
            }
            , {
                type: "separator"
            }
            , {
                template: "<label>Format:</label>"
            }
            , {
                template: "<input id='kUI_dropdown' class='uk-form-width-medium' />", overflow: "never"
            }
            , {
                type: "separator"
            }
            , {
                type:"buttonGroup", buttons:[ {
                    spriteCssClass: "k-tool-icon k-justifyLeft", text: "Left", togglable: !0, group: "text-align"
                }
                , {
                    spriteCssClass: "k-tool-icon k-justifyCenter", text: "Center", togglable: !0, group: "text-align"
                }
                , {
                    spriteCssClass: "k-tool-icon k-justifyRight", text: "Right", togglable: !0, group: "text-align"
                }
                ]
            }
            , {
                type:"buttonGroup", buttons:[ {
                    spriteCssClass: "k-tool-icon k-bold", text: "Bold", togglable: !0, showText: "overflow"
                }
                , {
                    spriteCssClass: "k-tool-icon k-italic", text: "Italic", togglable: !0, showText: "overflow"
                }
                , {
                    spriteCssClass: "k-tool-icon k-underline", text: "Underline", togglable: !0, showText: "overflow"
                }
                ]
            }
            , {
                type: "button", text: "Action", overflow: "always"
            }
            , {
                type: "button", text: "Another Action", overflow: "always"
            }
            , {
                type: "button", text: "Something else here", overflow: "always"
            }
            ]
        }
        ), $("#kUI_dropdown").kendoDropDownList( {
            optionLabel:"Paragraph", dataTextField:"text", dataValueField:"value", dataSource:[ {
                text: "Heading 1", value: 1
            }
            , {
                text: "Heading 2", value: 2
            }
            , {
                text: "Heading 3", value: 3
            }
            , {
                text: "Title", value: 4
            }
            , {
                text: "Subtitle", value: 5
            }
            ]
        }
        ))
    }
    ,
    window_widget:function() {
        var e=$("#kUI_window"),
        t=$("#kUI_undo");
        if(e.length) {
            var a=e,
            n=t.bind("click", function() {
                a.data("kendoWindow").open(), n.hide()
            }
            ),
            o=function() {
                n.show()
            }
            ;
            a.data("kendoWindow")||a.kendoWindow( {
                width: "600px", title: "Lorem ipsum dolor sit", actions: ["Pin", "Minimize", "Maximize", "Close"], close: o
            }
            )
        }
    }
}

;