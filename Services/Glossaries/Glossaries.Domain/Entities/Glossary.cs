using Glossaries.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Glossaries.Domain.Entities
{
    public class Glossary : EntityBase
    {
        [Required]
        [MaxLength(40)]
        public string Term { get; set; }

        [Required]
        public string Definition { get; set; }
    }
}
