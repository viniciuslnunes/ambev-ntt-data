﻿using Ambev.DeveloperEvaluation.Application.DTOs.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts
{
    /// <summary>
    /// Represents a single cart in the paginated list
    /// </summary>
    public class ListCartsResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<GetCartItemDto> Items { get; set; } = new List<GetCartItemDto>();
    }
}
