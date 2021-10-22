using DevExpress.DashboardCommon;
using System.Collections.Generic;

namespace Business
{
    public class FollowMeParameters
    {
        public enum ReportType
        {
            Hazırlama,
            Ring,
            Final,
            Boyahane,
            BoyahaneKazan,
            Fantezi,
            Lase,
            FanteziFinal,
            Sardon,
            CileAktarma,
            BobinAktarma,
            AktarmaVolufil,
            Vigüre
        }

        public List<DashboardParameter> parameterList = new List<DashboardParameter>();

        public FollowMeParameters()
        {
        }
    }
}