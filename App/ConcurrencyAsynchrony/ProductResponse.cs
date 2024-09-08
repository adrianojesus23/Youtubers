using Newtonsoft.Json;

namespace App.ConcurrencyAsynchrony;

// Classe principal que representa a resposta JSON
    public class ProductResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("discountPercentage")]
        public decimal DiscountPercentage { get; set; }

        [JsonProperty("rating")]
        public decimal Rating { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("warrantyInformation")]
        public string WarrantyInformation { get; set; }

        [JsonProperty("shippingInformation")]
        public string ShippingInformation { get; set; }

        [JsonProperty("availabilityStatus")]
        public string AvailabilityStatus { get; set; }

        [JsonProperty("reviews")]
        public List<Review> Reviews { get; set; }

        [JsonProperty("returnPolicy")]
        public string ReturnPolicy { get; set; }

        [JsonProperty("minimumOrderQuantity")]
        public int MinimumOrderQuantity { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Description: {Description}, Price: {Price:C}, " +
                   $"Rating: {Rating}, Stock: {Stock}, Brand: {Brand}, SKU: {Sku}, " +
                   $"Category: {Category}, Tags: {string.Join(", ", Tags)}";
        }
    }

    public class Dimensions
    {
        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }

        [JsonProperty("depth")]
        public decimal Depth { get; set; }
    }

    public class Review
    {
        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("reviewerName")]
        public string ReviewerName { get; set; }

        [JsonProperty("reviewerEmail")]
        public string ReviewerEmail { get; set; }
    }

    public class Meta
    {
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("qrCode")]
        public string QrCode { get; set; }
    }