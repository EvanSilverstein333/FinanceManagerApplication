using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceManager.Contract.Queries;
using FinanceManager.Contract.Commands;
using FinanceManager.Contract.Dto;
using System.Net;
using WebClient.Controllers.Code;
using WebClient.Controllers.Code.CrossCuttingConcerns;


namespace WebClient.Controllers
{
    public class FinancialTransactionController : Controller
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private INotifyCommandCompletedCallback _callback;

        public FinancialTransactionController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, INotifyCommandCompletedCallback callback)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _callback = callback;
        }

        // GET: FinancialTransaction
        public ActionResult Index(Guid? accountId)
        {
            if (accountId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.AccountId = accountId;
            var query = new GetFinancialTransactionsByAccountIdQuery(accountId.Value);
            var transactions = _queryProcessor.Execute(query);
            return View(transactions);
        }

        // GET: FinancialTransaction/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = new GetFinancialTransactionByIdQuery(id.GetValueOrDefault());
            var transaction = _queryProcessor.Execute(query);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: FinancialTransaction/Create
        public ActionResult Create(Guid? accountId)
        {

            if (accountId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var transaction = new FinancialTransactionDto()
            {
                Date = DateTime.Now.Date,
                Money = new ValueObjects.Finance.Money(0, "CAN"),
                AccountId = accountId.Value

            };
            return View(transaction);
        }

        // POST: FinancialTransaction/Create
        [HttpPost]
        public ActionResult Create(FinancialTransactionDto transaction)
        {
            RequestResultArgs requestResult = null;
            _callback.Completed += (args) => requestResult = args;
            transaction.Id = Guid.NewGuid();
            var cmd = new AddFinancialTransactionCommand(transaction);
            _commandProcessor.Execute(cmd);

            if (!requestResult.Succeeded)
            {
                this.SetErrorMessageContents(requestResult.MessageContents);
                return View(transaction);
            }

            return RedirectToAction("Index", new { accountId = transaction.AccountId });
           

        }

        // GET: FinancialTransaction/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = new GetFinancialTransactionByIdQuery(id.GetValueOrDefault());
            var transaction = _queryProcessor.Execute(query);
            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

        // POST: FinancialTransaction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FinancialTransactionDto transaction)
        {
            RequestResultArgs requestResult = null;
            _callback.Completed += (args) => requestResult = args;
            var cmd = new UpdateFinancialTransactionCommand(transaction);
            _commandProcessor.Execute(cmd);

            if (!requestResult.Succeeded)
            {
                this.SetErrorMessageContents(requestResult.MessageContents);
                return View(transaction);
            }
            return RedirectToAction("Index", new { accountId = transaction.AccountId });

        }

        // GET: FinancialTransaction/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = new GetFinancialTransactionByIdQuery(id.GetValueOrDefault());
            var transaction = _queryProcessor.Execute(query);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: FinancialTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(FinancialTransactionDto transaction)
        {
            if (transaction == null || transaction.Id == null || transaction.AccountId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RequestResultArgs requestResult = null;
            _callback.Completed += (args) => requestResult = args;
            var cmd = new RemoveFinancialTransactionCommand(transaction.Id, transaction.AccountId);
            _commandProcessor.Execute(cmd);

            if (!requestResult.Succeeded)
            {
                this.SetErrorMessageContents(requestResult.MessageContents);
                return View(transaction);
            }

            return RedirectToAction("Index", new { accountId = transaction.AccountId });





        }
    }
}
