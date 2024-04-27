using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartItemBL  : ICartItemService
    {
        private readonly IRepository<int, CartItem> _cartItemRepository;

        [ExcludeFromCodeCoverage]
        public CartItemBL()
        {
            _cartItemRepository = new CartItemRepository();
        }

        public CartItemBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public CartItem AddCartItem(CartItem cartItem)
        {
            try
            {
                var addedCartItem = _cartItemRepository.Add(cartItem);
                return addedCartItem.Result;
            }
            catch (ItemPresentException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ItemPresentException();
            }
        }

        public bool DeleteCartItem(int cartItemId)
        {
            var deletedCartItem = _cartItemRepository.Delete(cartItemId);
            if (deletedCartItem != null)
            {
                return true;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public CartItem GetCartItemById(int cartItemId)
        {
            var cartItem = _cartItemRepository.GetByKey(cartItemId);
            if (cartItem != null)
            {
                return cartItem.Result;
            }
            throw new NoCartItemWithGivenIdException();

        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            var updatedCartItem = _cartItemRepository.Update(cartItem);
            if (updatedCartItem != null)
            {
                return updatedCartItem.Result;
            }
            throw new NoCartItemWithGivenIdException();
        }
        [ExcludeFromCodeCoverage]
        public List<CartItem> GetAllCartItems()
        {
            var cartItems = _cartItemRepository.GetAll()?.Result.ToList();
            if (cartItems != null)
            {
                return cartItems;
            }
            throw new NoCartItemWithGivenIdException();
        }
    }
}
