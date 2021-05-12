using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using MyBlazorSolution.Module.BusinessObjects;

namespace MyBlazorSolution.Module.Controllers {
    
    public partial class PopupNotesController : ViewController {
        public PopupNotesController() {
            InitializeComponent();
            
            TargetObjectType = typeof(DemoTask);

            TargetViewType = ViewType.DetailView;

            PopupWindowShowAction showNotesAction = new PopupWindowShowAction(this, "ShowNotesAction", PredefinedCategory.Edit) {
                Caption = "Show Notes"
            };

            showNotesAction.CustomizePopupWindowParams += ShowNotesAction_CustomizePopupWindowParams;

            showNotesAction.Execute += ShowNotesAction_Execute;
        }

        private void ShowNotesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Note));

            string noteListViewId = Application.FindLookupListViewId(typeof(Note));

            CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(Note), noteListViewId);

            e.View = Application.CreateListView(noteListViewId, collectionSource, true);
        }

        private void ShowNotesAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e) {
            DemoTask task = (DemoTask)View.CurrentObject;
            foreach (Note note in e.PopupWindowViewSelectedObjects) {
                if (!string.IsNullOrEmpty(task.Description)) {
                    task.Description += Environment.NewLine;
                }
                // Add selected notes' text to a Task's description
                task.Description += note.Text;
            }
            View.ObjectSpace.CommitChanges();
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
