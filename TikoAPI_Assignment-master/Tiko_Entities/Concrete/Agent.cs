using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tiko_Entities.Abstract;

namespace Tiko_Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Agents")]
    public class Agent : IEntity
    {
        [Required]
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        [Required] public string Name { get; set; }
        public string CityName { get; set; }

    }
}