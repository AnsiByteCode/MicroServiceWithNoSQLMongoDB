namespace ES.ApplicationService.ServiceInterface
{
    #region Using
    using ES.CommandStack.Responses;
    using ESSample.Common.CartService;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Cart Service
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets the login details.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<GetCartByCustomerIdResponse> GetCartByCustomerId(Guid Id);

        /// <summary>
        /// Addtoes the cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns></returns>
        Task<AddtoCartResponse> AddtoCart(AddToCartRequestViewModel cart);

        /// <summary>
        /// Removes from cart.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<RemoveFromCartResponse> RemoveFromCart(Guid Id);
    }
}
