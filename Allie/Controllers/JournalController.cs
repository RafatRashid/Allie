﻿using Allie.ValidationClasses;
using AllieEntity;
using AllieService;
using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class JournalController : BaseController
    {
        // GET: Journal
        public ActionResult Index()
        {
            return View(ServiceFactory.GetJournalServices().GetAll((int)Session["CompanyId"]));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(FormCollection Form)
        {
            Journal journal = new Journal();
            journal.JournalDescription= Form["Description"];
            string temp = Form["Period"];
            string[] booyah = temp.Split('-');

            journal.JournalPeriod = new DateTime(Convert.ToInt32(booyah[1]), Convert.ToInt32(booyah[0])+1, 1);
            journal.CompanyId = (int)Session["CompanyId"];

            Session["Journal"] = journal;
            return RedirectToAction("GenerateJournal");
        }

        [HttpGet]
        public ActionResult GenerateJournal()
        {
            Journal journal = (Journal)Session["Journal"];
            DateTime journalPeriod = journal.JournalPeriod;
            List<Transaction> transactionList = (List<Transaction>)ServiceFactory.GetTransactionServices()
                                                            .GetAll((int)Session["CompanyId"], journalPeriod);
            if(transactionList[0].JournalId != 0)
            {
                return RedirectToAction("GetStoredJournal", new { id = transactionList[0].JournalId });
            }
            Session["TransactionList"] = transactionList;
            return View();
        }
        [HttpPost]
        public ActionResult GenerateJournal(FormCollection Form)
        {
            Journal journal = (Journal)Session["Journal"];
            List<Transaction> transactionList = (List<Transaction>)Session["TransactionList"];
            ServiceFactory.GetJournalServices().Insert(journal);
            ITransactionServices tranService = ServiceFactory.GetTransactionServices();
            ITransactionDetailServices detailService = ServiceFactory.GetTransactionDetailServices();

            foreach (Transaction t in transactionList)
            {
                t.JournalId = journal.Id;
                tranService.Update(t);
                List<TransactionDetail> detail = (List<TransactionDetail>)detailService.GetAll(t.Id);
                foreach(TransactionDetail d in detail)
                {
                    d.JournalId = t.JournalId;
                    detailService.Update(d);
                }
            }
            Session["Journal"] = null;
            Session["TransactionList"] = null;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetStoredJournal(int id)
        {
            return View(ServiceFactory.GetJournalServices().Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ServiceFactory.GetJournalServices().Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Journal j)
        {
            if(ValidateJournal.IsValid(j))
            { 
                ServiceFactory.GetJournalServices().Update(j);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = ValidateJournal.Message;
                return View(ServiceFactory.GetJournalServices().Get(j.Id));
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(ServiceFactory.GetJournalServices().Get(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(ServiceFactory.GetJournalServices().Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(Journal j)
        {
            ITransactionServices service = ServiceFactory.GetTransactionServices();
            if(j.LedgerId != 0)
                ServiceFactory.GetLedgerServices().Delete(j.LedgerId);

            List<Transaction> tList = (List<Transaction>)ServiceFactory.GetTransactionServices().GetByJournal(j.Id);
            foreach(Transaction t in tList)
            {
                t.JournalId = 0;
                service.Update(t);
            }
            ServiceFactory.GetJournalServices().Delete(j.Id);
            return RedirectToAction("Index");
        }
    }
}