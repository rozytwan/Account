using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCrud.Models;
using System.Collections;
using System.Web.Helpers;

namespace mvcCrud.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ColumnChart()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            
            var result = from c in datacontext.acc_transactions select new
            {
             date =c.date.Value.Month,
                amount = c.amount
            };
       
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 350, height: 250, theme: ChartTheme.Yellow)
            .AddTitle("Column Chart")
            .AddSeries("Default", chartType: "column", xValue: xvalue, yValues: yvalue)
            .SetXAxis("Month")
            .SetYAxis("Amount")
             .Write("bmp");

                return null;
        }
        public ActionResult BarChart()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions 
                         select new
                         {
                             date = c.date.Value.Month,
                             amount = c.amount
                         };
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
           
            new Chart(width: 350, height: 250, theme: ChartTheme.Yellow)
            .AddTitle("Bar Chart")
            .AddSeries("Default", chartType: "Bar", xValue: xvalue, yValues: yvalue)
             .SetXAxis("Month")
            .SetYAxis("Amount")
            .Write("bmp");

            return null;
        }
        public ActionResult PieChart()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions
                         group c by new
                         {
                             date = c.date.Value.Month,
                         } into g
                         select new
                         {
                             date =  g.Key.date,
                             Total = g.Sum(t => t.amount)
                            
                         };
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.Total));
            new Chart(width: 350, height: 250, theme: ChartTheme.Blue)
                .AddLegend("Month","amount")
            .AddTitle("Pie Chart")
            .AddSeries("Default", chartType: "Pie", xValue: xvalue, yValues: yvalue)
            
            .Write("bmp");

            return null;
        }
        public ActionResult LineChart()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = (from c in datacontext.acc_transactions orderby c.date
                         select new
                         {
                             date = c.date.Value.Month,
                             amount = c.amount
                         });
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width:1050, height: 250, theme: ChartTheme.Green)
            .AddTitle("Line Chart")
            .AddSeries("Default", chartType: "Line", xValue: xvalue, yValues: yvalue)
             .SetXAxis("Month")
            .SetYAxis("Amount")
            .Write("bmp");

            return null;
        }
        public ActionResult DoughnutChart()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions select c;
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("Doughnut Chart")
            .AddSeries("Default", chartType: "Doughnut", xValue: xvalue, yValues: yvalue)
            .Write("bmp");

            return null;
        }
        public ActionResult BoxPlotChart()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions
                         select new
                         {
                             date = c.date.Value.Month,
                             amount = c.amount
                         };
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("BoxPlot Chart")
            .AddSeries("Default", chartType: "BoxPlot", xValue: xvalue, yValues: yvalue)
             .SetXAxis("Month")
            .SetYAxis("Amount")
            .Write("bmp");

            return null;
        }
        public ActionResult Pyramid()
        {
            //var datacontext = new POS2Entities1();
            //ArrayList xvalue = new ArrayList();
            //ArrayList yvalue = new ArrayList();
            //var result = from c in datacontext.acc_transactions select c;
            //result.ToList().ForEach(rs => xvalue.Add(rs.date));
            //result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            //new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            //.AddTitle("Pyramid Chart")
            //.AddSeries("Default", chartType: "StackedColumn", xValue: xvalue, yValues: yvalue)
            //.Write("bmp");

            return null;
        }
        public ActionResult Polar()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions select c;
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("Polar Chart")
            .AddSeries("Default", chartType: "Polar", xValue: xvalue, yValues: yvalue)
            .Write("bmp");

            return null;
        }
        public ActionResult Radar()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions select c;
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("Radar Chart")
            .AddSeries("Default", chartType: "Radar", xValue: xvalue, yValues: yvalue)
            .Write("bmp");

            return null;
        }
        public ActionResult RangeBar()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions select c;
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("RangeBar Chart")
            .AddSeries("Default", chartType: "RangeBar", xValue: xvalue, yValues: yvalue)
            .AddLegend("test","test")
            .Write("bmp");

            return null;
        }
        public ActionResult StackedBar()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions select c;
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("StackBared Chart")
            .AddSeries("Default", chartType: "StackedBar100", xValue: xvalue, yValues: yvalue)
            .Write("bmp");

            return null;
        }

        public ActionResult Funnel()
        {
            var datacontext = new POS2Entities1();
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = from c in datacontext.acc_transactions select c;
            result.ToList().ForEach(rs => xvalue.Add(rs.date));
            result.ToList().ForEach(rs => yvalue.Add(rs.amount));
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
            .AddTitle("Funnel Chart")
            .AddSeries("Default", chartType: "Funnel", xValue: xvalue, yValues: yvalue)
            .Write("bmp");

            return null;
        }
    }
}