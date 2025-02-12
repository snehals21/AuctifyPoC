using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class IdeaEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
