using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace MyBlazorSolution.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Payment : BaseObject {
        public Payment(Session session) : base(session) { }

        private double rate;
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if (SetPropertyValue(nameof(Rate), ref rate, value))
                    OnChanged(nameof(Amount));
            }
        }
        
        private double hours;
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (SetPropertyValue(nameof(Hours), ref hours, value))
                    OnChanged(nameof(Amount));
            }
        }
        
        [PersistentAlias("Rate * Hours")]
        public double Amount
        {
            get { return (double)(EvaluateAlias(nameof(Amount)) ?? 0); }
        }
    }

}