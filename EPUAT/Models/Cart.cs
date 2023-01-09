using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPUAT.Models
{
    public class CartIt
    {
        public SanPham _shopping_Product { get; set; }
        public int _shopping_Quantity { get; set; }
    }
    // Gio Hang
    public class Cart
    {
        List<CartIt> items = new List<CartIt>();
        public IEnumerable<CartIt> Items
        {
            get { return items; }
        }
        public void Add(SanPham _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_Product.Id == _pro.Id);
            if (item == null)
            {
                items.Add(new CartIt
                {
                    _shopping_Product = _pro,
                    _shopping_Quantity = _quantity
                });
            }
            else
            {
                item._shopping_Quantity += _quantity;
            }

        }
        public void update(int id, int _quantity)
        {
            //lay san pham theo id
            var item = items.Find(s => s._shopping_Product.Id == id);
            // neu san pham da co cap nhat so luong
            if (item != null)
            {
                item._shopping_Quantity = _quantity;
            }
        }
        public double Total()
        {
            var total = items.Sum(s => s._shopping_Quantity * s._shopping_Product.Gia);
            return (double)total;
        }
        public void delete(int id)
        {
            items.RemoveAll(s => s._shopping_Product.Id == id);
        }
        public int Total_Quantity_in_Cart()
        {
            return items.Sum(s => s._shopping_Quantity);
        }
        public void ClearCart()
        {
            items.Clear();// xoa gio hang thuc hien oder 
        }
    }
}