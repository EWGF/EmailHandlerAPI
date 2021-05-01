﻿using EmailHandlerAPI.BusinessLayer;
using EmailHandlerAPI.DataAcessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace EmailHandlerAPI.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class EmailsController : ControllerBase
    {
        //TODO: Should be made throught Dependency Injection without creating the new instances :(
        private readonly IDBAcessHandler _dbHandler = new DBAcessHandler();
        private readonly IEmailSender _emailSender = new EmailSender();

        [HttpGet]
        public ActionResult<IEnumerable<EmailMessage>> Get() 
        {
            ActionResult<IEnumerable<EmailMessage>> result;
            result = new ActionResult<IEnumerable<EmailMessage>>(_dbHandler.GetEmails());
            return result;
        }

        [HttpPost]
        public EmailMessage Post([FromBody] EmailMessage message)
        {
            message = _emailSender.SendEmailMessage(message);
            return _dbHandler.AddEmails(message);
        }

    }


}
