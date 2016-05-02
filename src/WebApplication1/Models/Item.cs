using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Description { get; set; }
        //public ICollection<itemcategories> itemcategories { set; get; }

        public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Item))
            {
                return false;
            }
            else
            {
                Item newItem = (Item)otherItem;
                return this.ItemId.Equals(newItem.ItemId);
            }
        }

        public override int GetHashCode()
        {
            return this.ItemId.GetHashCode();
        }

    }
}
