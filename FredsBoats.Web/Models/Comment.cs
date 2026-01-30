
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FredsBoats.Web.Models
{
 [Table("comment")]
 public class Comment
   {
    [Key]
    [Column("commentid")]
    public int CommentId {get; set;}

    [Column("content")]
    [StringLength(50)]
    public string Content {get; set;} = string.Empty;

    [Column("author")]
    [StringLength(50)]
    public string Author {get; set;} = string.Empty;

    [Column("createdat")]
    public DateTime CreatedAt {get; set;}

    [Column("boatid")]
    public int BoatId {get; set;}

    [Column("boatid")]
    public Boat? Boat {get; set;}
   }
}