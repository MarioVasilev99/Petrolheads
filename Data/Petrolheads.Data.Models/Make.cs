namespace Petrolheads.Data.Models
{
    using Petrolheads.Data.Common.Models;

    public class Make : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
