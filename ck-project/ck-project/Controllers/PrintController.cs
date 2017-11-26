﻿using ck_project.Helpers;
using ck_project.Models;
using SelectPdf;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ck_project.Controllers
{
   // [Authorize]
    public class PrintController : Controller
    {
        ckdatabase db = new ckdatabase();
        ProjSummaryHelper projSummaryHelper = new ProjSummaryHelper();
        // GET: Printout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Convert(String url, int id, string str)
        {
            // get the data
            var lead = db.leads.Where(l => l.lead_number == id).FirstOrDefault();
            var projSummary = new ProjectSummary
            {
                Lead = db.leads.Where(c => c.lead_number == id).FirstOrDefault(),
                Branch = db.branches.ToList(),
            };

            if (lead != null)
            {
                projSummary = projSummaryHelper.CalculateProposalAmtDue(projSummary, id);
                projSummary = projSummaryHelper.CalculateInstallCategoryCostMap(lead, projSummary);
                projSummary = projSummaryHelper.GetProductCategoryList(lead, projSummary);
                projSummary = projSummaryHelper.CalculateInstallationsData(lead, projSummary);
                projSummary.ProductTotalMap = projSummaryHelper.GetProductTotalMap(lead);
            }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // get html code from url
            string htmlString = this.RenderView(str, projSummary);

            // get base url (to resolve relative links to external resources)
            var uri = new Uri(url);
            string baseUrl = uri.GetLeftPart(System.UriPartial.Authority);

            // set converter options
            converter.Options.PdfPageSize = PdfPageSize.Letter;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 5;
            converter.Options.MarginRight = 5;
            converter.Options.MarginTop = 5;
            converter.Options.MarginBottom = 5;

            // create a new pdf document converting the html string
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // get conversion result (contains document info from the web page)
            HtmlToPdfResult result = converter.ConversionResult;

            // set the document properties
            doc.DocumentInformation.Title = result.WebPageInformation.Title;
            doc.DocumentInformation.Subject = result.WebPageInformation.Description;
            doc.DocumentInformation.Keywords = result.WebPageInformation.Keywords;

            doc.DocumentInformation.Author = "CreativeKitchen";
            doc.DocumentInformation.CreationDate = DateTime.Now;

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = str + ".pdf";
            return fileResult;
        }
    }
}