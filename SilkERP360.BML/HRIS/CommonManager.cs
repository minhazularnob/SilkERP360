using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Enums;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class CommonManager
    {
        public void SaveApprover(ApproverDetail approver, ulong historyId, DBManager db)
        {
            string seqSql = $"SELECT {approver.GetSequence()}.NEXTVAL AS ID FROM DUAL";
            var seqReader = db.ExecuteDataReader(seqSql);

            seqReader.Read();
            ulong approverID = ulong.Parse(seqReader["ID"].ToString());
            seqReader.Close();

            approver.Id = approverID;
            approver.HistoryId = historyId;
            approver.Status = (int)PromotionStatus.Pending;

            string insertSql = approver.GenerateSqlInsert();
            db.ExecuteScalar(insertSql);
        }

    }
}
