namespace Venaro.Models
{
    public class Clothes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

		public double ListPrice { get; set; }

		public bool IsSold { get; set; }


        /// <summary>
        /// Navigation Property
        /// </summary>

		public Category Category { get; set; }  

        public int CategoryId { get; set; }


	}
}
