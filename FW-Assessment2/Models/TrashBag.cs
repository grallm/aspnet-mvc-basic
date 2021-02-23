using System;
namespace FW_Assessment2.Models
{
    public class TrashBag
    {
        public int Id { get; set; }
        public Brand  Brand { get; set; }
        public int Volume { get; set; }
        public bool Compostable { get; set; }
    }
}
