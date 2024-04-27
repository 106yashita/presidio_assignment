using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBLLibrary
{
    public class CartBL 
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IProductService _productService;

        [ExcludeFromCodeCoverage]
        public CartBL()
        {
            _cartRepository = new CartRepository();
            _productService = new ProductBL();
        }
        public CartBL(IRepository<int, Cart> cartRepository, IProductService productServices)
        {
            _cartRepository = cartRepository;
            _productService = productServices;
        }

        public bool ValidateMaxQuantityInCart(Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                if (cartItem.Quantity > 5)
                {
                    return true;
                }
            }
            return false;
        }

        // to check if the cart is eligible for discount
        public bool IsDiscountEligible(Cart cart)
        {
            double totalOrderValue = 0;
            int itemCount = 0;

            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productService.GetProductById(cartItem.ProductId);
                totalOrderValue += (cartItem.Quantity * product.Price);
                itemCount += cartItem.Quantity;
            }

            if (itemCount == 3 && totalOrderValue >= 1500)
            {
                // true means eligible for discount of 5%
                return true;
            }
            return false;
        }

        // Method to calculate shipping charge based on total order value
        public double CalculateShippingCharge(Cart cart)
        {
            double totalOrderValue = 0;

            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productService.GetProductById(cartItem.ProductId);
                totalOrderValue += (cartItem.Quantity * product.Price);
            }
            if (totalOrderValue < 100)
            {
                return 100;
            }
            return 0;
        }

        public Cart AddCart(Cart cart)
        {
            try
            {
                if (ValidateMaxQuantityInCart(cart))
                {
                    throw new MaxQuantityExceededException();
                }
                var addedCart = _cartRepository.Add(cart);
                if (addedCart != null)
                {
                    return addedCart.Result;
                }
            }
            catch (ItemPresentException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ItemPresentException();
            }
            return null;
        }

        public bool DeleteCart(int cartId)
        {
            var deletedCart = _cartRepository.Delete(cartId);
            if (deletedCart != null)
            {
                return true;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart GetCartById(int cartId)
        {
            var cart = _cartRepository.GetByKey(cartId);
            if (cart != null)
            {
                return cart.Result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart UpdateCart(Cart cart)
        {
            var updatedCart = _cartRepository.Update(cart);
            if (updatedCart != null)
            {
                return updatedCart.Result;
            }
            throw new NoCartWithGivenIdException();
        }


        public double CalculateTotalPriceOfItemInCart(Cart cart)
        {
            if (cart.CartItems.Count <= 0)
                throw new CartIsEmptyException();
            double totalPrice = 0;
            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productService.GetProductById(cartItem.ProductId);
                totalPrice += (cartItem.Quantity * product.Price);
            }
            totalPrice += CalculateShippingCharge(cart);
            if (IsDiscountEligible(cart))
                totalPrice = (0.95 * totalPrice);
            return totalPrice;
        }
    }
}
