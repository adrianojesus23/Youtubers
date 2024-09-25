﻿namespace ApiProduct.DTOs.Commands
{
    public class CreateProdutoCommand
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
