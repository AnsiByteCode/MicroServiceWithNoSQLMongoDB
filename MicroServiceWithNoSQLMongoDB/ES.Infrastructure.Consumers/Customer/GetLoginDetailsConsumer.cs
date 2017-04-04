namespace ES.Infrastructure.Consumers
{
    #region Using
    using CommandStack.Responses;
    using CommandStack.Requests;
    using Core.Entities.Models;
    using Core.Services;
    using Domain.QueryModels;
    using MassTransit;
    using Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Get Login Details Consumer
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.GetLoginDetailsRequest}" />
    public class GetLoginDetailsConsumer : IConsumer<GetLoginDetailsRequest>
    {
        /// <summary>
        /// The customer service
        /// </summary>
        private IService<Customer> customerService;

        /// <summary>
        /// The event store repository
        /// </summary>
        private ICustomerRepository eventStoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLoginDetailsConsumer"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public GetLoginDetailsConsumer(IService<Customer> customerService,ICustomerRepository eventStoreRepository)
        {
            this.customerService = customerService;
            this.eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<GetLoginDetailsRequest> context)
        {
            try
            {
                eventStoreRepository.Add(new ES.Domain.Customer(context.Message.Email, context.Message.Password));
                Dictionary<string, string> filter = new Dictionary<string, string>();
                filter.Add("Email", context.Message.Email);
                filter.Add("Password", context.Message.Password);
                await context.RespondAsync(new GetLoginDetailsResponse
                {
                    CustomerDetails = customerService.Filter(filter).Select(x => new GetLoginDetailsViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Address = x.Address,
                        ContactNo = x.ContactNo,
                        Email = x.Email,
                        Password = x.Password
                    }).FirstOrDefault(),
                    Message = "ok",
                    ResponseId = context.Message.Id,
                    Success = true
                });
            }
            catch (Exception exc)
            {
                await
                    context.RespondAsync(new GetLoginDetailsResponse
                    {
                        ResponseId = context.Message.Id,
                        Message = "Failed" + Environment.NewLine + exc.Message
                    });
                throw;
            }
        }
    }
}
