using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using MyBlazorSolution.Module.BusinessObjects;
using System;

namespace MyBlazorSolution.Module.Controllers {

    public partial class ClearContactTasksController : ViewController {
        public ClearContactTasksController() {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Contact);

            SimpleAction clearTasksAction = new SimpleAction(this, "ClearTaskAction", PredefinedCategory.View) {
                Caption = "Clear tasks",
                ConfirmationMessage = "Are you sure you want to clear the Tasks list?",
                ImageName = "Action_Clear"
            };

            clearTasksAction.Execute += ClearTasksAction_Execute;
        }

        private void ClearTasksAction_Execute(Object sender, SimpleActionExecuteEventArgs e) {
            while (((Contact)View.CurrentObject).Tasks.Count > 0) {
                ((Contact)View.CurrentObject).Tasks.Remove(((Contact)View.CurrentObject).Tasks[0]);
            }
            ObjectSpace.SetModified(View.CurrentObject);
        }

        protected override void OnActivated() {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }

        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        protected override void OnDeactivated() {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }

}
