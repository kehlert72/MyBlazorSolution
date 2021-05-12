using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using MyBlazorSolution.Module.BusinessObjects;
using System;

namespace MyBlazorSolution.Module.Blazor.Controllers {

    public partial class DateEditCalendarController : ObjectViewController<DetailView, Contact> {
        public DateEditCalendarController() {
            InitializeComponent();
        }

        protected override void OnActivated() {
            base.OnActivated();
            View.CustomizeViewItemControl<DateTimePropertyEditor>(this, SetCalendarView, nameof(Contact.Birthday));
        }
        
        private void SetCalendarView(DateTimePropertyEditor propertyEditor) {
            var dateEditAdapter = (DxDateEditAdapter<DateTime>)propertyEditor.Control;
            dateEditAdapter.ComponentModel.PickerDisplayMode = DevExpress.Blazor.DatePickerDisplayMode.ScrollPicker;
        }
    }

}