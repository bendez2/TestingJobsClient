using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestingJobs.Models;
using Word = Microsoft.Office.Interop.Word;

namespace TestingJobs.Components
{
    class Report
    {
        Word.Application app = new Word.Application();
        Word.Document doc;

        public void FirstReport(List<ExportRequest> exportRequest)
        {
            if (exportRequest != null)
            {
                doc = app.Documents.Add(Template: $@"{Environment.CurrentDirectory}\Templates\Первый отчет.docx", Visible: true);

                Word.Table table = doc.Bookmarks["Table"].Range.Tables[1];
                int currPage = 1;
                foreach (var item in exportRequest)
                {
                    int page = doc.ComputeStatistics(Word.WdStatistic.wdStatisticPages);

                    Word.Row row = table.Rows.Add();
                    if (page > currPage) //Если запись не влазеет на текущую страницу
                    {
                        row.Range.InsertBreak();
                        table = doc.Tables[doc.Tables.Count];

                        doc.Tables[1].Rows[1].Range.Copy();
                        row.Range.Paste();
                        table.Rows[2].Delete(); //Удаляем пустую строку после заголовка

                        currPage = page;
                        row = table.Rows.Add();
                    }

                    row.Cells[1].Range.Text = item.Id.ToString();
                    row.Cells[2].Range.Text = item.NameRequest;
                    row.Cells[3].Range.Text = item.NamePriority;
                    row.Cells[4].Range.Text = item.DateCreate.ToString();
                    row.Cells[5].Range.Text = item.CloseTime.ToString();
                    row.Cells[6].Range.Text = item.IfSLA.ToString();
                    row.Cells[7].Range.Text = item.ExucationTime.ToString();
                    row.Cells[8].Range.Text = item.InitiatorName;
                    row.Cells[9].Range.Text = item.EmployeeName;
                }

                app.Visible = true;
            }
        }
    }
}
