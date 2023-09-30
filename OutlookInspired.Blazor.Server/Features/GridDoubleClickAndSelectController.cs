﻿using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using Microsoft.JSInterop;

namespace OutlookInspired.Blazor.Server.Controllers{
    public class GridDoubleClickAndSelectController : ViewController<ListView> {
        protected override void OnFrameAssigned(){
            base.OnFrameAssigned();
            if (Frame.Context == TemplateContext.ApplicationWindow){
                Application.ServiceProvider.GetService<JSRuntime>().InvokeVoidAsync("eval", @"
            function addChildEventListener(base, eventName, selector, handler) {
                base.addEventListener(eventName, function (event) {
                    var closest = event.target.closest(selector);
                    if (closest && base.contains(closest)) {
                        handler.call(closest, event);
                    }
                });
            }
            let rootElement = document.querySelector(""body"");
            addChildEventListener(rootElement, ""dblclick"", "".xaf-double-click"", () => {
                window.xaf.loadingIndicator.show();
                return false;
            });
");
            }
        }

        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            if (View.Editor is not DxGridListEditor{ Control: IDxGridAdapter gridAdapter }) return;
            gridAdapter.GridModel.RowDoubleClick = gridAdapter.GridModel.RowClick;
            gridAdapter.GridModel.AllowSelectRowByClick = true;
            gridAdapter.GridModel.RowClick = default; 
            var oldCustomizeElement = gridAdapter.GridModel.CustomizeElement; 
            gridAdapter.GridModel.CustomizeElement = args => { 
                oldCustomizeElement.Invoke(args);
                if (args.ElementType is not GridElementType.DataCell) return;
                if(args.CssClass != null && args.CssClass.Contains("xaf-action")) {
                    args.CssClass = args.CssClass.Replace("xaf-action", "xaf-double-click");
                } else {
                    args.CssClass += " xaf-double-click";
                }
            };
        }
    }
}