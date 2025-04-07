﻿using Xunit;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;

namespace Ambev.DeveloperEvaluation.Integration.Repositories
{
    public class CartRepositoryTests : IAsyncLifetime
    {
        private DefaultContext _context;
        private CartRepository _repository;

        public async Task InitializeAsync()
        {
            var options = new DbContextOptionsBuilder<DefaultContext>()
                .UseNpgsql("Host=postgres;Port=5432;Database=developer_evaluation;Username=developer;Password=ev@luAt10n")
                .Options;
            _context = new DefaultContext(options);
            await _context.Database.EnsureCreatedAsync();
            _repository = new CartRepository(_context);
        }

        public async Task DisposeAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.DisposeAsync();
        }

        [Fact(DisplayName = "CartRepository: Create and retrieve cart successfully")]
        public async Task CreateAsync_ShouldPersistCart()
        {
            var cartId = Guid.NewGuid();
            var cart = new Cart
            {
                Id = cartId,
                UserId = Guid.NewGuid(),
                Date = DateTime.UtcNow
            };
            var created = await _repository.CreateAsync(cart);
            var fetched = await _repository.GetByIdAsync(cartId);
            Assert.NotNull(created);
            Assert.NotNull(fetched);
            Assert.Equal(cartId, fetched.Id);
        }
    }
}
