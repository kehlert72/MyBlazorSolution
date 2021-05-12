using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using MyBlazorSolution.Module.BusinessObjects;

namespace MyBlazorSolution.Module.Controllers {
    
    public partial class FindBySubjectController : ViewController {
        public FindBySubjectController() {
            InitializeComponent();

            TargetViewType = ViewType.ListView;
            
            TargetViewNesting = Nesting.Root;
            
            TargetObjectType = typeof(DemoTask);

            ParametrizedAction findBySubjectAction =
            new ParametrizedAction(this, "FindBySubjectAction", PredefinedCategory.ListView, typeof(string)) {
                Caption = "Find Task By Subject",
                ImageName = "Action_Search"
            };

            findBySubjectAction.Execute += FindBySubjectAction_Execute;
        }

        private void FindBySubjectAction_Execute(object sender, ParametrizedActionExecuteEventArgs e) {
            var objectType = ((ListView)View).ObjectTypeInfo.Type;
            
            IObjectSpace objectSpace = Application.CreateObjectSpace(objectType);

            string paramValue = e.ParameterCurrentValue as string;

            object obj = objectSpace.FindObject(objectType,
                CriteriaOperator.Parse($"Contains([{nameof(DemoTask.Subject)}], '{paramValue}')"));

            if (obj != null) {
                DetailView detailView = Application.CreateDetailView(objectSpace, obj);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                e.ShowViewParameters.CreatedView = detailView;
            }
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
