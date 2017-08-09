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
    public class FinancialAccountController : Controller
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private INotifyCommandCompletedCallback _callback;
        public FinancialAccountController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, INotifyCommandCompletedCallback callback)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _callback = callback;
            
        }

        // GET: FinancialAccount
        public ActionResult Index()
        {
            var query = new GetAllFinancialAccountsQuery();
            var accounts = _queryProcessor.Execute(query);
            return View(accounts);
        }

        // GET: FinancialAccount/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = new GetFinancialAccountByIdQuery(id.GetValueOrDefault());
            var account = _queryProcessor.Execute(query);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: FinancialAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinancialAccount/Create
        [HttpPost]
        public ActionResult Create(FinancialAccountDto account)
        {
            RequestResultArgs requestResult = null;
            _callback.Completed += (args) => requestResult = args;
            account.Id = Guid.NewGuid();
            var cmd = new AddFinancialAccountCommand(account);
            _commandProcessor.Execute(cmd);

            if (!requestResult.Succeeded)
            {
                this.SetErrorMessageContents(requestResult.MessageContents);
                return View(account);
            }
            return RedirectToAction("Index");
        }

        // GET: FinancialAccount/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = new GetFinancialAccountByIdQuery(id.GetValueOrDefault());
            var account = _queryProcessor.Execute(query);
            if (account == null)
            {
                return HttpNotFound();
            }

                return View(account);
        }

        // POST: FinancialAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FinancialAccountDto account)
        {

            RequestResultArgs requestResult = null;
            _callback.Completed += (args) => requestResult = args;
            var cmd = new UpdateFinancialAccountCommand(account);
            _commandProcessor.Execute(cmd);


            if (!requestResult.Succeeded)
            {
                this.SetErrorMessageContents(requestResult.MessageContents);
                return View(account);
            }

            return RedirectToAction("Index");


        }

        // GET: FinancialAccount/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = new GetFinancialAccountByIdQuery(id.GetValueOrDefault());
            var account = _queryProcessor.Execute(query);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: FinancialAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(FinancialAccountDto account)
        {
            if (account == null || account.Id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestResultArgs requestResult = null;
            _callback.Completed += (args) => requestResult = args;
            var cmd = new RemoveFinancialAccountCommand(account.Id);
            _commandProcessor.Execute(cmd);

            if (!requestResult.Succeeded)
            {
                this.SetErrorMessageContents(requestResult.MessageContents);
                return View(account);
            }
            return RedirectToAction("Index");





        }
    }
}
