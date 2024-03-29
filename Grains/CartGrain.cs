﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrainInterfaces;
using GrainInterfaces.States;
using Orleans;
using Orleans.Providers;

namespace Grains
{
    [StorageProvider(ProviderName = "CartStorage")]
    public class CartGrain : Grain<CartState>, ICartGrain
    {
        public async Task<Cart> GetCart()
        {
            await ReadStateAsync();
            if (State.Value != null)
            {
                return State.Value;
            }

            State.Value = new Cart
            {
                Id = Guid.NewGuid(),
                Products = new List<Product>()
            };
            await WriteStateAsync();
            return State.Value;
        }

        public async Task<List<Product>> GetProducts()
        {
            await ReadStateAsync();
            return State.Value.Products;

        }

        public async Task AddProducts(Product product)
        {
            await ReadStateAsync();
            if (State.Value==null)
            {
                State=new CartState();
            }
            State.Value.Products.Add(product);
            await WriteStateAsync();
        }
    }
}


    