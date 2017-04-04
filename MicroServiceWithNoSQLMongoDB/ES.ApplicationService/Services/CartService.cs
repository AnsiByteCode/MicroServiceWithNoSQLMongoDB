namespace ES.ApplicationService
{
    #region Using
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using ESSample.Common.CartService;
    using ServiceInterface;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Customer Service
    /// </summary>
    /// <seealso cref="ES.Contracts.ICustomerService" />
    public class CartService : ICartService
    {
        private readonly IRequestClientCreator _requestClientCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="requestClientCreator">The request client creator.</param>
        public CartService(IRequestClientCreator requestClientCreator)
        {
            _requestClientCreator = requestClientCreator;
        }

        /// <summary>
        /// Gets the cart by customer identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<GetCartByCustomerIdResponse> GetCartByCustomerId(Guid Id)
        {
            var client = _requestClientCreator.Create<GetCartByCustomerIdRequest, GetCartByCustomerIdResponse>();
            var createRequest = new GetCartByCustomerIdRequest(Id);
            var response = await client.Request(createRequest);
            return response;
        }

        /// <summary>
        /// Addtoes the cart.
        /// </summary>
        /// <param name="cartItem">The cart item.</param>
        /// <returns></returns>
        public async Task<AddtoCartResponse> AddtoCart(AddToCartRequestViewModel cartItem)
        {
            try
            {
                var client = _requestClientCreator.Create<AddtoCartRequest, AddtoCartResponse>();
                var createRequest = new AddtoCartRequest(cartItem.ProductId, cartItem.CustomerId);
                var response = await client.Request(createRequest);
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Removes from cart.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<RemoveFromCartResponse> RemoveFromCart(Guid Id)
        {
            var client = _requestClientCreator.Create<RemoveFromCartRequest, RemoveFromCartResponse>();
            var createRequest = new RemoveFromCartRequest(Id);
            var response = await client.Request(createRequest);
            return response;
        }
    }
}
