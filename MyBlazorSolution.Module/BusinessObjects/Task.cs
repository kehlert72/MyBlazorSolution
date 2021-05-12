using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace MyBlazorSolution.Module.BusinessObjects {

    public enum Priority {
        Low,
        Normal,
        High
    }

    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : Task {
        public DemoTask(Session session) : base(session) { }

        public override void AfterConstruction() {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }

        private Priority priority;
        public Priority Priority {
            get { return priority; }
            set {
                SetPropertyValue(nameof(Priority), ref priority, value);
            }
        }

        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts {
            get {
                return GetCollection<Contact>(nameof(Contacts));
            }
        }

        [Action(ToolTip = "Postpone the task to the next day")]
        public void Postpone() {
            if (DueDate == DateTime.MinValue) {
                DueDate = DateTime.Now;
            }
            DueDate = DueDate + TimeSpan.FromDays(1);
        }
    }

}