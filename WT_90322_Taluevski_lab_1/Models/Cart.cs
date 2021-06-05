using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.DAL.Entities;

namespace WT_90322_Taluevski_lab_1.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        /// Количество объектов в корзине
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        
        // общая стоимость
        public int TotalHorsePower
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
               item.Value.Car.HorsePower);
            }
        }


        /// Добавление в корзину

        public virtual void AddToCart(Car car)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(car.CarId))
                Items[car.CarId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(car.CarId, new CartItem
                {
                    Car = car,
                    Quantity = 1
                });
        }

        /// Удалить объект из корзины

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }


        /// Очистить корзину
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    /// Клас описывает одну позицию в корзине
    public class CartItem
    {
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }

}
