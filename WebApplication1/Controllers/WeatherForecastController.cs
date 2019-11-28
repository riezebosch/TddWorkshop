using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TddDemo;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private DemoContext context;

        public BankAccountController(DemoContext context)
        {
            this.context = context;
        }

        public ActionResult<BankAccount> Get(string iban)
        {
            //return NotFound();
            var account = context.BankAccounts.SingleOrDefault(x => x.Iban == iban);
            return account != null ? (ActionResult<BankAccount>)Ok(account) : NotFound();
        }
    }
}
